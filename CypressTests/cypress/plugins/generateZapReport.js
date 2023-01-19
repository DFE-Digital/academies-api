const ZapClient = require('zaproxy')
const fs = require('fs')

const zapOptions = {
    apiKey: ''
}

const zaproxy = new ZapClient(zapOptions)

// const target = "https://trams-external-api.azurewebsites.net"

// Get the report as json
// zaproxy.core.alerts(target, 0, 0, null, (res, err) => { 
//     if(res) {
//         console.log('res')
//     }
//     if(err) {
//         console.log(err.alerts.length)
//     }
//     else {
//         console.log('nowt')
//     }
// })

// Get the report as html
// zaproxy.core.htmlreport((res, err) => {
//     if(res){
//         console.log('res')
//     }
//     if(err){
//         console.log(err)
//     }
//     else {
//         console.log('null')
//     }
// })

const generateZapHTMLReport = async () => {
    const report = await zaproxy.core.htmlreport()

    try {
        fs.writeFileSync('./ZAP-Report.html', report)
    } catch (err) {
        console.log(err)
    }
}

module.exports = generateZapHTMLReport;