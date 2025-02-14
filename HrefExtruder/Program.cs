﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace HrefExtruder
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string filePath = args[0];
                HtmlDocument doc = new HtmlDocument();
                using (FileStream file = File.OpenRead(filePath))
                {
                    doc.Load(file);
                }
                string[] hrefs = ExtractHref(doc);
                hrefs = CleanList(hrefs, @"https://www.youtube.com/playlist?list=");

                foreach (var href in hrefs)
                {
                    Console.WriteLine(href);
                }

                Console.WriteLine($"Success found {hrefs.Length} hrefs");

            }
            else
            {
                Console.WriteLine("No linkparameter set try:");
                Console.WriteLine(@"HrevExtruder B:\Lib\Proj\CLRTools\Resources\UnityPlaylists.html");
            }
            Console.ReadKey();
        }

        private static string[] CleanList(string[] hrefs, string pattern)
        {

            List<string> result = new List<string>(8);
            foreach (var href in hrefs)
            {
                if (href.Contains(pattern))
                {
                    string id = href.Remove(0, pattern.Length);

                    if (id.Length > 5&&!result.Contains(id))
                    {

                        result.Add(id);
                    }
                }

            }

            return result.ToArray();
        }

        static string[] ExtractHref( HtmlDocument doc)
        {
            List<string> hrefs = new List<string>(128);
            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                HtmlAttribute att = link.Attributes["href"];
                
                // showing output
               hrefs.Add( att.Value);
            }

            return hrefs.ToArray();
        }
    }
}
