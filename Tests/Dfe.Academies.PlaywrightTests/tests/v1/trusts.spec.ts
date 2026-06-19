import { expect, test } from '@playwright/test';
import { v3TrustTestData } from '../../support/test-data';
import { TrustResponse, TrustSummaryResponse } from '../../support/types';

const { companiesHouseNumber, ukprn, groupName } = v3TrustTestData;

test.describe('Trusts endpoints', () => {
  test('should return a valid 401 response when omitting API key', async ({ request }) => {
    const response = await request.get('/trusts', {
      headers: { ApiKey: '' },
    });

    expect(response.status()).toBe(401);
  });

  test.describe('/trusts - Search Trusts', () => {
    test('should return a list of trusts when default search parameters set', async ({ request }) => {
      const response = await request.get('/trusts', {
        params: { page: 1, count: 5 },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as TrustSummaryResponse[];
      expect(body.length).toBeGreaterThanOrEqual(1);
      expect(body.length).toBeLessThanOrEqual(5);
    });

    test('should return a single trust when group name set', async ({ request }) => {
      const response = await request.get('/trusts', {
        params: { groupName, page: 1, count: 50 },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as TrustSummaryResponse[];
      expect(body[0].groupName).toBe(groupName);
    });

    test('should return a single trust when UKPRN set', async ({ request }) => {
      const response = await request.get('/trusts', {
        params: { ukPrn: ukprn, page: 1, count: 50 },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as TrustSummaryResponse[];
      expect(body[0].groupName).toBe(groupName);
    });

    test('should return a single trust when Companies House Number set', async ({ request }) => {
      const response = await request.get('/trusts', {
        params: { companiesHouseNumber, page: 1, count: 50 },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as TrustSummaryResponse[];
      expect(body[0].groupName).toBe(groupName);
      expect(body[0].companiesHouseNumber).toBe(companiesHouseNumber);
    });
  });

  test.describe('/trust/{ukprn} - Get Trust by UKPRN', () => {
    test('should return a single trust when UKPRN set', async ({ request }) => {
      const response = await request.get(`/trust/${ukprn}`);

      expect(response.status()).toBe(200);

      const body = (await response.json()) as TrustResponse;
      expect(body.giasData.ukprn).toEqual(ukprn);
      expect(body.giasData.groupName).toBe(groupName);
    });
  });
});
