using Arrowgene.Buffers;
using Arrowgene.Logging;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;

namespace Arrowgene.O2Jam.Server.PacketHandle
{
    public class RoomApplySkill : PacketHandler
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(RoomApplySkill));

        public override PacketId Id => PacketId.RoomUnknown1Req;

        public override void Handle(Client client, NetPacket packet)
        {
            IBuffer buffer = packet.CreateReadBuffer();
            int CountApply = buffer.ReadInt32();
            int Arrange = buffer.ReadInt32();
            int Visibility = buffer.ReadInt32();

            Logger.Info($"[CountApply:{CountApply}][Arrange:{Arrange}][Visibility:{Visibility}]");
            
            IBuffer res = new StreamBuffer();
            res.WriteInt32(CountApply);
            res.WriteInt32(Arrange);
            res.WriteInt32(Visibility);
            client.Send(res.GetAllBytes(), PacketId.RoomUnknown1Res);
            //Res_4024_0x0FB8 = 4024, // 0x0FB8 = 0x005602A0
        }
    }
}