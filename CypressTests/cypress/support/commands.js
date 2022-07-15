// ***********************************************
// This example commands.js shows you how to
// create various custom commands and overwrite
// existing commands.
//
// For more comprehensive examples of custom
// commands please read more here:
// https://on.cypress.io/custom-commands
// ***********************************************
//
//
// -- This is a parent command --
// Cypress.Commands.add('login', (email, password) => { ... })
//
//
// -- This is a child command --
// Cypress.Commands.add('drag', { prevSubject: 'element'}, (subject, options) => { ... })
//
//
// -- This is a dual command --
// Cypress.Commands.add('dismiss', { prevSubject: 'optional'}, (subject, options) => { ... })
//
//
// -- This will overwrite an existing command --
// Cypress.Commands.overwrite('visit', (originalFn, url, options) => { ... })



import { validateSchema } from "./validate-schema-command";

Cypress.Commands.add("validateSchema", validateSchema);


Cypress.Commands.add('beData', () => {
    const apiKey = Cypress.env('apiKey')
    const url = Cypress.env('url')

    cy.request({
        method:'GET',
        url: url + '/conversion-projects?count=4',
        headers: {
            ApiKey: apiKey,
            "Content-type" : "application/json"
         }
    })
})
