import { Trend } from "k6/metrics";

// Every endpoint name used by `recordDuration` across all scripts must be
// listed here. k6 requires all metrics to be declared in the init context
// (i.e. at module load time), so the Trend objects are created eagerly up
// front rather than lazily the first time an endpoint is hit - creating a
// metric inside the default/exec function would throw at runtime.
const ENDPOINT_NAMES = [
  // v1
  "v1_establishment_by_ukprn",
  "v1_establishment_by_urn",
  "v1_establishment_urns_by_region",
  "v1_establishments_search",
  "v1_establishments_bulk",
  "v1_trust_by_ukprn",
  "v1_trusts_search_by_name",
  "v1_trusts_search_by_ukprn",
  "v1_trusts_search_by_companies_house_number",
  "v1_education_performance_by_urn",
  // v2
  "v2_fss_projects",
  "v2_baseline_tracker",
  // v3
  "v3_trust_by_ukprn",
  "v3_trusts_search_by_name",
  "v3_trusts_search_by_ukprn",
  // v4
  "v4_trust_by_ukprn",
  "v4_trust_by_companies_house_number",
  "v4_trust_by_reference_number",
  "v4_trusts_search_by_name",
  "v4_trusts_search_by_ukprn",
  "v4_establishment_by_ukprn",
  "v4_establishment_by_urn",
  "v4_establishments_for_trust",
  "v4_diocese_search_by_name",
  "v4_diocese_search_by_code",
  "v4_diocese_by_code",
  "v4_local_authorities_search_by_name",
  "v4_local_authorities_search_by_code",
  "v4_local_authority_by_code",
  "v4_significant_changes_search",
  // v5
  "v5_establishments_search",
  "v5_establishments_search_by_name",
  "v5_establishments_search_by_ukprn",
  "v5_establishments_search_by_urn",
  "v5_establishments_bulk_by_urns",
];

// Registry of per-endpoint Trend metrics, keyed by endpoint name. Each
// endpoint gets its own Trend so avg/med/p90/p95/max/min/count can be read
// back independently in handleSummary, instead of only ever seeing one
// aggregate http_req_duration number across every request in a script.
const trends = {};
for (const name of ENDPOINT_NAMES) {
  trends[name] = new Trend(`endpoint_${name}_duration`, true);
}

// Records a response's duration against a named endpoint trend.
// `name` must be one of ENDPOINT_NAMES above, e.g. 'v4_trust_by_ukprn'.
export function recordDuration(name, res) {
  const trend = trends[name];
  if (!trend) {
    throw new Error(
      `Unknown endpoint metric name "${name}" - add it to ENDPOINT_NAMES in utils/metrics.js`,
    );
  }
  trend.add(res.timings.duration);
}

export function getEndpointNames() {
  return ENDPOINT_NAMES.slice();
}
