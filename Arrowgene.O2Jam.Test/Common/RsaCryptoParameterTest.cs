using System.Collections.Generic;
using Arrowgene.O2Jam.Server.Common;
using Xunit;
using Xunit.Abstractions;

namespace Arrowgene.O2Jam.Test.Common
{
    public class RsaCryptoParameterTest
    {
        private readonly ITestOutputHelper _output;


        public RsaCryptoParameterTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void TestPotentialEs()
        {
            RsaCryptoParameter cParams = new RsaCryptoParameter(251, 269, 54391, 68711);
            List<int> es = cParams.FindPotentialE(12857, 50946);
            Assert.True(es.Count == 4);
        }
    }
}