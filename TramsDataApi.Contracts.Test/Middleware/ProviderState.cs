using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TramsDataApi.Contracts.Test.Middleware
{
    /// <summary>
    /// Provider state DTO
    /// </summary>
    /// <param name="State">State description</param>
    /// <param name="Params">State parameters</param>
    public record ProviderState(string State, IDictionary<string, object> Params);
}
