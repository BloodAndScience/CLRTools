using HtmlAgilityPack;
using System;
using System.Xml;

namespace HrefExtruder
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
        }

        static void ExtractHref(string URL)
        {
            // declaring & loading dom
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc = web.Load(URL);

    // extracting all links
            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
    {
                HtmlAttribute att = link.Attributes["href"];
                // showing output
                Console.WriteLine(att.Value);
            }
        }
    }
}
