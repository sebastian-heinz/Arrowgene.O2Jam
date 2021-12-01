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
            res.WriteByte(0);
            res.WriteByte(0);
            res.WriteByte(0);
            res.WriteByte(0);

            res.WriteByte(32);//1=pc room 32=자유이용권  //Ticket to use all the songs.
            res.WriteByte(0);
            res.WriteByte(0);
            res.WriteByte(0);
            DateTime now = DateTime.Now;
            string nowStr = now.ToString("yyyy-dd-MM hh:mm:ss"); //The period of use of all the songs.
            res.WriteCString(nowStr);

            res.WriteByte(255);
            res.WriteByte(255);
            res.WriteByte(255);
            res.WriteByte(255);

            ushort value = 0;//O2스타터 뮤직세트

            res.WriteUInt16(value);
            if (value != 0)
            {
                res.WriteCString("Test");
            }

            res.WriteByte(1);//무한 반지
            res.WriteByte(0);
            res.WriteByte(0);
            res.WriteByte(0);
            res.WriteCString("Test2");
            
            res.WriteByte(255);
            res.WriteByte(255);
            res.WriteByte(255);
            res.WriteByte(255);

            client.Send(res.GetAllBytes(), PacketId.LoginRes);
            //Res_1001_0x03E9 = 1001, // 0x03E9 = 0x00559020 (0x00401000)
        }
    }
}