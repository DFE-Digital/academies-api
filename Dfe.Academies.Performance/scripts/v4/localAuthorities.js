import http from 'k6/http'
import { sleep } from 'k6'
import { isStatus200, getHeaders } from '../utils/utils.js'
import { recordDuration } from '../utils/metrics.js'

export const options = {
  thresholds: {
    http_req_failed: ['rate<0.01'],
    http_req_duration: ['p(95)<1000']
  },
  scenarios: {
    baseline_sample: {
      executor: 'shared-iterations',
      vus: 1,
      iterations: 5,
      maxDuration: '3m'
    }
  }
}

const baseUrl = `${__ENV.BASE_URL}/v4`

export default function localAuthorities() {

  searchLocalAuthorityByName('City of London')

  searchLocalAuthorityByCode('201')

  getLocalAuthorityByCode('201')

  sleep(1)
}

function searchLocalAuthorityByName(name) {
  const res = http.get(`${baseUrl}/local-authorities?name=${encodeURIComponent(name)}`, {
    headers: getHeaders()
  })

  isStatus200(res)
  recordDuration('v4_local_authorities_search_by_name', res)
}

function searchLocalAuthorityByCode(code) {
  const res = http.get(`${baseUrl}/local-authorities?code=${code}`, {
    headers: getHeaders()
  })

  isStatus200(res)
  recordDuration('v4_local_authorities_search_by_code', res)
}

function getLocalAuthorityByCode(code) {
  const res = http.get(`${baseUrl}/local-authorities/${code}`, {
    headers: getHeaders()
  })

  isStatus200(res)
  recordDuration('v4_local_authority_by_code', res)
}
