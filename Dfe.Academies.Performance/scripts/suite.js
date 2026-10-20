import { htmlReport } from 'https://raw.githubusercontent.com/benc-uk/k6-reporter/main/dist/bundle.js'
import { textSummary } from 'https://jslib.k6.io/k6-summary/0.0.1/index.js'
import { default as v1Establishments } from './v1/establishments.js'
import { default as v1Trusts } from './v1/trusts.js'
import { default as keyStagePerformance } from './v1/keyStagePerformance.js'
import { default as baselineTracker } from './v2/baselineTracker.js'
import { default as fssProjects } from './v2/fssProjects.js'
import { default as trustsV3 } from './v3/trusts.js'
import { default as establishments } from './v4/establishments.js'
import { default as trustsV4 } from './v4/trusts.js'
import { default as diocese } from './v4/diocese.js'
import { default as localAuthorities } from './v4/localAuthorities.js'
import { default as significantChanges } from './v4/significantChanges.js'
import { default as establishmentsV5 } from './v5/establishments.js'
import { buildBaselineSummary, buildBaselineFilename } from './utils/baseline.js'

export const options = {
  // Ensure count/p90/p95 are captured on every Trend (including the
  // per-endpoint trends in utils/metrics.js) so they're available to
  // handleSummary for the baseline JSON output.
  summaryTrendStats: ['avg', 'min', 'med', 'p(90)', 'p(95)', 'max', 'count'],
  thresholds: {
    http_req_failed: ['rate<0.01'],   // Failure rate less than 1%
    http_req_duration: ['p(95)<1000'] // Requests take <1s at the 95th percentile
  },
  // Baseline capture only, not a load test: every scenario runs on a single
  // VU with a handful of sequential iterations (shared-iterations), and
  // scenarios are staggered just far enough apart that they never run
  // concurrently - this keeps us from overloading the shared dev
  // environment. Observed runs complete each of these fast scenarios in
  // ~8-10s, so a 45s startTime step (and 1m maxDuration safety cap) leaves
  // a healthy margin without the long idle waits a bigger step would cause.
  // establishmentsV5 gets a much longer startTime gap and maxDuration
  // because its unfiltered /establishments search is known to be very slow
  // (N+1 lookups per establishment, no pagination).
  scenarios: {
    v1Establishments: {
      exec: 'v1est',
      executor: 'shared-iterations',
      vus: 1,
      iterations: 5,
      maxDuration: '1m'
    },
    v1Trusts: {
      exec: 'v1t',
      executor: 'shared-iterations',
      vus: 1,
      iterations: 5,
      maxDuration: '1m',
      startTime: '45s'
    },
    keyStagePerformance: {
      exec: 'ksp',
      executor: 'shared-iterations',
      vus: 1,
      iterations: 5,
      maxDuration: '1m',
      startTime: '90s'
    },
    baselineTracker: {
      exec: 'bt',
      executor: 'shared-iterations',
      vus: 1,
      iterations: 5,
      maxDuration: '1m',
      startTime: '135s'
    },
    fssProjects: {
      exec: 'fss',
      executor: 'shared-iterations',
      vus: 1,
      iterations: 5,
      maxDuration: '1m',
      startTime: '180s'
    },
    trustsV3: {
      exec: 'v3t',
      executor: 'shared-iterations',
      vus: 1,
      iterations: 5,
      maxDuration: '1m',
      startTime: '225s'
    },
    establishments: {
      exec: 'est',
      executor: 'shared-iterations',
      vus: 1,
      iterations: 5,
      maxDuration: '1m',
      startTime: '270s'
    },
    trustsV4: {
      exec: 'v4t',
      executor: 'shared-iterations',
      vus: 1,
      iterations: 5,
      maxDuration: '1m',
      startTime: '315s'
    },
    diocese: {
      exec: 'dio',
      executor: 'shared-iterations',
      vus: 1,
      iterations: 5,
      maxDuration: '1m',
      startTime: '360s'
    },
    localAuthorities: {
      exec: 'la',
      executor: 'shared-iterations',
      vus: 1,
      iterations: 5,
      maxDuration: '1m',
      startTime: '405s'
    },
    significantChanges: {
      exec: 'sc',
      executor: 'shared-iterations',
      vus: 1,
      iterations: 5,
      maxDuration: '1m',
      startTime: '450s'
    },
    establishmentsV5: {
      exec: 'v5est',
      executor: 'shared-iterations',
      vus: 1,
      iterations: 3,
      maxDuration: '10m',
      startTime: '495s'
    },
  }
}

export function v1est() {
  v1Establishments()
}

export function v1t() {
  v1Trusts()
}

export function ksp() {
  keyStagePerformance()
}

export function bt() {
  baselineTracker()
}

export function fss() {
  fssProjects()
}

export function v3t() {
  trustsV3()
}

export function v4t() {
  trustsV4()
}

export function est() {
  establishments()
}

export function dio() {
  diocese()
}

export function la() {
  localAuthorities()
}

export function sc() {
  significantChanges()
}

export function v5est() {
  establishmentsV5()
}

export function handleSummary(data) {
  return {
    'summary.html': htmlReport(data),
    [buildBaselineFilename()]: JSON.stringify(buildBaselineSummary(data), null, 2),
    stdout: textSummary(data, { indent: ' ', enableColors: true }),
  }
}
