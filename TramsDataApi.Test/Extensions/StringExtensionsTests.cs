using TramsDataApi.Extensions;
using Xunit;

namespace TramsDataApi.Test.Extensions
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData("123", 123)]
        [InlineData("456", 456)]
        [InlineData("0", 0)]
        [InlineData("-789", -789)]
        [InlineData("abc", 0)]  // Invalid string
        [InlineData(null, 0)]   // Null string
        [InlineData("", 0)]     // Empty string
        public void ToInt_ReturnsExpectedResult(string input, int expectedResult)
        {
            // Act
            int result = input.ToInt();

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
