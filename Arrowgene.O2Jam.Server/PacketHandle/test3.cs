using System;
using Arrowgene.Buffers;
using Arrowgene.Logging;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;

namespace Arrowgene.O2Jam.Server.PacketHandle
{
    public class test3 : PacketHandler
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(test3));

        public override PacketId Id => PacketId.test3Req;

        public override void Handle(Client client, NetPacket packet)
        {
            IBuffer res = new StreamBuffer();
            res.WriteByte(0);
            res.WriteByte(0);
            res.WriteByte(0);
            res.WriteByte(0);

            res.WriteByte(0xdd);//랜덤반지
                res.WriteByte(0x05);
                res.WriteByte(0);
                res.WriteByte(0);

                res.WriteByte(0xdd);//랜덤반지
                res.WriteByte(0x05);
                res.WriteByte(0);
                res.WriteByte(0);

                res.WriteByte(0xdd);//랜덤반지
                res.WriteByte(0x05);
                res.WriteByte(0);
                res.WriteByte(0);
            client.Send(res.GetAllBytes(), PacketId.test3Res);
        }
    }
}