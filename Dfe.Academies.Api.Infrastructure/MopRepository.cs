﻿using Dfe.Academies.Academisation.Data;
using Dfe.Academies.Application.Common.Interfaces;
using Dfe.Academies.Infrastructure.Repositories;

namespace Dfe.Academies.Infrastructure
{
    public class MopRepository<TEntity> : Repository<TEntity, MopContext>, IMopRepository<TEntity> where TEntity : class, new()
    {
        public MopRepository(MopContext dbContext) : base(dbContext)
        {
        }
    }
}
