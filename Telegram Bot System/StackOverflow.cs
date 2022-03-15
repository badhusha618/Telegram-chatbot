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
    class StackOverflow
    {

        public object getstc(String Q)
        {
           
                String apikey = "AIzaSyCXRBjYJDvfnkLfUgS9uQuR0_EgjqKsOeU";
                String cx = "1c2569988866834a3";
                WebRequest req = WebRequest.Create("https://www.googleapis.com/customsearch/v1?key=" + apikey + "&cx=" + cx + "&q=" + Q);
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                Stream dataStream = res.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                String ResponseString = reader.ReadToEnd();
                dynamic jsonData = JsonConvert.DeserializeObject(ResponseString);
                return jsonData;
        }
    }
}
