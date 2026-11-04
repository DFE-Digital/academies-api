import http from "k6/http";
import { sleep } from "k6";
import { isStatus200, getHeaders } from "../utils/utils.js";
import { recordDuration } from "../utils/metrics.js";

export const options = {
  thresholds: {
    http_req_failed: ["rate<0.01"],
    http_req_duration: ["p(95)<1000"],
  },
  scenarios: {
    baseline_sample: {
      executor: "shared-iterations",
      vus: 1,
      iterations: 5,
      maxDuration: "3m",
    },
  },
};

const baseUrl = __ENV.BASE_URL;

export default function trusts() {
  getTrustByUkPrn("10067112");

  searchTrustByName("SOUTH YORK MULTI ACADEMY TRUST");

  searchTrustByUkPrn("10067112");

  searchTrustByCompaniesHouseNumber("11082297");

  sleep(1);
}

function getTrustByUkPrn(ukprn) {
  const res = http.get(`${baseUrl}/trust/${ukprn}`, {
    headers: getHeaders(),
  });

  isStatus200(res);
  recordDuration("v1_trust_by_ukprn", res);
}

function searchTrustByName(name) {
  const res = http.get(
    `${baseUrl}/trusts?groupName=${encodeURIComponent(name)}&page=1&count=5`,
    {
      headers: getHeaders(),
    },
  );

  isStatus200(res);
  recordDuration("v1_trusts_search_by_name", res);
}

function searchTrustByUkPrn(ukprn) {
  const res = http.get(`${baseUrl}/trusts?ukPrn=${ukprn}&page=1&count=50`, {
    headers: getHeaders(),
  });

  isStatus200(res);
  recordDuration("v1_trusts_search_by_ukprn", res);
}

function searchTrustByCompaniesHouseNumber(companiesHouseNumber) {
  const res = http.get(
    `${baseUrl}/trusts?companiesHouseNumber=${companiesHouseNumber}&page=1&count=50`,
    {
      headers: getHeaders(),
    },
  );

  isStatus200(res);
  recordDuration("v1_trusts_search_by_companies_house_number", res);
}
