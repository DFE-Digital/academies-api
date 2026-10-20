import http from 'k6/http'
import { sleep } from 'k6'
import { isStatus200, getHeaders } from '../utils/utils.js'
import { recordDuration } from '../utils/metrics.js'

export const options = {
  thresholds: {
    http_req_failed: ['rate<0.01'],   // Failure rate less than 1%
    http_req_duration: ['p(95)<1000'] // Requests take <1s at the 95th percentile
  },
  // Baseline capture only: run sequentially on a single VU (no concurrency)
  // so we don't overload the shared dev environment. See README for details.
  // Fewer iterations and a longer maxDuration than the other scripts because
  // the unfiltered /establishments search below is known to be very slow
  // (N+1 lookups per establishment with no pagination) - see README.
  scenarios: {
    baseline_sample: {
      executor: 'shared-iterations',
      vus: 1,
      iterations: 3,
      maxDuration: '10m'
    }
  }
}

const baseUrl = `${__ENV.BASE_URL}/v5`

export default function () {

  searchEstablishments()

  searchEstablishmentByName('The Aldgate School')

  searchEstablishmentByUkPrn('10079319')

  searchEstablishmentByUrn('100000')

  bulkSearchEstablishmentsByUrns(['100000', '100002'])

  sleep(1)
}

function searchEstablishments() {
  // No filters are supplied here on purpose (it's the "full search" case),
  // but this endpoint currently does a DB lookup per establishment with no
  // pagination, so it can take tens of seconds against a real dataset.
  // Use an explicit, longer timeout so we capture its true response time
  // instead of it being cut off by k6's 60s default request timeout.
  const res = http.get(`${baseUrl}/establishments`, {
    headers: getHeaders(),
    timeout: '120s'
  })

  isStatus200(res)
  recordDuration('v5_establishments_search', res)
}

function searchEstablishmentByName(name) {
  const res = http.get(`${baseUrl}/establishments?name=${encodeURIComponent(name)}`, {
    headers: getHeaders()
  })

  isStatus200(res)
  recordDuration('v5_establishments_search_by_name', res)
}

function searchEstablishmentByUkPrn(ukprn) {
  const res = http.get(`${baseUrl}/establishments?ukPrn=${ukprn}`, {
    headers: getHeaders()
  })

  isStatus200(res)
  recordDuration('v5_establishments_search_by_ukprn', res)
}

function searchEstablishmentByUrn(urn) {
  const res = http.get(`${baseUrl}/establishments?urn=${urn}`, {
    headers: getHeaders()
  })

  isStatus200(res)
  recordDuration('v5_establishments_search_by_urn', res)
}

function bulkSearchEstablishmentsByUrns(urns) {
  const res = http.post(`${baseUrl}/establishments/bulk/urns`, JSON.stringify({ urns }), {
    headers: getHeaders()
  })

  isStatus200(res)
  recordDuration('v5_establishments_bulk_by_urns', res)
}
