#!/bin/bash

# exit on failures
set -e
set -o pipefail

while getopts "c" opt; do
  case $opt in
    c)
      CONNECTION_STRING=$opt
      ;;
    *)
      usage
      ;;
  esac
done

/sql/migratedb -v --connection "$CONNECTION_STRING"
/sql/migratelegacydb -v --connection "$CONNECTION_STRING"
