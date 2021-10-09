using Arrowgene.Buffers;
using Arrowgene.Logging;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;

namespace Arrowgene.O2Jam.Server.PacketHandle
{
    public class CashHandle : PacketHandler
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(CashHandle));

        public override PacketId Id => PacketId.CashReq;

        public override void Handle(Client client, NetPacket packet)
        {
            IBuffer res = new StreamBuffer();
            res.WriteUInt32(1000);
            res.WriteUInt32(2000);
            client.Send(res.GetAllBytes(), PacketId.CashRes);
            //Res_5029_0x13A5 = 5029, // 0x13A5 = 0x00563900
        }
    }
}