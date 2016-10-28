using System;
namespace XMLProcessingHomework
{
    class Startup
    {
        static void Main()
        {
            DOMParser.XMLParser();
            Console.WriteLine();

            XPath.XPathManipulation();
            Console.WriteLine();

            StreamingParser.XMLReaderExtractXML();
            Console.WriteLine();

            LINQ.ExtractXMLWithLinq();
            Console.WriteLine();

            XPath.ExtractAlbumsPrices();

            LINQ.ExtractAlbumsPrices();

            XSL.TransformXmlToHtml();
            XSL.TransformXmlWithXslTransform();
        }
    }
}
