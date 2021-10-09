using System;
using Arrowgene.Buffers;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;
using Arrowgene.Logging;
using Arrowgene.O2Jam.Server.Common;

namespace Arrowgene.O2Jam.Server.PacketHandle
{
    public class LoginHandle : PacketHandler
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(LoginHandle));

        public override PacketId Id => PacketId.LoginReq;

        public override void Handle(Client client, NetPacket packet)
        {
            IBuffer buffer = packet.CreateReadBuffer();
            buffer.Position = 15;
            ushort a = buffer.ReadUInt16();
            if (a > 2)
            {
                byte[] aa = buffer.ReadBytes(a - 2);
                Logger.Info($"aa:{Util.HexDump(aa)}");
            }

            string b = buffer.ReadCString();
            string c = buffer.ReadCString();
            string d = buffer.ReadCString();
            string e = buffer.ReadCString();

            Logger.Info($"b:{b} c:{c} d:{d} e:{e}");

            IBuffer res = new StreamBuffer();
            res.WriteInt32(0);
            res.WriteInt32(0);
            DateTime now = DateTime.Now;
            string nowStr = now.ToString("yyyy-dd-MM hh:mm:ss");
            res.WriteCString(nowStr);
            res.WriteInt32(0);
            ushort value = 0;
            res.WriteUInt16(value);
            if (value != 0)
            {
                res.WriteCString("Test");
            }

            res.WriteInt32(0);
            res.WriteCString("Test2");

            client.Send(res.GetAllBytes(), PacketId.LoginRes);
            //Res_1001_0x03E9 = 1001, // 0x03E9 = 0x00559020 (0x00401000)
        }
    }
}