using Arrowgene.Buffers;
using Arrowgene.Logging;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;

namespace Arrowgene.O2Jam.Server.PacketHandle
{
    public class LobbyBackButton : PacketHandler
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(LobbyBackButton));

        public override PacketId Id => PacketId.LobbyBackButtonReq;

        public override void Handle(Client client, NetPacket packet)
        {
            IBuffer res = new StreamBuffer();
            res.WriteByte(0);
            client.Send(res.GetAllBytes(), PacketId.LobbyBackButtonRes);
            //Res_2022_0x07E6 = 2022, // 0x07E6 = 0x0055C660
        }
    }
}