using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Tr8n;
using Tr8n.tokens;
namespace Tr8nSample
{
    class Program
    {
        #region Member Variables
        #endregion

        #region Properties
        #endregion

        #region Methods

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("TR8N Sample Application");

            application.SetConfig("tr8nconfig.yml", "dev");
            application.init(application.config["remote:host"],application.config["remote:client_id"],application.config["remote:access_token"],null);
            application.defaultLanguage = "ru";

            Console.WriteLine("Default language is " + application.defaultLanguage);
            Console.WriteLine("Default locale is " + application.defaultLocale);
//            Console.WriteLine("Flag for Russia is " + new language("ru").flagUrl);

            application.defaultLanguage = "es";
//            source ps = new source("/browsesurnames.aspx", "es", "17");
//            ps.Load();
            //Console.WriteLine("Supported Languages are:");
            //foreach (language lan in application.languages)
            //    Console.WriteLine(lan.englishName + " - " + lan.nativeName);

            application.LoadLanguageTranslationFile(@"c:\dev\mh\wvrweb\ltf\tr8n20131023.ltf");

            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter some tml: ");
                string tml = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(tml))
                    break;
                if (tml.StartsWith("cmd:"))
                {
                    ProcessCommand(tml.Substring(4));
                    continue;
                }

                tokenList dataTokens = new tokenList("data", tml);
                if (dataTokens.tokens.Count > 0)
                {
                    Console.WriteLine("Data Tokens:");
                    foreach (dataToken tok in dataTokens.tokens)
                        Console.WriteLine(tok.name);
                }

                tokenList transTokens = new tokenList("transform", tml);
                if (transTokens.tokens.Count > 0)
                {
                    Console.WriteLine("Transform Tokens:");
                    foreach (transformToken tok in transTokens.tokens)
                        Console.WriteLine(tok.tokenText);
                }

                Console.WriteLine(tml.translatep(17, "Richard","Familylink.com"));
//                Console.WriteLine("U.S. CENSUS [span:1790-1940] IS NOW HERE!".translate("attr", "id=\"topYears\""));

//                Console.WriteLine(application.translate(tml,"count",17,"user","Richard","sitename","Familylink.com"));

            }

        }

        public static void ProcessCommand(string command)
        {
            if (command.StartsWith("export "))
            {
                string filename=command.Substring(7).Trim();
                string data = Tr8nBase.apiGetString("application/translations", "",3600000);
                StreamWriter sw = new StreamWriter(filename);
                sw.Write(data);
                sw.Close();
                Console.WriteLine("Export to " + filename + " completed");
                return;
            }
            Console.WriteLine("Unknown command");
        }

        #endregion
    }
}
