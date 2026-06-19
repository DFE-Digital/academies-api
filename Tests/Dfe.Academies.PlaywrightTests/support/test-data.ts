export const keyStagePerformanceTestData = {
  urn: '100000',
  schoolName: 'The Aldgate School',
} as const;

export const trustTestData = {
  companiesHouseNumber: '11082297',
  ukprns: ['10067112', '10067113'],
  groupName: 'SOUTH YORK MULTI ACADEMY TRUST',
  secondTrustName: 'THE BISHOP FRASER TRUST',
  trustReferenceNumber: 'TR03739',
  urns: [116868, 116332],
} as const;

export const v3TrustTestData = {
  companiesHouseNumber: '11082297',
  ukprn: '10067112',
  groupName: 'SOUTH YORK MULTI ACADEMY TRUST',
} as const;

export const establishmentTestData = {
  name: 'The Aldgate School',
  trustUkprn: 10058885,
  ukprns: ['10079319', '10018890'],
  urns: [100000, 100002],
} as const;

export const dioceseTestData = {
  name: 'Diocese of London',
  code: 'CE23',
} as const;

export const localAuthorityTestData = {
  name: 'City of London',
  code: '201',
} as const;

export const significantChangeTestData = {
  deliveryOfficer: 'Guest',
} as const;
