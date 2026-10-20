import { htmlReport } from "https://raw.githubusercontent.com/benc-uk/k6-reporter/main/dist/bundle.js";
import { textSummary } from "https://jslib.k6.io/k6-summary/0.0.1/index.js";
import v1Establishments from "./v1/establishments.js";
import v1Trusts from "./v1/trusts.js";
import keyStagePerformance from "./v1/keyStagePerformance.js";
import baselineTracker from "./v2/baselineTracker.js";
import fssProjects from "./v2/fssProjects.js";
import trustsV3 from "./v3/trusts.js";
import establishments from "./v4/establishments.js";
import trustsV4 from "./v4/trusts.js";
import diocese from "./v4/diocese.js";
import localAuthorities from "./v4/localAuthorities.js";
import significantChanges from "./v4/significantChanges.js";
import establishmentsV5 from "./v5/establishments.js";
import {
  buildBaselineSummary,
  buildBaselineFilename,
} from "./utils/baseline.js";

export const options = {
  // Ensure count/p90/p95 are captured on every Trend (including the
  // per-endpoint trends in utils/metrics.js) so they're available to
  // handleSummary for the baseline JSON output.
  summaryTrendStats: ["avg", "min", "med", "p(90)", "p(95)", "max", "count"],
  thresholds: {
    http_req_failed: ["rate<0.01"], // Failure rate less than 1%
    http_req_duration: ["p(95)<1000"], // Requests take <1s at the 95th percentile
  },
  // Baseline capture only
  // The 11 fast endpoint groups are chained directly as plain
  // sequential function calls inside a single scenario/iteration below, so
  // the next call starts the instant the previous one returns - no padding.
  // establishmentsV5 stays as its own scenario because its unfiltered
  // search is genuinely slow (N+1 lookups per establishment, no
  // pagination), so it gets its own safety margin instead of slowing down
  // every iteration of the fast group.
  scenarios: {
    fastEndpoints: {
      exec: "fast",
      executor: "shared-iterations",
      vus: 1,
      iterations: 5,
      maxDuration: "3m",
    },
    establishmentsV5: {
      exec: "v5est",
      executor: "shared-iterations",
      vus: 1,
      iterations: 3,
      maxDuration: "10m",
      startTime: "2m",
    },
  },
};

export function fast() {
  v1Establishments();
  v1Trusts();
  keyStagePerformance();
  baselineTracker();
  fssProjects();
  trustsV3();
  establishments();
  trustsV4();
  diocese();
  localAuthorities();
  significantChanges();
}

export function v5est() {
  establishmentsV5();
}

export function handleSummary(data) {
  return {
    "summary.html": htmlReport(data),
    [buildBaselineFilename()]: JSON.stringify(
      buildBaselineSummary(data),
      null,
      2,
    ),
    stdout: textSummary(data, { indent: " ", enableColors: true }),
  };
}
