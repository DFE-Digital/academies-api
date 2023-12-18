using Dfe.Academies.Academisation.Data;
using Dfe.Academies.Domain.Trust;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TramsDataApi.Test.Helpers
{
    public static class MstrContextExtensions
    {
        public static long GetNextTrustId(this MstrContext context)
        {
            var trustMaxId = context.Trusts.Max(t => t.SK);

            if (trustMaxId == null)
                return 1;

            return (long)trustMaxId + 1;
        }
    }
}
