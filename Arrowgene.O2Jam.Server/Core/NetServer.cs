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
        private readonly Setting _setting;

        public NetServer(Setting setting)
        {
            _setting = new Setting(setting);
            _consumer = new ServerConsumer(_setting.ServerSetting);
            
            _consumer.AddHandler(new UnknownHandle());
            _consumer.AddHandler(new LoginHandle());
            
            _server = new AsyncEventServer(
                IPAddress.Any,
                15010,
                _consumer,
                _setting.ServerSetting
            );
        }

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