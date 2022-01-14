/// <reference types="Cypress"/>
describe("GET conversion-projects", () => {
 let apiKey = Cypress.env('apiKey');
 let url = Cypress.env('url')

  it('Should reject PATCH request to URI containing invalid project ID with 400 error - alphabetical chars', () => {
    cy.request({
        method : 'PATCH',
        failOnStatusCode: false,
        url: url+"/conversion-projects/abcdef",
        headers: {
          ApiKey: apiKey,
          "Content-type" : "application/json"
        }
      })
      .should((response)=>{
        cy.log(response)
        expect(response.body.errors.id).to.contain('The value \'abcdef\' is not valid.')
        expect(response.status).to.eq(400)
      })
  });

  it('Should reject PATCH request to URI containing invalid project Id with 404- non-existant ID', () => {
    cy.request({
        method : 'PATCH',
        failOnStatusCode: false,
        url: url+"/conversion-projects/99999999",
        headers: {
          ApiKey: apiKey,
        },
        body:{

        }
      }).should((response)=>{
        expect(response.status).to.eq(404)
      })
    })    

    it('Should reject PATCH request to URI containing invalid project Id with 415- negative number ID', () => {
      cy.request({
          method : 'PATCH',
          failOnStatusCode: false,
          url: url+"/conversion-projects/-1",
          headers: {
            ApiKey: apiKey,
          },
          body:{
  
          }
        }).should((response)=>{
          expect(response.status).to.eq(404)
        })
      })
});
