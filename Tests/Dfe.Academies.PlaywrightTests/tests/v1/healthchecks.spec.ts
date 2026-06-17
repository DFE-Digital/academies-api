import { expect, test } from '@playwright/test';

test.describe('Health and Database Checks', () => {
  test.describe('Health check endpoint', () => {
    test('should return a healthy response', async ({ request }) => {
      const response = await request.get('/HealthCheck');

      expect(response.status()).toBe(200);
      expect(await response.text()).toContain('Healthy');
    });
  });
});
