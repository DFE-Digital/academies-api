describe('Trusts endpoints tests', () => {

  const apiKey = Cypress.env('apiKey');
  const baseUrlV4 = `${Cypress.env('url')}/v4`
  const companiesHouseNumber = '11082297'
  const ukprns = ['10067112', '10067113']
  const groupName = 'SOUTH YORK MULTI ACADEMY TRUST'
  const trustReferenceNumber = 'TR03739'

  context('Search Trusts', () => {
    
    it('should return a list of trusts when default search parameters set', () => {

      cy.api({
        method: 'GET',
        url: `${baseUrlV4}/trusts`,
        qs: {
          page: 1,
          count: 10
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

    it('should return a single trust when group name set', () => {

      cy.api({
        method: 'GET',
        url: `${baseUrlV4}/trusts`,
        qs: {
          groupName: groupName,
          page: 1,
          count: 10
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

    it('should return a single trust when UKPRN set', () => {

      cy.api({
        method: 'GET',
        url: `${baseUrlV4}/trusts`,
        qs: {
          ukPrn: ukprns[0],
          page: 1,
          count: 10
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

    it('should return a single trust when Companies House Number set', () => {

      cy.api({
        method: 'GET',
        url: `${baseUrlV4}/trusts`,
        qs: {
          companiesHouseNumber: companiesHouseNumber,
          page: 1,
          count: 10
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

  context('Get Trust by UKPRN', () => {
    
    it('should return a single trust when UKPRN set', () => {

      cy.api({
        method: 'GET',
        url: `${baseUrlV4}/trust/${ukprns[0]}`,
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

  context('Bulk Get Trusts by UKPRN', () => {

    it('should return a single trust when a single UKPRN is provided', () => {

      cy.api({
        method: 'GET',
        url: `${baseUrlV4}/trusts/bulk`,
        qs: {
          ukprns: ukprns[0]
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

    it('should return a list of trusts when multiple UKPRNs provided', () => {

      cy.api({
        method: 'GET',
        url: `${baseUrlV4}/trusts/bulk`,
        qs: {
          ukprns: ukprns[0],
          ukprn: ukprns[1]
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

  context('Get Trust by Companies House Number', () => {

    it('should return a single trust when Companies House Number set', () => {

      cy.api({
        method: 'GET',
        url: `${baseUrlV4}/trust/companiesHouseNumber/${companiesHouseNumber}`,
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

  context('Get Trusts by Trust Reference Number', () => {

    it('should return a single trust when Trust Reference Number set', () => {

      cy.api({
        method: 'GET',
        url: `${baseUrlV4}/trust/trustReferenceNumber/${trustReferenceNumber}`,
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
