using Dfe.Academies.Academisation.Data;
using Dfe.Academies.Application.Common.Interfaces;
using Dfe.Academies.Infrastructure.Repositories;

namespace Dfe.Academies.Infrastructure
{
    public class MstrRepository<TEntity> : Repository<TEntity, MstrContext>, IMstrRepository<TEntity> where TEntity : class, new()
    {
        public MstrRepository(MstrContext dbContext) : base(dbContext)
        {
        }
    }
}
