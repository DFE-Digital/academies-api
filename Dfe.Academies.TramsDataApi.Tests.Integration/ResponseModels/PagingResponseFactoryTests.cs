using Microsoft.AspNetCore.Http;
using TramsDataApi.ResponseModels;

namespace Dfe.Academies.TramsDataApi.Tests.Integration.ResponseModels
{
    public class PagingResponseFactoryTests
    {
        [Fact]
        public void Create_ShouldReturnPagingResponse_WithNextPageUrl_WhenMoreRecordsExist()
        {
            // Arrange
            int page = 1;
            int count = 10;
            int recordCount = 25;

            var context = new DefaultHttpContext();
            var request = context.Request;
            request.Path = "/api/items";
            request.QueryString = new QueryString("?filter=test");

            // Act
            var result = PagingResponseFactory.Create(page, count, recordCount, request);

            // Assert
            Assert.Equal(recordCount, result.RecordCount);
            Assert.Equal(page, result.Page);
            Assert.NotNull(result.NextPageUrl);
            Assert.Contains("page=2", result.NextPageUrl);
            Assert.Contains("count=10", result.NextPageUrl);
            Assert.Contains("filter=test", result.NextPageUrl);
        }

        [Fact]
        public void Create_ShouldReturnPagingResponse_WithoutNextPageUrl_WhenNoMoreRecords()
        {
            // Arrange
            int page = 3;
            int count = 10;
            int recordCount = 25;

            var context = new DefaultHttpContext();
            var request = context.Request;
            request.Path = "/api/items";
            request.QueryString = new QueryString("?filter=test");

            // Act
            var result = PagingResponseFactory.Create(page, count, recordCount, request);

            // Assert
            Assert.Equal(recordCount, result.RecordCount);
            Assert.Equal(page, result.Page);
            Assert.Null(result.NextPageUrl);
        }

        [Fact]
        public void CreateV4PagingResponse_NoNextPage_ReturnsCorrectResponse()
        {
            // Arrange
            int count = 10;
            int recordCount = 25;
            int page = 3; 
            var request = new DefaultHttpContext().Request;
            request.Path = "/test";
            request.QueryString = new QueryString("?foo=bar");

            // Act
            var result = PagingResponseFactory.CreateV4PagingResponse(page, count, recordCount, request);

            // Assert
            Assert.Equal(page, result.Page);
            Assert.Equal(recordCount, result.RecordCount);
            Assert.Null(result.NextPageUrl); // No next page
        }

        [Fact]
        public void CreateV4PagingResponse_HasNextPage_ConstructsNextPageUrl()
        {
            // Arrange
            int page = 1;
            int count = 10;
            int recordCount = 50;
            var request = new DefaultHttpContext().Request;
            request.Path = "/test";
            request.QueryString = new QueryString("?foo=bar&count=10&page=1");

            // Act
            var result = PagingResponseFactory.CreateV4PagingResponse(page, count, recordCount, request);

            // Assert
            Assert.Equal(page, result.Page);
            Assert.Equal(recordCount, result.RecordCount);
            Assert.NotNull(result.NextPageUrl);
            Assert.Contains("page=2", result.NextPageUrl); 
            Assert.Contains("count=10", result.NextPageUrl);
            Assert.Contains("foo=bar", result.NextPageUrl); 
        }

        [Fact]
        public void CreateV4PagingResponse_IgnoresPageAndCountInQuery()
        {
            // Arrange
            int page = 1;
            int count = 5;
            int recordCount = 20; 
            var request = new DefaultHttpContext().Request;
            request.Path = "/test";
            request.QueryString = new QueryString("?page=old&count=old&bar=baz");

            // Act
            var result = PagingResponseFactory.CreateV4PagingResponse(page, count, recordCount, request);

            // Assert
            Assert.Contains("page=2", result.NextPageUrl);
            Assert.Contains("count=5", result.NextPageUrl); 
            Assert.Contains("bar=baz", result.NextPageUrl); 
            Assert.DoesNotContain("page=old", result.NextPageUrl);
            Assert.DoesNotContain("count=old", result.NextPageUrl);
        }
    }
}
