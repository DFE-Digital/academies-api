import http from 'k6/http'
import { check, sleep } from 'k6'

export const options = {
    vus: 20,
    duration: '30s'
}

const baseUrl = __ENV.BASE_URL

export default function () {

  getEducationPerformanceByUrn('100000')
  
  sleep(1)
}

function getEducationPerformanceByUrn(urn) {
  const res = http.get(`${baseUrl}/educationPerformance/${urn}`, {
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