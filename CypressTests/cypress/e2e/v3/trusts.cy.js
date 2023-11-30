describe('Trusts endpoints tests', () => {

  const apiKey = Cypress.env('apiKey')
  const baseUrlV3 = `${Cypress.env('url')}/v3`
  const companiesHouseNumber = '11082297'
  const ukprn = '10067112'
  const groupName = 'SOUTH YORK MULTI ACADEMY TRUST'

  context('Search Trusts', () => {
    
    it('should return a list of trusts when default search parameters set', () => {

      cy.api({
        method: 'GET',
        url: `${baseUrlV3}/trusts`,
        qs: {
          page: 1,
          count: 50
        },
        headers: {
          ApiKey: apiKey,
          "Content-type": "application/json"
        }
      })
        .then((response) => {
          expect(response.status).to.eq(200)
          expect(response.body.data).to.have.lengthOf.at.least(1).and.lengthOf.at.most(50)
          expect(response.body.paging.page).to.eq(1)
        })
    })

    it('should return a single trust when group name set', () => {

      cy.api({
        method: 'GET',
        url: `${baseUrlV3}/trusts`,
        qs: {
          groupName: groupName,
          page: 1,
          count: 50
        },
        headers: {
          ApiKey: apiKey,
          "Content-type": "application/json"
        }
      })
        .then((response) => {
          expect(response.status).to.eq(200)
          expect(response.body.data[0].groupName).to.eq(groupName)
        })
    })

    it('should return a single trust when UKPRN set', () => {

      cy.api({
        method: 'GET',
        url: `${baseUrlV3}/trusts`,
        qs: {
          ukPrn: ukprn,
          page: 1,
          count: 50
        },
        headers: {
          ApiKey: apiKey,
          "Content-type": "application/json"
        }
      })
        .then((response) => {
          expect(response.status).to.eq(200)
          expect(response.body.data[0].groupName).to.eq(groupName)
        })
    })

    it('should return a single trust when Companies House Number set', () => {

      cy.api({
        method: 'GET',
        url: `${baseUrlV3}/trusts`,
        qs: {
          companiesHouseNumber: companiesHouseNumber,
          page: 1,
          count: 50
        },
        headers: {
          ApiKey: apiKey,
          "Content-type": "application/json"
        }
      })
        .then((response) => {
          expect(response.status).to.eq(200)
          expect(response.body.data[0].groupName).to.eq(groupName)
          expect(response.body.data[0].companiesHouseNumber).to.eq(companiesHouseNumber)
        })
    })
  })

  context('Get Trust by UKPRN', () => {
    
    it('should return a single trust when UKPRN set', () => {

      cy.api({
        method: 'GET',
        url: `${baseUrlV3}/trust/${ukprn}`,
        headers: {
          ApiKey: apiKey,
          "Content-type": "application/json"
        }
      })
        .then((response) => {
          expect(response.status).to.eq(200)
          expect(response.body.data).to.include.keys('trustData', 'giasData', 'establishments')
          expect(response.body.data.giasData.groupName).to.eq(groupName)
        })
    })
  })
})
