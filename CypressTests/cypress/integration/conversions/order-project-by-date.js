/// <reference types ='Cypress'/>

describe('Project Application ordered by date', () => {

    it('TC01: Application ordered by date received', () => {

        cy.beData()
        .should((response) => {

            // GET project by random [0][2][1]
            const projectDates = ([response.body[1].applicationReceivedDate, response.body[0].applicationReceivedDate, response.body[2].applicationReceivedDate])
            cy.log(projectDates)

            // GET project timestamps
            const timestamps = Cypress._.map(projectDates)
            .map((str) => new Date(str))
            cy.log(timestamps)

            // GET & sort timestamps ascending order
            const sorted = Cypress._.sortBy(timestamps)
            cy.log(sorted)
            // timestamps[1] === slice i.e.,projectDates([0], [1], [2])
            expect(timestamps[2]).to.deep.equal(sorted[0])
        })
    })
})