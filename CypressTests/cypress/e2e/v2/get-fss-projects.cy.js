/// <reference types="Cypress"/>
describe("Free Schools Store endpoint", () => {

  const apiKey = Cypress.env('apiKey');
  const url = Cypress.env('url')
  
  it("Should return a valid 200 response", () => {
    cy.api({
      url: url + "/v2/fss/projects",
      headers: {
        ApiKey: apiKey,
      }
    }).its('status').should('eq', 200)
  })

  it("Should return a valid 401 response when omitting API key", () => {
    cy.api({
      failOnStatusCode: false,
      url: url + "/v2/fss/projects",
      headers: {
        ApiKey: '',
      }
    }).its('status').should('eq', 401)
  })
})
