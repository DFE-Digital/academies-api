import { expect, test } from '@playwright/test';
import { significantChangeTestData } from '../../support/test-data';
import type { PagedSignificantChangesResponse } from '../../support/types';

const { deliveryOfficer } = significantChangeTestData;

test.describe('Significant Changes endpoints', () => {
  test.describe('/v4/significantchanges - Search Significant Changes', () => {
    test('should return paginated significant changes when delivery officer set', async ({ request }) => {
      const response = await request.get('/v4/significantchanges', {
        params: { deliveryOfficer, page: 1, count: 10 },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as PagedSignificantChangesResponse;
      expect(body.data.length).toBeGreaterThanOrEqual(1);
      expect(body.data.length).toBeLessThanOrEqual(10);
      expect(body.paging.page).toBe(1);
    });
  });
});
