/// <reference types="cypress" />
// ***********************************************************
// This example plugins/index.js can be used to load plugins
//
// You can change the location of this file or turn off loading
// the plugins file with the 'pluginsFile' configuration option.
//
// You can read more here:
// https://on.cypress.io/plugins-guide
// ***********************************************************

// This function is called when a project is opened or re-opened (e.g. due to
// the project's config changing)

const { generateZapHTMLReport, getAlertCount } = require('./generateZapReport');

/**
 * @type {Cypress.PluginConfig}
 */
// eslint-disable-next-line no-unused-vars
module.exports = (on, config) => {
  // `on` is used to hook into various events Cypress emits
  // `config` is the resolved Cypress config

  // Map process env var to cypress var for usage outside of Cypress run
  process.env = config.env

  // eslint-disable-next-line no-unused-vars
  on('after:run', async (res) => {
    if(process.env.zapReport) {
      const alertCount = await getAlertCount()
      if(Number(alertCount.numberOfAlerts) > 0)
        await generateZapHTMLReport()
      else
        console.log('No alerts found')
    }
  })
}
