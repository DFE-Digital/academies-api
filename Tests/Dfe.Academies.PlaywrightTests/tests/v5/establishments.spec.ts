import { expect, test } from '@playwright/test';
import { establishmentTestData } from '../../support/test-data';
import type { Establishment } from '../../support/types';

const { name, ukprns, urns } = establishmentTestData;

test.describe('v5 Establishment endpoints', () => {
  test('should return a valid 401 response when omitting API key', async ({ request }) => {
    const response = await request.get('/v5/establishments', {
      headers: { ApiKey: '' },
    });

    expect(response.status()).toBe(401);
  });

  test.describe('/v5/establishments - Search Establishments', () => {
    test('should return a list of establishments when no search parameters set', async ({ request }) => {
      const response = await request.get('/v5/establishments');

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Establishment[];
      expect(body.length).toBeGreaterThanOrEqual(1);
      expect(body.length).toBeLessThanOrEqual(100);
    });

    test('should return establishments when name set', async ({ request }) => {
      const response = await request.get('/v5/establishments', {
        params: { name },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Establishment[];
      expect(body[0].name).toBe(name);
    });

    test('should return establishments when UKPRN set', async ({ request }) => {
      const response = await request.get('/v5/establishments', {
        params: { ukPrn: ukprns[0] },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Establishment[];
      expect(body[0].ukprn).toBe(ukprns[0]);
    });

    test('should return establishments when URN set', async ({ request }) => {
      const response = await request.get('/v5/establishments', {
        params: { urn: String(urns[0]) },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Establishment[];
      expect(body[0].urn).toBe(String(urns[0]));
    });
  });

  test.describe('/v5/establishments/bulk/urns - Bulk Search Establishments', () => {
    test('should return a list of establishments when URNs set', async ({ request }) => {
      const response = await request.post('/v5/establishments/bulk/urns', {
        data: { urns: urns.map((urn) => String(urn)) },
      });

      expect(response.status()).toBe(200);
      const body = (await response.json()) as Establishment[];
      expect(body).toHaveLength(2);
      expect(body[0].urn).toBe(String(urns[0]));
      expect(body[1].urn).toBe(String(urns[1]));
    });
  });
});
