import { htmlReport } from 'https://raw.githubusercontent.com/benc-uk/k6-reporter/main/dist/bundle.js'
import { textSummary } from 'https://jslib.k6.io/k6-summary/0.0.1/index.js'
import { default as keyStagePerformance } from './v1/keyStagePerformance.js'
import { default as baselineTracker } from './v2/baselineTracker.js'
import { default as fssProjects } from './v2/fssProjects.js'
import { default as trustsV3 } from './v3/trusts.js'
import { default as establishments } from './v4/establishments.js'
import { default as trustsV4 } from './v4/trusts.js'

export const options = {
  thresholds: {
    http_req_failed: ['rate<0.01'],   // Failure rate less than 1%
    http_req_duration: ['p(95)<1000'] // Requests take <1s at the 95th percentile
  },
  scenarios: {
    keyStagePerformance: {
      exec: 'ksp',
      executor: 'constant-arrival-rate',
      duration: '10s',
      preAllocatedVUs: 100,
      rate: 10,
      timeUnit: '1s',
      gracefulStop: '60s'
    },
    baselineTracker: {
      exec: 'bt',
      executor: 'constant-arrival-rate',
      duration: '10s',
      preAllocatedVUs: 100,
      rate: 10,
      timeUnit: '1s',
      gracefulStop: '60s',
      startTime: '30s'
    },
    fssProjects: {
      exec: 'fss',
      executor: 'constant-arrival-rate',
      duration: '10s',
      preAllocatedVUs: 100,
      rate: 10,
      timeUnit: '1s',
      gracefulStop: '60s',
      startTime: '60s'
    },
    trustsV3: {
      exec: 'v3t',
      executor: 'constant-arrival-rate',
      duration: '10s',
      preAllocatedVUs: 100,
      rate: 10,
      timeUnit: '1s',
      gracefulStop: '60s',
      startTime: '90s'
    },
    establishments: {
      exec: 'est',
      executor: 'constant-arrival-rate',
      duration: '10s',
      preAllocatedVUs: 100,
      rate: 10,
      timeUnit: '1s',
      gracefulStop: '60s',
      startTime: '120s'
    },
    trustsV4: {
      exec: 'v4t',
      executor: 'constant-arrival-rate',
      duration: '10s',
      preAllocatedVUs: 100,
      rate: 10,
      timeUnit: '1s',
      gracefulStop: '60s',
      startTime: '150s'
    },
  }
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

export function handleSummary(data) {
  return {
    'summary.html': htmlReport(data),
    stdout: textSummary(data, { indent: ' ', enableColors: true }),
  }
}
