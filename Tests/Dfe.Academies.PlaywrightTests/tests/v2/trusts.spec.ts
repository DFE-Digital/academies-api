import { expect, test } from '@playwright/test';
import { trustTestData, v3TrustTestData } from '../../support/test-data';
import {
  TrustResponseApiResponseV2,
  TrustResponseApiSingleResponseV2,
  TrustSummaryResponseApiResponseV2,
} from '../../support/types';
import { repeatedQueryParams } from '../../support/query-params';

const { companiesHouseNumber, ukprn, groupName } = v3TrustTestData;
const { ukprns, secondTrustName } = trustTestData;

test.describe('Trusts endpoints', () => {
  test.describe('/v2/trusts - Search Trusts', () => {
    test('should return a list of trusts when default search parameters set', async ({ request }) => {
      const response = await request.get('/v2/trusts', {
        params: { page: 1, count: 5 },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as TrustSummaryResponseApiResponseV2;
      expect(body.data.length).toBeGreaterThanOrEqual(1);
      expect(body.data.length).toBeLessThanOrEqual(5);
      expect(body.paging.page).toBe(1);
    });

    test('should return a single trust when group name set', async ({ request }) => {
      const response = await request.get('/v2/trusts', {
        params: { groupName, page: 1, count: 50 },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as TrustSummaryResponseApiResponseV2;
      expect(body.data[0].groupName).toBe(groupName);
    });

    test('should return a single trust when UKPRN set', async ({ request }) => {
      const response = await request.get('/v2/trusts', {
        params: { ukPrn: ukprn, page: 1, count: 50 },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as TrustSummaryResponseApiResponseV2;
      expect(body.data[0].groupName).toBe(groupName);
    });

    test('should return a single trust when Companies House Number set', async ({ request }) => {
      const response = await request.get('/v2/trusts', {
        params: { companiesHouseNumber, page: 1, count: 50 },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as TrustSummaryResponseApiResponseV2;
      expect(body.data[0].groupName).toBe(groupName);
      expect(body.data[0].companiesHouseNumber).toBe(companiesHouseNumber);
    });
  });

  test.describe('/v2/trust/{ukprn} - Get Trust by UKPRN', () => {
    test('should return a single trust when UKPRN set', async ({ request }) => {
      const response = await request.get(`/v2/trust/${ukprn}`);

      expect(response.status()).toBe(200);

      const body = (await response.json()) as TrustResponseApiSingleResponseV2;
      expect(body.data.giasData.ukprn).toEqual(ukprn);
      expect(body.data.giasData.groupName).toBe(groupName);
    });
  });

  test.describe('/v2/trusts/bulk - Bulk Get Trusts by UKPRN', () => {
    test('should return a single trust when a single UKPRN is provided', async ({ request }) => {
      const response = await request.get('/v2/trusts/bulk', {
        params: { ukprn: ukprns[0] },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as TrustResponseApiResponseV2;
      // paging is not implemented
      // expect(body.paging.page).toBe(1);
      // expect(body.paging.recordCount).toBe(1);

      expect(body.data[0].giasData.groupName).toBe(groupName);
      expect(body.data[0].giasData.ukprn).toBe(ukprns[0]);
    });

    test('should return a list of trusts when multiple UKPRNs provided', async ({ request }) => {
      const response = await request.get('/v2/trusts/bulk', {
        params: repeatedQueryParams('ukprn', ukprns),
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as TrustResponseApiResponseV2;
      // paging is not implemented
      // expect(body.paging.page).toBe(1);
      // expect(body.paging.recordCount).toBe(2);

      const data = body.data;
      expect(data).toHaveLength(2);
      expect(data).toEqual(
        expect.arrayContaining([
          expect.objectContaining({
            giasData: expect.objectContaining({ groupName, ukprn: ukprns[0] }),
          }),
          expect.objectContaining({
            giasData: expect.objectContaining({ groupName: secondTrustName, ukprn: ukprns[1] }),
          }),
        ]),
      );
    });
  });
});
