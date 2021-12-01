using System.Net;
using Arrowgene.O2Jam.Server.PacketHandle;
using Arrowgene.Logging;
using Arrowgene.Networking.Tcp.Server.AsyncEvent;

namespace Arrowgene.O2Jam.Server.Core
{
    public class NetServer
    {
        private static readonly ILogger Logger = LogProvider.Logger<Logger>(typeof(NetServer));

        private readonly AsyncEventServer _server;
        private readonly ServerConsumer _consumer;

        public NetServer(Setting setting)
        {
            Setting = new Setting(setting);
            _consumer = new ServerConsumer(Setting.ServerSetting);

            _consumer.AddHandler(new UnknownHandle());
            _consumer.AddHandler(new LoginHandle());
            _consumer.AddHandler(new PlanetHandle());
            _consumer.AddHandler(new ChannelHandle());
            _consumer.AddHandler(new MusicListHandle(this));
            _consumer.AddHandler(new CharacterHandle());
            _consumer.AddHandler(new RoomListHandle());
            _consumer.AddHandler(new CreateRoomHandle());
            _consumer.AddHandler(new RoomSongSelectHandle());
            _consumer.AddHandler(new RoomColorSelectHandle());
            _consumer.AddHandler(new RoomApplySkill());
            _consumer.AddHandler(new RoomUnknown2Handle());
            _consumer.AddHandler(new StartGameHandle());
            _consumer.AddHandler(new GameCheck1Handle());
            _consumer.AddHandler(new GameCheck2Handle());
            _consumer.AddHandler(new CashHandle());
            _consumer.AddHandler(new Room1Handle());
            _consumer.AddHandler(new PingHandle());
            _consumer.AddHandler(new DisconnectHandle());

            _consumer.AddHandler(new LobbyBackButton());
            _consumer.AddHandler(new RoomBackButton());
            _consumer.AddHandler(new InGameBackButton());
            _consumer.AddHandler(new RoomSongSelectButton1());
            _consumer.AddHandler(new RoomSongSelectButton2());
            _consumer.AddHandler(new RoomSongSelectCheckButton());
            _consumer.AddHandler(new InGameRanking());
            _consumer.AddHandler(new Resalt());
            _consumer.AddHandler(new LobbyChat());

            _consumer.AddHandler(new test());
            _consumer.AddHandler(new test1());
            _consumer.AddHandler(new test2());
            _consumer.AddHandler(new test3());

            _server = new AsyncEventServer(
                IPAddress.Any,
                15010,
                _consumer,
                Setting.ServerSetting
            );
        }

        public Setting Setting { get; }

        public void Start()
        {
            _server.Start();
        }

        public void Stop()
        {
            _server.Stop();
        }
    }
}