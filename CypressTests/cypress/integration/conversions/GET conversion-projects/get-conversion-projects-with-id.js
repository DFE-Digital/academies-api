/// <reference types="Cypress"/>
describe("GET conversion-projects", () => {
 let apiKey = Cypress.env('apiKey');
 let url = Cypress.env('url')

  it('Should reject invalid \'?count\' parameters - alphabetical chars', () => {
    cy.request({
        failOnStatusCode: false,
        url: url+"/conversion-projects?count=abcdef",
        headers: {
          ApiKey: apiKey,
        }
      })
      .its('body.errors.count').should('contain','The value \'abcdef\' is not valid.')
  });

  it('Should reject invalid \'?count\' parameters - negative integer value', () => {
    cy.request({
        failOnStatusCode: false,
        url: url+"/conversion-projects?count=-1",
        headers: {
          ApiKey: apiKey,
        }
      }).should((response)=>{
        expect(response.status).to.eq(500)
        expect(response.body.Message).to.contain('Internal Server Error: The number of rows provided for a FETCH clause must be greater then zero')
      })
    })    

    it('Should reject invalid \'?count\' parameters - negative integer value', () => {
      cy.request({
          failOnStatusCode: false,
          url: url+"/conversion-projects?count=-1",
          headers: {
            ApiKey: apiKey,
          }
        })
      })
});
