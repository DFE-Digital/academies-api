import { expect, test } from '@playwright/test';
import type { PagedBaselineTrackerResponse } from '../../support/types';

test.describe('Baseline Tracker endpoint', () => {
  test.describe('/v2/basline-tracker - Get Baseline Trackers', () => {
    test('should return a list of baseline trackers when default parameters set', async ({ request }) => {
      const response = await request.get('/v2/basline-tracker', {
        params: { page: 1, count: 50 },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as PagedBaselineTrackerResponse;
      expect(body.data.length).toBeGreaterThanOrEqual(1);
      expect(body.data.length).toBeLessThanOrEqual(50);
    });
  });
});
