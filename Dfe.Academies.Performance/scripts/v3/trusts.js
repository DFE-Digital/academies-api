import http from 'k6/http'
import { check, sleep } from 'k6'

export const options = {
    vus: 20,
    duration: '30s'
}

const baseUrl = 'https://localhost:5001/v3'

export default function () {

  getTrustByUkPrn('10067112')

  searchTrustByName('SOUTH YORK MULTI ACADEMY TRUST')

  searchTrustByUkPrn('10067112')

  sleep(1)
}

function getTrustByUkPrn(ukprn) {
  const res = http.get(`${baseUrl}/trust/${ukprn}`, {
      headers: getHeaders()
  })

  isStatus200(res)
}

function searchTrustByName(name) {
  const res = http.get(`${baseUrl}/trusts?groupName=${name}&page=1&count=10`, {
      headers: getHeaders()
  })

  isStatus200(res);
}

function searchTrustByUkPrn(ukprn) {
  const res = http.get(`${baseUrl}/trusts?ukPrn=${ukprn}&page=1&count=10`, {
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