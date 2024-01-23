import http from 'k6/http'
import { check, sleep } from 'k6'

export const options = {
    vus: 20,
    duration: '30s'
}

const baseUrl = 'https://localhost:5001/v2'

export default function () {

  getFreeSchoolProjects()
  
  sleep(1)
}

function getFreeSchoolProjects() {
  const res = http.get(`${baseUrl}/fss/projects`, {
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