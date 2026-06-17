import { test, expect } from '@playwright/test';
import { repeatedQueryParams } from '../../support/query-params';
import { establishmentTestData } from '../../support/test-data';
import type { Establishment } from '../../support/types';

const { name, ukPrn, urns } = establishmentTestData;

test.describe('Establishment endpoints', () => {
  test.describe('Search Establishments', () => {
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
        params: { ukPrn },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Establishment[];
      expect(body[0].ukprn).toBe(ukPrn);
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

  test.describe('Get Establishment URNs by Region', () => {
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

  test.describe('Get Establishment by UKPRN', () => {
    test('should return establishments when UKPRN set', async ({ request }) => {
      const response = await request.get(`/v4/establishment/${ukPrn}`);

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Establishment;
      expect(body.ukprn).toBe(ukPrn);
    });
  });

  test.describe('Get Establishment by URN', () => {
    test('should return a single establishment when a URN is provided', async ({ request }) => {
      const response = await request.get(`/v4/establishment/urn/${urns[0]}`);

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Establishment;
      expect(body.urn).toBe(String(urns[0]));
    });
  });

  test.describe('Bulk Get Establishments by URN', () => {
    test('should return a single establishment when a URN is provided', async ({ request }) => {
      const response = await request.get('/v4/establishments/bulk', {
        params: { request: urns[0] },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Establishment[];
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
});
