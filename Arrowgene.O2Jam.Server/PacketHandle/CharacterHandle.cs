using Arrowgene.Buffers;
using Arrowgene.Logging;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;

namespace Arrowgene.O2Jam.Server.PacketHandle
{
    public class CharacterHandle : PacketHandler
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(CharacterHandle));

        public override PacketId Id => PacketId.CharacterReq;

        public override void Handle(Client client, NetPacket packet)
        {
            IBuffer res = new StreamBuffer();
            // RVA: otwo:base+0x15A396
            res.WriteInt32(0); // if not 0 skip 
            res.WriteCString("Character");
            res.WriteByte(1); // gender
            res.WriteInt32(0);
            res.WriteInt32(0);
            res.WriteInt32(9999);//Cash Point

            // otwo.540C50
            res.WriteInt32(100); //level
            res.WriteInt32(0);
            res.WriteInt32(0);
            res.WriteInt32(0);
            res.WriteInt32(1234);//Exp
            res.WriteInt32(0);
            res.WriteByte(0);

            //int val2 = 0x23;
            // loop start
            res.WriteInt32(1429);//악기(a musical instrument)
            res.WriteInt32(1431);//헤어,모자(Hair,hat)
            res.WriteInt32(0);//소품(Props)
            res.WriteInt32(0);//장갑(Gloves)
            res.WriteInt32(0);//목걸이(Necklace)
            res.WriteInt32(1432);//상의(consultation)
            res.WriteInt32(1433);//하의(Bottom)
            res.WriteInt32(1481);//안경(Glasses)
            res.WriteInt32(0);//귀걸이(Earrings)
            res.WriteInt32(0);//의상소품(Costume props)
            res.WriteInt32(1434);//신발(shoes)

            res.WriteInt32(35);//val2

            res.WriteInt32(1343);//날개(Wings)
            res.WriteInt32(0);//악기소품(Musical instrument props)
            res.WriteInt32(0);//펫(Pet)
            res.WriteInt32(1185);//헤어소품(Hair props)
            res.WriteInt32(1541);//목걸이,코스튬(Necklace, costume)

            //My Bag
            //When there's no My Bag. Only [res.WriteInt32(1);]
            res.WriteInt32(1);//The number of items you own(소유한 내가방 개수 + 1 (a blank space) = 3)
            //
            res.WriteInt32(1501);//Item id [1]
            res.WriteInt32(1502);//Item id [2]
            res.WriteInt32(0);//There must be an empty space(꼭 빈공간이 있어야 한다) [3]
            //
            res.WriteInt32(0);//null

            //Present box
            //When there's no present box. Only [ res.WriteInt16(0); ]
            res.WriteInt16(0);//The number of gifts you own(소유한 선물 개수)
            //
            res.WriteInt32(0);//?
            res.WriteInt32(1501);//Item id
            res.WriteCString("Test");//The person who gave it to me as a gift(선물해주신분 닉네임)

            res.WriteInt32(0);
            res.WriteInt32(1502);
            res.WriteCString("Test1");
            //
            res.WriteInt16(0);
            res.WriteInt32(0);
            res.WriteInt32(0);
            //
            res.WriteInt32(9999);//Cash Point

            //item rings
            //When there's no rings. Only [ res.WriteInt32(0); ]
            res.WriteInt32(0);//The number of rings you own(소유한 반지 개수)
            //
            res.WriteInt32(1501);//Ring item id(링 아이템 번호)
            res.WriteInt32(999);//The number of rings(링 개수)
            
            res.WriteInt32(1502);
            res.WriteInt32(999);
            //
            res.WriteInt16(98);//The number of penalties(패널티 횟수)
            res.WriteInt16(9);//Penalty level(패널티 레벨)

            client.Send(res.GetAllBytes(), PacketId.CharacterRes);
            //Res_2001_0x07D1 = 2001, // 0x07D1 = 0x0055A350
        }
    }
}