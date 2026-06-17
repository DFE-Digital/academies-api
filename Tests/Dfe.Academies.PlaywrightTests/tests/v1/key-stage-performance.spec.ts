import { test, expect } from '@playwright/test';
import { keyStagePerformanceTestData } from '../../support/test-data';
import type { KeyStagePerformance } from '../../support/types';

const { urn, schoolName } = keyStagePerformanceTestData;

test.describe('Key Stage Performance endpoint', () => {
  test('returns education performance data when URN supplied', async ({ request }) => {
    const response = await request.get(`/educationPerformance/${urn}`);

    expect(response.status()).toBe(200);

    const body = (await response.json()) as KeyStagePerformance;
    expect(body.schoolName).toBe(schoolName);
    expect(body).toEqual(
      expect.objectContaining({
        schoolName: expect.any(String),
        keyStage1: expect.anything(),
        keyStage2: expect.anything(),
        keyStage4: expect.anything(),
        keyStage5: expect.anything(),
      }),
    );
  });
});
