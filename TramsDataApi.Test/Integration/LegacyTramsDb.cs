using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Test.Integration
{
    public class LegacyTramsDb : IDisposable
    {
        private readonly LegacyTramsDbContext _legacyTramsDbContext;
        private readonly RandomGenerator _randomGenerator;

        public LegacyTramsDb(LegacyTramsDbContext legacyTramsDbContext)
        {
            _legacyTramsDbContext = legacyTramsDbContext;
            _randomGenerator = new RandomGenerator();
        }

        public IList<Group> AddGroups(int numberOfGroups)
        {
             var groups = Builder<Group>.CreateListOfSize(numberOfGroups)
                .All()
                .With(g => g.Ukprn = _randomGenerator.NextString(8, 8))
                .With(g => g.GroupId = _randomGenerator.NextString(7, 7))
                .With(g => g.GroupName = _randomGenerator.NextString(8, 8))
                .With(g => g.GroupUid = _randomGenerator.Int().ToString())
                .Build();

            _legacyTramsDbContext.Group.AddRange(groups);
           _legacyTramsDbContext.SaveChanges();

            return groups;
         }

        public IList<Trust> AddTrustsFromGroups(IList<Group> groups)
        {
            var trusts = new List<Trust>();
            int index = 1;
            foreach (var group in groups)
            {
                trusts.Add(new Trust { Rid = index.ToString(), TrustRef = group.GroupId });
                index++;
            }
            AddTrusts(trusts);
            return trusts;
        }

        public void AddTrusts(IList<Trust> trusts)
        {
            _legacyTramsDbContext.Trust.AddRange(trusts);
            _legacyTramsDbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _legacyTramsDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _legacyTramsDbContext.RemoveRange(_legacyTramsDbContext.Group);
            _legacyTramsDbContext.RemoveRange(_legacyTramsDbContext.Trust);
            _legacyTramsDbContext.SaveChanges();
        }
    }
}
