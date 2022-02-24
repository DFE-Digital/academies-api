describe("E2E Academy Transfers", () => {
    let apiKey = Cypress.env('apiKey');
    let url = Cypress.env('url');

    it('GET All Academy Transfer Projects', () => {
    cy.request({
        method : 'GET',
        failOnStatusCode: false,
        url: url+"academyTransferProject",
        headers: {
            ApiKey: apiKey,
            "Content-type" : "application/json"
        }
        })
        .then((response) =>{
        cy.log("Number of Projects found: "+response.body.length);
        cy.log(JSON.stringify(response.body));
        expect(response.status).to.eq(200);
        })
    });
       
});