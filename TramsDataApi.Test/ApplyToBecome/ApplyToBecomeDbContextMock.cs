using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TramsDataApi.ApplyToBecome;

namespace TramsDataApi.Test.ApplyToBecome
{
    public class ApplyToBecomeDbContextMock : ApplyToBecomeDbContext
    {
        public ManualResetEventSlim ManualResetEvent = new ManualResetEventSlim();
        public Stack<Exception> Exceptions = new Stack<Exception>();

        public ApplyToBecomeDbContextMock(DbContextOptions<ApplyToBecomeDbContext> options) : base(options) { }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            if (Exceptions.Any())
            {
                ManualResetEvent.Set();
                throw Exceptions.Pop();
            }

            var task = await base.SaveChangesAsync(cancellationToken);
            ManualResetEvent.Set();
            return task;
        }

        public override int SaveChanges()
        {
            ManualResetEvent.Reset();
            return base.SaveChanges();
        }
    }
}
