describe('Establishment endpoints tests', () => {

  const apiKey = Cypress.env('apiKey')
  const baseUrlV4 = `${Cypress.env('url')}/v4`

  context('Search Establishments', () => {

    it('should return a list of establishments when no search parameters set', () => {

      cy.api({
        method: 'GET',
        url: `${baseUrlV4}/establishments`,
        headers: {
          ApiKey: apiKey,
          "Content-type": "application/json"
        }
      })
        .then((response) => {
          expect(response.status).to.eq(200);
          // TODO add more response checks
        })
    })

    it('should return establishments when name set', () => {

      cy.api({
        method: 'GET',
        url: `${baseUrlV4}/establishments`,
        qs: {
          name: 'The Aldgate School'
        },
        headers: {
          ApiKey: apiKey,
          "Content-type": "application/json"
        }
      })
        .then((response) => {
          expect(response.status).to.eq(200);
          // TODO add more response checks
        })
    })

    it('should return establishments when UKPRN set', () => {

      cy.api({
        method: 'GET',
        url: `${baseUrlV4}/establishments`,
        qs: {
          ukPrn: '10079319'
        },
        headers: {
          ApiKey: apiKey,
          "Content-type": "application/json"
        }
      })
        .then((response) => {
          expect(response.status).to.eq(200);
          // TODO add more response checks
        })
    })

    it('should return establishments when URN set', () => {

      cy.api({
        method: 'GET',
        url: `${baseUrlV4}/establishments`,
        qs: {
          urn: '100000'
        },
        headers: {
          ApiKey: apiKey,
          "Content-type": "application/json"
        }
      })
        .then((response) => {
          expect(response.status).to.eq(200);
          // TODO add more response checks
        })
    })
  })

  context('Get Establishment URNs by Region', () => {

    it('should return a list of URNs when a single region is provided', () => {

      cy.api({
        method: 'GET',
        url: `${baseUrlV4}/establishment/regions`,
        qs: {
          regions: 'North West'
        },
        headers: {
          ApiKey: apiKey,
          "Content-type": "application/json"
        }
      })
        .then((response) => {
          expect(response.status).to.eq(200);
          // TODO add more response checks
        })
    })

    it('should return a list of URNs when multiple regions are provided', () => {

      cy.api({
        method: 'GET',
        url: `${baseUrlV4}/establishment/regions`,
        qs: {
          regions: 'North West',
          regions: 'South West'
        },
        headers: {
          ApiKey: apiKey,
          "Content-type": "application/json"
        }
      })
        .then((response) => {
          expect(response.status).to.eq(200);
          // TODO add more response checks
        })
    })
  })

  context('Get Establishment by UKPRN', () => {

    const ukPrn = '10079319'

    it('should return establishments when UKPRN set', () => {

      cy.api({
        method: 'GET',
        url: `${baseUrlV4}/establishment/${ukPrn}`,
        headers: {
          ApiKey: apiKey,
          "Content-type": "application/json"
        }
      })
        .then((response) => {
          expect(response.status).to.eq(200);
          // TODO add more response checks
        })
    })
  })

  context('Get Establishment by URN', () => {

    const urn = '100000';

    it('should return a single establishment when a URN is provided', () => {

      cy.api({
        method: 'GET',
        url: `${baseUrlV4}/establishment/urn/${urn}`,
        headers: {
          ApiKey: apiKey,
          "Content-type": "application/json"
        }
      })
        .then((response) => {
          expect(response.status).to.eq(200);
          // TODO add more response checks
        })
    })
  })

  context('Bulk Get Establishments by URN', () => {

    const urns = [100000, 100002];

    it('should return a single establishment when a URN is provided', () => {

      cy.api({
        method: 'GET',
        url: `${baseUrlV4}/establishments/bulk`,
        qs: {
          request: urns[0],
        },
        headers: {
          ApiKey: apiKey,
          "Content-type": "application/json"
        }
      })
        .then((response) => {
          expect(response.status).to.eq(200);
          // TODO add more response checks
        })
    })

    it('should return a list of establishments when multiple URNs are provided', () => {

      cy.api({
        method: 'GET',
        url: `${baseUrlV4}/establishments/bulk`,
        qs: {
          request: urns[0],
          request: urns[1]
        },
        headers: {
          ApiKey: apiKey,
          "Content-type": "application/json"
        }
      })
        .then((response) => {
          expect(response.status).to.eq(200);
          // TODO add more response checks
        })
    })
  })

  context('Get Establishments by Trust', () => {

    const trustUkprn = '10067112'

    it('should return establishments when trust UKPRN set', () => {

      cy.api({
        method: 'GET',
        url: `${baseUrlV4}/establishments/trust`,
        qs: {
          trustUkprn: trustUkprn
        },
        headers: {
          ApiKey: apiKey,
          "Content-type": "application/json"
        }
      })
        .then((response) => {
          expect(response.status).to.eq(200);
          // TODO add more response checks
        })
    })
  })
})
