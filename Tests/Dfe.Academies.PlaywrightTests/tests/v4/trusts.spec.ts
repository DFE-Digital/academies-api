import { expect, test } from '@playwright/test';
import { repeatedQueryParams } from '../../support/query-params';
import { trustTestData } from '../../support/test-data';
import type { PagedTrustsResponse, Trust, TrustsByEstablishmentUrnsResponse } from '../../support/types';

const { companiesHouseNumber, ukprns, groupName, secondTrustName, trustReferenceNumber, urns } = trustTestData;

test.describe('Trusts endpoints', () => {
  test('should return a valid 401 response when omitting API key', async ({ request }) => {
    const response = await request.get('/v4/trusts', {
      headers: { ApiKey: '' },
    });

    expect(response.status()).toBe(401);
  });

  test.describe('/v4/trust/{ukprn} - Get Trust by UKPRN', () => {
    test('should return a single trust when UKPRN set', async ({ request }) => {
      const response = await request.get(`/v4/trust/${ukprns[0]}`);

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Trust;
      expect(body.name).toBe(groupName);
    });
  });

  test.describe('/v4/trust/companiesHouseNumber/{companiesHouseNumber} - Get Trust by Companies House Number', () => {
    test('should return a single trust when Companies House Number set', async ({ request }) => {
      const response = await request.get(`/v4/trust/companiesHouseNumber/${companiesHouseNumber}`);

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Trust;
      expect(body.name).toBe(groupName);
      expect(body.companiesHouseNumber).toBe(companiesHouseNumber);
    });
  });

  test.describe('/v4/trust/trustReferenceNumber/{trustReferenceNumber} - Get Trusts by Trust Reference Number', () => {
    test('should return a single trust when Trust Reference Number set', async ({ request }) => {
      const response = await request.get(`/v4/trust/trustReferenceNumber/${trustReferenceNumber}`);

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Trust;
      expect(body.name).toBe(groupName);
      expect(body.referenceNumber).toBe(trustReferenceNumber);
    });
  });

  test.describe('/v4/trusts - Search Trusts', () => {
    test('should return a list of trusts when default search parameters set', async ({ request }) => {
      const response = await request.get('/v4/trusts', {
        params: { page: 1, count: 10 },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as PagedTrustsResponse;
      expect(body.data.length).toBeGreaterThanOrEqual(1);
      expect(body.data.length).toBeLessThanOrEqual(10);
      expect(body.paging.page).toBe(1);
    });

    test('should return a single trust when group name set', async ({ request }) => {
      const response = await request.get('/v4/trusts', {
        params: { groupName, page: 1, count: 10 },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as PagedTrustsResponse;
      expect(body.data[0].name).toBe(groupName);
    });

    test('should return a single trust when UKPRN set', async ({ request }) => {
      const response = await request.get('/v4/trusts', {
        params: { ukPrn: ukprns[0], page: 1, count: 10 },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as PagedTrustsResponse;
      expect(body.data[0].name).toBe(groupName);
    });

    test('should return a single trust when Companies House Number set', async ({ request }) => {
      const response = await request.get('/v4/trusts', {
        params: { companiesHouseNumber, page: 1, count: 10 },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as PagedTrustsResponse;
      expect(body.data[0].name).toBe(groupName);
      expect(body.data[0].companiesHouseNumber).toBe(companiesHouseNumber);
    });
  });

  test.describe('/v4/trusts/bulk - Bulk Get Trusts by UKPRN', () => {
    test('should return a single trust when a single UKPRN is provided', async ({ request }) => {
      const response = await request.get('/v4/trusts/bulk', {
        params: { ukprns: ukprns[0] },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Trust[];
      expect(body[0].name).toBe(groupName);
      expect(body[0].ukprn).toBe(ukprns[0]);
    });

    test('should return a list of trusts when multiple UKPRNs provided', async ({ request }) => {
      const response = await request.get('/v4/trusts/bulk', {
        params: repeatedQueryParams('ukprns', ukprns),
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Trust[];
      expect(body).toHaveLength(2);

      const responseText = JSON.stringify(body);
      expect(responseText).toContain(groupName);
      expect(responseText).toContain(ukprns[0]);
      expect(responseText).toContain(secondTrustName);
      expect(responseText).toContain(ukprns[1]);
    });
  });

  test.describe('/v4/trusts/establishments/urns - Search Trusts by URNs', () => {
    test('should return a list of trusts when URNs set', async ({ request }) => {
      const response = await request.post('/v4/trusts/establishments/urns', {
        data: { urns: urns.map((urn) => String(urn)) },
      });

      expect(response.status()).toBe(200);
      const body = (await response.json()) as TrustsByEstablishmentUrnsResponse;
      expect(Object.keys(body)).toHaveLength(2);
      expect(body[String(urns[0])].name).toBeDefined();
      expect(body[String(urns[1])].name).toBeDefined();
    });
  });
});
