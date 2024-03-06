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
        timeUnit: '1s',
        gracefulStop: '60s'
      }
    }
  }

const baseUrl = `${__ENV.BASE_URL}/v4`

export default function () {

    getEstablishmentByUkPrn('10079319')

    getEstablishmentByUrn('100000')

    getEstablishmentsForTrust('10067112')

    sleep(1)
}

function getEstablishmentByUkPrn(ukprn) {
    const res = http.get(`${baseUrl}/establishment/${ukprn}`, {
        headers: getHeaders()
    })

    isStatus200(res)
}

function getEstablishmentByUrn(urn) {
    const res = http.get(`${baseUrl}/establishment/urn/${urn}`, {
        headers: getHeaders()
    })

    isStatus200(res)
}

function getEstablishmentsForTrust(ukprn) {
    const res = http.get(`${baseUrl}/establishments/trust?trustUkPrn=${ukprn}`, {
        headers: getHeaders()
    })

    isStatus200(res)
}
