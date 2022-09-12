using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace krak
{
    internal class Program
    {
        static void telefon_lookup()
        {
            int tlf;
            string navn;
            string street;
            string postalPlaceName;

            Console.Clear();
            Console.WriteLine("Telefon nummer?");
            tlf = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            var url = "https://www.krak.dk/"+ tlf + "/personer";

            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(url);
            try
            {
                foreach (var item in doc.DocumentNode.SelectNodes("/html/body/div[1]/div/div/div[1]/div/ul/li[1]/div/div/div[1]/div/div[1]/h3/a"))
                {
                    navn = item.InnerText;
                    Console.WriteLine("Navn: " + navn);
                }

                foreach (var item in doc.DocumentNode.SelectNodes("/html/body/div[1]/div/div/div[1]/div/ul/li[1]/div/div/div[1]/div/div[2]/span[2]"))
                {
                    postalPlaceName = item.InnerText;
                    Console.WriteLine("By: " + postalPlaceName);
                }

                foreach (var item in doc.DocumentNode.SelectNodes("/html/body/div[1]/div/div/div[1]/div/ul/li[1]/div/div/div[1]/div/div[2]/span[1]"))
                {
                    street = item.InnerText;
                    Console.WriteLine("Vej: " + street);
                }
            }
            catch
            {
                Console.WriteLine("Intet fundet. Ugyldigt nummer eller intet match.");
            }
            
     
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Console.Clear();
            Console.Title = "Krak lookup";
            int mainin;

            Console.WriteLine("1. TLF lookup");
            mainin = Convert.ToInt32(Console.ReadLine());

            if (mainin == 1)
            {
                telefon_lookup();
            }
       
        }
    }
}
