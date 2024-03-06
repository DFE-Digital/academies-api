import http from 'k6/http'
import { sleep } from 'k6'
import { isStatus200, getHeaders } from '../utils/utils.js'

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
      timeUnit: '1s'
    }
  }
}

const baseUrl = `${__ENV.BASE_URL}/v2`

export default function () {

  getBaselineTrackers()

  sleep(1)
}

function getBaselineTrackers() {
  // TODO change url endpoint when spelling mistake resolved
  const res = http.get(`${baseUrl}/basline-tracker?page=1&count=50`, {
    headers: getHeaders()
  })

  isStatus200(res)
}
