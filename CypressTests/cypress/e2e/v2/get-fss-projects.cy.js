/// <reference types="Cypress"/>
describe("GET fss-projects", () => {
 let apiKey = Cypress.env('apiKey');
 let url = Cypress.env('url')
  it("Should return a valid 200 response", () => {
    cy.api({
      failOnStatusCode: false,
      url: url+"/v2/fss/projects",
      headers: {
        ApiKey: apiKey,
      }
    }).its('status').should('eq', 200)
  });

  it("Should return a valid 401 response when omitting API key", () => {
    cy.api({
      failOnStatusCode: false,
      url: url+"/v2/fss/projects",
      headers: {
        ApiKey: '',
      }
    }).its('status').should('eq', 401)
  });
});
