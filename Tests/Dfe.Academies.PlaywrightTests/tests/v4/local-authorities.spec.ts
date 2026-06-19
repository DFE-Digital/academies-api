import { expect, test } from '@playwright/test';
import { localAuthorityTestData } from '../../support/test-data';
import type { LocalAuthority } from '../../support/types';

const { name, code } = localAuthorityTestData;

test.describe('Local Authority endpoints', () => {
  test.describe('/v4/local-authorities - Search Local Authorities', () => {
    test('should return a list of local authorities when no search parameters set', async ({ request }) => {
      const response = await request.get('/v4/local-authorities');

      expect(response.status()).toBe(200);

      const body = (await response.json()) as LocalAuthority[];
      expect(body.length).toBeGreaterThanOrEqual(1);
    });

    test('should return local authorities when name set', async ({ request }) => {
      const response = await request.get('/v4/local-authorities', {
        params: { name },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as LocalAuthority[];
      expect(body).toHaveLength(1);
      expect(body[0].name).toBe(name);
    });

    test('should return local authorities when code set', async ({ request }) => {
      const response = await request.get('/v4/local-authorities', {
        params: { code },
      });

      expect(response.status()).toBe(200);

      const body = (await response.json()) as LocalAuthority[];
      expect(body).toHaveLength(1);
      expect(body[0].code).toBe(code);
    });
  });

  test.describe('/v4/local-authorities/{code} - Get Local Authority by Code', () => {
    test('should return a local authority when code set', async ({ request }) => {
      const response = await request.get(`/v4/local-authorities/${code}`);

      expect(response.status()).toBe(200);

      const body = (await response.json()) as LocalAuthority;
      expect(body.name).toBe(name);
      expect(body.code).toBe(code);
    });
  });
});
