export interface PagedTrustsResponse {
  data: Trust[];
  paging: {
    page: number;
  };
}

export interface Trust {
  name: string;
  ukprn?: string;
  companiesHouseNumber?: string;
  referenceNumber?: string;
}

export interface Establishment {
  name?: string;
  ukprn?: string;
  urn?: string;
}

export interface V3Trust {
  groupName: string;
  companiesHouseNumber?: string;
}

export interface V3TrustByUkprnResponse {
  data: {
    trustData: unknown;
    giasData: {
      groupName: string;
    };
    establishments: unknown;
  };
}

export interface KeyStagePerformance {
  schoolName: string;
  keyStage1: unknown;
  keyStage2: unknown;
  keyStage4: unknown;
  keyStage5: unknown;
}

export interface PagedBaselineTrackerResponse {
  data: unknown[];
}

export interface FssProjectsResponse {
  data: Array<{
    localAuthority: unknown;
    projectId: unknown;
    projectStatus: unknown;
    trustId: unknown;
    trustName: unknown;
    urn: unknown;
  }>;
}
