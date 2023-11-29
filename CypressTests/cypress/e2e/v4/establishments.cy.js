describe('Establishment endpoints tests', () => {

  const apiKey = Cypress.env('apiKey')
  const baseUrlV4 = `${Cypress.env('url')}/v4`
  const name = 'The Aldgate School'
  const ukPrn = '10079319'
  const urns = [100000, 100002]
  const trustUkprn = '10067112'

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
          expect(response.status).to.eq(200)
          expect(response.body).to.have.lengthOf.at.least(1).and.lengthOf.at.most(100)
        })
    })

    it('should return establishments when name set', () => {

      cy.api({
        method: 'GET',
        url: `${baseUrlV4}/establishments`,
        qs: {
          name: name
        },
        headers: {
          ApiKey: apiKey,
          "Content-type": "application/json"
        }
      })
        .then((response) => {
          expect(response.status).to.eq(200)
          expect(response.body[0].name).to.eq(name)
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
          expect(response.status).to.eq(200)
          expect(response.body[0].ukprn).to.eq(ukPrn)
        })
    })

    it('should return establishments when URN set', () => {

      cy.api({
        method: 'GET',
        url: `${baseUrlV4}/establishments`,
        qs: {
          urn: `${urns[0]}`
        },
        headers: {
          ApiKey: apiKey,
          "Content-type": "application/json"
        }
      })
        .then((response) => {
          expect(response.status).to.eq(200)
          expect(response.body[0].urn).to.eq(`${urns[0]}`)
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
          expect(response.status).to.eq(200)
          expect(response.body).to.have.lengthOf.at.least(1)
        })
    })

    it('should return a list of URNs when multiple regions are provided', () => {

      /* TODO Update to make use of qs in request once issue #17921 resolved, see
       * https://github.com/cypress-io/cypress/issues/17921
      */
      cy.api({
        method: 'GET',
        url: `${baseUrlV4}/establishment/regions?regions=North%20West&regions=South%20West`,
        // qs: {
        //   regions: 'North West',
        //   regions: 'South West'
        // },
        headers: {
          ApiKey: apiKey,
          "Content-type": "application/json"
        }
      })
        .then((response) => {
          expect(response.status).to.eq(200)
          expect(response.body).to.have.lengthOf.at.least(1)
        })
    })
  })

  context('Get Establishment by UKPRN', () => {

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
          expect(response.status).to.eq(200)
          expect(response.body.ukprn).to.eq(ukPrn)
        })
    })
  })

  context('Get Establishment by URN', () => {

    it('should return a single establishment when a URN is provided', () => {

      cy.api({
        method: 'GET',
        url: `${baseUrlV4}/establishment/urn/${urns[0]}`,
        headers: {
          ApiKey: apiKey,
          "Content-type": "application/json"
        }
      })
        .then((response) => {
          expect(response.status).to.eq(200)
          expect(response.body.urn).to.eq(`${urns[0]}`)
        })
    })
  })

  context('Bulk Get Establishments by URN', () => {

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
          expect(response.status).to.eq(200)
          expect(response.body[0].urn).to.eq(`${urns[0]}`)
        })
    })

    it('should return a list of establishments when multiple URNs are provided', () => {

      /* TODO Update to make use of qs in request once issue #17921 resolved, see
       * https://github.com/cypress-io/cypress/issues/17921
      */
      cy.api({
        method: 'GET',
        url: `${baseUrlV4}/establishments/bulk?request=${urns[0]}&request=${urns[1]}`,
        // qs: {
        //   request: urns[0],
        //   request: urns[1]
        // },
        headers: {
          ApiKey: apiKey,
          "Content-type": "application/json"
        }
      })
        .then((response) => {
          expect(response.status).to.eq(200)
          expect(response.body[0].urn).to.eq(`${urns[0]}`)
          expect(response.body[1].urn).to.eq(`${urns[1]}`)
        })
    })
  })

  context('Get Establishments by Trust', () => {

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
          expect(response.status).to.eq(200)
          expect(response.body).to.have.lengthOf.at.least(1)
        })
    })
  })
})
