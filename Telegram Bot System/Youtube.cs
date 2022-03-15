using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication3;
namespace Telegram_Bot_System
{
    class Youtube
    {

        public object GetSearch(String b)
        {
           
                int maxResult = 6;
                String key = "AIzaSyDHIwATJ87PxHZIqHaO2kf9IgEAXOvaJi0";
                var request = WebRequest.Create("https://youtube.googleapis.com/youtube/v3/search?type=video&maxResults=" + maxResult + "&q=" + b + "&part=snippet" + "&key=" + key);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                HttpWebResponse res = (HttpWebResponse)request.GetResponse();
                Stream datas = response.GetResponseStream();
                StreamReader reader = new StreamReader(datas);
                String ResponseString = reader.ReadToEnd();
                dynamic ta = JsonConvert.DeserializeObject(ResponseString);
                return ta;
        }
    }
}
