import http from 'k6/http'
import { check, sleep } from 'k6'

export const options = {
    vus: 20,
    duration: '30s',
    // httpDebug: 'full',
}

const baseUrl = 'https://localhost:5001/v4'

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