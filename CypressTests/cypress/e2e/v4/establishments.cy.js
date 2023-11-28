describe('Establishment endpoints tests', () => {

  const apiKey = Cypress.env('apiKey');
  const url = Cypress.env('url')

  context('Search Establishments', () => {
    
    it.skip('should return a list of establishments when no search parameters set', () => {

    })

    it.skip('should return establishments when name set', () => {

    })

    it.skip('should return establishments when UKPRN set', () => {

    })

    it.skip('should return establishments when URN set', () => {

    })
  })

  context('Get Establishment URNs by Region', () => {

    it.skip('should return a list of URNs when a single region is provided', () => {

    })

    it.skip('should return a list of URNs when multiple regions are provided', () => {

    })
  })

  context('Get Establishment by UKPRN', () => {

    it.skip('should return establishments when UKPRN set', () => {

    })
  })

  context('Get Establishment by URN', () => {

    it.skip('should return a single establishment when a URN is provided', () => {

    })
  })

  context('Bulk Get Establishments by URN', () => {

    it.skip('should return a single establishment when a URN is provided', () => {

    })

    it.skip('should return a list of establishments when multiple URNs are provided', () => {

    })
  })

  context('Get Establishments by Trust', () => {

    it.skip('should return establishments when UKPRN set', () => {

    })
  })
})
