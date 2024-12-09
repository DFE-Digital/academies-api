describe("Health and Database Checks", () => {
  let apiKey = Cypress.env('apiKey')
  let url = Cypress.env('url')

  context('Health check endpoint', () => {
    it('should return a healthy response', () => {
      cy.api({
        url: `${url}/HealthCheck`,
        headers: {
          ApiKey: apiKey,
          "Content-type": "application/json"
        }
      })
        .then((response) => {
          expect(response.body).to.contain('Healthy')
          expect(response.status).to.eq(200)
        })
    })
  })
})
