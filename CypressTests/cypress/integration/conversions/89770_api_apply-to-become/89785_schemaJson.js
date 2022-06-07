/// <reference types="Cypress"/>
import { applyToBecomeAcademySchema } from "../../../schemas/schema"        

let apiKey = Cypress.env('apiKey')
let url = Cypress.env('url')


describe('Test Against Json Schema API V2 School application', () => {

    it('GET Application Data by ID', () => {
        cy.request({
            url: url + 'v2/apply-to-become/application/A2B_1645',
            headers: {
                ApiKey: apiKey,
              }
        }).then((response) => {
            expect(response.status).to.eq(200)
            cy.log(response.body)
            cy.validateSchema(applyToBecomeAcademySchema, response.body)
        })
    })
})