# Academies API Performance tests

This directory holds the performance test scripts for the Academies API.

Tests are written for the [k6](https://k6.io) performance testing tool.

## Setup

You will need k6 installed to be able to run these tests. Details on how to do so are available in their [documentation](https://grafana.com/docs/k6/latest/get-started/installation/).

## Configuration

The variables you will need to set are defined below:

| Variable | Description | Example |
|---|---|---|
| `API_KEY` | The API key used in headers for requests | `app-key` |
| `BASE_URL` | The url of the service to be tested | `https//localhost:5001` |
| `ENVIRONMENT` | A short label for the environment under test, used to tag/name baseline output files | `t1`, `rgat` |

## Running the tests

To run an individual script, navigate to the correct directory and run

`k6 run -e API_KEY=<your-value> -e BASE_URL=<your-value> <your-script-name>`

To run the full suite (every endpoint) and capture per-endpoint timings in one go, run `suite.js` from the `scripts` directory and set `ENVIRONMENT` to label the run:

`k6 run -e API_KEY=<your-value> -e BASE_URL=<your-value> -e ENVIRONMENT=t1 suite.js`

## Results

By default, metrics are output to the console at the end of the tests, including any checks that are run as part of the test scripts.

Running `suite.js` also writes:
- `summary.html` - the existing k6-reporter HTML summary.
- `results/baseline-<ENVIRONMENT>-<timestamp>.json` - a normalised snapshot of every endpoint's response-time stats (avg/min/med/p90/p95/max/count), tagged with the `ENVIRONMENT` label and the host of `BASE_URL` (no secrets/API keys are written).

Both outputs are gitignored - treat `results/` as local, disposable evidence you keep around to compare runs.

## Load profile

These scripts exist purely to capture a response-time **baseline**, not to load/stress test the API. Every scenario therefore uses a single VU running a handful of sequential iterations (`shared-iterations`), rather than k6's `constant-arrival-rate` executor at a sustained rate - this avoids overloading the shared dev environment, and when running `suite.js`, scenarios are staggered far enough apart (minutes, not seconds) that they never overlap.

The `/v5/establishments` unfiltered search (no `name`/`ukPrn`/`urn` supplied) is a known outlier: it currently does a database lookup per establishment with no pagination, so against a real dataset it can take tens of seconds per call. `v5/establishments.js` and the equivalent `suite.js` scenario use fewer iterations, a longer `maxDuration`, and an explicit 120s request timeout (k6's default is 60s) so the true response time is captured instead of being cut off. If you see most requests for this endpoint failing with `request timeout`, that's a sign of this known slow query, not necessarily the test overloading the service - it's worth raising as a performance issue on the `/v5/establishments` endpoint itself.

## Setting and comparing a baseline (e.g. t1 vs rgat)

This suite is primarily intended to capture a timing **baseline** against the current `t1` database connection, so it can later be compared against the same suite run after the environment is pointed at `rgat`, to spot regressions caused by the database change.

1. While the dev environment is still connected to `t1`, run the suite and label it accordingly:

   `k6 run -e API_KEY=<your-value> -e BASE_URL=<your-value> -e ENVIRONMENT=t1 suite.js`

   This produces `results/baseline-t1-<timestamp>.json`. Keep this file somewhere safe (it isn't committed).

2. After the environment is switched to `rgat`, run the exact same suite again with the new label:

   `k6 run -e API_KEY=<your-value> -e BASE_URL=<your-value> -e ENVIRONMENT=rgat suite.js`

   This produces `results/baseline-rgat-<timestamp>.json`.

3. Compare the two baseline files:

   `node compare-baseline.js results/baseline-t1-<timestamp>.json results/baseline-rgat-<timestamp>.json`

   This prints a per-endpoint table of baseline vs candidate average/p95 response times and the percentage change, and flags any endpoint whose p95 increased by more than 20% as a `REGRESSION` (pass `--threshold=<percent>` to change this). The script exits with a non-zero code if any regressions are found, so it can be wired into CI later if desired.