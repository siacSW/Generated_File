using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //XmlTextReader reader = new XmlTextReader(@"E:\Files\trf_supplierdocs_cis_inventory.ktr");
            //while (reader.Read())
            //{
            //    switch (reader.NodeType)
            //    {
            //        case XmlNodeType.Element: // The node is an element.
            //            Console.Write("<" + reader.Name);
            //            Console.WriteLine(">");
            //            break;
            //        case XmlNodeType.Text: //Display the text in each element.
            //            Console.WriteLine(reader.Value);
            //            if (reader.Value == "<connection>")
            //            {

            //            }
            //            break;
            //        case XmlNodeType.EndElement: //Display the end of the element.
            //            Console.Write("</" + reader.Name);
            //            Console.WriteLine(">");
            //            break;
            //    }
            //}

            var doc = XDocument.Load(@"E:\Files\trf_supplierdocs_cis_inventory.ktr");

          
        
            var elementsToUpdate = doc.Descendants()
                                      .Where(o => o.Name == "connection" && o.HasElements ).FirstOrDefault();

            List<XElement> ilist = new List<XElement>();
            ilist.Add(elementsToUpdate);
            //update elements value

            foreach (XElement element in ilist)
            {
                var x = element.Descendants().Where(z => z.Name == "name").FirstOrDefault() ;
               // x.Value 

               Console.WriteLine(element.Elements());
            }

            // string path = @"E:\Files\test_trans2.ktr";
            //var xElement = XElement.Load(path);
            //var points = xElement.Descendants("connection");
            //var point = points.FirstOrDefault();

            //List<XElement> ilist = new List<XElement>();
            //ilist.Add(point);


            //foreach (var item in ilist)
            //{

            //    Console.WriteLine(item);
            //}

            //save the XML back as file
          // doc.Save(@"E:\Files\test_trans3.ktr");
            Console.ReadLine();
        }
    }
}
