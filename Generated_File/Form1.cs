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
        string SqlSourceStat;
        
        XDocument doc = XDocument.Load(@"E:\Files\test_trans7.ktr");
        public Form1()
        {
            InitializeComponent();
        }

        //Source Event
        private void button1_Click_1(object sender, EventArgs e)
        {
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

        //Target Event
        private void button2_Click(object sender, EventArgs e)
        {
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

        private void button3_Click_2(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        private void btnsort_Click(object sender, EventArgs e)
        {
            var elementsToUpdate = doc.Descendants()
                                      .Where(o => o.Name == "step" && o.HasElements).Skip(3).FirstOrDefault();

            var fields = elementsToUpdate.Descendants()
                                     .Where(o => o.Name == "fields" && o.HasElements).FirstOrDefault();




            int rowscount = dataGridView1.Rows.Count;

            //to append new childs
            for (int i = 0; i < rowscount-1; i++)
            {
                var fiedlNode = fields.Descendants()
                                       .Where(x => x.Name.LocalName == "field")
                                       .FirstOrDefault();
                fields.Add(fiedlNode);
            }

            //to assign new values 
            var fieldsNodes = elementsToUpdate.Descendants()
                                 .Where(o => o.Name == "field" && o.HasElements).ToList();

            for (int i = 0; i < fieldsNodes.Count; i++)
            {
                var nam_tst = fieldsNodes[i].Descendants().Where(z => z.Name == "name").FirstOrDefault();
                nam_tst.Value = dataGridView1.Rows[i].Cells["cmbName"].Value.ToString();

            }


            doc.Save(@"E:\Files\test_trans7.ktr");

            MessageBox.Show("Sorted Fields Created");


        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
        }

        private void btnSortView_Click(object sender, EventArgs e)
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
       
            dataGridView1.Columns.Add(dgvCmb);

            sortpnl.Visible = true;
        }

        private void btnTrS_Click(object sender, EventArgs e)
        {
            DataGridViewComboBoxColumn dgvCmb = new DataGridViewComboBoxColumn();
            dgvCmb.HeaderText = "Sort Column";

            SqlSourceStat = trgSql.Text;

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
          
            datagridTrgSRT.Columns.Add(dgvCmb);

            trgPnl.Visible = true;
        }

        private void btnTrgSr_Click(object sender, EventArgs e)
        {
            datagridTrgSRT.Rows.Add();
        }
        private void btnTrgDel_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.datagridTrgSRT.SelectedRows)
            {
                datagridTrgSRT.Rows.RemoveAt(item.Index);
            }
        }

        private void btnTrgSrt_Click(object sender, EventArgs e)
        {
            var elementsToUpdate = doc.Descendants()
                                     .Where(o => o.Name == "step" && o.HasElements).Skip(5).FirstOrDefault();

            var fields = elementsToUpdate.Descendants()
                                     .Where(o => o.Name == "fields" && o.HasElements).FirstOrDefault();




            int rowscount = datagridTrgSRT.Rows.Count;

            //to append new childs
            for (int i = 0; i < rowscount - 1; i++)
            {
                var fiedlNode = fields.Descendants()
                                       .Where(x => x.Name.LocalName == "field")
                                       .FirstOrDefault();
                fields.Add(fiedlNode);
            }

            //to assign new values 
            var fieldsNodes = elementsToUpdate.Descendants()
                                 .Where(o => o.Name == "field" && o.HasElements).ToList();

            for (int i = 0; i < fieldsNodes.Count; i++)
            {
                var nam_tst = fieldsNodes[i].Descendants().Where(z => z.Name == "name").FirstOrDefault();
                nam_tst.Value = datagridTrgSRT.Rows[i].Cells["cmbName"].Value.ToString();

            }


            doc.Save(@"E:\Files\test_trans7.ktr");

            MessageBox.Show("Sorted Fields Created");
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
