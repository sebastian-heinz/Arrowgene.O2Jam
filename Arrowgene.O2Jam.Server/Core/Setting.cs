using System.IO;
using System.Runtime.Serialization;
using Arrowgene.Networking.Tcp.Server.AsyncEvent;
using Arrowgene.O2Jam.Server.Common;

namespace Arrowgene.O2Jam.Server.Core
{
    [DataContract]
    public class Setting
    {
        public Setting()
        {
            ServerSetting = new AsyncEventSettings();
            DataPath = Path.Combine(Util.ExecutingDirectory(), "Data");
        }

        public Setting(Setting setting)
        {
            ServerSetting = new AsyncEventSettings(setting.ServerSetting);
            DataPath = setting.DataPath;
        }

        [DataMember(Order = 0)]
        public AsyncEventSettings ServerSetting { get; set; }

        [DataMember(Order = 1)]
        public string DataPath { get; set; }
    }
}