import './support/load-env';
import { defineConfig } from '@playwright/test';

function requireEnv(name: string): string {
  const value = process.env[name];
  if (!value) {
    throw new Error(`${name} environment variable is required`);
  }
  return value;
}

const apiBaseUrl = requireEnv('API_BASE_URL').replace(/\/$/, '');
const apiKey = requireEnv('API_KEY');

export default defineConfig({
  testDir: './tests',
  fullyParallel: true,
  forbidOnly: !!process.env.CI,
  retries: process.env.CI ? 2 : 0,
  workers: process.env.CI ? 1 : undefined,
  reporter: process.env.CI
    ? [
        ['list'],
        ['html', { open: 'never' }],
        ['json', { outputFile: 'reports/report.json' }],
      ]
    : [['html', { open: 'never' }], ['list']],
  use: {
    baseURL: apiBaseUrl,
    extraHTTPHeaders: {
      ApiKey: apiKey,
      'Content-Type': 'application/json',
    },
    userAgent: 'AcademiesApi/1.0 Playwright',
    trace: 'on-first-retry',
  },
  projects: [
    {
      name: 'api',
    },
  ],
});
