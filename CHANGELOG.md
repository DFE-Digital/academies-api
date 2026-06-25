# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/).

### Statuses
- `Added` for new features.  
- `Changed` for changes in existing functionality.  
- `Fixed` for any bug fixes.  
- `Removed` for now removed features.  
- `Deprecated` for soon-to-be removed features.  
- `Security` in case of vulnerabilities.  

---

## Unreleased
See the [full commit history](https://github.com/DFE-Digital/academies-api/compare/production-2026-06-19.540...main) for everything awaiting release

---

## [production-2026-06-19.540](https://github.com/DFE-Digital/academies-api/releases/tag/production-2026-06-19.540) - 2026-06-19

### Added
- Establishment by name endpoint added to v4 controller
- GOR region added to Trust and related mappings

### Changed
- Refactored Swagger API key auth integration
- [287527](https://dfe-gov-uk.visualstudio.com/Academies-and-Free-Schools-SIP/_workitems/edit/287527) - Output Cypress test results to Teams channel using adaptive cards
- Updated validate-packages action to latest version
- Publish NuGet packages to NuGet.org instead of GitHub Packages

---

## [production-2026-06-12.525](https://github.com/DFE-Digital/academies-api/releases/tag/production-2026-06-12.525) - 2026-06-12

### Added
- Diocese search endpoints (`GET /v4/diocese` and `GET /v4/diocese/{code}`)
- MSSQL support

### Changed
- Bump container app hosting module to v2.6.5
- Bump terraform-azurerm-container-apps-hosting module to v2.8.1
- Downgrade FluentAssertions to 7.0.0

---

## [production-2026-04-27.517](https://github.com/DFE-Digital/academies-api/releases/tag/production-2026-04-27.517) - 2026-04-27

### Changed
- [253486](https://dfe-gov-uk.visualstudio.com/Academies-and-Free-Schools-SIP/_workitems/edit/253486) - Search significant change records by AD names

---

## [production-2026-04-21.513](https://github.com/DFE-Digital/academies-api/releases/tag/production-2026-04-21.513) - 2026-04-21

### Added
- [253486](https://dfe-gov-uk.visualstudio.com/Academies-and-Free-Schools-SIP/_workitems/edit/253486) - Search significant changes by RSC contact

### Removed
- Remove tfsec

---

## [production-2026-03-04.509](https://github.com/DFE-Digital/academies-api/releases/tag/production-2026-03-04.509) - 2026-03-04

### Added
- [268858](https://dfe-gov-uk.visualstudio.com/Academies-and-Free-Schools-SIP/_workitems/edit/268858) - Additional Ofsted publication date fields

---

## [production-2026-02-16.505](https://github.com/DFE-Digital/academies-api/releases/tag/production-2026-02-16.505) - 2026-02-16

### Added
- V5 search establishment by URNs endpoint

---

## [production-2026-01-23.501](https://github.com/DFE-Digital/academies-api/releases/tag/production-2026-01-23.501) - 2026-01-23

### Changed
- Get Ofsted data from real data table

---

## [production-2025-12-15.498](https://github.com/DFE-Digital/academies-api/releases/tag/production-2025-12-15.498) - 2025-12-15

### Added
- Local authority search
- Endpoint to retrieve local authority by code

### Changed
- Reverted API contract changes

---

## [production-2025-11-24.490](https://github.com/DFE-Digital/academies-api/releases/tag/production-2025-11-24.490) - 2025-11-24

### Added
- [242722](https://dfe-gov-uk.visualstudio.com/Academies-and-Free-Schools-SIP/_workitems/edit/242722) - Significant change v4 endpoint
- V5 search establishment with mock report card
- `MainPhone` added to establishment DTO

### Changed
- Updated v4 establishments endpoint to allow searching across establishment fields
- Package validator policy update

---

## [production-2025-07-22.450](https://github.com/DFE-Digital/academies-api/releases/tag/production-2025-07-22.450) - 2025-07-22

### Added
- Get trusts by establishment URNs

---

## [production-2025-06-13.446](https://github.com/DFE-Digital/academies-api/releases/tag/production-2025-06-13.446) - 2025-06-13

### Fixed
- [215979](https://dfe-gov-uk.visualstudio.com/Academies-and-Free-Schools-SIP/_workitems/edit/215979) - Excel exports fail when too many UKPRNs are queried

### Changed
- Pin dependencies
- Update deploy-azure-container-apps-action to v5

---

## [production-2025-05-12.437](https://github.com/DFE-Digital/academies-api/releases/tag/production-2025-05-12.437) - 2025-05-12

### Changed
- Wait for Sonar quality gate response before finishing the workflow
- Replaced `SingleOrDefault` with `FirstOrDefault`
- Dependency and Terraform module updates

---

## [production-2025-03-26.429](https://github.com/DFE-Digital/academies-api/releases/tag/production-2025-03-26.429) - 2025-03-26

### Added
- Previous establishment with URN info added to response

### Changed
- Added Sonar linting instructions to README
- Remove path filters and update pinned versions
- Dependency updates

---

## [production-2025-03-13.418](https://github.com/DFE-Digital/academies-api/releases/tag/production-2025-03-13.418) - 2025-03-13

### Changed
- Pull Ofsted data from `mis_mstr.establishments`
- Reduced build layers and aligned to SonarQube quality rules
- Workflow and dependency updates

---

## [production-2025-02-14.405](https://github.com/DFE-Digital/academies-api/releases/tag/production-2025-02-14.405) - 2025-02-14

### Added
- `excludeClosed` parameter to v4 establishments search
- Package validation gate to workflows

### Changed
- Split workflow into concurrent build and import stages

---

## [production-2025-01-30.395](https://github.com/DFE-Digital/academies-api/releases/tag/production-2025-01-30.395) - 2025-01-30

### Changed
- API client nullable response property

---

## [production-2025-01-30.392](https://github.com/DFE-Digital/academies-api/releases/tag/production-2025-01-30.392) - 2025-01-30

### Added
- Academies API client NuGet package
- NSwag multi-version support

### Changed
- Renovate config update
- NuGet package deployment fix
- Deploy workflow sequencing

### Removed
- Persons API logic
- Azure Front Door CDN

---

## [production-2025-01-15.378](https://github.com/DFE-Digital/academies-api/releases/tag/production-2025-01-15.378) - 2025-01-15

### Fixed
- "Data is null" exception when `NumberOfShortInspectionsSinceLast` is null

---

## [production-2025-01-14.375](https://github.com/DFE-Digital/academies-api/releases/tag/production-2025-01-14.375) - 2025-01-14

### Changed
- Migrated Establishment and Further Education Establishment data from `mis` schema to `mis_mstr` schema

### Removed
- NSwag builder

---

## [production-2025-01-08.370](https://github.com/DFE-Digital/academies-api/releases/tag/production-2025-01-08.370) - 2025-01-08

### Added
- EF Migration Bundle for Academies API
- Entrypoint file to consolidate migration scripts into one

### Changed
- Switch to using Cypress docker image for running tests
- Dependency and Terraform updates

---

## [production-2024-12-11.360](https://github.com/DFE-Digital/academies-api/releases/tag/production-2024-12-11.360) - 2024-12-11

### Added
- DbContext checks to health checks

### Changed
- Use Azure Linux base image
- Set container port to 8080
- Corrected MIT licence
- Stabilised version constraints
- Restrict scope of update task to security packages only
- Dependency updates

---

## [production-2024-11-19.336](https://github.com/DFE-Digital/academies-api/releases/tag/production-2024-11-19.336) - 2024-11-19

### Fixed
- Null exception when `OverallEffectiveness` is null

---

## [production-2024-11-19.333](https://github.com/DFE-Digital/academies-api/releases/tag/production-2024-11-19.333) - 2024-11-19

### Changed
- [188025](https://dfe-gov-uk.visualstudio.com/Academies-and-Free-Schools-SIP/_workitems/edit/188025) - Update column type

---

## [production-2024-11-19.332](https://github.com/DFE-Digital/academies-api/releases/tag/production-2024-11-19.332) - 2024-11-19

### Changed
- Bump deploy-azure-container-apps-action to v3.0.0
- Update Container App module to v1.15.0
- Updated `OverallEffectiveness` property type in `MisEstablishment` table
- Removed `UngradedInspectionOverallOutcome` property
- [188025](https://dfe-gov-uk.visualstudio.com/Academies-and-Free-Schools-SIP/_workitems/edit/188025) - Update column type

---

## [production-2024-10-18.322](https://github.com/DFE-Digital/academies-api/releases/tag/production-2024-10-18.322) - 2024-10-18

### Added
- Deploy Health Insights API

### Changed
- Updated testing logic and packages
- Workflow and infrastructure updates

---

## [production-2024-10-14.314](https://github.com/DFE-Digital/academies-api/releases/tag/production-2024-10-14.314) - 2024-10-14

### Added
- Get MP by school URN endpoint

---

## [production-2024-10-10.311](https://github.com/DFE-Digital/academies-api/releases/tag/production-2024-10-10.311) - 2024-10-10

### Changed
- Updated to use new NuGet packages

---

## [production-2024-10-01.308](https://github.com/DFE-Digital/academies-api/releases/tag/production-2024-10-01.308) - 2024-10-01

### Removed
- API key fallback

---

## [production-2024-09-30.305](https://github.com/DFE-Digital/academies-api/releases/tag/production-2024-09-30.305) - 2024-09-30

### Added
- Get associated persons with trust endpoint

### Changed
- Terraform azurerm upgrade to v4
- Dependency and infrastructure updates

---

## [production-2024-09-18.297](https://github.com/DFE-Digital/academies-api/releases/tag/production-2024-09-18.297) - 2024-09-18

### Added
- [173197](https://dfe-gov-uk.visualstudio.com/Academies-and-Free-Schools-SIP/_workitems/edit/173197) - Persons API new endpoints

### Changed
- Enforcing generic repository to return aggregate root
- Allow operators to override the default minimum number of app containers
- Dependency updates

---

## [production-2024-09-04.275](https://github.com/DFE-Digital/academies-api/releases/tag/production-2024-09-04.275) - 2024-09-04

### Added
- Persons API
- Persons API client NuGet package
- Integration tests for Persons API
- Docker image CVE scanning

### Changed
- DevOps for new Persons API
- General refactoring
- Dependency and infrastructure updates

---

## [production-2024-08-01.237](https://github.com/DFE-Digital/academies-api/releases/tag/production-2024-08-01.237) - 2024-08-01

### Added
- Nonces to Swagger HTML so it loads with CSP changes

### Changed
- Upgrade to .NET 8
- Renovate configuration
- Forward all proxied headers
- Annotate releases in Application Insights for all environments
- Ignore API key when accessing healthcheck endpoint
- Adds back config for v2–v4 endpoints to Swagger
- Dependency and infrastructure updates

### Fixed
- String interpolation on logging for v4 establishments endpoints

### Security
- Set minimum security headers for all requests
- Use HSTS for all responses

---

## [production-2024-05-22.166](https://github.com/DFE-Digital/academies-api/releases/tag/production-2024-05-22.166) - 2024-05-22

### Fixed
- Ensure 404 is thrown on bulk endpoint

### Changed
- Add exclusion paths for build and test
- Fix PR checks not running

---

## [production-2024-05-08.162](https://github.com/DFE-Digital/academies-api/releases/tag/production-2024-05-08.162) - 2024-05-08

### Added
- [165019](https://dfe-gov-uk.visualstudio.com/Academies-and-Free-Schools-SIP/_workitems/edit/165019) - Get bulk establishments by UKPRN (v4)

---

## [production-2024-04-30.157](https://github.com/DFE-Digital/academies-api/releases/tag/production-2024-04-30.157) - 2024-04-30

### Changed
- Shared deployment workflow
- Deploy MX records for production environment
- Disable CDN health probes
- Set max request count before applying rate limit
- Override default Container Registry hostname
- Dependency and infrastructure updates

---

## [production-2024-03-19.138](https://github.com/DFE-Digital/academies-api/releases/tag/production-2024-03-19.138) - 2024-03-19

### Added
- [155067](https://dfe-gov-uk.visualstudio.com/Academies-and-Free-Schools-SIP/_workitems/edit/155067) - Integrate get construct projects
- Extend `searchString` on v3 search by companies house to reduce clash chance

### Changed
- Update StatusCake alarms to 40, 20, 5
- Update workflows to use actions on Node 20
- Update performance tests for constant benchmark load
- Infrastructure and dependency updates

---

## [production-2024-01-30.123](https://github.com/DFE-Digital/academies-api/releases/tag/production-2024-01-30.123) - 2024-01-30

### Added
- [152055](https://dfe-gov-uk.visualstudio.com/Academies-and-Free-Schools-SIP/_workitems/edit/152055) - Support for calling external MFSP API to get projects
- Attendance data
- [152436](https://dfe-gov-uk.visualstudio.com/Academies-and-Free-Schools-SIP/_workitems/edit/152436) - Allow trusts that do not have a status of Open to be searched for
- Legacy Cypress tests for v1, v2 and v3 endpoints
- Performance tests for supported endpoints
- API tests for the v4 trust endpoint

### Changed
- [152950](https://dfe-gov-uk.visualstudio.com/Academies-and-Free-Schools-SIP/_workitems/edit/152950) - Fixed the educational performance tests
- v4 Cypress test to check for values regardless of order
- Infrastructure updates

---

## [production-2024-01-23.118](https://github.com/DFE-Digital/academies-api/releases/tag/production-2024-01-23.118) - 2024-01-23

### Fixed
- [153650](https://dfe-gov-uk.visualstudio.com/Academies-and-Free-Schools-SIP/_workitems/edit/153650) - Trusts missing establishments

---

## [production-2023-11-30.100](https://github.com/DFE-Digital/academies-api/releases/tag/production-2023-11-30.100) - 2023-11-30

### Added
- [138587](https://dfe-gov-uk.visualstudio.com/Academies-and-Free-Schools-SIP/_workitems/edit/138587) - Get establishment information from last trust record via GIAS
- v4 trust endpoints (search, by reference number, and related)
- v1 establishment by UKPRN and URN endpoints
- Serilog API user enricher
- Cypress tests for v4 endpoints
- StatusCake SSL checks for public endpoints
- Swagger documentation for v1 and v2 endpoints

### Changed
- Trust queries use no tracking
- Headteacher fields mapped and date string handling updated
- Fix for trust search when no search criteria are sent
- `PhaseOfEducationCode` corrected from string to int
- Infrastructure updates

### Removed
- A2B
- Transfers

---

## [production-2023-07-17.34](https://github.com/DFE-Digital/academies-api/releases/tag/production-2023-07-17.34) - 2023-07-17

### Fixed
- Academy transfer project duplicate URN fix

---

## [production-2023-07-11.30](https://github.com/DFE-Digital/academies-api/releases/tag/production-2023-07-11.30) - 2023-07-11

### Fixed
- Null reference in filter by incoming trust

---

## [production-2023-06-21.20](https://github.com/DFE-Digital/academies-api/releases/tag/production-2023-06-21.20) - 2023-06-21

### Changed
- .NET 6 upgrade

---

## [production-2023-04-21.5](https://github.com/DFE-Digital/academies-api/releases/tag/production-2023-04-21.5) - 2023-04-21

### Fixed
- Logic for returning trusts and associated address information

---

## [production-2023-04-03.2](https://github.com/DFE-Digital/academies-api/releases/tag/production-2023-04-03.2) - 2023-04-03

### Changed
- Switch to new deployment method
- Trust search performance improvements (batching SQL commands)
- OWASP ZAP CI tests
- Infrastructure and Terraform updates

### Removed
- Conversion project controllers and backing code
- Cypress tests for conversion projects
- Azure DevOps Pipeline connection

---
