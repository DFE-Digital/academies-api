describe('Trusts endpoints tests', () => {

  const apiKey = Cypress.env('apiKey')
  const baseUrlV4 = `${Cypress.env('url')}/v4`
  const companiesHouseNumber = '11082297'
  const ukprns = ['10067112', '10067113']
  const groupName = 'SOUTH YORK MULTI ACADEMY TRUST'
  const trustReferenceNumber = 'TR03739'


  context('Get Person by Constituency', () => {
    
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
          expect(response.status).to.eq(200)
          expect(response.body.name).to.eq(groupName)
        })
    })
  })
})
