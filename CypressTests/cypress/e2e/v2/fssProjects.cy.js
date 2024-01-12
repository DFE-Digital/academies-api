/// <reference types="Cypress"/>
describe("Free Schools Store endpoint", () => {

  const apiKey = Cypress.env('apiKey')
  const baseUrlV2 = `${Cypress.env('url')}/v2`
  
  it("Should return a valid response with data", () => {
    cy.api({
      url: `${baseUrlV2}/fss/projects`,
      headers: {
        ApiKey: apiKey,
      }
    })
    .then((response) => {
      expect(response.status).to.eq(200)
      expect(response.body.data).to.have.lengthOf.at.least(1)
      expect(response.body.data[0]).to.include.all.keys('localAuthority', 'projectId', 'projectStatus', 'trustId', 'trustName', 'urn')
    })
  })

  it("Should return a valid 401 response when omitting API key", () => {
    cy.api({
      failOnStatusCode: false,
      url: `${baseUrlV2}/fss/projects`,
      headers: {
        ApiKey: '',
      }
    }).its('status').should('eq', 401)
  })
})
