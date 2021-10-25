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

        private readonly string _encrypted_argument_1 =
            "00C70200E85000DF8E00E85000CA9300F1A60096B800043E00811000717E0096B80099FC0013FD00CB8300A40C006E4200B96E00B705003F1600BF7500ADFE001B2000C4C100C5F30099F4005BBD00384F00F70800EEB500B9AF00C19100D50B00EEB50086CF00D83B00EBCF00639B00E83600DF6F005FB300192000583200637E001ABB00512000717E001A6800774100A50700A40C0000D800ED6E00C534006F880078BF006C3300ED0200AF02008D8C006EF6003C0900191000ED6E002C47005DC200192000FB5800A40C00CB8300DD38002C4700316A00F70800774100B11800A876006F8800280E00854E00F27600C2AA00AE6F00781200170E006351001B1700A40C0053AF0104BF0087CB004E1700923E00B6A000D83F00FAC700ADFE007205000B8200746300E32E0014D9004DEA00531C00DAD600E812000BB30002CC00CC050028B40097B600012400980A00CEC4004D5F00C2AA00AE6F000029001D99002970003F1600BF7500EFDC";

        private readonly string _decrypted_argument_1 =
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
            string argument = cArgs.GetArgumentString();
            Assert.Equal(_expected_argument, argument);
        }

        [Fact]
        public void TestDecryption()
        {
            ClientStartupArguments cArgs = new ClientStartupArguments();
            string decrypted = cArgs.Decrypt(_encrypted_argument_1);
            Assert.Equal(_decrypted_argument_1, decrypted);
        }

        [Fact]
        public void TestEncryption()
        {
            ClientStartupArguments cArgs = new ClientStartupArguments();
            string encrypted = cArgs.Encrypt(_decrypted_argument_1);
            Assert.Equal(_encrypted_argument_1, encrypted);
        }
    }
}