using System;
using Arrowgene.Buffers;
using Arrowgene.Logging;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;

namespace Arrowgene.O2Jam.Server.PacketHandle
{
    public class GameCheck2Handle : PacketHandler
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(GameCheck2Handle));

        public override PacketId Id => PacketId.GameCheck2Req;

        public override void Handle(Client client, NetPacket packet)
        {
            IBuffer res = new StreamBuffer();
            // client read 14bytes
            byte[] data = new byte[14];
            res.WriteBytes(data);
            client.Send(res.GetAllBytes(), PacketId.GameCheck2Res);
        }
    }
}