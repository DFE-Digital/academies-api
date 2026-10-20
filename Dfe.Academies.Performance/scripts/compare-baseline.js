#!/usr/bin/env node
'use strict'

// Compares two baseline JSON files produced by Dfe.Academies.Performance's
// k6 suite (see utils/baseline.js) and reports, per endpoint, how the p95
// response time has changed. Intended usage:
//
//   node compare-baseline.js results/baseline-t1-<ts>.json results/baseline-rgat-<ts>.json
//
// Exits non-zero if any endpoint's p95 regressed beyond the threshold
// (default 20%), so it can be wired into CI later if desired.

const fs = require('fs')
const path = require('path')

function parseArgs(argv) {
  const args = argv.slice(2)
  const positionals = []
  let thresholdPercent = 20

  for (const arg of args) {
    if (arg.startsWith('--threshold=')) {
      const value = Number(arg.split('=')[1])
      if (!Number.isFinite(value) || value < 0) {
        throw new Error(`Invalid --threshold value: "${arg}". Expected a non-negative number, e.g. --threshold=20`)
      }
      thresholdPercent = value
    } else if (arg === '--help' || arg === '-h') {
      positionals.push(arg)
    } else {
      positionals.push(arg)
    }
  }

  if (positionals.includes('--help') || positionals.includes('-h') || positionals.length !== 2) {
    throw new Error(
      'Usage: node compare-baseline.js <baseline.json> <candidate.json> [--threshold=20]\n\n' +
        '  <baseline.json>   earlier run to compare against, e.g. a t1 baseline\n' +
        '  <candidate.json>  later run being checked, e.g. an rgat baseline\n' +
        '  --threshold=N     percentage p95 increase that counts as a regression (default 20)',
    )
  }

  const [baselinePath, candidatePath] = positionals
  return { baselinePath, candidatePath, thresholdPercent }
}

function loadBaseline(filePath) {
  const resolved = path.resolve(filePath)
  const raw = fs.readFileSync(resolved, 'utf8')
  return JSON.parse(raw)
}

function formatMs(value) {
  return typeof value === 'number' ? `${value.toFixed(1)}ms` : 'n/a'
}

function percentChange(baselineValue, candidateValue) {
  if (typeof baselineValue !== 'number' || typeof candidateValue !== 'number' || baselineValue === 0) {
    return null
  }
  return ((candidateValue - baselineValue) / baselineValue) * 100
}

function compareEndpoints(baseline, candidate, thresholdPercent) {
  const endpointNames = Array.from(
    new Set([...Object.keys(baseline.endpoints || {}), ...Object.keys(candidate.endpoints || {})]),
  ).sort()

  const rows = []
  let regressionCount = 0

  for (const name of endpointNames) {
    const b = baseline.endpoints && baseline.endpoints[name]
    const c = candidate.endpoints && candidate.endpoints[name]

    const change = percentChange(b && b.p95Ms, c && c.p95Ms)

    let flag
    if (!b || !c) {
      flag = 'MISSING'
    } else if (change !== null && change > thresholdPercent) {
      flag = 'REGRESSION'
      regressionCount += 1
    } else if (change !== null && change < -thresholdPercent) {
      flag = 'IMPROVED'
    } else {
      flag = 'OK'
    }

    rows.push({
      endpoint: name,
      'baseline avg': b ? formatMs(b.avgMs) : 'n/a',
      'candidate avg': c ? formatMs(c.avgMs) : 'n/a',
      'baseline p95': b ? formatMs(b.p95Ms) : 'n/a',
      'candidate p95': c ? formatMs(c.p95Ms) : 'n/a',
      'p95 change': change === null ? 'n/a' : `${change >= 0 ? '+' : ''}${change.toFixed(1)}%`,
      flag,
    })
  }

  return { rows, regressionCount }
}

function main() {
  const { baselinePath, candidatePath, thresholdPercent } = parseArgs(process.argv)
  const baseline = loadBaseline(baselinePath)
  const candidate = loadBaseline(candidatePath)

  console.log(`Baseline:  ${baseline.environment} (${baseline.baseUrlHost || 'unknown host'}) captured ${baseline.generatedAt}`)
  console.log(`Candidate: ${candidate.environment} (${candidate.baseUrlHost || 'unknown host'}) captured ${candidate.generatedAt}`)
  console.log(`Regression threshold: p95 increase > ${thresholdPercent}%`)
  console.log('')

  const { rows, regressionCount } = compareEndpoints(baseline, candidate, thresholdPercent)

  console.table(rows)

  if (regressionCount > 0) {
    console.error(`\n${regressionCount} endpoint(s) regressed beyond the ${thresholdPercent}% p95 threshold.`)
    process.exitCode = 1
  } else {
    console.log('\nNo p95 regressions detected.')
  }
}

try {
  main()
} catch (error) {
  console.error(error.message)
  process.exitCode = 2
}
