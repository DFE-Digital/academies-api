﻿namespace Dfe.Academies.Contracts.Tests.Middleware
{
    /// <summary>
    /// Provider state DTO
    /// </summary>
    /// <param name="State">State description</param>
    /// <param name="Params">State parameters</param>
    public record ProviderState(string State, IDictionary<string, Object> Params);
}
