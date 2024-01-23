import http from 'k6/http'
import { check, sleep } from 'k6'

export const options = {
    vus: 20,
    duration: '30s'
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

function isStatus200(res) {
  check(res, {
      'status is 200': (r) => r.status === 200,
  })
}

function getHeaders() {
  return {
      'ApiKey': 'app-key',
      'Content-Type': 'application/json'
  }
}