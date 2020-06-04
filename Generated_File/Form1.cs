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

        List<XElement> ilist = new List<XElement>();
        TextBox a = new TextBox();

        string SqlSourceStat;
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
             
            }


            ilist.Clear();


            var elementsToSrcConn = doc.Descendants()
                                      .Where(o => o.Name == "step" && o.HasElements).Skip(2).FirstOrDefault();

            ilist.Add(elementsToSrcConn);
            foreach (XElement element in ilist)
            {
                var connection = element.Descendants().Where(z => z.Name == "connection").FirstOrDefault();

                var sql = element.Descendants().Where(z => z.Name == "sql").FirstOrDefault();

                connection.Value = txtsrname.Text;
                sql.Value = SrcSql.Text;

                SqlSourceStat = SrcSql.Text;
            }

            // after processing save it in file
            doc.Save(@"E:\Files\test_trans7.ktr");

            MessageBox.Show("Src Config created ");

            ilist.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // get the file 
            var doc = XDocument.Load(@"E:\Files\test_trans7.ktr");


            // to read file property 
            var elementsToUpdate = doc.Descendants()
                                      .Where(o => o.Name == "connection" && o.HasElements).Skip(1).FirstOrDefault();

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

            }

            ilist.Clear();

            var elementsToTrg = doc.Descendants()
                                   .Where(o => o.Name == "step" && o.HasElements).Skip(4).FirstOrDefault();

            ilist.Add(elementsToTrg);
            foreach (XElement element in ilist)
            {
                var connection = element.Descendants().Where(z => z.Name == "connection").FirstOrDefault();
                var sql_trg = element.Descendants().Where(z => z.Name == "sql").FirstOrDefault();

                connection.Value = txtTrgNam.Text;
                sql_trg.Value = trgSql.Text;
                
            }

            // after processing save it in file
            doc.Save(@"E:\Files\test_trans7.ktr");

            MessageBox.Show("Trg Config created ");

            ilist.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(a.Name);
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            DataGridViewComboBoxColumn dgvCmb = new DataGridViewComboBoxColumn();
            dgvCmb.HeaderText = "Sort Column";
           
            SqlSourceStat = SrcSql.Text;

            string toBeSearched = "select ";
            int ix = SqlSourceStat.IndexOf(toBeSearched);

            if (ix != -1)
            {
                string afterSelect = SqlSourceStat.Substring(ix + toBeSearched.Length);


                string FinalWord = BeforeStatment.Before(afterSelect, "from ");

                string[] Arr = FinalWord.Split(',');

                for (int i = 0; i < Arr.Length; i++)
                {
                    Arr[i] = Arr[i].Trim();

                    dgvCmb.Items.Add(Arr[i]);
                }
                
            }
           

            
            dgvCmb.Name = "cmbName";
            if (dataGridView1.Rows.Count == 0)
            {
                dataGridView1.AllowUserToAddRows = true;
            }
            else
            {
                dataGridView1.Rows.Add();
            }
            dataGridView1.Columns.Add(dgvCmb);


        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            // if (dataGridView1.)
            // {

            // }

            //string x =  dataGridView1.Rows.Count.ToString();

            //MessageBox.Show(x);
            //int columnIndex = dataGridView1.CurrentCell.ColumnIndex;
            //string columnName = dataGridView1.Columns[columnIndex].Name;
            //string name = "";

            //int i = 0;
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    if (row.Cells["cmbName"].Value == null)
            //    {
            //        dataGridView1.Rows.RemoveAt(i);
            //    }
            //    i++;

            //    //if (row.Cells["cmbName"].Value == null)
            //    //{
            //    //    MessageBox.Show("Row is empty");
            //    //}
            //    //else
            //    //{

            //    //    name = row.Cells["cmbName"].Value.ToString();
            //    //}

            //    //MessageBox.Show(name);
            //}

            dataGridView1.Rows.Add();



        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }


    static class BeforeStatment
    {
        public static string Before(this string value, string a)
        {
            int posA = value.IndexOf(a);
            if (posA == -1)
            {
                return "";
            }
            return value.Substring(0, posA);
        }
    }


}
