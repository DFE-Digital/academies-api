import http from 'k6/http'
import { check, sleep } from 'k6'

export const options = {
    vus: 20,
    duration: '30s'
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