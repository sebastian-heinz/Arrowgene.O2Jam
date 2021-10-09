using System;
using Arrowgene.Buffers;
using Arrowgene.Logging;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;

namespace Arrowgene.O2Jam.Server.PacketHandle
{
    public class StartGameHandle : PacketHandler
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(StartGameHandle));

        public override PacketId Id => PacketId.StartGameReq;

        public override void Handle(Client client, NetPacket packet)
        {
            IBuffer res = new StreamBuffer();
            res.WriteInt32(0);
            res.WriteInt32(0);
            client.Send(res.GetAllBytes(), PacketId.StartGameRes);
            //Res_4011_0x0FAB = 4011, // 0x0FAB = 0x0055F630
        }
    }
}