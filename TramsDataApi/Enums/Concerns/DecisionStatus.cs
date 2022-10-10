using System;
using System.ComponentModel;

namespace TramsDataApi.Enums.Concerns
{
    [Obsolete("This endpoint is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public enum DecisionStatus
    {
        InProgress = 1,
        Closed = 2,
    }
}
