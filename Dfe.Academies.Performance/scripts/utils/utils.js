import { check } from 'k6'

export function isStatus200(res) {
  check(res, {
      'status is 200': (r) => r.status === 200,
  })
}

export function getHeaders() {
  return {
      'ApiKey': `${__ENV.API_KEY}`,
      'Content-Type': 'application/json'
  }
}
