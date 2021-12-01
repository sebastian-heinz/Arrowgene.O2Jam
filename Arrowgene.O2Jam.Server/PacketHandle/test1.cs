using System;
using Arrowgene.Buffers;
using Arrowgene.Logging;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;

namespace Arrowgene.O2Jam.Server.PacketHandle
{
    public class test1 : PacketHandler
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(test1));

        public override PacketId Id => PacketId.test1Req;

        public override void Handle(Client client, NetPacket packet)
        {
            //IBuffer res = new StreamBuffer();
            //res.WriteByte(0);
            //client.Send(res.GetAllBytes(), PacketId.test1Res);
        }
    }
}