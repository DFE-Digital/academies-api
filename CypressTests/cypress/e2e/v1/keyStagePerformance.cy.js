describe('Key Stage Performance endpoint tests', () => {

  const apiKey = Cypress.env('apiKey');
  const url = Cypress.env('url')
  const urn = '100000'
  const schoolName = 'The Aldgate School'

  it('Returns education performance data when URN supplied', () => {

    cy.api({
      method: 'GET',
      url: `${url}/educationPerformance/${urn}`,
      headers: {
        ApiKey: apiKey,
        "Content-type": "application/json"
      }
    })
      .then((response) => {
        expect(response.status).to.eq(200)
        expect(response.body.schoolName).to.eq(schoolName)
        expect(response.body).to.include.keys('schoolName', 'keyStage1', 'keyStage2', 'keyStage4', 'keyStage5')
      })
  })
})