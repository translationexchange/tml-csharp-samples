using System;
using System.Collections.Generic;
using System.Text;

using Tr8n;
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

            Console.WriteLine("default language is " + Tr8nClient.defaultLanguage);

            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter some tml: ");
                string tml = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(tml))
                    break;

                Console.WriteLine(Tr8n.Tr8nClient.translate(tml));
            }

        }

        #endregion
    }
}
