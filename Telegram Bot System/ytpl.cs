using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
namespace Telegram_Bot_System
{
    class ytpl
    {
        public object getsearch(String S)
        {
            try
            {
                int maxResult = 3;
                String key = "AIzaSyDHIwATJ87PxHZIqHaO2kf9IgEAXOvaJi0";
                var request = WebRequest.Create("https://youtube.googleapis.com/youtube/v3/search?type=playlist&maxResults=" + maxResult + "&q=" + S + "&part=snippet" + "&key=" + key);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                HttpWebResponse res = (HttpWebResponse)request.GetResponse();
                Stream datas = response.GetResponseStream();
                StreamReader reader = new StreamReader(datas);
                String ResponseString = reader.ReadToEnd();
                dynamic ydata = JsonConvert.DeserializeObject(ResponseString);
                using (StreamWriter writer = new StreamWriter("e:\\c1.json"))
                {
                    writer.WriteLine(ResponseString);
                }
                return ydata;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }
            return 0;
        }
    }
}
