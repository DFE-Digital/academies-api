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
  scenarios: {
    baseline_sample: {
      executor: 'shared-iterations',
      vus: 1,
      iterations: 5,
      maxDuration: '3m'
    }
  }
}

const baseUrl = __ENV.BASE_URL

export default function () {

  getEstablishmentByUkPrn('10079319')

  getEstablishmentByUrn('100000')

  getEstablishmentUrnsByRegion('North West')

  searchEstablishmentByName('The Aldgate School')

  bulkGetEstablishmentsByUrn(100000)

  sleep(1)
}

function getEstablishmentByUkPrn(ukprn) {
  const res = http.get(`${baseUrl}/establishment/${ukprn}`, {
    headers: getHeaders()
  })

  isStatus200(res)
  recordDuration('v1_establishment_by_ukprn', res)
}

function getEstablishmentByUrn(urn) {
  const res = http.get(`${baseUrl}/establishment/urn/${urn}`, {
    headers: getHeaders()
  })

  isStatus200(res)
  recordDuration('v1_establishment_by_urn', res)
}

function getEstablishmentUrnsByRegion(region) {
  const res = http.get(`${baseUrl}/establishment/regions?regions=${encodeURIComponent(region)}`, {
    headers: getHeaders()
  })

  isStatus200(res)
  recordDuration('v1_establishment_urns_by_region', res)
}

function searchEstablishmentByName(name) {
  const res = http.get(`${baseUrl}/establishments?name=${encodeURIComponent(name)}`, {
    headers: getHeaders()
  })

  isStatus200(res)
  recordDuration('v1_establishments_search', res)
}

function bulkGetEstablishmentsByUrn(urn) {
  const res = http.get(`${baseUrl}/establishments/bulk?urn=${urn}`, {
    headers: getHeaders()
  })

  isStatus200(res)
  recordDuration('v1_establishments_bulk', res)
}
