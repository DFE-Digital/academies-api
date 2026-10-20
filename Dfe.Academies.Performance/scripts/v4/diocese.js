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

const baseUrl = `${__ENV.BASE_URL}/v4`

export default function () {

  searchDioceseByName('Diocese of London')

  searchDioceseByCode('CE23')

  getDioceseByCode('CE23')

  sleep(1)
}

function searchDioceseByName(name) {
  const res = http.get(`${baseUrl}/diocese?name=${encodeURIComponent(name)}`, {
    headers: getHeaders()
  })

  isStatus200(res)
  recordDuration('v4_diocese_search_by_name', res)
}

function searchDioceseByCode(code) {
  const res = http.get(`${baseUrl}/diocese?code=${code}`, {
    headers: getHeaders()
  })

  isStatus200(res)
  recordDuration('v4_diocese_search_by_code', res)
}

function getDioceseByCode(code) {
  const res = http.get(`${baseUrl}/diocese/${code}`, {
    headers: getHeaders()
  })

  isStatus200(res)
  recordDuration('v4_diocese_by_code', res)
}
