using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using System.IO;
using Telegram.Bot.Types.InputFiles;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Telegram_Bot_System;

namespace ConsoleApplication3
{
    class Program
    {
        public static Telegram_Bot_System.IndiaToday n = new Telegram_Bot_System.IndiaToday();
        public static Telegram_Bot_System.Doubt d = new Telegram_Bot_System.Doubt();
        public static Telegram_Bot_System.cricbuzz c = new Telegram_Bot_System.cricbuzz();
        public static Telegram_Bot_System.Tutorialpoint y = new Telegram_Bot_System.Tutorialpoint();
        public static Telegram_Bot_System.StackOverflow stf = new Telegram_Bot_System.StackOverflow();
        public static Telegram_Bot_System.Youtube yt = new Telegram_Bot_System.Youtube();
        public static Telegram_Bot_System.Quora qu = new Telegram_Bot_System.Quora();
        public static Telegram_Bot_System.GoogleSearch gs = new Telegram_Bot_System.GoogleSearch();
        public static Telegram_Bot_System.ytpl h = new Telegram_Bot_System.ytpl();
        public static ITelegramBotClient botClient = new TelegramBotClient("1611848520:AAEDsDSzBDsKxUeqMVemDbZGU3TkI4paj_U");
        public static void Main(string[] args)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            var me = botClient.GetMeAsync().Result;
            Console.WriteLine("Hello, Welcome My Basha Chat! I am user " + me.Id + " and my name is" + me.FirstName + ".");
            botClient.OnMessage += Bot_OnMessage;
            botClient.OnCallbackQuery += Bot_OnCallbakQuery;
            botClient.StartReceiving();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            botClient.StopReceiving();
        }
        public static async void Bot_OnCallbakQuery(object sender, CallbackQueryEventArgs e)
        {

            Console.WriteLine("Query from user");
            await botClient.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, e.CallbackQuery.Data);

        }
        public static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            Console.WriteLine(e.Message.Text);
            Console.WriteLine(e.Message.Chat.LastName);
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                try { 
                if(e.Message.Text.ToLower().StartsWith("/help"))
                {
                    showHelpText(e);   
                }

                 else if (e.Message.Text.ToLower() == "/cy")
                {
                    var inlineKeyboard = new InlineKeyboardMarkup(new[]
                {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("ABOUT SAC", "https://www.youtube.com/watch?v=TuoDifBYqUY")
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("SADHAKATHULLAH APPA COLLEEGE YOUTUBE CHANNEL", "https://www.youtube.com/channel/UCJSwEVig-1txO_Tbz01x54g")
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("SAC STUTENT WOLRD RECORD", "https://www.youtube.com/watch?v=UM0PRtbRIr8")
                    }
                });

                    Console.WriteLine(e.Message.Text);
                    Console.WriteLine(e.Message.Chat.LastName);
                    await botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat.Id,
                        text: "SAC YOUTUBE",
                        replyMarkup: inlineKeyboard
                    );


                }
               
                else if (e.Message.Text.ToLower() == "/cws")
                {
                    var inlineKeyboard = new InlineKeyboardMarkup(new[] {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("SADHAKATHULLAH APPA COLLEEGE MAIN", "http://sadakath.ac.in/")
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("SADHAKATHULLAH APPA COLLEEGE RESULT", "http://sadakath.ac.in/results.php")
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("SADHAKATHULLAH APPA COLLEEGE ONLINEPAYMENT", "https://easycollege.in/sadakathullaappa/school/webpayindex.aspx")
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("SADHAKATHULLAH APPA COLLEEGE EXAM", "http://www.exam.sadakath.ac.in/semesterexamsecond/student/")
                    }
                });
                    Console.WriteLine(e.Message.Text);
                    Console.WriteLine(e.Message.Chat.LastName);

                    await botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat.Id,
                        text: "COLLEGE WEBSITES",
                        replyMarkup: inlineKeyboard
                    );

                    
                }


                else if (e.Message.Text.ToLower().StartsWith("/gl "))
                {
                    try
                    {
                        dynamic Data = gs.getGoogle(e.Message.Text.Substring(4));
                        String msg = "";
                        int maxResult = 5;
                        if (Data.items.Count < 5) maxResult = Data.items.Count;
                        for (int i = 0; i < maxResult; i++)
                        {
                            msg += (i + 1) + ". [" + Data.items[i].title + "](" + Data.items[i].link + ")(" + Data.items[i].snippet + ")\n\n";
                        }
                        await botClient.SendTextMessageAsync(e.Message.Chat.Id, msg, ParseMode.Markdown, disableWebPagePreview: true);
                    }
                    catch (Exception ee)
                    {
                       
                        botClient.SendTextMessageAsync(e.Message.Chat.Id, "Not Available" + Environment.NewLine + "pleace check the content");

                    }

                }
                else if (e.Message.Text.EndsWith("?"))
                {
                    try
                    {
                        dynamic Data = d.getdoubt(e.Message.Text);
                        String msg = "";
                        int maxResult = 1;
                        if (Data.items.Count < 5) maxResult = Data.items.Count;
                        for (int i = 0; i < maxResult; i++)
                        {
                            msg += (i + 1) + ". [" + Data.items[i].title + "](" + Data.items[i].link + ")(" + Data.items[i].snippet + ")\n\n";
                        }                   
                        
                        await botClient.SendTextMessageAsync(e.Message.Chat.Id, msg, ParseMode.Markdown, disableWebPagePreview: true);
                    }
                    catch (Exception ee)
                    {

                        botClient.SendTextMessageAsync(e.Message.Chat.Id, "Not Available" + Environment.NewLine + "pleace check the content");

                    }

                }
                else if (e.Message.Text.ToLower().StartsWith("/yt"))
                {
                    try
                    {
                        dynamic aa = yt.GetSearch(e.Message.Text.Substring(4));
                        string frontLink = "https://www.youtube.com/watch?v=";
                        string l1 = aa.items[0].snippet.title + " - " + aa.items[0].snippet.channelTitle;
                        string l2 = aa.items[1].snippet.title + " - " + aa.items[1].snippet.channelTitle;
                        string l3 = aa.items[2].snippet.title + " - " + aa.items[2].snippet.channelTitle;
                        string l4 = aa.items[3].snippet.title + " - " + aa.items[3].snippet.channelTitle;
                        string l5 = aa.items[4].snippet.title + " - " + aa.items[3].snippet.channelTitle;
                        string l6 = aa.items[5].snippet.title + " - " + aa.items[3].snippet.channelTitle;
                        string a1 = frontLink + aa.items[0].id.videoId;
                        string a2 = frontLink + aa.items[1].id.videoId;
                        string a3 = frontLink + aa.items[2].id.videoId;
                        string a4 = frontLink + aa.items[3].id.videoId;
                        string a5 = frontLink + aa.items[4].id.videoId;
                        string a6 = frontLink + aa.items[5].id.videoId;

                        var inlineKeyboard = new InlineKeyboardMarkup(new[] {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData(l1, a1)
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData(l2, a2)
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData(l3, a3)
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData(l4, a4)
                    },
                    
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData(l5, a5)
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData(l6, a6)
                    }
                });
                        Console.WriteLine(e.Message.Text);
                        await botClient.SendTextMessageAsync(
                            chatId: e.Message.Chat.Id,
                            text: ".",
                            replyMarkup: inlineKeyboard
                        );

                    }
                    catch (Exception cc)
                    {
                        Console.WriteLine(cc);
                        botClient.SendTextMessageAsync(e.Message.Chat.Id, "Not available." + Environment.NewLine + "pleace check ");
                    }
                }
                else if (e.Message.Text.ToLower().StartsWith("/n"))
                {
                    try
                    {

                        dynamic r = n.getNews(e.Message.Text.Substring(3));
                        String b = "";
                        int max = 5;
                        if (r.items.Count < 5) max = r.items.Count;
                        for (int i = 0; i < max; i++)
                        {
                            b += (i + 1) + ". [" + r.items[i].title + "](" + r.items[i].link + ")(" + r.items[i].snippet + ")\n\n";
                        }
                        await botClient.SendTextMessageAsync(e.Message.Chat.Id, b, ParseMode.Markdown, disableWebPagePreview: true);
                    }
                    catch (Exception eee)
                    {

                        Console.WriteLine(eee);
                        botClient.SendTextMessageAsync(e.Message.Chat.Id, "Not available." + Environment.NewLine + "pleace check ");
                    }
                }
                else if (e.Message.Text.ToLower().StartsWith("/qu "))
                {
                    try
                    {
                        dynamic quara = qu.getQuora(e.Message.Text.Substring(4));
                        String msg = "";
                        int maxResult = 4;
                        if (quara.items.Count < 4) maxResult = quara.items.Count;
                        for (int i = 0; i < maxResult; i++)
                        {
                            msg += (i + 1) + ". [" + quara.items[i].title + "](" + quara.items[i].link + ")(" + quara.items[i].snippet + ")\n\n";
                        }
                        await botClient.SendTextMessageAsync(e.Message.Chat.Id, msg, ParseMode.Markdown, disableWebPagePreview: true);
                    }
                    catch (Exception eee)
                    {
                        Console.WriteLine(eee);
                        botClient.SendTextMessageAsync(e.Message.Chat.Id, "Not available." + Environment.NewLine + "pleace check ");
                    }
                }
                else if (e.Message.Text.ToLower().StartsWith("/sf"))
                {
                    try
                    {
                        dynamic st = stf.getstc(e.Message.Text.Substring(4));
                        String stfl = "";
                        int maxResult = 3;
                        if (st.items.Count < 3) maxResult = st.items.Count;
                        for (int i = 0; i < maxResult; i++)
                        {
                            stfl += (i + 1) + ". [" + st.items[i].title + "](" + st.items[i].link + ")(" + st.items[i].snippet + ")\n\n";
                        }
                        await botClient.SendTextMessageAsync(e.Message.Chat.Id, stfl, ParseMode.Markdown, disableWebPagePreview: true);
                    }
                    catch (Exception eee)
                    {

                        Console.WriteLine(eee);
                        botClient.SendTextMessageAsync(e.Message.Chat.Id, "Not available." + Environment.NewLine + "pleace check ");
                    }
                }

                else if (e.Message.Text.ToLower().StartsWith("/tt"))
                {
                    try
                    {

                        dynamic a = y.result(e.Message.Text.Substring(4));
                        String g = "";
                        int max = 1;
                        if (a.items.Count < 2) max = a.items.Count;
                        for (int i = 0; i < max; i++)
                        {
                            g += (i + 1) + ". [" + a.items[i].title + "](" + a.items[i].link + ")(" + a.items[i].snippet + ")\n\n";
                        }                        
                        await botClient.SendTextMessageAsync(e.Message.Chat.Id, g, ParseMode.Markdown, disableWebPagePreview: true);
                    }
                    catch (Exception eee)
                    {

                        Console.WriteLine(eee);
                        botClient.SendTextMessageAsync(e.Message.Chat.Id, "Not available." + Environment.NewLine + "pleace check ");
                    }
                }
                else if (e.Message.Text.ToLower().StartsWith("/c"))
                {
                    try
                    {

                        dynamic v = c.getdis(e.Message.Text.Substring(3));
                        String b = "";
                        int max = 5;
                        if (v.items.Count < 5) max = v.items.Count;
                        for (int i = 0; i < max; i++)
                        {
                            b += (i + 1) + ". [" + v.items[i].title + "](" + v.items[i].link + ")(" + v.items[i].snippet + ")\n\n";
                        }
                        await botClient.SendTextMessageAsync(e.Message.Chat.Id, b, ParseMode.Markdown, disableWebPagePreview: false);
                    }
                    catch (Exception eee)
                    {
                        
                        Console.WriteLine(eee);
                        botClient.SendTextMessageAsync(e.Message.Chat.Id, "Not available." + Environment.NewLine + "pleace check ");
                    }
                }
                }
                catch(Exception tt)
                {

                    Console.WriteLine(tt);
                }
                if(e.Message.Text.ToLower()=="hi")
                {
                 await botClient.SendTextMessageAsync(e.Message.Chat.Id, "Hi");
                }
                if (e.Message.Text.StartsWith("Where are you from"))
                {
                   
                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, "i am from server" + Environment.NewLine + "You are from  " + e.Message.Chat.LastName);
                }
                if (e.Message.Text.ToLower()=="good morning")
                {

                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, "Good morning" + Environment.NewLine  + e.Message.Chat.LastName);
                    FileStream ss = System.IO.File.OpenRead(@"E:\Photos\11.webp");
                    InputOnlineFile s = new InputOnlineFile(ss, "11.webp");
                    await botClient.SendPhotoAsync(e.Message.Chat.Id, s);
                }
                if (e.Message.Text.ToLower()=="goodmorning")
                {

                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, "Good morning" + Environment.NewLine  + e.Message.Chat.LastName);
                    FileStream ss = System.IO.File.OpenRead(@"E:\Photos\11.webp");
                    InputOnlineFile s = new InputOnlineFile(ss, "11.webp");
                    await botClient.SendPhotoAsync(e.Message.Chat.Id, s);
                }
                if (e.Message.Text.ToUpper()=="GOOD AFTERNOON")
                {

                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, "Good afternoon" + Environment.NewLine  + e.Message.Chat.LastName);
                    FileStream ss = System.IO.File.OpenRead(@"E:\Photos\7.jpg");
                    InputOnlineFile s = new InputOnlineFile(ss, "7.jpg");
                    await botClient.SendPhotoAsync(e.Message.Chat.Id, s);
                }
                if (e.Message.Text.ToUpper()=="GOODAFTERNOON")
                {

                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, "Good afternoon" + Environment.NewLine  + e.Message.Chat.LastName);
                    FileStream ss = System.IO.File.OpenRead(@"E:\Photos\7.jpg");
                    InputOnlineFile s = new InputOnlineFile(ss, "7.jpg");
                    await botClient.SendPhotoAsync(e.Message.Chat.Id, s);
                }
                if (e.Message.Text.ToLower()=="Good evening")
                {
                    
                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, "Good evening" + Environment.NewLine + e.Message.Chat.LastName);
                    FileStream fs = System.IO.File.OpenRead(@"E:\Photos\4.jpg");
                    InputOnlineFile myp = new InputOnlineFile(fs, "4.jpg");
                    await botClient.SendPhotoAsync(e.Message.Chat.Id, myp);
                }
                if (e.Message.Text.ToLower()=="Goodevening")
                {

                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, "Good evening" + Environment.NewLine + e.Message.Chat.LastName);
                    FileStream fs = System.IO.File.OpenRead(@"E:\Photos\4.jpg");
                    InputOnlineFile myp = new InputOnlineFile(fs, "4.jpg");
                    await botClient.SendPhotoAsync(e.Message.Chat.Id, myp);
                }
                if (e.Message.Text.ToLower()=="good night")
                {

                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, "Good night" + Environment.NewLine +  e.Message.Chat.LastName);
                    FileStream fs = System.IO.File.OpenRead(@"E:\Photos\3.jpg");
                    InputOnlineFile myp = new InputOnlineFile(fs, "3.jpg");
                    await botClient.SendPhotoAsync(e.Message.Chat.Id, myp);
                } if (e.Message.Text.ToLower()=="goodnight")
                {

                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, "Good night" + Environment.NewLine +  e.Message.Chat.LastName);
                    FileStream fs = System.IO.File.OpenRead(@"E:\Photos\3.jpg");
                    InputOnlineFile myp = new InputOnlineFile(fs, "3.jpg");
                    await botClient.SendPhotoAsync(e.Message.Chat.Id, myp);
                }
                if (e.Message.Text == "/start")
                {
                    
                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, "WELCOME OUR CHATBOT CLICK THE /help FOR BOT INFORMATION");
                    FileStream fs = System.IO.File.OpenRead(@"E:\Photos\2.jpg");
                    InputOnlineFile myp = new InputOnlineFile(fs, "2.jpg");
                    await botClient.SendPhotoAsync(e.Message.Chat.Id, myp);
                }
                    else if(e.Message.Text.ToLower()=="hello")
                {
                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, "Hello " );
                    FileStream fs = System.IO.File.OpenRead(@"E:\Photos\6.jpg");
                    InputOnlineFile myp = new InputOnlineFile(fs, "6.jpg");
                    await botClient.SendPhotoAsync(e.Message.Chat.Id, myp);
                }
                else if (e.Message.Text.ToLower() == "how are you")
                {
                    
                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, "I'm well" + Environment.NewLine + "How are you " + e.Message.Chat.LastName);
                }
                else if (e.Message.Text.ToLower() == "howareyou")
                {

                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, "I'm well" + Environment.NewLine + "How are you" + e.Message.Chat.LastName);
                }
             
                else if (e.Message.Text.ToLower()=="good")
                {

                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, "Oh Good" + Environment.NewLine + "Do like you standup Comedy" +Environment.NewLine +e.Message.Chat.LastName + " Tybe'/yt madura muthu comedy' and watch the videos");
                }
                else if (e.Message.Text.ToLower() == "i'm good")
                {
               
                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, "Oh Good" + Environment.NewLine + "Do like you standup Comedy" + Environment.NewLine + e.Message.Chat.LastName + " Tybe'/yt madura muthu comedy' and watch the videos");
                }
             
                else if (e.Message.Text.ToLower() == "imGood")
                {
                    
                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, "Oh Good" + Environment.NewLine + "Do like you standup Comedy" + Environment.NewLine + e.Message.Chat.LastName + " Tybe'/yt madura muthu comedy' and watch the videos");
                }

                else if (e.Message.Text.ToLower().Contains("well"))
                {
                   
                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, "Oh Good" + Environment.NewLine + "Do like you standup Comedy" + Environment.NewLine + e.Message.Chat.LastName + " Tybe'/yt madura muthu comedy'and watch the videos");
                }
                else if (e.Message.Text.ToUpper().Contains("FINE"))
                {
                   
                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, "Oh Good" + Environment.NewLine + "Do like you standup Comedy " + Environment.NewLine + e.Message.Chat.LastName + " Tybe'/yt madura muthu comedy'and watch the videos");
                }
              
                else if (e.Message.Text.ToLower().Contains("bad"))
                {
                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, "Oh " + Environment.NewLine + "Do like you standup Comedy" + Environment.NewLine + e.Message.Chat.LastName + " Tybe'/yt madura muthu comedy'and watch the videos");
                }
                else if (e.Message.Text.ToLower().Contains("not"))
                {
                   
                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, "oh" + Environment.NewLine + "Do like you standup Comedy" + Environment.NewLine
 + e.Message.Chat.LastName + " Tybe'/yt madura muthu comedy'and watch the videos");
                }
               
                else if (e.Message.Text.ToLower().Contains("ok"))
                {
                   
                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, "oh" + Environment.NewLine + "Do like you standup Comedy" + Environment.NewLine + e.Message.Chat.LastName + "Tybe'/yt madura muthu comedy'and watch the videos");
                }
                else if (e.Message.Text.ToLower().Contains("okay"))
                {
                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, "oh" + Environment.NewLine + "Do like you standup Comedy" + Environment.NewLine + e.Message.Chat.LastName + "Tybe'/yt madura muthu comedy'and watch the videos");
                }
                else if (e.Message.Text == "/sc")
                {
                    await botClient.SendContactAsync(
    chatId: e.Message.Chat.Id,
    phoneNumber: "0462 2540763",
    firstName: "SAC",
    lastName: "Phone number"
);
                }
                if (e.Message.Text.ToLower() == "/fb")
                {   
                    await botClient.SendPollAsync(
                       chatId: e.Message.Chat.Id,
                       question: "DO YOU LIKE THIS BOT",
                       options: new[]
    {
        "Awesome " ,
        "Not bad ",
        "Useless",
        "Please improve"

    }
                   );                  
                    FileStream fs = System.IO.File.OpenRead(@"E:\Photos\1.jpg");
                    InputOnlineFile myp = new InputOnlineFile(fs, "1.jpg");
                    await botClient.SendPhotoAsync(e.Message.Chat.Id, myp);
                }
                else if (e.Message.Text.ToLower().StartsWith("/q"))
                {
                    try
                    {
                        await botClient.SendTextMessageAsync(e.Message.Chat.Id, "Wait few sec please");
                        sendSurahAudio(e.Message.Text, e);
                    }
                    catch(Exception q)
                    {
                        Console.WriteLine(q);
                    }
                }
                  }
                    }

        public async static void sendSurahAudio(string p, MessageEventArgs e)
        {
            if (e.Message.Text.ToLower() == "/q1")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\001.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 1.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "1.mp3");

            }
            else if (e.Message.Text.ToLower() == "/q71")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\071.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 071.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "071.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q72")

            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\072.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 072.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "072.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q73")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\071.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 071.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "073.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q74")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\074.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 074.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "074.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q75")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\075.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 075.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "075.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q76")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\076.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 076.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "076.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q77")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\077.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 077.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "077.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q78")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\078.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 078.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "078.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q79")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\079.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 079.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "079.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q80")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\080.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 080.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "080.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q81")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\081.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 081.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "081.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q82")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\082.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 083.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "083.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q84")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\084.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 084.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "084.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q83")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\083.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 083.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "083.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q85")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\085.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 085.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "085.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q86")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\086.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 086.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "086.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q87")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\087.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 087.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "087.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q88")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\088.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 088.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "088.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q89")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\089.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 089.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "089.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q90")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\090.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 090.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "090.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q91")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\091.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 091.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "091.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q92")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\092.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 092.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "092.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q93")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\093.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 093.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "093.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q94")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\094.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 094.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "094.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q95")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\095.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 095.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "095.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q96")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\096.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 096.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "096.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q97")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\097.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 097.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "097.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q98")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\098.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 098.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "098.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q99")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\099.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 099.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "099.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q100")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\100.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 100.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "100.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q101")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\101.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 101.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "101.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q102")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\102.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 102.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "102.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q103")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\103.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 103.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "103.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q104")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\104.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 104.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "104.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q105")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\105.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 105.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "105.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q106")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\106.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 106.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "106.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q107")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\107.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 107.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "107.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q108")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\108.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 108.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "108.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q109")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\109.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 109.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "109.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q110")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\110.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 110.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "110.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q111")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\111.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 111.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "111.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q112")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\112.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 112.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "112.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q114")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\114.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 114.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "114.mp3");
            }
            else if (e.Message.Text.ToLower() == "/q113")
            {
                FileStream q = System.IO.File.OpenRead(@"E:\quran\113.mp3");
                InputOnlineFile m = new InputOnlineFile(q, " 113.mp3");
                await botClient.SendAudioAsync(e.Message.Chat.Id, m, "113.mp3");
            }
        }
        public async static void showHelpText(MessageEventArgs e)
        {
            await botClient.SendTextMessageAsync(e.Message.Chat.Id, 
                                          "/gl - For Google Search"
                  + Environment.NewLine + "/yt - For Youtube Search" 
                  + Environment.NewLine + "/qu - For quara search "
                  + Environment.NewLine + "/tt - For Tutorial Points"
                  + Environment.NewLine + "/c  - For Cricbuzz"
                  + Environment.NewLine + "/sf - For Stackoverflow"
                  + Environment.NewLine + "/q  - For Quran adiyayath 1 and 71 to 114"
                  + Environment.NewLine + "/cy  - For Our College Youtube"
                  + Environment.NewLine + "/cws - For Our College Websiites"
                  + Environment.NewLine + "/n - For India Today News"
                  + Environment.NewLine +"Endwith ?- For Question Command");
        }
    }
}



    
