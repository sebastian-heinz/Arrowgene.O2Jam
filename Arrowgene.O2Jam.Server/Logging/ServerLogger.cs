using System;
using Arrowgene.O2Jam.Server.Common;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Packet;
using Arrowgene.Logging;
using Arrowgene.Networking.Tcp;

namespace Arrowgene.O2Jam.Server.Logging
{
    public class ServerLogger : Logger
    {
        private Setting _setting;

        public override void Initialize(string identity, string name, Action<Log> write, object configuration)
        {
            base.Initialize(identity, name, write, configuration);
            _setting = configuration as Setting;
            if (_setting == null)
            {
                Error("Couldn't apply ServerLogger configuration");
            }
        }

        public void Info(Client client, string message)
        {
            Info($"{client.Identity} {message}");
        }

        public void Debug(Client client, string message)
        {
            Debug($"{client.Identity} {message}");
        }

        public void Error(Client client, string message)
        {
            Error($"{client.Identity} {message}");
        }

        public void Exception(Client client, Exception exception)
        {
            if (exception == null)
            {
                Write(LogLevel.Error, $"{client.Identity} Exception was null.", null);
            }
            else
            {
                Write(LogLevel.Error, $"{client.Identity} {exception}", exception);
            }
        }

        public void Info(ITcpSocket socket, string message)
        {
            Info($"[{socket.Identity}] {message}");
        }

        public void Debug(ITcpSocket socket, string message)
        {
            Debug($"[{socket.Identity}] {message}");
        }

        public void Error(ITcpSocket socket, string message)
        {
            Error($"[{socket.Identity}] {message}");
        }

        public void Exception(ITcpSocket socket, Exception exception)
        {
            if (exception == null)
            {
                Write(LogLevel.Error, $"{socket.Identity} Exception was null.", null);
            }
            else
            {
                Write(LogLevel.Error, $"{socket.Identity} {exception}", exception);
            }
        }

        public void Packet(ITcpSocket socket, NetPacket packet)
        {
            Write(LogLevel.Info, $"{socket.Identity}{Environment.NewLine}{packet.AsString()}", packet);
        }

        public void Packet(Client client, NetPacket packet)
        {
            Write(LogLevel.Info, $"{client.Identity}{Environment.NewLine}{packet.AsString()}", packet);
        }

        public void Data(ITcpSocket socket, byte[] data, string message = "Data")
        {
            Write(LogLevel.Info, $"{socket.Identity} {message}{Environment.NewLine}{Util.HexDump(data)}", data);
        }

        public void Data(Client client, byte[] data, string message = "Data")
        {
            Write(LogLevel.Info, $"{client.Identity} {message}{Environment.NewLine}{Util.HexDump(data)}", data);
        }
    }
}