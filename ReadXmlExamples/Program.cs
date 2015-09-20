using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ReadXmlExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetAllArtistWithXdocument();
            //GetAllArtistWithXdocument2();
            GetAllArtistWithXmlReader();
        }

        private static void GetAllArtistWithXmlReader()
        {
            using (XmlReader reader = XmlReader.Create("cdCatalog.xml"))
            {
                while (reader.Read())
                {
                     if (reader.Name.Equals("ARTIST")) Console.WriteLine(reader.ReadInnerXml());
                }
            }    
        }

        private static void GetAllArtistWithXdocument()
        {
            XDocument xDoc = XDocument.Load("cdCatalog.xml");

            IEnumerable<XElement> artists = from e in xDoc.Root.Descendants("CD") select e.Element("ARTIST");

            Console.WriteLine("found {0} elements", artists.Count());

            foreach (var xElement in artists)
            {
                Console.WriteLine(xElement.Value);
                
            }
        }
        private static void GetAllArtistWithXdocument2()
        {
            XDocument xDoc = XDocument.Load("cdCatalog.xml");

            IEnumerable<XElement> artists = xDoc.Root.Elements("CD").Elements("ARTIST");

            Console.WriteLine("found {0} elements", artists.Count());

            foreach (var xElement in artists)
            {
                Console.WriteLine(xElement.Value);
            }
        }
    }
}
