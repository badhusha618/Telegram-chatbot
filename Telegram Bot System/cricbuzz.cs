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
    class cricbuzz
    {

        public object getdis(String c)
        {
            try
            {
                String apikey = "AIzaSyCXRBjYJDvfnkLfUgS9uQuR0_EgjqKsOeU";
                String cx = "01b2b585c434bc352";
                WebRequest req = WebRequest.Create("https://www.googleapis.com/customsearch/v1?key=" + apikey + "&cx=" + cx + "&q=" + c);
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                Stream dataStream = res.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                String ResponseString = reader.ReadToEnd();
                dynamic jsonData = JsonConvert.DeserializeObject(ResponseString);
                using (StreamWriter writer = new StreamWriter("e:\\csk.json"))
                {
                    writer.WriteLine(ResponseString);
                }
                return jsonData;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.StackTrace);
            }

            return 0;

        }
    }
}
