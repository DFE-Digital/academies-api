export const applyToBecomeAcademySchema = {
  
    type: "object",
    properties: {
      data: {
        type: "object",
        properties: {
          name: {
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
            type: "string"
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
            type: "string"
          },
          changesToTrust: {
            type: "boolean"
          },
          changesToTrustExplained: {
            type: "string"
          },
          changesToLaGovernance: {
            type: "boolean"
          },
          changesToLaGovernanceExplained: {
            type: "string"
          },
          formTrustOpeningDate: {
            type: "string"
          },
          trustApproverName: {
            type: "string"
          },
          trustApproverEmail: {
            type: "string"
          },
          formTrustReasonApprovalToConvertAsSat: {
            type : "boolean"
          },
          formTrustReasonApprovedPerson: {
            type: "string"
          },
          formTrustReasonForming: {
            type: "string"
          },
          formTrustReasonVision: {
            type: "string"
          },
          formTrustReasonGeoAreas: {
            type: "string"
          },
          formTrustReasonFreedom: {
            type: "string"
          },
          formTrustReasonImproveTeaching: {
            type: "string"
          },
          formTrustPlanForGrowth: {
            type: "string"
          },
          formTrustPlansForNoGrowth: {
            type: "string"
          },
          formTrustGrowthPlansYesNo: {
            type: "boolean"
          },
          formTrustImprovementSupport: {
            type: "string"
          },
          formTrustImprovementStrategy: {
            type: "string"
          },
          formTrustImprovementApprovedSponsor: {
            type: "string"
          },
          applicationStatusId: {
            type: "string"
          },
          keyPersons: {
            type: "array",
            items: [
              {
                type: "object",
                properties: {
                  name: {
                    type: "string"
                  },
                  keyPersonDateOfBirth: {
                    type: "string"
                  },
                  keyPersonBiography: {
                    type: "string"
                  },
                  keyPersonCeoExecutive: {
                    type: "boolean"
                  },
                  keyPersonChairOfTrust: {
                    type: "boolean"
                  },
                  keyPersonFinancialDirector: {
                    type: "boolean"
                  },
                  keyPersonFinancialDirectorTime: {
                    type: "string"
                  },
                  keyPersonMember: {
                    type: "string"
                  },
                  keyPersonOther: {
                    type: "string"
                  },
                  keyPersonTrustee: {
                    type: "string"
                  }
                },
                required: [
                  "name",
                  "keyPersonDateOfBirth",
                  "keyPersonBiography",
                  "keyPersonCeoExecutive",
                  "keyPersonChairOfTrust",
                  "keyPersonFinancialDirector",
                  "keyPersonFinancialDirectorTime",
                  "keyPersonMember",
                  "keyPersonOther",
                  "keyPersonTrustee"
                ]
              }
            ]
          },
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
                  schoolConversionMainContactOtherName: {
                    type: "string"
                  },
                  schoolConversionMainContactOtherEmail: {
                    type: "string"
                  },
                  schoolConversionMainContactOtherTelephone: {
                    type: "string"
                  },
                  schoolConversionMainContactOtherRole: {
                    type: "string"
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
                    type: "string"
                  },
                  schoolConversionTargetDateExplained: {
                    type: "string"
                  },
                  schoolConversionReasonsForJoining: {
                    type: "string"
                  },
                  schoolConversionChangeNamePlanned: {
                    type: "boolean"
                  },
                  schoolConversionProposedNewSchoolName: {
                    type: "string"
                  },
                  schoolAdSchoolContributionToTrust: {
                    type: "string"
                  },
                  schoolOngoingSafeguardingInvestigations: {
                    type: "boolean"
                  },
                  schoolOngoingSafeguardingDetails: {
                    type: "string"
                  },
                  schoolPartOfLaReorganizationPlan: {
                    type: "boolean"
                  },
                  schoolLaReorganizationDetails: {
                    type: "string"
                  },
                  schoolPartOfLaClosurePlan: {
                    type: "boolean"
                  },
                  schoolLaClosurePlanDetails: {
                    type: "string"
                  },
                  schoolFaithSchool: {
                    type: "boolean"
                  },
                  schoolFaithSchoolDioceseName: {
                    type: "string"
                  },
                  diocesePermissionEvidenceDocumentLink: {
                    type: "string"
                  },
                  schoolIsPartOfFederation: {
                    type: "boolean"
                  },
                  schoolIsSupportedByFoundation: {
                    type: "boolean"
                  },
                  schoolSupportedFoundationBodyName: {
                    type: "string"
                  },
                  foundationEvidenceDocumentLink: {
                    type: "string"
                  },
                  schoolHasSACREException: {
                    type: "boolean"
                  },
                  schoolSACREExemptionEndDate: {
                    type: "string"
                  },
                  schoolAdFeederSchools: {
                    type: "string"
                  },
                  governingBodyConsentEvidenceDocumentLink: {
                    type: "string"
                  },
                  schoolAdEqualitiesImpactAssessmentCompleted: {
                    type: "boolean"
                  },
                  schoolAdEqualitiesImpactAssessmentDetails: {
                    type: "string"
                  },
                  schoolAdInspectedButReportNotPublished: {
                    type: "boolean"
                  },
                  schoolAdInspectedButReportNotPublishedExplain: {
                    type: "string"
                  },
                  schoolAdditionalInformationAdded: {
                    type: "boolean"
                  },
                  schoolAdditionalInformation: {
                    type: "string"
                  },
                  previousFinancialYear: {
                    type: "object",
                    properties: {
                      fyEndDate: {
                        type: "string"
                      },
                      revenueCarryForward: {
                        type: "integer"
                      },
                      revenueIsDeficit: {
                        type: "boolean"
                      },
                      revenueStatusExplained: {
                        type: "string"
                      },
                      capitalCarryForward: {
                        type: "integer"
                      },
                      capitalIsDeficit: {
                        type: "boolean"
                      },
                      capitalStatusExplained: {
                        type: "string"
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
                        type: "integer"
                      },
                      revenueIsDeficit: {
                        type: "boolean"
                      },
                      revenueStatusExplained: {
                        type: "string"
                      },
                      capitalCarryForward: {
                        type: "integer"
                      },
                      capitalIsDeficit: {
                        type: "boolean"
                      },
                      capitalStatusExplained: {
                        type: "string"
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
                        type: "integer"
                      },
                      revenueIsDeficit: {
                        type: "boolean"
                      },
                      revenueStatusExplained: {
                        type: "string"
                      },
                      capitalCarryForward: {
                        type: "integer"
                      },
                      capitalIsDeficit: {
                        type: "boolean"
                      },
                      capitalStatusExplained: {
                        type: "string"
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
                    type: "string"
                  },
                  schoolFinancialInvestigationsTrustAware: {
                    type: "boolean"
                  },
                  schoolCapacityYear1: {
                    type: "integer"
                  },
                  schoolCapacityYear2: {
                    type: "integer"
                  },
                  schoolCapacityYear3: {
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
                    type: "string"
                  },
                  schoolBuildLandWorksPlannedCompletionDate: {
                    type: "string"
                  },
                  schoolBuildLandSharedFacilities: {
                    type: "boolean"
                  },
                  schoolBuildLandSharedFacilitiesExplained: {
                    type: "string"
                  },
                  schoolBuildLandGrants: {
                    type: "boolean"
                  },
                  schoolBuildLandGrantsExplained: {
                    type: "string"
                  },
                  schoolBuildLandPFIScheme: {
                    type: "boolean"
                  },
                  schoolBuildLandPFISchemeType: {
                    type: "string"
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
                  schoolPlanToConsultStakeholders: {
                    type: "string"
                  },
                  declarationBodyAgree: {
                    type: "boolean"
                  },
                  declarationIAmTheChairOrHeadteacher: {
                    type: "boolean"
                  },
                  declarationSignedByName: {
                    type: "string"
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
                  "schoolCapacityYear1",
                  "schoolCapacityYear2",
                  "schoolCapacityYear3",
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