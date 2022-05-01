using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace LaserGame_V2_2
{
    public class ESPService
    {
        public ESPService()
        {

        }

        // free commands

        public string post(string ip, string keyCommand, string valueCommand)
        {
            return Utils.POSTAsync("http://"+ ip+"?"+ keyCommand+"="+valueCommand).Result;
        }
        public Task<string> postAsync(string ip, string keyCommand, string valueCommand)
        {
            return Utils.POSTAsync("http://" + ip + "?" + keyCommand + "=" + valueCommand);
        }

        internal Task<string> postAsync(string ip, string v, object noColorCmd)
        {
            throw new NotImplementedException();
        }
    }
}
