describe("Health Check and Database Check", () => {
    let apiKey = Cypress.env('apiKey');
    let url = Cypress.env('url')

    it('Health Check', () => {
        cy.api({
            method : 'GET',
            failOnStatusCode: false,
            url: url+"/HealthCheck",
            headers: {
              ApiKey: apiKey,
              "Content-type" : "application/json"
            }
          })
          .then((response)=>{
            expect(response.body).to.contain('Health check ok');
            expect(response.status).to.eq(200);
            cy.log(JSON.stringify(response.body));
          })
      });

      it('Database Check', () => {
        cy.api({
            method : 'GET',
            failOnStatusCode: false,
            url: url+"check_db",
            headers: {
              ApiKey: apiKey,
              "Content-type" : "application/json"
            }
          })
          .then((response)=>{ 
            expect(response.status).to.eq(200);
            expect(response.body).to.eq(true);
            cy.log("Database Check = "+JSON.stringify(response.body));
          })
      });

   });