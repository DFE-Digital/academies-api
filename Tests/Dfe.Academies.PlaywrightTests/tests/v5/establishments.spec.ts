import { test, expect } from '@playwright/test';
import { establishmentTestData } from '../../support/test-data';
import type { Establishment } from '../../support/types';

const { name, ukPrn, urns } = establishmentTestData;

test.describe('Establishment endpoints', () => {
  test.describe('Search Establishments', () => {
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
        params: { ukPrn },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Establishment[];
      expect(body[0].ukprn).toBe(ukPrn);
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
});
