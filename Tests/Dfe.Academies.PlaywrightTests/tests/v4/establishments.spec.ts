import { expect, test } from '@playwright/test';
import { repeatedQueryParams } from '../../support/query-params';
import { establishmentTestData } from '../../support/test-data';
import type { Establishment } from '../../support/types';

const { name, trustUkprn, ukprns, urns } = establishmentTestData;

test.describe('Establishment endpoints', () => {
  test.describe('/v4/establishment/{ukPrn} - Get Establishment by UKPRN', () => {
    test('should return establishments when UKPRN set', async ({ request }) => {
      const response = await request.get(`/v4/establishment/${ukprns[0]}`);

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Establishment;
      expect(body.ukprn).toBe(ukprns[0]);
    });
  });

  test.describe('/v4/establishment/urn/{urn} - Get Establishment by URN', () => {
    test('should return a single establishment when a URN is provided', async ({ request }) => {
      const response = await request.get(`/v4/establishment/urn/${urns[0]}`);

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Establishment;
      expect(body.urn).toBe(String(urns[0]));
    });
  });

  test.describe('/v4/establishments - Search Establishments', () => {
    test('should return a list of establishments when no search parameters set', async ({ request }) => {
      const response = await request.get('/v4/establishments');

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Establishment[];
      expect(body.length).toBeGreaterThanOrEqual(1);
      expect(body.length).toBeLessThanOrEqual(100);
    });

    test('should return establishments when name set', async ({ request }) => {
      const response = await request.get('/v4/establishments', {
        params: { name },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Establishment[];
      expect(body[0].name).toBe(name);
    });

    test('should return establishments when UKPRN set', async ({ request }) => {
      const response = await request.get('/v4/establishments', {
        params: { ukPrn: ukprns[0] },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Establishment[];
      expect(body[0].ukprn).toBe(ukprns[0]);
    });

    test('should return establishments when URN set', async ({ request }) => {
      const response = await request.get('/v4/establishments', {
        params: { urn: String(urns[0]) },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Establishment[];
      expect(body[0].urn).toBe(String(urns[0]));
    });
  });

  test.describe('/v4/establishments/SearchByNameStartsWith - Search Establishments By Name Starts With', () => {
    test('should return a list of establishments when a name starts with is provided', async ({ request }) => {
      const startOfName = name.substring(0, 6);
      const response = await request.get('/v4/establishments/SearchByNameStartsWith', {
        params: { name: startOfName },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Establishment[];
      expect(body.length).toBeGreaterThanOrEqual(1);
      body.forEach((establishment) => {
        expect(establishment.name!.startsWith(startOfName)).toBe(true);
      });
    });
  });

  test.describe('/v4/establishment/regions - Establishment URNs by Region', () => {
    test('should return a list of URNs when a single region is provided', async ({ request }) => {
      const response = await request.get('/v4/establishment/regions', {
        params: { regions: 'North West' },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as string[];
      expect(body.length).toBeGreaterThanOrEqual(1);
    });

    test('should return a list of URNs when multiple regions are provided', async ({ request }) => {
      const response = await request.get('/v4/establishment/regions', {
        params: repeatedQueryParams('regions', ['North West', 'South West']),
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as string[];
      expect(body.length).toBeGreaterThanOrEqual(1);
    });
  });

  test.describe('/v4/establishments/bulk - Bulk Get Establishments by URN', () => {
    test('should return a single establishment when a URN is provided', async ({ request }) => {
      const response = await request.get('/v4/establishments/bulk', {
        params: { request: urns[0] },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Establishment[];
      expect(body).toHaveLength(1);
      expect(body[0].urn).toBe(String(urns[0]));
    });

    test('should return a list of establishments when multiple URNs are provided', async ({ request }) => {
      const response = await request.get('/v4/establishments/bulk', {
        params: repeatedQueryParams('request', urns),
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Establishment[];
      expect(body[0].urn).toBe(String(urns[0]));
      expect(body[1].urn).toBe(String(urns[1]));
    });
  });

  test.describe('/v4/establishments/bulk/urns - Bulk Search Establishments', () => {
    test('should return a list of establishments when URNs set', async ({ request }) => {
      const response = await request.post('/v4/establishments/bulk/urns', {
        data: { urns: urns.map((urn) => String(urn)) },
      });

      expect(response.status()).toBe(200);
      const body = (await response.json()) as Establishment[];
      expect(body).toHaveLength(2);
      expect(body[0].urn).toBe(String(urns[0]));
      expect(body[1].urn).toBe(String(urns[1]));
    });
  });

  test.describe('/v4/establishments/trust - Get Establishments by Trust', () => {
    test('should return a list of establishments when a trust is provided', async ({ request }) => {
      const response = await request.get('/v4/establishments/trust', {
        params: { trustUkprn: trustUkprn },
      });

      expect(response.status()).toBe(200);
      const body = (await response.json()) as Establishment[];
      expect(body.length).toBeGreaterThanOrEqual(1);
    });
  });

  test.describe('/v4/establishments/ukprn/bulk - Get Establishments by UKPRNs', () => {
    test('should return a single establishment when a UKPRN is provided', async ({ request }) => {
      const response = await request.get('/v4/establishments/ukprn/bulk', {
        params: { ukprn: ukprns[0] },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Establishment[];
      expect(body).toHaveLength(1);
      expect(body[0].ukprn).toBe(String(ukprns[0]));
    });

    test('should return a list of establishments when multiple URNs are provided', async ({ request }) => {
      const response = await request.get('/v4/establishments/ukprn/bulk', {
        params: repeatedQueryParams('ukprn', ukprns),
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Establishment[];
      expect(body).toHaveLength(2);
      expect(body[0].ukprn).toBe(String(ukprns[0]));
      expect(body[1].ukprn).toBe(String(ukprns[1]));
    });
  });

  test.describe('/v4/establishments/bulk/ukprns - Bulk Search Establishments by UKPRNs', () => {
    test('should return a list of establishments when UKPRNs set', async ({ request }) => {
      const response = await request.post('/v4/establishments/bulk/ukprns', {
        data: { ukprns: ukprns.map((ukprn) => String(ukprn)) },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Establishment[];
      expect(body).toHaveLength(2);
      expect(body[0].ukprn).toBe(String(ukprns[0]));
      expect(body[1].ukprn).toBe(String(ukprns[1]));
    });
  });
});
