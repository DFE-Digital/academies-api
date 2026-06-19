const ZapClient = require('zaproxy');

async function generateZapHtmlReport() {
  console.log('Generating ZAP report');

  const zaproxy = new ZapClient({
    apiKey: process.env.ZAP_API_KEY,
    proxy: {
      host: process.env.ZAP_ADDRESS,
      port: process.env.ZAP_PORT,
    },
  });

  let recordsRemaining = 100;
  while (recordsRemaining !== 0) {
    try {
      const response = await zaproxy.pscan.recordsToScan();
      recordsRemaining = Number.parseInt(response.recordsToScan, 10);

      if (Number.isNaN(recordsRemaining)) {
        console.log('Error converting passive scan result');
        recordsRemaining = 0;
      }
    } catch (error) {
      console.log(`Error from the ZAP Passive Scan API: ${error}`);
      recordsRemaining = 0;
    }
  }

  try {
    const response = await zaproxy.reports.generate({
      title: 'Report',
      template: 'traditional-html',
      reportfilename: 'ZAP-Report.html',
      reportdir: '/zap/wrk',
    });

    console.log(JSON.stringify(response));
  } catch (error) {
    console.log(`Error from ZAP Report API: ${error}`);
    process.exit(1);
  }
}

generateZapHtmlReport();
