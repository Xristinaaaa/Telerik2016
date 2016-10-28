using System;
using System.Xml;
using System.Xml.XPath;

namespace XMLProcessingHomework
{
    class XPath
    {
        public static void XPathManipulation()
        {
            XmlDocument document = new XmlDocument();
            document.Load("../../Catalogue.xml");
            string xpathQuery = "catalogue/artist";

            XmlNodeList artistList = document.SelectNodes(xpathQuery);
            foreach (XmlNode artist in artistList)
            {
                string artistName = artist.SelectSingleNode("name").InnerText;
                XmlNodeList albums = artist.SelectNodes("album");
                Console.WriteLine("Artist {0} has {1} albums", artistName, albums.Count);
            }
        }

        public static void XParthNavigateToXMLWriter()
        {
            XPathDocument document = new XPathDocument("../../Catalogue.xml");
            XPathNavigator navigator = document.CreateNavigator();
            
            XmlWriter xml = XmlWriter.Create("Albums.xml");
            navigator.WriteSubtree(xml);
            xml.Close();
        }

        public static void ExtractAlbumsPrices()
        {
            XmlDocument document = new XmlDocument();
            document.Load("../../Catalogue.xml");
            string xpathQuery = "catalogue/artist/album";

            XmlNodeList albums = document.SelectNodes(xpathQuery);

            Console.WriteLine("(XPath) All albums prices: ");
            foreach (XmlNode album in albums)
            {
                string price = album.SelectSingleNode("price").InnerText;
                Console.WriteLine(price);
            }
        }
    }
}
