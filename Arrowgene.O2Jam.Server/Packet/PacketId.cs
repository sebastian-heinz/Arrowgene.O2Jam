namespace Arrowgene.O2Jam.Server.Packet
{
    public enum PacketId : ushort
    {
        Unknown = 0,
        
        LoginReq = 1000,       // 0x03E8
        LoginRes = 1001,       // 0x03E9
        PlanetReq = 1002,      // 0x03EA
        PlanetRes = 1003,      // 0x03EB
        ChannelReq = 1004,     // 0x03EC
        ChannelRes = 1005,     // 0x03ED
        
        CharacterReq = 2000,   // 0x07D0
        CharacterRes = 2001,   // 0x07D1
        RoomListReq = 2002,    // 0x07D2
        RoomListRes = 2003,    // 0x07D3
        
        Room1Req = 2010,       // 0x07DA
        Room1Res = 2011,       // 0x07DB
        
        UnkRes = 2026,         // 0x07EA
        
        MusicListReq = 4030,   // 0x0FBE
        MusicListRes = 4031,   // 0x0FBF
        
        CashReq = 5028,        // 0x13A4
        CashRes = 5029,        // 0x13A5
        
        PingReq = 6001,        // 0x1771
        PingRes = 6001,        // 0x1771
        
        DisconnectReq = 65520, // 0xFFF0
    }
}