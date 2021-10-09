using Arrowgene.Buffers;
using Arrowgene.Logging;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;

namespace Arrowgene.O2Jam.Server.PacketHandle
{
    public class LobbyChat : PacketHandler
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(LobbyChat));

        public override PacketId Id => PacketId.LobbyChatReq;

        public override void Handle(Client client, NetPacket packet)
        {
            //2013 로비 일반 채팅 (Lobby normal chatting)
            //2016 공지 사항 (Notice)
            //2018 [님에게]메세지를 보내지 못했습니다 ([To you] I couldn't send you a message)
            //2019 귓속말 받은거 (Whispering I got)
            IBuffer res = new StreamBuffer();
            res.WriteByte(1);
            client.Send(res.GetAllBytes(), PacketId.LobbyChatRes);
        }
    }
}