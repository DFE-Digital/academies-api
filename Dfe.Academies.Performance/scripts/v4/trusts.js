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

    getTrustByUkPrn('10067112')

    getTrustByCompaniesHouseNumber('11082297')

    getTrustByReferenceNumber('TR03739')

    searchTrustByUkPrn('10067112')

    searchTrustByName('SOUTH YORK MULTI ACADEMY TRUST')

    sleep(1)
}

function getTrustByUkPrn(ukprn) {
    const res = http.get(`${baseUrl}/trust/${ukprn}`, {
        headers: getHeaders()
    })

    isStatus200(res)
}

function getTrustByCompaniesHouseNumber(companiesHouseNumber) {
    const res = http.get(`${baseUrl}/trust/companiesHouseNumber/${companiesHouseNumber}`, {
        headers: getHeaders()
    })

    isStatus200(res)

}

function getTrustByReferenceNumber(trustReferenceNumber) {
    const res = http.get(`${baseUrl}/trust/trustReferenceNumber/${trustReferenceNumber}`, {
        headers: getHeaders()
    })

    isStatus200(res)
}

function searchTrustByName(name) {
    const res = http.get(`${baseUrl}/trusts?groupName=${name}&page=1&count=10`, {
        headers: getHeaders()
    })

    isStatus200(res)
}

function searchTrustByUkPrn(ukprn) {
    const res = http.get(`${baseUrl}/trusts?ukPrn=${ukprn}&page=1&count=10`, {
        headers: getHeaders()
    })

    isStatus200(res)
}
