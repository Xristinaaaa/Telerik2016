using System;
using System.Xml;

namespace XMLProcessingHomework
{
    class DOMParser
    {
        public static void XMLParser()
        {
            XmlDocument document = new XmlDocument();
            document.Load("../../Catalogue.xml");
            XmlNode root = document.DocumentElement;

            foreach (XmlNode node in root.ChildNodes)
            {
                int countOfAlbums = 0;

                foreach (XmlNode innerNode in node.ChildNodes)
                {
                    if (innerNode.Name == "album")
                    {
                        countOfAlbums += 1;
                    }
                }

                Console.WriteLine("Artist {0} has {1} albums.", node["name"].InnerText, countOfAlbums);
            }
        }

        public static void DeleteXMLElements()
        {
            XmlDocument document = new XmlDocument();
            document.Load("../../Catalogue.xml");
            XmlNode root = document.DocumentElement;

            foreach (XmlNode node in root.ChildNodes)
            {
                var price = double.Parse(node["price"].InnerText);
                if (price > 20)
                {
                    node.RemoveChild(node["album"]);
                }
                Console.WriteLine(node);
            }
        }
    }
}
