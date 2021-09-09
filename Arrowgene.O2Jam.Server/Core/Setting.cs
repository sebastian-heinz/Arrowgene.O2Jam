using Arrowgene.Networking.Tcp.Server.AsyncEvent;

namespace Arrowgene.O2Jam.Server.Core
{
    public class Setting
    {
        public Setting()
        {
            ServerSetting = new AsyncEventSettings();
        }
        
        public Setting(Setting setting)
        {
            ServerSetting = new AsyncEventSettings(setting.ServerSetting);
        }
        
       public AsyncEventSettings ServerSetting { get; set; }
    }
}