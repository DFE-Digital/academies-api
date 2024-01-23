import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
    vus: 400,
    duration: '30s',
    // httpDebug: 'full',
};

const baseUrl = "https://localhost:5001/v4";

export default function () {

    searchTrustByName("Name91b71279-6799-4f2c-843d-8e6b35ae7ffa");

    getTrustByUkPrn("UKPRN692c06a7-089a-46be-ae3b-e4d6fee8126e");

    searchTrustByUkPrn("UKPRN692c06a7-089a-46be-ae3b-e4d6fee8126e");

    getTrustByCompaniesHouseNumber("CompaniesHouseNumbercfa7f419-f27e-4f6c-9266-9a9c560ae6a3");

    getTrustByReferenceNumber("GroupID97be1318-42e1-4527-a75e-595ba4768153");

    sleep(1);
}

function searchTrustByName(name) {
    const res = http.get(`${baseUrl}/trusts?groupName=${name}&page=1&count=10`, {
        headers: getHeaders()
    });

    isStatus200(res);
}

function searchTrustByUkPrn(ukprn) {
    const res = http.get(`${baseUrl}/trusts?ukPrn=${ukprn}&page=1&count=10`, {
        headers: getHeaders()
    });

    isStatus200(res);
}

function getTrustByUkPrn(ukprn) {
    const res = http.get(`${baseUrl}/trust/${ukprn}`, {
        headers: getHeaders()
    });

    isStatus200(res);
}

function getTrustByCompaniesHouseNumber(companiesHouseNumber) {
    const res = http.get(`${baseUrl}/trust/companiesHouseNumber/${companiesHouseNumber}`, {
        headers: getHeaders()
    });

    isStatus200(res);

}

function getTrustByReferenceNumber(trustReferenceNumber) {
    const res = http.get(`${baseUrl}/trust/trustReferenceNumber/${trustReferenceNumber}`, {
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