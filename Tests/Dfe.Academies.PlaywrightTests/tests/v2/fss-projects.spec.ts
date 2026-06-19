import { expect, test } from '@playwright/test';
import type { FssProjectsResponse } from '../../support/types';

test.describe('Free Schools Store endpoint', () => {
  test.describe('/v2/fss/projects - Get FSS Projects', () => {
    test('should return a valid response with data', async ({ request }) => {
      const response = await request.get('/v2/fss/projects');

      expect(response.status()).toBe(200);

      const body = (await response.json()) as FssProjectsResponse;
      expect(body.data.length).toBeGreaterThanOrEqual(1);

      const requiredKeys = ['localAuthority', 'projectId', 'projectStatus', 'trustId', 'trustName', 'urn'] as const;

      for (const key of requiredKeys) {
        expect(body.data[0]).toHaveProperty(key);
      }
    });

    test('should return a valid 401 response when omitting API key', async ({ request }) => {
      const response = await request.get('/v2/fss/projects', {
        headers: { ApiKey: '' },
      });

      expect(response.status()).toBe(401);
    });
  });
});
