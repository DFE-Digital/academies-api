﻿using Dfe.Academies.Domain.Interfaces.Repositories;
using Dfe.Academies.Domain.EducationalPerformance;
using DfE.CoreLibs.Contracts.Academies.V1.EducationalPerformance;

namespace Dfe.Academies.Application.EducationalPerformance
{
    public class EducationalPerformanceQueries : IEducationalPerformanceQueries
    {
        private readonly IEducationalPerformanceRepository _educationPerformanceRepository;

        public EducationalPerformanceQueries(IEducationalPerformanceRepository educationPerformanceRepository)
        {
            this._educationPerformanceRepository = educationPerformanceRepository;
        }
        public async Task<List<SchoolAbsenceDataDto>> GetSchoolAbsenceDataByUrn(string urn, CancellationToken cancellationToken)
        {
            var absenceData = await _educationPerformanceRepository.GetSchoolAbsencesByURN(urn, cancellationToken);

            if (absenceData == null)
            {
                return new ();
            }

            return MapToSchoolAbsenceDataDto(absenceData);
        }

        private List<SchoolAbsenceDataDto> MapToSchoolAbsenceDataDto(List<SchoolAbsence> schoolAbsences)
        {
            var schoolAbsenceDataDtos = new List<SchoolAbsenceDataDto>();

            foreach (var schoolAbsence in schoolAbsences)
            {
                schoolAbsenceDataDtos.Add(new SchoolAbsenceDataDto()
                {
                    OverallAbsence = schoolAbsence.PERCTOT,
                    PersistentAbsence = schoolAbsence.PPERSABS10,
                    Year = schoolAbsence.DownloadYear
                });
            }

            return schoolAbsenceDataDtos;
        }
    }
}
