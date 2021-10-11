using Arrowgene.O2Jam.Server.Common;
using Xunit;
using Xunit.Abstractions;

namespace Arrowgene.O2Jam.Test.Common
{
    public class ClientStartupArgumentsTest
    {
        private readonly ITestOutputHelper _output;

        private readonly string _expected_argument =
            "29121.125.76.135|121.125.76.136022105O2Jam05O2Jam048.05081374159810crioncross1012345678900219011081374159816user@mail.domain15203.238.136.182051501102-116o2jam.nopp.co.kr0613730757http://o2jam.nopp.co.kr/client/bbs_patch_notice_nopp.html05O2JAM";


        public ClientStartupArgumentsTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void TestToString()
        {
            ClientStartupArguments cArgs = new ClientStartupArguments();
            cArgs.P1.Add("121.125.76.135");
            cArgs.P1.Add("121.125.76.136");
            cArgs.P2 = 21;
            cArgs.P3 = "O2Jam";
            cArgs.P4 = "O2Jam";
            cArgs.P5 = 8.05f;
            cArgs.P6 = "13741598";
            cArgs.AccountName = "crioncross";
            cArgs.P8 = "1234567890";
            cArgs.P9 = "19";
            cArgs.P10 = "1";
            cArgs.P11 = "13741598";
            cArgs.Email = "user@mail.domain";
            cArgs.P13 = "203.238.136.182";
            cArgs.P14 = "15011";
            cArgs.P15 = "-1";
            cArgs.P16 = "o2jam.nopp.co.kr";
            cArgs.P17 = "137307";
            cArgs.P18 = "http://o2jam.nopp.co.kr/client/bbs_patch_notice_nopp.html";
            cArgs.P19 = "O2JAM";
            

            string argument = cArgs.ToString();
            Assert.Equal(_expected_argument, argument);
        }
    }
}