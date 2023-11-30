describe("Baseline Tracker endpoint", () => {

  const apiKey = Cypress.env('apiKey')
  const baseUrlV2 = `${Cypress.env('url')}/v2`
  
  it("Should return a list of baseline trackers when default parameters set", () => {

    // TODO change url endpoint when spelling mistake resolved
    cy.api({
      method: 'GET',
      url: `${baseUrlV2}/basline-tracker`,
      qs: {
        page: 1,
        count: 50
      },
      headers: {
        ApiKey: apiKey,
        "Content-type": "application/json"
      }
    })
      .then((response) => {
        expect(response.status).to.eq(200)
        expect(response.body.data).to.have.lengthOf.at.least(1).and.lengthOf.at.most(50)
      })
  })

})
