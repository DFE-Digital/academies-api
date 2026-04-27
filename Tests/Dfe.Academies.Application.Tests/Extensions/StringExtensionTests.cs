using Dfe.Academies.Utils.Extensions;

namespace Dfe.Academies.Application.Tests.Extensions;

public class StringExtensionTests
{

    [Theory]
    [InlineData("John Smith", "JSmith")]
    [InlineData("john7 doe", "Jdoe7")]
    [InlineData("JOHN michael doe", "Jdoe")]
    [InlineData("7 Smith", "Smith7")] 
    public void ToAdName_StandardNames(string input, string expected)
    {
        Assert.Equal(expected, input.ToAdName());
    } 
}
