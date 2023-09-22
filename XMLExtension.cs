using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project2_Group_24
{
    public static class XMLExtension
    {
        public static void WriteStartDocument(this XDocument doc, string version, string encoding)
        {
            doc.Declaration = new XDeclaration(version, encoding, null);
        }

        public static XElement WriteStartRootElement(this XDocument doc, string rootElementName)
        {
            XElement root = new XElement(rootElementName);
            doc.Add(root);
            return root;
        }

        public static void WriteEndRootElement(this XDocument doc)
        {
            // No action required as XElement handles this automatically.
        }

        public static XElement WriteStartElement(this XElement element, string elementName)
        {
            XElement newElement = new XElement(elementName);
            element.Add(newElement);
            return newElement;
        }

        public static void WriteEndElement(this XElement element)
        {
            // No action required as XElement handles this automatically.
        }

        public static void WriteAttribute(this XElement element, string attributeName, string value)
        {
            element.SetAttributeValue(attributeName, value);
        }
    }
}
