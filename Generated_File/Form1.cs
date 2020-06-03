using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Generated_File
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FileStream inputt = new FileStream(@"E:\Files\trf_supplierdocs_cis_inventory.ktr", FileMode.Open, FileAccess.Read);

            //StreamReader reader = new StreamReader(inputt);

            //XmlDocument xmlDocument = new XmlDocument();

            //xmlDocument.Load(@"E:\Files\trf_supplierdocs_cis_inventory.ktr");

           // Console.WriteLine();


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // get the file 
            var doc = XDocument.Load(@"E:\Files\test_trans7.ktr");


            // to read file property 
            var elementsToUpdate = doc.Descendants()
                                      .Where(o => o.Name == "connection" && o.HasElements).FirstOrDefault();

            List<XElement> ilist = new List<XElement>();
            ilist.Add(elementsToUpdate);

            //update elements value

            foreach (XElement element in ilist)
            {
                var name = element.Descendants().Where(z => z.Name == "name").FirstOrDefault();
                var server = element.Descendants().Where(z => z.Name == "server").FirstOrDefault();
                var type = element.Descendants().Where(z => z.Name == "type").FirstOrDefault();
                var database = element.Descendants().Where(z => z.Name == "database").FirstOrDefault();
                var port = element.Descendants().Where(z => z.Name == "port").FirstOrDefault();
                var username = element.Descendants().Where(z => z.Name == "username").FirstOrDefault();
                var password = element.Descendants().Where(z => z.Name == "password").FirstOrDefault();

                name.Value = txtsrname.Text;
                server.Value = txtsrServer.Text;
                type.Value = SrCmb.SelectedItem.ToString();
                database.Value = txtsrDb.Text;
                port.Value = txtsrPor.Text;
                username.Value = txtsrUser.Text;
                password.Value = txtsrPsw.Text;

                // Console.WriteLine(element);
            }

            // after processing save it in file
             doc.Save(@"E:\Files\test_trans7.ktr");

            MessageBox.Show("Src Config created ");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // get the file 
            var doc = XDocument.Load(@"E:\Files\test_trans7.ktr");


            // to read file property 
            var elementsToUpdate = doc.Descendants()
                                      .Where(o => o.Name == "connection" && o.HasElements).Skip(1).FirstOrDefault();

            List<XElement> ilist = new List<XElement>();
            ilist.Add(elementsToUpdate);

            //update elements value

            foreach (XElement element in ilist)
            {
                var name = element.Descendants().Where(z => z.Name == "name").FirstOrDefault();
                var server = element.Descendants().Where(z => z.Name == "server").FirstOrDefault();
                var type = element.Descendants().Where(z => z.Name == "type").FirstOrDefault();
                var database = element.Descendants().Where(z => z.Name == "database").FirstOrDefault();
                var port = element.Descendants().Where(z => z.Name == "port").FirstOrDefault();
                var username = element.Descendants().Where(z => z.Name == "username").FirstOrDefault();
                var password = element.Descendants().Where(z => z.Name == "password").FirstOrDefault();

                name.Value = txtTrgNam.Text;
                server.Value = txtTrSrV.Text;
                type.Value = TrgCmb.SelectedItem.ToString();
                database.Value = txtTrDB.Text;
                port.Value = txtTRPo.Text;
                username.Value = txtTrgUs.Text;
                password.Value = txtTrgPs.Text;

                // Console.WriteLine(element);
            }

            // after processing save it in file
            doc.Save(@"E:\Files\test_trans7.ktr");

            MessageBox.Show("Trg Config created ");
        }
    }
}
