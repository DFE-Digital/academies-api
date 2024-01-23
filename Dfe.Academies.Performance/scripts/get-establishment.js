import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
    vus: 800,
    duration: '30s',
    // httpDebug: 'full',
};

const baseUrl = "https://localhost:5001/v4";

export default function () {
    getEstablishmentsForTrust("UKPRN37cda865-dbe0-426f-9485-84c1cf3d8513");

    getEstablishmentByUkPrn("UKPRN0b2ecaa7-4ec3-4138-805b-3d7d904962a4");

    sleep(1);
}

function getEstablishmentsForTrust(ukprn) {
    const res = http.get(`${baseUrl}/establishments/trust?trustUkPrn=${ukprn}`, {
        headers: getHeaders()
    });

    isStatus200(res);
}

function getEstablishmentByUkPrn(ukprn) {
    const res = http.get(`${baseUrl}/establishment/${ukprn}`, {
        headers: getHeaders()
    });

    isStatus200(res);
}

function isStatus200(res) {
    check(res, {
        'status is 200': (r) => r.status === 200,
    });
}

function getHeaders() {
    return {
        "ApiKey": "app-key",
        "Content-Type": "application/json"
    };
}