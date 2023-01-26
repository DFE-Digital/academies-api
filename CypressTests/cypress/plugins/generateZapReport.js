const ZapClient = require('zaproxy')
const fs = require('fs')

// TODO pull these values from (Cypress) config
const zapOptions = {
    apiKey: '',
    proxy: 'http://zap:8080'
}

const zaproxy = new ZapClient(zapOptions)

const generateZapHTMLReport = async () => {
    try {
        const report = await zaproxy.core.htmlreport()
        if(!fs.existsSync('./reports')) {
            fs.mkdirSync('./reports')
        }
        fs.writeFileSync('./reports/ZAP-Report.html', report)
    } catch (err) {
        console.log(err)
    }
}

module.exports = generateZapHTMLReport;