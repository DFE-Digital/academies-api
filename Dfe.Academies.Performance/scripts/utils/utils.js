import { check } from "k6";

export function isStatus200(res) {
  const passed = check(res, {
    "status is 200": (r) => r.status === 200,
  });

  // Surface failing requests individually
  if (!passed) {
    console.error(
      `FAILED REQUEST: ${res.request.method} ${res.url} -> status=${res.status}` +
        `${res.error ? ` error="${res.error}"` : ""} duration=${res.timings.duration.toFixed(0)}ms`,
    );
  }
}

export function getHeaders() {
  return {
    ApiKey: `${__ENV.API_KEY}`,
    "Content-Type": "application/json",
  };
}
