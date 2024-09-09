using Dfe.Academies.Academisation.Data;
using Dfe.Academies.Infrastructure.Repositories;
using Dfe.Academies.Domain.Interfaces.Repositories;

namespace Dfe.Academies.Infrastructure
{
    public class MstrRepository<TEntity> : Repository<TEntity, MstrContext>, IMstrRepository<TEntity> where TEntity : class, new()
    {
        public MstrRepository(MstrContext dbContext) : base(dbContext)
        {
        }
    }
}
