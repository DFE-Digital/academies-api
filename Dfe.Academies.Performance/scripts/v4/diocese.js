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

const baseUrl = `${__ENV.BASE_URL}/v4`;

export default function diocese() {
  searchDioceseByName("Diocese of London");

  searchDioceseByCode("CE23");

  getDioceseByCode("CE23");

  sleep(1);
}

function searchDioceseByName(name) {
  const res = http.get(`${baseUrl}/diocese?name=${encodeURIComponent(name)}`, {
    headers: getHeaders(),
  });

  isStatus200(res);
  recordDuration("v4_diocese_search_by_name", res);
}

function searchDioceseByCode(code) {
  const res = http.get(`${baseUrl}/diocese?code=${code}`, {
    headers: getHeaders(),
  });

  isStatus200(res);
  recordDuration("v4_diocese_search_by_code", res);
}

function getDioceseByCode(code) {
  const res = http.get(`${baseUrl}/diocese/${code}`, {
    headers: getHeaders(),
  });

  isStatus200(res);
  recordDuration("v4_diocese_by_code", res);
}
