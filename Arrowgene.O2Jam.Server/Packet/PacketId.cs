namespace Arrowgene.O2Jam.Server.Packet
{
    public enum PacketId : ushort
    {
        Unknown = 0,

        LoginReq = 1000,
        LoginRes = 1001,
        PlanetReq = 1002,
        PlanetRes = 1003,
        ChannelReq = 1004,
        ChannelRes = 1005,

        CharacterReq = 2000,
        CharacterRes = 2001,
        RoomListReq = 2002,
        RoomListRes = 2003,
        CreateRoomReq = 2004,
        AnnounceRoomRes = 2005,
        CreateRoomRes = 2006,
        Room1Req = 2010,
        Room1Res = 2011,
        LobbyBackButtonReq = 2021,
        LobbyBackButtonRes = 2022,
        RoomSongSelectButton1Req = 2030,
        RoomSongSelectButton1Res = 2031,
        UnkRes = 2026,

        RoomBackButtonReq = 3005,
        RoomBackButtonRes = 3006,

        RoomSongSelectReq = 4000,
        RoomSongSelectRes = 4001,
        RoomColorSelectReq = 4004,
        RoomColorSelectRes = 4005,
        StartGameReq = 4010,
        StartGameRes = 4011,
        InGameBackButtonReq = 4021,
        InGameBackButtonRes = 4022,
        RoomUnknown1Req = 4023,
        RoomUnknown1Res = 4024,
        RoomUnknown2Req = 4025,
        RoomUnknown2Res = 4026,
        MusicListReq = 4030,
        MusicListRes = 4031,
        GameCheck2Req = 4048,
        GameCheck2Res = 4049,
        InGameStartRes = 4050,
        RoomSongSelectButton2Req = 4051,
        RoomSongSelectButton2Res = 4052,
        RoomSongSelectCheckButtonReq = 4053,
        RoomSongSelectCheckButtonRes = 4054,
        GameCheck1Req = 4055,
        GameCheck1Res = 4056,

        CashReq = 5028,
        CashRes = 5029,

        PingReq = 6001,
        PingRes = 6001,

        DisconnectReq = 65520,

        InGameRankingReq = 4014,
        InGameRankingRes = 4015,
        Resalt1Req = 4016,
        Resalt1Res = 4017,
        Resalt2Res = 4018,

        LobbyChatReq = 2012,
        LobbyChatRes = 2013,


        // Reference

        //Res_1001_0x03E9 = 1001, // 0x03E9 = 0x00559020 (0x00401000)
        //Res_1003_0x03EB = 1003, // 0x03EB = 0x00559FF0
        //Res_1005_0x03ED = 1005, // 0x03ED = 0x0055A110

        //Res_2001_0x07D1 = 2001, // 0x07D1 = 0x0055A350
        //Res_2003_0x07D3 = 2003, // 0x07D3 = 0x0055B710
        //Res_2005_0x07D5 = 2005, // 0x07D5 = 0x0055B9A0
        Res_2006_0x07D6 = 2006, // 0x07D6 = 0x0055BB40
        Res_2007_0x07D7 = 2007, // 0x07D7 = 0x0055BC60
        Res_2008_0x07D8 = 2008, // 0x07D8 = 0x0055BCB0
        Res_2009_0x07D9 = 2009, // 0x07D9 = 0x0055BDF0
        //Res_2011_0x07DB = 2011, // 0x07DB = 0x0055BEC0
        Res_2013_0x07DD = 2013, // 0x07DD = 0x0055BFA0
        Res_2014_0x07DE = 2014, // 0x07DE = 0x0055C020
        Res_2016_0x07E0 = 2016, // 0x07E0 = 0x0055C0A0
        Res_2018_0x07E2 = 2018, // 0x07E2 = 0x0055C190
        Res_2019_0x07E3 = 2019, // 0x07E3 = 0x0055C280
        Res_2020_0x07E4 = 2020, // 0x07E4 = 0x0055C600
        //Res_2022_0x07E6 = 2022, // 0x07E6 = 0x0055C660
        Res_2023_0x07E7 = 2023, // 0x07E7 = 0x0055C790
        Res_2025_0x07E9 = 2025, // 0x07E9 = 0x0055C940
        Res_2026_0x07EA = 2026, // 0x07EA = 0x0055A9A0
        Res_2028_0x07EC = 2028, // 0x07EC = 0x0055B230
        Res_2029_0x07ED = 2029, // 0x07ED = 0x0055B4D0
        //Res_2031_0x07EF = 2031, // 0x07EF = 0x0055B590
        Res_2033_0x07F1 = 2033, // 0x07F1 = 0x0055B640
        Res_2035_0x07F3 = 2035, // 0x07F3 = 0x0055B6D0

        Res_3001_0x0BB9 = 3001, // 0x0BB9 = 0x0055CA00
        Res_3003_0x0BBB = 3003, // 0x0BBB = 0x0055CAD0
        Res_3004_0x0BBC = 3004, // 0x0BBC = 0x0055D420
        //Res_3006_0x0BBE = 3006, // 0x0BBE = 0x0055D700
        Res_3007_0x0BBF = 3007, // 0x0BBF = 0x0055D820
        Res_3009_0x0BC1 = 3009, // 0x0BC1 = 0x0055E120
        Res_3010_0x0BC2 = 3010, // 0x0BC2 = 0x0055E2F0
        Res_3012_0x0BC4 = 3012, // 0x0BC4 = 0x0055E740
        Res_3013_0x0BC5 = 3013, // 0x0BC5 = 0x0055ECA0
        Res_3014_0x0BC6 = 3014, // 0x0BC6 = 0x0055F210

        //Res_4001_0x0FA1 = 4001, // 0x0FA1 = 0x0055F2D0
        Res_4003_0x0FA3 = 4003, // 0x0FA3 = 0x0055F3C0
        //Res_4005_0x0FA5 = 4005, // 0x0FA5 = 0x0055F3F0
        Res_4007_0x0FA7 = 4007, // 0x0FA7 = 0x0055F470
        Res_4009_0x0FA9 = 4009, // 0x0FA9 = 0x0055F5B0
        //Res_4011_0x0FAB = 4011, // 0x0FAB = 0x0055F630
        Res_4013_0x0FAD = 4013, // 0x0FAD = 0x0055F950
        //Res_4015_0x0FAF = 4015, // 0x0FAF = 0x0055FA20
        //Res_4017_0x0FB1 = 4017, // 0x0FB1 = 0x0055FBA0
        //Res_4018_0x0FB2 = 4018, // 0x0FB2 = 0x0055FBE0
        Res_4022_0x0FB6 = 4022, // 0x0FB6 = 0x00560160
        //Res_4024_0x0FB8 = 4024, // 0x0FB8 = 0x005602A0
        //Res_4026_0x0FBA = 4026, // 0x0FBA = 0x00560960
        Res_4028_0x0FBC = 4028, // 0x0FBC = 0x00560A00
        Res_4029_0x0FBD = 4029, // 0x0FBD = 0x0055FF00
        //Res_4031_0x0FBF = 4031, // 0x0FBF = 0x005593B0
        Res_4035_0x0FC3 = 4035, // 0x0FC3 = 0x005598B0
        Res_4037_0x0FC5 = 4037, // 0x0FC5 = 0x00559990
        Res_4039_0x0FC7 = 4039, // 0x0FC7 = 0x00559A10
        Res_4040_0x0FC8 = 4040, // 0x0FC8 = 0x00559A60
        Res_4043_0x0FCB = 4043, // 0x0FCB = 0x00559B50
        Res_4045_0x0FCD = 4045, // 0x0FCD = 0x00563D70
        Res_4047_0x0FCF = 4047, // 0x0FCF = 0x00563D90
        //Res_4049_0x0FD1 = 4049, // 0x0FD1 = 0x00563DB0
        //Res_4050_0x0FD2 = 4050, // 0x0FD2 = 0x00563FE0
        //Res_4052_0x0FD4 = 4052, // 0x0FD4 = 0x00563D10
        //Res_4054_0x0FD6 = 4054, // 0x0FD6 = 0x00563D30
        //Res_4056_0x0FD8 = 4056, // 0x0FD8 = 0x00563D50
        Res_4058_0x0FDA = 4058, // 0x0FDA = 0x00560600

        Res_5003_0x138B = 5003, // 0x138B = 0x00560C80
        Res_5005_0x138D = 5005, // 0x138D = 0x00560CF0
        Res_5011_0x1393 = 5011, // 0x1393 = 0x00560D70
        Res_5014_0x1396 = 5014, // 0x1396 = 0x00562E40
        Res_5016_0x1398 = 5016, // 0x1398 = 0x00562E90
        Res_5018_0x139A = 5018, // 0x139A = 0x00562EB0
        Res_5024_0x13A0 = 5024, // 0x13A0 = 0x00563010
        Res_5026_0x13A2 = 5026, // 0x13A2 = 0x005631B0
        Res_5027_0x13A3 = 5027, // 0x13A3 = 0x00563880
        //Res_5029_0x13A5 = 5029, // 0x13A5 = 0x00563900
        Res_5031_0x13A7 = 5031, // 0x13A7 = 0x00563950
        Res_5033_0x13A9 = 5033, // 0x13A9 = 0x005639A0
        Res_5035_0x13AB = 5035, // 0x13AB = 0x00563A20
        Res_5037_0x13AD = 5037, // 0x13AD = 0x00563A60
        Res_5039_0x13AF = 5039, // 0x13AF = 0x00563B20

    }
}