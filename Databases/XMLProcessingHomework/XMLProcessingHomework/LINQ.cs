using System;
using System.Xml.Linq;

namespace XMLProcessingHomework
{
    class LINQ
    {
        public static void ExtractXMLWithLinq()
        {
            XDocument document = XDocument.Load("../../Catalogue.xml");
            var songsTitles = document.Descendants("song").Descendants("title");

            Console.WriteLine("Song titles: ");
            foreach (var songTitle in songsTitles)
            {
                Console.WriteLine(songTitle.Value);
            }
        }

        public static void CreatePersonWithLinq()
        {
            XElement person =
                new XElement("person",
                    new XElement("name", "Ivan Ivanov"),
                    new XElement("phone", 2342352),
                    new XElement("address", "25 A.Alexandrov, Sofia, Bulgaria"));
            Console.WriteLine(person);
        }

        public static void RewriteCatalogue()
        {
            XDocument document = XDocument.Load("../../Catalogue.xml");
            
            XElement root = new XElement("artist");
            root.Add(new XElement("name", "Beyonce"));
            root.Add(new XElement("album", 
                        new XElement("name", "Lemonade"),
                        new XElement("year","2016",
                        new XElement("producer", "Beyonce"),
                        new XElement("price","100"),
                        new XElement("songs", 
                            new XElement("song",
                                new XElement("title", "Pray You Catch Me"),
                                new XElement("duration", 3.16)),
                            new XElement("song",
                                new XElement("title", "Hold up"),
                                new XElement("duration", 3.41)),
                            new XElement("song",
                                new XElement("title", "Sorry"),
                                new XElement("duration", 3.53))))));
            document.Element("catalogue").Add(root);
            document.Save("../../Catalogue.xml");
        }

        public static void ExtractAlbumsPrices()
        {
            XDocument document = XDocument.Load("../../Catalogue.xml");
            var prices = document.Descendants("artist").Descendants("album").Descendants("price");

            Console.WriteLine("(LINQ) All Albums prices: ");
            foreach (var price in prices)
            {
                Console.WriteLine(price.Value);
            }
        }
    }
}
