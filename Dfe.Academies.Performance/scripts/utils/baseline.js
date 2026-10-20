import { getEndpointNames } from "./metrics.js";

function hostOnly(url) {
  if (!url) {
    return undefined;
  }
  return String(url)
    .replace(/^[a-zA-Z][a-zA-Z0-9+.-]*:\/\//, "")
    .split("/")[0];
}

function sanitizeForFilename(value) {
  const cleaned = String(value)
    .trim()
    .replace(/[^a-zA-Z0-9_-]+/g, "-");
  return cleaned || "unspecified";
}

// Builds a clean, comparable snapshot of per-endpoint response time stats
// from a k6 handleSummary `data` object, keyed by the same endpoint names
// used when calling recordDuration() in each script.
export function buildBaselineSummary(data) {
  const environment = __ENV.ENVIRONMENT || "unspecified";
  const endpoints = {};

  for (const name of getEndpointNames()) {
    const metric = data.metrics[`endpoint_${name}_duration`];
    const values = metric?.values;

    endpoints[name] = values
      ? {
          avgMs: values.avg,
          minMs: values.min,
          medMs: values.med,
          p90Ms: values["p(90)"],
          p95Ms: values["p(95)"],
          maxMs: values.max,
          count: values.count,
        }
      : null;
  }

  return {
    environment,
    baseUrlHost: hostOnly(__ENV.BASE_URL),
    generatedAt: new Date().toISOString(),
    endpoints,
  };
}

// Produces a stable, environment/timestamp-tagged output path for the
// baseline JSON, e.g. results/baseline-t1-2026-01-01T12-00-00-000Z.json
export function buildBaselineFilename() {
  const environment = sanitizeForFilename(__ENV.ENVIRONMENT || "unspecified");
  const timestamp = new Date().toISOString().replace(/[:.]/g, "-");
  return `results/baseline-${environment}-${timestamp}.json`;
}
