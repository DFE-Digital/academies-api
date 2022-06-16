describe("E2E Academy Transfers", () => {
    let apiKey = Cypress.env('apiKey');
    let url = Cypress.env('url');
    var savedURN;
    var savedOutgoingTrustUkprn;
    var originalAcademyPerformanceAdditionalInformation;

    it('GET All Academy Transfer Projects', () => {
        cy.request({
            method : 'GET',
            failOnStatusCode: false,
            url: url+"academyTransferProject",
            headers: {
                ApiKey: apiKey,
                "Content-type" : "application/json"
            }
        })
        .then((response) =>{
            expect(response.status).to.eq(200);
            savedURN = response.body[0].projectUrn;
            cy.log("1st Project URN = "+savedURN);
            savedOutgoingTrustUkprn = response.body[0].outgoingTrustUkprn;
            cy.log("1st Project outgoingTrustUkprn = "+savedOutgoingTrustUkprn);
        })
        
    });

    it('Find and update a Project and verify the changes', () => {
        cy.request({
            method : 'GET',
            failOnStatusCode: false,
            url: url+"academyTransferProject/"+savedURN,
            headers: {
                ApiKey: apiKey,
                "Content-type" : "application/json"
            }
        })
        .then((response) =>{
            expect(response.status).to.eq(200);
            savedOutgoingTrustUkprn = response.body.outgoingTrustUkprn;
            cy.log("savedOutgoingTrustUkprn = "+savedOutgoingTrustUkprn);
            expect("Project URN = "+response.body.projectUrn).to.eq("Project URN = "+savedURN);
            originalAcademyPerformanceAdditionalInformation = response.body.academyPerformanceAdditionalInformation;
            cy.log("originalAcademyPerformanceAdditionalInformation = "+originalAcademyPerformanceAdditionalInformation);
        })
        
        // *****academyPerformanceAdditionalInformation does not exist and requires necessary information to complete tests*****

        // cy.request({
        //     method : 'PATCH',
        //     failOnStatusCode: false,
        //     body:{
        //         "outgoingTrustUkprn": `${savedOutgoingTrustUkprn}`,
        //         "academyPerformanceAdditionalInformation": "Offstead Report - UPDATE TEST"            
        //     },
        //     url: url+"academyTransferProject/"+savedURN,
        //     headers: {
        //         ApiKey: apiKey,
        //         "Content-type" : "application/json"
        //     }
        // })
        // .then((response) =>{
        //     expect(response.status).to.eq(200);
        //     expect(response.body.academyPerformanceAdditionalInformation)
        //     .to.eq("Offstead Report - UPDATE TEST");
        // })

        // cy.request({
        //     method : 'PATCH',
        //     failOnStatusCode: false,
        //     body:{
        //         "outgoingTrustUkprn": `${savedOutgoingTrustUkprn}`,
        //         "academyPerformanceAdditionalInformation": `${originalAcademyPerformanceAdditionalInformation}`           
        //     },
        //     url: url+"academyTransferProject/"+savedURN,
        //     headers: {
        //         ApiKey: apiKey,
        //         "Content-type" : "application/json"
        //     }
        // })
        // .then((response) =>{
        //     expect(response.status).to.eq(200);
        //     expect(response.body.academyPerformanceAdditionalInformation)
        //     .to.eq(originalAcademyPerformanceAdditionalInformation);
        // })
    });
});