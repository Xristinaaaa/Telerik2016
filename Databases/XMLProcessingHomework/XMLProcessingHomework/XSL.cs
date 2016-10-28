using System;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace XMLProcessingHomework
{
    class XSL
    {
        public static void TransformXmlToHtml()
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("../../Catalogue.xslt");
            xslt.Transform("../../Catalogue.xml", "../../Catalogue.html");

            
        }
        public static void TransformXmlWithXslTransform()
        {
            XslTransform xslt = new XslTransform();

            xslt.Load("../../Catalogue.xslt");
            
            XPathDocument data = new XPathDocument("../../Catalogue.xml");
            
            XmlWriter writer = new XmlTextWriter(Console.Out);
            
            xslt.Transform(data, null, writer, null);
        }
    }
}
