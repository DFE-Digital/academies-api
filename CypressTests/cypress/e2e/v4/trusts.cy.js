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
          expect(response.body.data).to.have.lengthOf.at.least(1).and.lengthOf.at.most(10)
          expect(response.body.paging.page).to.eq(1)
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
          expect(response.body.data[0].name).to.eq(groupName)
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
          expect(response.body.data[0].name).to.eq(groupName)
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
          expect(response.body.data[0].name).to.eq(groupName)
          expect(response.body.data[0].companiesHouseNumber).to.eq(companiesHouseNumber)
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
          expect(response.body.name).to.eq(groupName)
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
          expect(response.body[0].name).to.eq(groupName)
          expect(response.body[0].ukprn).to.eq(ukprns[0])
        })
    })

    it('should return a list of trusts when multiple UKPRNs provided', () => {

      /* TODO Update to make use of qs in request once issue #17921 resolved, see
       * https://github.com/cypress-io/cypress/issues/17921
      */
      cy.api({
        method: 'GET',
        url: `${baseUrlV4}/trusts/bulk?ukprns=${ukprns[0]}&ukprns=${ukprns[1]}`,
        // qs: {
        //   ukprns: [ukprns[0], ukprns[1]]
        // },
        headers: {
          ApiKey: apiKey,
          "Content-type": "application/json"
        }
      })
        .then((response) => {
          expect(response.status).to.eq(200);
          expect(response.body[0].name).to.eq(groupName)
          expect(response.body[0].ukprn).to.eq(ukprns[0])
          expect(response.body[1].name).to.eq('THE BISHOP FRASER TRUST')
          expect(response.body[1].ukprn).to.eq(ukprns[1])
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
          expect(response.body.name).to.eq(groupName)
          expect(response.body.companiesHouseNumber).to.eq(companiesHouseNumber)
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
          expect(response.body.name).to.eq(groupName)
          expect(response.body.referenceNumber).to.eq(trustReferenceNumber)
        })
    })
  })

})
