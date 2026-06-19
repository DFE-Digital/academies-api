export interface PagingResponse {
  page: number;
  recordCount: number;
  nextPageUrl?: string;
}

export interface PagedTrustsResponse {
  data: Trust[];
  paging: PagingResponse;
}

export interface TrustSummaryResponse {
  ukprn: string;
  urn?: string;
  groupName: string;
  companiesHouseNumber?: string;
}

// v1

export interface KeyStagePerformance {
  schoolName: string;
  keyStage1: unknown;
  keyStage2: unknown;
  keyStage4: unknown;
  keyStage5: unknown;
}

// v2 + v3

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

export interface PagedBaselineTrackerResponse {
  data: unknown[];
}

export interface TrustSummaryResponseApiResponseV2 {
  data: TrustSummaryResponse[];
  paging: PagingResponse;
}

export interface TrustResponse {
  ifdData: unknown;
  giasData: {
    groupName: string;
    ukprn: string;
  };
  establishments: Establishment;
}

export interface TrustResponseApiSingleResponseV2 {
  data: TrustResponse;
}

export interface TrustResponseApiResponseV2 {
  data: TrustResponse[];
  paging: PagingResponse;
}

export interface Trust {
  name: string;
  ukprn?: string;
  companiesHouseNumber?: string;
  referenceNumber?: string;
  urn?: string;
}

export interface TrustDto {
  name?: string;
  ukprn?: string;
  companiesHouseNumber?: string;
  referenceNumber?: string;
  gor?: string;
}

export type TrustsByEstablishmentUrnsResponse = Record<string, TrustDto>;

// v4 + v5

export interface Establishment {
  name?: string;
  ukprn?: string;
  urn?: string;
}

export interface Diocese {
  name: string;
  code: string;
}

export interface LocalAuthority {
  name: string;
  code: string;
}

export interface SignificantChange {
  sigChangeId?: number;
  urn?: number;
  deliveryLead?: string;
  academyName?: string;
  trustName?: string;
}

export interface PagedSignificantChangesResponse {
  data: SignificantChange[];
  paging: {
    page: number;
    recordCount: number;
  };
}
