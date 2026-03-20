using System;
using System.Threading;
using System.Threading.Tasks;
using Dfe.Academies.Application.DataLakePoc;
using Dfe.Academies.DataLakePoc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using TramsDataApi.RequestModels;

namespace TramsDataApi.Controllers.V5;

/// <summary>
/// POC endpoints for querying the Databricks data lake via <see cref="IDataLakeQueryService"/>.
/// </summary>
[ApiController]
[ApiVersion("5.0")]
[Route("v{version:apiVersion}/")]
public class DataLakePocController(IDataLakeQueryService dataLakeQueryService, ILogger<DataLakePocController> logger)
    : ControllerBase
{
    /// <summary>
    /// Executes a SQL statement against the configured Databricks SQL warehouse and returns a tabular result.
    /// </summary>
    /// <remarks>
    /// Example request body:
    /// <code>
    /// { "sql": "SELECT 1 AS example_column" }
    /// </code>
    /// Suitable for small result sets (Databricks inline disposition, ~25 MiB limit).
    /// </remarks>
    [HttpPost]
    [Route("datalake/query")]
    [SwaggerOperation(
        Summary = "Execute SQL against Databricks (POC)",
        Description = "Runs SQL via the data lake query service. Configure DatabricksSql in application settings.")]
    [SwaggerResponse(200, "Query completed successfully.", typeof(DatabricksQueryResult))]
    [SwaggerResponse(400, "Request validation failed (e.g. empty SQL).")]
    public async Task<ActionResult<DatabricksQueryResult>> ExecuteSql(
        [FromBody] DataLakeSqlQueryRequest request,
        CancellationToken cancellationToken)
    {
        if (request == null || string.IsNullOrWhiteSpace(request.Sql))
        {
            logger.LogWarning("Data lake query rejected: SQL is missing or empty.");
            return BadRequest("Sql is required.");
        }

        logger.LogInformation("Executing data lake SQL query (length: {Length} characters).", request.Sql.Length);

        try
        {
            var catalog = string.IsNullOrWhiteSpace(request.Catalog) ? null : request.Catalog.Trim();
            var schema = string.IsNullOrWhiteSpace(request.Schema) ? null : request.Schema.Trim();
            var waitTimeout = string.IsNullOrWhiteSpace(request.WaitTimeout) ? null : request.WaitTimeout.Trim();

            var result = await dataLakeQueryService
                .ExecuteSqlAsync(
                    request.Sql.Trim(),
                    catalog,
                    schema,
                    waitTimeout,
                    cancellationToken)
                .ConfigureAwait(false);

            logger.LogInformation(
                "Data lake query returned {RowCount} row(s), {ColumnCount} column(s), truncated: {Truncated}.",
                result.Rows.Count,
                result.ColumnNames.Count,
                result.Truncated);

            return Ok(result);
        }
        catch (InvalidOperationException ex)
        {
            logger.LogWarning(ex, "Data lake query failed.");
            return BadRequest(ex.Message);
        }
    }
}
