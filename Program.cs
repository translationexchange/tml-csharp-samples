using System;
using System.Collections.Generic;
using System.Text;

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
            Console.WriteLine("TR8N Sample Application");

            Tr8nClient.SetConfig("tr8nconfig.yml", "dev");

            Console.WriteLine("Default language is " + Tr8nClient.defaultLanguage);
            Console.WriteLine("Default locale is " + Tr8nClient.defaultLocale);


            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter some tml: ");
                string tml = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(tml))
                    break;

                Console.WriteLine("Data Tokens:");
                tokenList dataTokens = new tokenList("data", tml);
                foreach (dataToken tok in dataTokens.tokens)
                    Console.WriteLine(tok.tokenText);

                Console.WriteLine("Transform Tokens:");
                tokenList transTokens = new tokenList("transform", tml);
                foreach (transformToken tok in transTokens.tokens)
                    Console.WriteLine(tok.tokenText);

                Console.WriteLine(Tr8n.Tr8nClient.translate(tml,"count",17,"user","Richard"));

            }

        }

        #endregion
    }
}
