import { expect, test } from '@playwright/test';
import { v3TrustTestData } from '../../support/test-data';
import type {
  PagedTrustsResponse,
  TrustResponseApiSingleResponseV2,
  TrustSummaryResponseApiResponseV2,
} from '../../support/types';

const { companiesHouseNumber, ukprn, groupName } = v3TrustTestData;

test.describe('Trusts endpoints', () => {
  test('should return a valid 401 response when omitting API key', async ({ request }) => {
    const response = await request.get('/v3/trusts', {
      headers: { ApiKey: '' },
    });

    expect(response.status()).toBe(401);
  });

  test.describe('/v3/trusts - Search Trusts', () => {
    test('should return a list of trusts when default search parameters set', async ({ request }) => {
      const response = await request.get('/v3/trusts', {
        params: { page: 1, count: 50 },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as PagedTrustsResponse;
      expect(body.data.length).toBeGreaterThanOrEqual(1);
      expect(body.data.length).toBeLessThanOrEqual(50);
      expect(body.paging.page).toBe(1);
    });

    test('should return a single trust when group name set', async ({ request }) => {
      const response = await request.get('/v3/trusts', {
        params: { groupName, page: 1, count: 50 },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as TrustSummaryResponseApiResponseV2;
      expect(body.data[0].groupName).toBe(groupName);
    });

    test('should return a single trust when UKPRN set', async ({ request }) => {
      const response = await request.get('/v3/trusts', {
        params: { ukPrn: ukprn, page: 1, count: 50 },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as TrustSummaryResponseApiResponseV2;
      expect(body.data[0].groupName).toBe(groupName);
    });

    test('should return a single trust when Companies House Number set', async ({ request }) => {
      const response = await request.get('/v3/trusts', {
        params: { companiesHouseNumber, page: 1, count: 50 },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as TrustSummaryResponseApiResponseV2;
      expect(body.data[0].groupName).toBe(groupName);
      expect(body.data[0].companiesHouseNumber).toBe(companiesHouseNumber);
    });
  });

  test.describe('/v3/trust/{ukprn} - Get Trust by UKPRN', () => {
    test('should return a single trust when UKPRN set', async ({ request }) => {
      const response = await request.get(`/v3/trust/${ukprn}`);

      expect(response.status()).toBe(200);

      const body = (await response.json()) as TrustResponseApiSingleResponseV2;
      expect(body.data).toEqual(
        expect.objectContaining({
          trustData: expect.anything(),
          giasData: expect.anything(),
          establishments: expect.anything(),
        }),
      );
      expect(body.data.giasData.groupName).toBe(groupName);
    });
  });
});
