import http from 'k6/http'
import { sleep } from 'k6'
import { isStatus200, getHeaders } from '../utils/utils.js'
import { recordDuration } from '../utils/metrics.js'

export const options = {
  thresholds: {
    http_req_failed: ['rate<0.01'],   // Failure rate less than 1%
    http_req_duration: ['p(95)<1000'] // Requests take <1s at the 95th percentile
  },
  scenarios: {
    constant_load: {
      executor: 'constant-arrival-rate',
      duration: '10s',
      preAllocatedVUs: 100,
      rate: 10,
      timeUnit: '1s',
      gracefulStop: '60s'
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
  const res = http.get(`${baseUrl}/establishments`, {
    headers: getHeaders()
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
