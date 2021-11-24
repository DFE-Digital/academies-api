using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels.ApplyToBecome;

namespace TramsDataApi.Gateways
{
    public class A2BApplicationKeyPersonsGateway : IA2BApplicationKeyPersonsGateway
    {
        private readonly TramsDbContext _tramsDbContext;
        
        public A2BApplicationKeyPersonsGateway(TramsDbContext tramsDbContext)
        {
            _tramsDbContext = tramsDbContext;
        }
        
        public A2BApplicationKeyPersons GetByKeyPersonsId(int keyPersonsId)
        {
            return _tramsDbContext.A2BApplicationKeyPersons
                .AsNoTracking()
                .FirstOrDefault(k => k.KeyPersonId == keyPersonsId);
        }

        public A2BApplicationKeyPersons CreateA2BApplicationKeyPersons(A2BApplicationKeyPersons keyPersons)
        {
            _tramsDbContext.A2BApplicationKeyPersons.Add(keyPersons);
            _tramsDbContext.SaveChanges();

            return keyPersons;
        }
    }
}