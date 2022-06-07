export const applyToBecomeAcademySchema = {
  
    type: "object",
    properties: {
      data: {
        type: "object",
        properties: {
          name: {
            type: "string"
           },
          trustName: {
                type: "string"
           },
          applicationId: {
            type: "string"
          },
          applicationType: {
            type: "string"
          },
          trustId: {
            type: "string"
          },
          formTrustProposedNameOfTrust: {
            type: ["string", "null"]
          },
          applicationSubmitted: {
            type: "boolean"
          },
          applicationLeadAuthorId: {
            type: "string"
          },
          applicationLeadEmail: {
            type: "string", format: "email"
          },
          applicationVersion: {
            type: "string"
          },
          applicationLeadAuthorName: {
            type: "string"
          },
          applicationRole: {
            type: "string"
          },
          applicationRoleOtherDescription: {
            type: ["string", "null"]
          },
          changesToTrust: {
            type: "boolean"
          },
          changesToTrustExplained: {
            type: ["string", "null"]
          },
          changesToLaGovernance: {
            type: "boolean"
          },
          changesToLaGovernanceExplained: {
            type: ["string", "null"]
          },
          formTrustOpeningDate: {
            type: ["string", "null"]
          },
          trustApproverName: {
            type: ["string", "null"]
          },
          trustApproverEmail: {
            type: ["string", "null"]
          },
          formTrustReasonApprovalToConvertAsSat: { // This is not in use
            type : ["boolean", "null"] 
          },
          formTrustReasonApprovedPerson: { // This is not in use
            type: ["string", "null"] 
          },
          formTrustReasonForming: { // This is not in use
            type: ["string", "null"] 
          },
          formTrustReasonVision: { // This is not in use
            type: ["string", "null"] 
          },
          formTrustReasonGeoAreas: { // This is not in use
            type: ["string", "null"] 
          },
          formTrustReasonFreedom: { // This is not in use
            type: ["string", "null"]
          },
          formTrustReasonImproveTeaching: { // This is not in use
            type: ["string", "null"] 
          },
          formTrustPlanForGrowth: { // This is not in use
            type: ["string", "null"]
          },
          formTrustPlansForNoGrowth: { // This is not in use
            type:["string", "null"]
          },
          formTrustGrowthPlansYesNo: { // This is not in use
            type: ["boolean", "null"]
          },
          formTrustImprovementSupport: { // This is not in use
            type: ["string", "null"]
          },
          formTrustImprovementStrategy: { // This is not in use
            type: ["string", "null"]
          },
          formTrustImprovementApprovedSponsor: {
            type: ["string", "null"]
          },
          applicationStatusId: {
            type: ["string", "null"]
          },
          // keyPersons: { // This is not in use
          //   type: "array",
          //   items: [
          //     {
          //       type: "object",
          //       properties: {
          //         name: {
          //           type: "string"
          //         },
          //         keyPersonDateOfBirth: {
          //           type: "string"
          //         },
          //         keyPersonBiography: {
          //           type: "string"
          //         },
          //         keyPersonCeoExecutive: {
          //           type: "boolean"
          //         },
          //         keyPersonChairOfTrust: {
          //           type: "boolean"
          //         },
          //         keyPersonFinancialDirector: {
          //           type: "boolean"
          //         },
          //         keyPersonMember: {
          //           type: "boolean"
          //         },
          //         keyPersonOther: {
          //           type: "boolean"
          //         },
          //         keyPersonTrustee: {
          //           type: "boolean"
          //         }
          //       },
          //       required: [
          //         "name",
          //         "keyPersonDateOfBirth",
          //         "keyPersonBiography",
          //         "keyPersonCeoExecutive",
          //         "keyPersonChairOfTrust",
          //         "keyPersonFinancialDirector",
          //         "keyPersonMember",
          //         "keyPersonOther",
          //         "keyPersonTrustee"
          //       ]
          //     }
          //   ]
          // },
          applyingSchools: {
            type: "array",
            items: [
              {
                type: "object",
                properties: {
                  schoolName: {
                    type: "string"
                  },
                  schoolConversionContactHeadName: {
                    type: "string"
                  },
                  schoolConversionContactHeadEmail: {
                    type: "string"
                  },
                  schoolConversionContactHeadTel: {
                    type: "string"
                  },
                  schoolConversionContactChairName: {
                    type: "string"
                  },
                  schoolConversionContactChairEmail: {
                    type: "string"
                  },
                  schoolConversionContactChairTel: {
                    type: "string"
                  },
                  schoolConversionContactRole: {
                    type: "string"
                  },
                  schoolConversionMainContactOtherName: { // This is not in use
                    type: ["string",  "null"]
                  },
                  schoolConversionMainContactOtherEmail: { // This is not in use
                    type: ["string", "null"]
                  },
                  schoolConversionMainContactOtherTelephone: { // This is not in use
                    type: ["string", "null"]
                  },
                  schoolConversionMainContactOtherRole: { // This is not in use
                    type: ["string", "null"]
                  },
                  schoolConversionApproverContactName: {
                    type: "string"
                  },
                  schoolConversionApproverContactEmail: {
                    type: "string"
                  },
                  schoolConversionTargetDateSpecified: {
                    type: "boolean"
                  },
                  schoolConversionTargetDate: {
                    type: ["string", "null"]
                  },
                  schoolConversionTargetDateExplained: {
                    type: ["string", "null"]
                  },
                  schoolConversionReasonsForJoining: {
                    type: "string"
                  },
                  schoolConversionChangeNamePlanned: {
                    type: "boolean"
                  },
                  schoolConversionProposedNewSchoolName: { // This is not in use
                    type: ["string", "null"]
                  },
                  schoolAdSchoolContributionToTrust: {
                    type: "string"
                  },
                  schoolOngoingSafeguardingInvestigations: {
                    type: "boolean"
                  },
                  schoolOngoingSafeguardingDetails: { // This is not in use
                    type: ["string", "null"]
                  },
                  schoolPartOfLaReorganizationPlan: {
                    type: "boolean"
                  },
                  schoolLaReorganizationDetails: { // This is not in use
                    type: ["string", "null"]
                  },
                  schoolPartOfLaClosurePlan: {
                    type: "boolean"
                  },
                  schoolLaClosurePlanDetails: { // This is not in use
                    type: ["string", "null"]
                  },
                  schoolFaithSchool: {
                    type: "boolean"
                  },
                  schoolFaithSchoolDioceseName: { // This is not in use
                    type: ["string", "null"]
                  },
                  diocesePermissionEvidenceDocumentLink: { // This is not in use
                    type: ["string", "null"]
                  },
                  schoolIsPartOfFederation: {
                    type: "boolean"
                  },
                  schoolIsSupportedByFoundation: {
                    type: "boolean"
                  },
                  schoolSupportedFoundationBodyName: { // This is not in use
                    type: ["string", "null"]
                  },
                  foundationEvidenceDocumentLink: { // This is not in use
                    type: ["string", "null"]
                  },
                  schoolHasSACREException: {
                    type: "boolean"
                  },
                  schoolSACREExemptionEndDate: { // This is not in use
                    type: ["string", "null"]
                  },
                  schoolAdFeederSchools: {
                    type: "string"
                  },
                  governingBodyConsentEvidenceDocumentLink: { // This is not in use
                    type: ["string", "null"]
                  },
                  schoolAdEqualitiesImpactAssessmentCompleted: {
                    type: "boolean"
                  },
                  schoolAdEqualitiesImpactAssessmentDetails: { // This is not in use
                    type: ["string", "null"]
                  },
                  schoolAdInspectedButReportNotPublished: {
                    type: "boolean"
                  },
                  schoolAdInspectedButReportNotPublishedExplain: { // This is not in use
                    type: ["string", "null"]
                  },
                  schoolAdditionalInformationAdded: {
                    type: "boolean"
                  },
                  schoolAdditionalInformation: {
                    type: ["string", "null"]
                  },
                  previousFinancialYear: {
                    type: "object",
                    properties: {
                      fyEndDate: {
                        type: "string"
                      },
                      revenueCarryForward: {
                        type: "number"
                      },
                      revenueIsDeficit: {
                        type: "boolean"
                      },
                      revenueStatusExplained: {
                        type: ["string", "null"]
                      },
                      capitalCarryForward: {
                        type: "number"
                      },
                      capitalIsDeficit: {
                        type: "boolean"
                      },
                      capitalStatusExplained: {
                        type: ["string", "null"]
                      }
                    },
                    required: [
                      "fyEndDate",
                      "revenueCarryForward",
                      "revenueIsDeficit",
                      "revenueStatusExplained",
                      "capitalCarryForward",
                      "capitalIsDeficit",
                      "capitalStatusExplained"
                    ]
                  },
                  currentFinancialYear: {
                    type: "object",
                    properties: {
                      fyEndDate: {
                        type: "string"
                      },
                      revenueCarryForward: {
                        type: "number"
                      },
                      revenueIsDeficit: {
                        type: "boolean"
                      },
                      revenueStatusExplained: {
                        type: ["string", "null"]
                      },
                      capitalCarryForward: {
                        type: "integer"
                      },
                      capitalIsDeficit: {
                        type: "boolean"
                      },
                      capitalStatusExplained: {
                        type: ["string", "null"]
                      }
                    },
                    required: [
                      "fyEndDate",
                      "revenueCarryForward",
                      "revenueIsDeficit",
                      "revenueStatusExplained",
                      "capitalCarryForward",
                      "capitalIsDeficit",
                      "capitalStatusExplained"
                    ]
                  },
                  nextFinancialYear: {
                    type: "object",
                    properties: {
                      fyEndDate: {
                        type: "string"
                      },
                      revenueCarryForward: {
                        type: "number"
                      },
                      revenueIsDeficit: {
                        type: "boolean"
                      },
                      revenueStatusExplained: {
                        type: ["string", "null"]
                      },
                      capitalCarryForward: {
                        type: "number"
                      },
                      capitalIsDeficit: {
                        type: "boolean"
                      },
                      capitalStatusExplained: {
                        type: ["string", "null"]
                      }
                    },
                    required: [
                      "fyEndDate",
                      "revenueCarryForward",
                      "revenueIsDeficit",
                      "revenueStatusExplained",
                      "capitalCarryForward",
                      "capitalIsDeficit",
                      "capitalStatusExplained"
                    ]
                  },
                  financeOngoingInvestigations: {
                    type: "boolean"
                  },
                  schoolFinancialInvestigationsExplain: {
                    type: ["string", "null"]
                  },
                  schoolFinancialInvestigationsTrustAware: {
                    type: ["boolean", "null"]
                  },
                  projectedPupilNumbersYear1: {
                    type: "integer"
                  },
                  projectedPupilNumbersYear2: {
                    type: "integer"
                  },
                  projectedPupilNumbersYear3: {
                    type: "integer"
                  },
                  schoolCapacityAssumptions: {
                    type: "string"
                  },
                  schoolCapacityPublishedAdmissionsNumber: {
                    type: "integer"
                  },
                  schoolBuildLandOwnerExplained: {
                    type: "string"
                  },
                  schoolBuildLandWorksPlanned: {
                    type: "boolean"
                  },
                  schoolBuildLandWorksPlannedExplained: {
                    type: ["string", "null"]
                  },
                  schoolBuildLandWorksPlannedCompletionDate: {
                    type: ["string", "null"]
                  },
                  schoolBuildLandSharedFacilities: {
                    type: "boolean"
                  },
                  schoolBuildLandSharedFacilitiesExplained: {
                    type: ["string", "null"]
                  },
                  schoolBuildLandGrants: {
                    type: "boolean"
                  },
                  schoolBuildLandGrantsExplained: {
                    type: ["string", "null"]
                  },
                  schoolBuildLandPFIScheme: {
                    type: "boolean"
                  },
                  schoolBuildLandPFISchemeType: {
                    type: ["string", "null"]
                  },
                  schoolBuildLandPriorityBuildingProgramme: {
                    type: "boolean"
                  },
                  schoolBuildLandFutureProgramme: {
                    type: "boolean"
                  },
                  schoolSupportGrantFundsPaidTo: {
                    type: "string"
                  },
                  schoolHasConsultedStakeholders: {
                    type: "boolean"
                  },
                  schoolPlanToConsultStakeholders: { // This is not in use
                    type: ["string", "null"]
                  },
                  declarationBodyAgree: {
                    type: "boolean"
                  },
                  declarationIAmTheChairOrHeadteacher: {
                    type: "boolean"
                  },
                  declarationSignedByName: {
                    type: ["string", "null"]
                  }
                },
                required: [
                  "schoolName",
                  "schoolConversionContactHeadName",
                  "schoolConversionContactHeadEmail",
                  "schoolConversionContactHeadTel",
                  "schoolConversionContactChairName",
                  "schoolConversionContactChairEmail",
                  "schoolConversionContactChairTel",
                  "schoolConversionContactRole",
                  "schoolConversionMainContactOtherName",
                  "schoolConversionMainContactOtherEmail",
                  "schoolConversionMainContactOtherTelephone",
                  "schoolConversionMainContactOtherRole",
                  "schoolConversionApproverContactName",
                  "schoolConversionApproverContactEmail",
                  "schoolConversionTargetDateSpecified",
                  "schoolConversionTargetDate",
                  "schoolConversionTargetDateExplained",
                  "schoolConversionReasonsForJoining",
                  "schoolConversionChangeNamePlanned",
                  "schoolConversionProposedNewSchoolName",
                  "schoolAdSchoolContributionToTrust",
                  "schoolOngoingSafeguardingInvestigations",
                  "schoolOngoingSafeguardingDetails",
                  "schoolPartOfLaReorganizationPlan",
                  "schoolLaReorganizationDetails",
                  "schoolPartOfLaClosurePlan",
                  "schoolLaClosurePlanDetails",
                  "schoolFaithSchool",
                  "schoolFaithSchoolDioceseName",
                  "diocesePermissionEvidenceDocumentLink",
                  "schoolIsPartOfFederation",
                  "schoolIsSupportedByFoundation",
                  "schoolSupportedFoundationBodyName",
                  "foundationEvidenceDocumentLink",
                  "schoolHasSACREException",
                  "schoolSACREExemptionEndDate",
                  "schoolAdFeederSchools",
                  "governingBodyConsentEvidenceDocumentLink",
                  "schoolAdEqualitiesImpactAssessmentCompleted",
                  "schoolAdEqualitiesImpactAssessmentDetails",
                  "schoolAdInspectedButReportNotPublished",
                  "schoolAdInspectedButReportNotPublishedExplain",
                  "schoolAdditionalInformationAdded",
                  "schoolAdditionalInformation",
                  "previousFinancialYear",
                  "currentFinancialYear",
                  "nextFinancialYear",
                  "financeOngoingInvestigations",
                  "schoolFinancialInvestigationsExplain",
                  "schoolFinancialInvestigationsTrustAware",
                  "projectedPupilNumbersYear1",
                  "projectedPupilNumbersYear2",
                  "projectedPupilNumbersYear3",
                  "schoolCapacityAssumptions",
                  "schoolCapacityPublishedAdmissionsNumber",
                  "schoolBuildLandOwnerExplained",
                  "schoolBuildLandWorksPlanned",
                  "schoolBuildLandWorksPlannedExplained",
                  "schoolBuildLandWorksPlannedCompletionDate",
                  "schoolBuildLandSharedFacilities",
                  "schoolBuildLandSharedFacilitiesExplained",
                  "schoolBuildLandGrants",
                  "schoolBuildLandGrantsExplained",
                  "schoolBuildLandPFIScheme",
                  "schoolBuildLandPFISchemeType",
                  "schoolBuildLandPriorityBuildingProgramme",
                  "schoolBuildLandFutureProgramme",
                  "schoolSupportGrantFundsPaidTo",
                  "schoolHasConsultedStakeholders",
                  "schoolPlanToConsultStakeholders",
                  "declarationBodyAgree",
                  "declarationIAmTheChairOrHeadteacher",
                  "declarationSignedByName"
                ]
              }
            ]
          }
        },
        required: [
          "name",
          "applicationId",
          "applicationType",
          "trustId",
          "formTrustProposedNameOfTrust",
          "applicationSubmitted",
          "applicationLeadAuthorId",
          "applicationLeadEmail",
          "applicationVersion",
          "applicationLeadAuthorName",
          "applicationRole",
          "applicationRoleOtherDescription",
          "changesToTrust",
          "changesToTrustExplained",
          "changesToLaGovernance",
          "changesToLaGovernanceExplained",
          "formTrustOpeningDate",
          "trustApproverName",
          "trustApproverEmail",
          "formTrustReasonApprovalToConvertAsSat",
          "formTrustReasonApprovedPerson",
          "formTrustReasonForming",
          "formTrustReasonVision",
          "formTrustReasonGeoAreas",
          "formTrustReasonFreedom",
          "formTrustReasonImproveTeaching",
          "formTrustPlanForGrowth",
          "formTrustPlansForNoGrowth",
          "formTrustGrowthPlansYesNo",
          "formTrustImprovementSupport",
          "formTrustImprovementStrategy",
          "formTrustImprovementApprovedSponsor",
          "applicationStatusId",
          "keyPersons",
          "applyingSchools"
        ]
      }
    },
    required: [
      "data"
    ]
  }