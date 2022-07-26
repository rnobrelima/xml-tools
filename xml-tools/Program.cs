using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace xml_tools
{
    class Program
    {
        static void Main(string[] args)
        {
            FindDuplicatesByTagName();
        }

        static void FindDuplicatesByTagName()
        {
            var filePath = "D:\\XML";
            var archives = Directory.GetFiles(filePath);

            foreach (string fileName in archives)
            {

                XmlDocument xml = new XmlDocument();

                xml.Load(fileName);
                List<string> guides = new List<string>();
                List<string> guidesDuplicates = new List<string>();

                var nodes = xml.GetElementsByTagName("ans:numeroGuiaPrestador");

                for (int i = 0; i < nodes.Count; i++)
                {
                    if (guides.Contains(nodes.Item(i).InnerText))
                        guidesDuplicates.Add(nodes.Item(i).InnerText);

                    guides.Add(nodes.Item(i).InnerText);

                }
                if (guidesDuplicates.Count > 0)
                {
                    Console.WriteLine(String.Format("File: " + fileName));
                    Console.WriteLine(String.Format("Guides Duplicates: " + String.Join(",", guidesDuplicates)));
                }
                else
                {
                    Console.WriteLine(String.Format("Files: " + fileName + " No Guides Duplicates!"));
                }
            }
        }
    }
}

