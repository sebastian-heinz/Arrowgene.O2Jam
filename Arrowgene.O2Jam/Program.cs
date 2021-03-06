using System;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;
using Arrowgene.Logging;

namespace Arrowgene.O2Jam
{
    class Program
    {
        private static readonly object ConsoleLock = new();
        private static readonly Setting Setting = new();

        static void Main(string[] args)
        {
           // new Test();
            
            LogProvider.Configure<ServerLogger>(Setting);
            LogProvider.OnLogWrite += LogProviderOnOnLogWrite;
            LogProvider.Start();

            if (args.Length == 0)
            {
                NetServer netServer = new NetServer(Setting);
                netServer.Start();
                Console.ReadKey();
                netServer.Stop();
                return;
            }

            LogProvider.Stop();
        }

        private static void LogProviderOnOnLogWrite(object sender, LogWriteEventArgs e)
        {
            ConsoleColor consoleColor = ConsoleColor.Gray;
            switch (e.Log.LogLevel)
            {
                case LogLevel.Debug:
                    consoleColor = ConsoleColor.Yellow;
                    break;
                case LogLevel.Info:
                    consoleColor = ConsoleColor.Cyan;
                    break;
                case LogLevel.Error:
                    consoleColor = ConsoleColor.Red;
                    break;
            }

            if (e.Log.Tag is NetPacket packet)
            {
                switch (packet.Source)
                {
                    case PacketSource.Server:
                        consoleColor = ConsoleColor.Green;
                        break;
                    case PacketSource.Client:
                        consoleColor = ConsoleColor.Magenta;
                        break;
                }
            }

            lock (ConsoleLock)
            {
                Console.ForegroundColor = consoleColor;
                Console.WriteLine(e.Log);
                Console.ResetColor();
            }
        }
    }
}