import { expect, test } from '@playwright/test';
import { dioceseTestData } from '../../support/test-data';
import type { Diocese } from '../../support/types';

const { name, code } = dioceseTestData;

test.describe('Diocese endpoints', () => {
  test.describe('/v4/diocese - Search Dioceses', () => {
    test('should return a list of dioceses when no search parameters set', async ({ request }) => {
      const response = await request.get('/v4/diocese');

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Diocese[];
      expect(body.length).toBeGreaterThanOrEqual(1);
    });

    test('should return dioceses when name set', async ({ request }) => {
      const response = await request.get('/v4/diocese', {
        params: { name },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Diocese[];
      expect(body).toHaveLength(1);
      expect(body[0].name).toBe(name);
    });

    test('should return dioceses when code set', async ({ request }) => {
      const response = await request.get('/v4/diocese', {
        params: { code },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Diocese[];
      expect(body).toHaveLength(1);
      expect(body[0].code).toBe(code);
    });
  });

  test.describe('/v4/diocese/{code} - Get Diocese by Code', () => {
    test('should return a diocese when code set', async ({ request }) => {
      const response = await request.get(`/v4/diocese/${code}`);

      expect(response.status()).toBe(200);

      const body = (await response.json()) as Diocese;
      expect(body.name).toBe(name);
      expect(body.code).toBe(code);
    });
  });
});
