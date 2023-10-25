using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PactNet.Infrastructure.Outputters;
using Xunit.Abstractions;

namespace Dfe.Academies.Contracts.Tests.XUnitHelpers
{
    public class XUnitOutput : IOutput
    {
        private readonly ITestOutputHelper _output;

        public XUnitOutput(ITestOutputHelper output)
        {
            _output = output;
        }
        public void WriteLine(string line)
        {
            _output.WriteLine(line);
        }
    }
}
