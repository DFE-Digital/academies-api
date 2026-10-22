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

export default function significantChanges() {

  searchSignificantChangesByDeliveryOfficer('Guest')

  sleep(1)
}

function searchSignificantChangesByDeliveryOfficer(deliveryOfficer) {
  const res = http.get(`${baseUrl}/significantchanges?deliveryOfficer=${encodeURIComponent(deliveryOfficer)}&page=1&count=10`, {
    headers: getHeaders()
  })

  isStatus200(res)
  recordDuration('v4_significant_changes_search', res)
}
