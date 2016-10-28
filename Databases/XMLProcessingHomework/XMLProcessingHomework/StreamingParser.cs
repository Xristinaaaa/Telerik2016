using System;
using System.Text;
using System.Xml;

namespace XMLProcessingHomework
{
    class StreamingParser
    {
        public static void XMLReaderExtractXML()
        {
            Console.WriteLine("Song titles: ");
            using (XmlReader reader = XmlReader.Create("../../Catalogue.xml"))
            {
                while (reader.Read())
                {
                    if (reader.Name == "title")
                    {
                        Console.WriteLine(reader.ReadElementString());
                    }
                }
            }
        }

        /*
        public static void CreateAlbum()
        {
            string fileName = "../../Album.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("album");
                writer.WriteAttributeString("name", "Albums Library");

                writer.WriteEndDocument();
            }

            using (XmlReader reader = XmlReader.Create("../../Catalogue.xml"))
            {
                while (reader.Read())
                {
                    if (reader.Name == "artist")
                    {
                        
                    }
                }
            }
        }
        */
    }
}
