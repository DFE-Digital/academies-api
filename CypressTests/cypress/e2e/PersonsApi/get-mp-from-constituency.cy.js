describe('Get MP From Constituency Test', () => {

  const apiKey = Cypress.env('apiKey')
  const baseUrl = `${Cypress.env('personsUrl')}/v1`
  const constituency = `Aberdeen%20North`

  const firstName = `Kirsty`
  const lastName = `Blackman`
  const email = `kirsty.blackman.mp@parliament.uk`
  const displayName = `Kirsty Blackman`
  const displayNameWithTitle = `Kirsty Blackman MP`
  const role = `Member of Parliament`
  const constituencyName = `Aberdeen North`

  context('Get Person by Constituency', () => {
    
    it('should return MP details when constituency set', () => {

      cy.api({
        method: 'GET',
        url: `${baseUrl}/get-mp-from-constituency?Constituency=${constituency}`,
        headers: {
          ApiKey: apiKey,
          "Content-type": "application/json"
        }
      })
        .then((response) => {
          expect(response.status).to.eq(200)
          expect(response.body.firstName).to.eq(firstName)
          expect(response.body.lastName).to.eq(lastName)
          expect(response.body.email).to.eq(email)
          expect(response.body.displayName).to.eq(displayName)
          expect(response.body.displayNameWithTitle).to.eq(displayNameWithTitle)
          expect(response.body.role).to.eq(role)
          expect(response.body.constituencyName).to.eq(constituencyName)
        })
    })
  })
})
