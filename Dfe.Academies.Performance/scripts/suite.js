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
  scenarios: {
    v1Establishments: {
      exec: 'v1est',
      executor: 'constant-arrival-rate',
      duration: '10s',
      preAllocatedVUs: 100,
      rate: 10,
      timeUnit: '1s',
      gracefulStop: '60s'
    },
    v1Trusts: {
      exec: 'v1t',
      executor: 'constant-arrival-rate',
      duration: '10s',
      preAllocatedVUs: 100,
      rate: 10,
      timeUnit: '1s',
      gracefulStop: '60s',
      startTime: '30s'
    },
    keyStagePerformance: {
      exec: 'ksp',
      executor: 'constant-arrival-rate',
      duration: '10s',
      preAllocatedVUs: 100,
      rate: 10,
      timeUnit: '1s',
      gracefulStop: '60s',
      startTime: '60s'
    },
    baselineTracker: {
      exec: 'bt',
      executor: 'constant-arrival-rate',
      duration: '10s',
      preAllocatedVUs: 100,
      rate: 10,
      timeUnit: '1s',
      gracefulStop: '60s',
      startTime: '90s'
    },
    fssProjects: {
      exec: 'fss',
      executor: 'constant-arrival-rate',
      duration: '10s',
      preAllocatedVUs: 100,
      rate: 10,
      timeUnit: '1s',
      gracefulStop: '60s',
      startTime: '120s'
    },
    trustsV3: {
      exec: 'v3t',
      executor: 'constant-arrival-rate',
      duration: '10s',
      preAllocatedVUs: 100,
      rate: 10,
      timeUnit: '1s',
      gracefulStop: '60s',
      startTime: '150s'
    },
    establishments: {
      exec: 'est',
      executor: 'constant-arrival-rate',
      duration: '10s',
      preAllocatedVUs: 100,
      rate: 10,
      timeUnit: '1s',
      gracefulStop: '60s',
      startTime: '180s'
    },
    trustsV4: {
      exec: 'v4t',
      executor: 'constant-arrival-rate',
      duration: '10s',
      preAllocatedVUs: 100,
      rate: 10,
      timeUnit: '1s',
      gracefulStop: '60s',
      startTime: '210s'
    },
    diocese: {
      exec: 'dio',
      executor: 'constant-arrival-rate',
      duration: '10s',
      preAllocatedVUs: 100,
      rate: 10,
      timeUnit: '1s',
      gracefulStop: '60s',
      startTime: '240s'
    },
    localAuthorities: {
      exec: 'la',
      executor: 'constant-arrival-rate',
      duration: '10s',
      preAllocatedVUs: 100,
      rate: 10,
      timeUnit: '1s',
      gracefulStop: '60s',
      startTime: '270s'
    },
    significantChanges: {
      exec: 'sc',
      executor: 'constant-arrival-rate',
      duration: '10s',
      preAllocatedVUs: 100,
      rate: 10,
      timeUnit: '1s',
      gracefulStop: '60s',
      startTime: '300s'
    },
    establishmentsV5: {
      exec: 'v5est',
      executor: 'constant-arrival-rate',
      duration: '10s',
      preAllocatedVUs: 100,
      rate: 10,
      timeUnit: '1s',
      gracefulStop: '60s',
      startTime: '330s'
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
