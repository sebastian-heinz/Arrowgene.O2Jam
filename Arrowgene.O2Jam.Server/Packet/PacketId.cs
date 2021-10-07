namespace Arrowgene.O2Jam.Server.Packet
{
    public enum PacketId : ushort
    {
        Unknown = 0,

        LoginReq = 1000,           // 0x03E8
        LoginRes = 1001,           // 0x03E9
        PlanetReq = 1002,          // 0x03EA
        PlanetRes = 1003,          // 0x03EB
        ChannelReq = 1004,         // 0x03EC
        ChannelRes = 1005,         // 0x03ED

        CharacterReq = 2000,       // 0x07D0
        CharacterRes = 2001,       // 0x07D1
        RoomListReq = 2002,        // 0x07D2
        RoomListRes = 2003,        // 0x07D3
        CreateRoomReq = 2004,      // 0x07D4
        AnnounceRoomRes = 2005,    // 0x07D5
        CreateRoomRes = 2006,      // 0x07D6
        Room1Req = 2010,           // 0x07DA
        Room1Res = 2011,           // 0x07DB

        WaitRoomBackReq = 2021,
        WaitRoomBackRes = 2022,

        UnkRes = 2026,             // 0x07EA

        RoomBackReq = 3005,
        RoomBackRes = 3006,

        RoomSongSelectReq = 4000,  // 0x0FA0
        RoomSongSelectRes = 4001,  // 0x0FA1
        RoomColorSelectReq = 4004, // 0x0FA4
        RoomColorSelectRes = 4005, // 0x0FA5
        StartGameReq = 4010,       // 0x0FAA
        StartGameRes = 4011,       // 0x0FAB

        InGameBackReq = 4021,
        InGameBackRes = 4022,

        RoomUnknown1Req = 4023,    // 0x0FB7
        RoomUnknown1Res = 4024,    // 0x0FB8
        RoomUnknown2Req = 4025,    // 0x0FB9
        RoomUnknown2Res = 4026,    // 0x0FBA
        MusicListReq = 4030,       // 0x0FBE
        MusicListRes = 4031,       // 0x0FBF
        GameCheck2Req = 4048,      // 0x0FD0
        GameCheck2Res = 4049,      // 0x0FD1

        InGameStartRes = 4050,     // 0x0FD2

        GameCheck1Req = 4055,      // 0x0FD7
        GameCheck1Res = 4056,      // 0x0FD8
        
        CashReq = 5028,            // 0x13A4
        CashRes = 5029,            // 0x13A5

        PingReq = 6001,            // 0x1771
        PingRes = 6001,            // 0x1771

        DisconnectReq = 65520,     // 0xFFF0
    }
}