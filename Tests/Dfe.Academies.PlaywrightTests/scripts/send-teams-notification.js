const axios = require('axios');
const fs = require('node:fs');
const path = require('node:path');

function readReportData() {
  let reportStats = { tests: 0, passes: 0, failures: 0 };
  let failedTests = [];

  const reportPath = path.join(process.cwd(), 'reports', 'report.json');

  if (fs.existsSync(reportPath)) {
    const reportData = JSON.parse(fs.readFileSync(reportPath, 'utf8'));

    if (reportData?.stats) {
      const { expected = 0, unexpected = 0, flaky = 0, skipped = 0 } = reportData.stats;

      reportStats = {
        tests: expected + unexpected + flaky + skipped,
        passes: expected + flaky,
        failures: unexpected,
      };

      if (reportStats.failures > 0 && reportData.suites) {
        failedTests = extractFailedTests(reportData.suites);
      }
    }
  } else {
    console.warn('Report file not found at:', reportPath);
  }

  return { reportStats, failedTests };
}

function extractFailedTests(suites, titlePath = []) {
  const failedTests = [];

  for (const suite of suites) {
    const currentPath = suite.title ? [...titlePath, suite.title] : titlePath;

    for (const spec of suite.specs ?? []) {
      if (!spec.ok) {
        const lastResult = spec.tests?.[0]?.results?.at(-1);
        const errorMessage = lastResult?.errors?.[0]?.message || 'No error message available';
        const fullTitle = [...currentPath, spec.title].filter(Boolean).join(' > ');

        failedTests.push({
          fullTitle,
          errorMessage: cleanErrorMessage(errorMessage),
        });
      }
    }

    if (suite.suites?.length) {
      failedTests.push(...extractFailedTests(suite.suites, currentPath));
    }
  }

  return failedTests;
}

function buildCardBody(reportStats, failedTests) {
  const hasFailures = reportStats.failures > 0;
  const statusText = hasFailures ? '**Playwright Test Run Failed** ❌' : '**Playwright Test Run Passed** ✅';

  const cardBody = [
    {
      type: 'TextBlock',
      wrap: true,
      text: statusText,
      size: 'large',
      horizontalAlignment: 'center',
    },
    {
      type: 'TextBlock',
      wrap: true,
      text: '**Branch:** ' + process.env.GITHUB_REF,
    },
    {
      type: 'TextBlock',
      wrap: true,
      text: '**Workflow:** ' + process.env.GITHUB_WORKFLOW,
    },
    {
      type: 'TextBlock',
      wrap: true,
      text: '**Environment:** ' + process.env.ENVIRONMENT,
    },
    {
      type: 'FactSet',
      facts: [
        { title: 'Total Tests:', value: reportStats.tests.toString() },
        { title: 'Passed:', value: reportStats.passes.toString() },
        { title: 'Failed:', value: reportStats.failures.toString() },
      ],
    },
  ];

  if (hasFailures && failedTests.length > 0) {
    addFailedTestDetails(cardBody, failedTests);
  }

  cardBody.push({
    type: 'TextBlock',
    wrap: true,
    text: '**See more information:** [' + process.env.INFORMATION_LINK + '](' + process.env.INFORMATION_LINK + ')',
    spacing: 'medium',
  });

  return cardBody;
}

function addFailedTestDetails(cardBody, failedTests) {
  cardBody.push({
    type: 'TextBlock',
    wrap: true,
    text: '**Failed Tests:**',
    weight: 'bolder',
    spacing: 'medium',
  });

  for (const [index, test] of failedTests.entries()) {
    if (index < 10) {
      cardBody.push(
        {
          type: 'TextBlock',
          wrap: true,
          text: `**${index + 1}.** ${test.fullTitle}`,
          weight: 'bolder',
          spacing: 'small',
        },
        {
          type: 'TextBlock',
          wrap: true,
          text: `*Error:* ${truncateText(test.errorMessage, 500)}`,
          spacing: 'none',
          isSubtle: true,
        },
      );
    }
  }

  if (failedTests.length > 10) {
    cardBody.push({
      type: 'TextBlock',
      wrap: true,
      text: `*... and ${failedTests.length - 10} more failed tests. See full report for details.*`,
      spacing: 'small',
      isSubtle: true,
    });
  }
}

function createTeamsMessage(cardBody, hasFailures) {
  const style = hasFailures ? 'attention' : 'good';

  return {
    type: 'message',
    attachments: [
      {
        contentType: 'application/vnd.microsoft.card.adaptive',
        contentUrl: null,
        content: {
          $schema: 'https://adaptivecards.io/schemas/adaptive-card.json',
          type: 'AdaptiveCard',
          version: '1.2',
          body: [
            {
              type: 'Container',
              style,
              items: cardBody,
            },
          ],
        },
      },
    ],
  };
}

function cleanErrorMessage(errorMessage) {
  if (!errorMessage) return 'No error message available';

  const lines = errorMessage.split('\n');
  const relevantLines = [];

  for (const line of lines) {
    if (line.includes('    at ')) {
      break;
    }

    if (line.trim() !== '') {
      relevantLines.push(line.trim());
    }
  }

  return relevantLines.join(' ').trim() || errorMessage.split('\n')[0];
}

function truncateText(text, maxLength) {
  if (!text || text.length <= maxLength) return text;
  return text.substring(0, maxLength) + '...';
}

async function sendTeamsNotification() {
  try {
    const { reportStats, failedTests } = readReportData();
    const cardBody = buildCardBody(reportStats, failedTests);
    const message = createTeamsMessage(cardBody, reportStats.failures > 0);

    await axios.post(process.env.TEAMS_WEBHOOK_URL, message);
    console.log('Message sent to Teams successfully');
  } catch (error) {
    console.error('Error sending notification to Teams:', error);
    process.exit(1);
  }
}

sendTeamsNotification();
