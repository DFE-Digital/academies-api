import { expect, test } from '@playwright/test';
import { repeatedQueryParams } from '../../support/query-params';
import { establishmentTestData } from '../../support/test-data';
import type { Establishment } from '../../support/types';

const { name, ukprns, urns } = establishmentTestData;

test.describe('Establishment endpoints', () => {
  test.describe('/establishment/{ukPrn} - Get Establishment by UKPRN', () => {
    test('should return establishments when UKPRN set', async ({ request }) => {
      const response = await request.get(`/establishment/${ukprns[0]}`);

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Establishment;
      expect(body.ukprn).toBe(ukprns[0]);
    });
  });

  test.describe('/establishment/regions - Establishment URNs by Region', () => {
    test('should return a list of URNs when a single region is provided', async ({ request }) => {
      const response = await request.get('/establishment/regions', {
        params: { regions: 'North West' },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as string[];
      expect(body.length).toBeGreaterThanOrEqual(1);
    });

    test('should return a list of URNs when multiple regions are provided', async ({ request }) => {
      const response = await request.get('/establishment/regions', {
        params: repeatedQueryParams('regions', ['North West', 'South West']),
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as string[];
      expect(body.length).toBeGreaterThanOrEqual(1);
    });
  });

  test.describe('/establishment/urn/{urn} - Get Establishment by URN', () => {
    test('should return a single establishment when a URN is provided', async ({ request }) => {
      const response = await request.get(`/establishment/urn/${urns[0]}`);

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Establishment;
      expect(body.urn).toBe(String(urns[0]));
    });
  });

  test.describe('/establishments - Search Establishments', () => {
    test('should return no establishments when no parameters set', async ({ request }) => {
      const response = await request.get('/establishments');

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Establishment[];
      expect(body).toHaveLength(0);
    });

    test('should return establishments when name set', async ({ request }) => {
      const response = await request.get('/establishments', {
        params: { name },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Establishment[];
      expect(body[0].name).toBe(name);
    });

    test('should return establishments when UKPRN set', async ({ request }) => {
      const response = await request.get('/establishments', {
        params: { ukPrn: ukprns[0] },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Establishment[];
      expect(body[0].ukprn).toBe(ukprns[0]);
    });

    test('should return establishments when URN set', async ({ request }) => {
      const response = await request.get('/establishments', {
        params: { urn: String(urns[0]) },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Establishment[];
      expect(body[0].urn).toBe(String(urns[0]));
    });
  });

  test.describe('/establishments/bulk - Bulk Get Establishments by URN', () => {
    test('should return a single establishment when a URN is provided', async ({ request }) => {
      const response = await request.get('/establishments/bulk', {
        params: { urn: urns[0] },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Establishment[];
      expect(body).toHaveLength(1);
      expect(body[0].urn).toBe(String(urns[0]));
    });

    test('should return a list of establishments when multiple URNs are provided', async ({ request }) => {
      const response = await request.get('/establishments/bulk', {
        params: repeatedQueryParams('urn', urns),
      });

      expect(response.status()).toBe(200);
      const body = (await response.json()) as Establishment[];
      expect(body[0].urn).toBe(String(urns[0]));
      expect(body[1].urn).toBe(String(urns[1]));
    });
  });
});
