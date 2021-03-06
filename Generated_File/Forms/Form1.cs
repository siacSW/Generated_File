﻿using Devart.Data.MySql;
using Generated_File.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Generated_File
{
    public partial class Form1 : Form
    {

        List<XElement> ilist = new List<XElement>();
        List<string> MergeSort = new List<string>();
       
        string SqlSourceStat;

        List<string> Connection = new List<string>();

        XDocument doc;
        XDocument mySql_Attributes;
        XDocument sqlserver_attributes;
        XDocument Sap_attributes;
        XDocument MariaDb_attributes;
   

        string username_;
        string password_;
        string host;
        string port_;
        string database_;

       
        public Form1()
        {
            InitializeComponent();

            try
            {
                doc = XDocument.Load(@"E:\Files\test_trans7-Copy.ktr");
                mySql_Attributes = XDocument.Load(@"E:\Files\MySql-attributes.xml");
                sqlserver_attributes = XDocument.Load(@"E:\Files\SqlServer-Attributes.xml");
                Sap_attributes = XDocument.Load(@"E:\Files\Sap-Attributes.xml");
                MariaDb_attributes = XDocument.Load(@"E:\Files\MariaDb-Attributes.xml");
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Error in Reading Template File " + ex.Message);
                Environment.Exit(1);
            }
        }

        //Source Event
        private void button1_Click_1(object sender, EventArgs e)
        {
            // to read file property 

            try
            {

                var elementsToUpdate = doc.Descendants()
                                          .Where(o => o.Name == "connection" && o.HasElements).FirstOrDefault();


                this.Cursor = Cursors.WaitCursor;
                ilist.Add(elementsToUpdate);

                //update elements value

           string type_selectin = null;

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
                Connection.Add(txtsrname.Text);
                
               
                if (SrCmb.SelectedItem.ToString() == "SAP")
                {
                 // server.ReplaceWith(xElementServer);
                    type.Value = "GENERIC";
                }
              else
               {
                        server.Value = txtsrServer.Text;
                        type.Value = SrCmb.SelectedItem.ToString();
               }
                type_selectin = type.Value;
                database.Value = txtsrDb.Text;
              
                port.Value = txtsrPor.Text;
                
                username.Value = txtsrUser.Text;
               // password.Value = Methods.PasswordEncrypt(txtsrPsw.Text);
                
             
            }

            ilist.Clear();

            if (type_selectin == "MYSQL")
            {
                    var AttributesElements = doc.Descendants()
                                    .Where(o => o.Name == "attributes" && o.HasElements).FirstOrDefault();
                    var Port_Number = mySql_Attributes.Descendants().Where(x => x.Name == "attribute").Skip(7).FirstOrDefault();
                    Port_Number.Value = txtsrPor.Text;
                    mySql_Attributes.Save(@"E:\Files\MySql-attributes.xml");
                    AttributesElements.ReplaceWith(mySql_Attributes.Root);
             }

            if (type_selectin == "MARIADB")
            {
                    var AttributesElements = doc.Descendants()
                                  .Where(o => o.Name == "attributes" && o.HasElements).FirstOrDefault();
                    var Port_Number = MariaDb_attributes.Descendants().Where(x => x.Name == "attribute").Skip(7).FirstOrDefault();
                    Port_Number.Value = txtsrPor.Text;
                    MariaDb_attributes.Save(@"E:\Files\MariaDb-Attributes.xml");
                    AttributesElements.ReplaceWith(MariaDb_attributes.Root);
            }

           if (type_selectin == "MSSQLNATIVE")
           {
                    var AttributesElements = doc.Descendants()
                             .Where(o => o.Name == "attributes" && o.HasElements).FirstOrDefault();
                    var Port = sqlserver_attributes.Descendants().Where(x => x.Name == "attribute").Skip(13).FirstOrDefault();
                    Port.Value = txtsrPor.Text;
                    sqlserver_attributes.Save(@"E:\Files\SqlServer-Attributes.xml");
                    AttributesElements.ReplaceWith(sqlserver_attributes.Root);
           }

          if (type_selectin == "SAP")
           {
                    var AttributesElements = doc.Descendants()
                             .Where(o => o.Name == "attributes" && o.HasElements).FirstOrDefault();
                    var Port_Number = Sap_attributes.Descendants().Where(x => x.Name == "attribute").Skip(13).FirstOrDefault();
                    var Jdbc_Conn = Sap_attributes.Descendants().Where(x => x.Name == "attribute").Skip(3).FirstOrDefault();
                    Port_Number.Value = txtsrPor.Text;
                    Jdbc_Conn.Value = txtSAPJDB.Text;
                    Sap_attributes.Save(@"E:\Files\Sap-Attributes.xml");
                    AttributesElements.ReplaceWith(Sap_attributes.Root);
           }

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

            int FileCounted = dataTableNames.Rows.Count;
             for (int i = 0; i < FileCounted; i++)
             {
                    // after processing save it in file
                    doc.Save(@"E:\Files\test_trans"+i+".ktr");
             }


            MessageBox.Show("Src Config created ");
            ilist.Clear();
           this.Cursor = Cursors.Default;
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("File Not Found " + ex.Message);
            }
            catch(Exception ex)
            {

                MessageBox.Show(" Error Occured " + ex.Message);
            }

        }

        //Target Event
        private void button2_Click(object sender, EventArgs e)
        {
            // to read file property 
            try
            {

            
            var elementsToUpdate = doc.Descendants()
                                      .Where(o => o.Name == "connection" && o.HasElements).Skip(1).FirstOrDefault();

               this.Cursor = Cursors.WaitCursor;
                ilist.Add(elementsToUpdate);

           string type_selectin = null;

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
                Connection.Add(txtTrgNam.Text);
                server.Value = txtTrSrV.Text;
                if (TrgCmb.SelectedItem.ToString() == "SAP")
                 {
                    type.Value = "GENERIC";
                 }
               else
                 {
                    type.Value = TrgCmb.SelectedItem.ToString();
                 }
                type_selectin = type.Value;
                database.Value = txtTrDB.Text;
                port.Value = txtTRPo.Text;
                username.Value = txtTrgUs.Text;
               // password.Value = Methods.PasswordEncrypt(txtTrgPs.Text);

            }

            ilist.Clear();

                if (type_selectin == "MYSQL")
                {
                    var AttributesElements = doc.Descendants()
                                    .Where(o => o.Name == "attributes" && o.HasElements).FirstOrDefault();
                    var Port_Number = mySql_Attributes.Descendants().Where(x => x.Name == "attribute").Skip(7).FirstOrDefault();
                    Port_Number.Value = txtsrPor.Text;
                    mySql_Attributes.Save(@"E:\Files\MySql-attributes.xml");
                    AttributesElements.ReplaceWith(mySql_Attributes.Root);
                }

                if (type_selectin == "MARIADB")
                {
                    var AttributesElements = doc.Descendants()
                                  .Where(o => o.Name == "attributes" && o.HasElements).FirstOrDefault();
                    var Port_Number = MariaDb_attributes.Descendants().Where(x => x.Name == "attribute").Skip(7).FirstOrDefault();
                    Port_Number.Value = txtsrPor.Text;
                    MariaDb_attributes.Save(@"E:\Files\MariaDb-Attributes.xml");
                    AttributesElements.ReplaceWith(MariaDb_attributes.Root);
                }

                if (type_selectin == "MSSQLNATIVE")
                {
                    var AttributesElements = doc.Descendants()
                             .Where(o => o.Name == "attributes" && o.HasElements).FirstOrDefault();
                    var Port = sqlserver_attributes.Descendants().Where(x => x.Name == "attribute").Skip(13).FirstOrDefault();
                    Port.Value = txtsrPor.Text;
                    sqlserver_attributes.Save(@"E:\Files\SqlServer-Attributes.xml");
                    AttributesElements.ReplaceWith(sqlserver_attributes.Root);
                }

                if (type_selectin == "SAP")
                {
                    var AttributesElements = doc.Descendants()
                             .Where(o => o.Name == "attributes" && o.HasElements).FirstOrDefault();
                    var Port_Number = Sap_attributes.Descendants().Where(x => x.Name == "attribute").Skip(13).FirstOrDefault();
                    var Jdbc_Conn = Sap_attributes.Descendants().Where(x => x.Name == "attribute").Skip(3).FirstOrDefault();
                    Port_Number.Value = txtsrPor.Text;
                    Jdbc_Conn.Value = txtSAPJDB.Text;
                    Sap_attributes.Save(@"E:\Files\Sap-Attributes.xml");
                    AttributesElements.ReplaceWith(Sap_attributes.Root);
                }

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
           
            catch (Exception ex)
            {

                MessageBox.Show(" Error Occured " + ex.Message);
            }

        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        private void btnsort_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {

                MessageBox.Show(" Error Occured " + ex.Message);
            }


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
            try
            {
                DataGridViewComboBoxColumn dgvCmb = new DataGridViewComboBoxColumn();
                dgvCmb.HeaderText = "Sort Column";

                SqlSourceStat = SrcSql.Text;

                string toBeSearched = "select ";
                int ix = SqlSourceStat.IndexOf(toBeSearched);

                if (ix != -1)
                {
                    string afterSelect = SqlSourceStat.Substring(ix + toBeSearched.Length);

                    string FinalWord = Methods.Before(afterSelect, "from ");

                    string[] Arr = FinalWord.Split(',');


                    for (int i = 0; i < Arr.Length; i++)
                    {
                        Arr[i] = Arr[i].Trim();
                        MergeSort.Add(Arr[i]);

                        dgvCmb.Items.Add(Arr[i]);
                    }

                }



                dgvCmb.Name = "cmbName";

                dataGridView1.Columns.Add(dgvCmb);

                sortpnl.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured" + ex.Message);
            }
         
        }

        private void btnTrS_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewComboBoxColumn dgvCmb = new DataGridViewComboBoxColumn();
                dgvCmb.HeaderText = "Sort Column";


                SqlSourceStat = trgSql.Text;

                string toBeSearched = "select ";
                int ix = SqlSourceStat.IndexOf(toBeSearched);

                if (ix != -1)
                {
                    string afterSelect = SqlSourceStat.Substring(ix + toBeSearched.Length);


                    string FinalWord = Methods.Before(afterSelect, "from ");

                    string[] Arr = FinalWord.Split(',');


                    for (int i = 0; i < Arr.Length; i++)
                    {
                        Arr[i] = Arr[i].Trim();
                        MergeSort.Add(Arr[i]);

                        dgvCmb.Items.Add(Arr[i]);
                    }

                }



                dgvCmb.Name = "cmbName";

                datagridTrgSRT.Columns.Add(dgvCmb);

                trgPnl.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured " + ex.Message);
            }
           
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
            try
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
            catch (Exception ex)
            {

                MessageBox.Show(" Error Occured " + ex.Message);
            }
        }

        private void btnmerg_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewComboBoxColumn dgvCmb = new DataGridViewComboBoxColumn();
                DataGridViewComboBoxColumn keycmb = new DataGridViewComboBoxColumn();
                dgvCmb.HeaderText = "Values Column";
                keycmb.HeaderText = "Keys Column";

                //For Values datagridView
                foreach (var item in MergeSort.Distinct())
                {
                    dgvCmb.Items.Add(item);
                }

                //To Filter only matched values ..
                var query = MergeSort.GroupBy(x => x)
                  .Where(g => g.Count() > 1)
                  .Select(y => y.Key)
                  .ToList();

                //For Keys datagridView
                foreach (var item in query)
                {
                    keycmb.Items.Add(item);
                }



                dgvCmb.Name = "ValueColms";
                keycmb.Name = "Keycolms";


                valuedatagrd.Columns.Add(dgvCmb);
                keydatagrd.Columns.Add(keycmb);
                MergPnl.Visible = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error Occured " + ex.Message);
                
            }
           
        }

        private void btnMergSav_Click(object sender, EventArgs e)
        {
            //Keys Actions
            #region

            try
            {


            var elementsToUpdate = doc.Descendants()
                                    .Where(o => o.Name == "step" && o.HasElements).FirstOrDefault();

            var fields = elementsToUpdate.Descendants()
                                     .Where(o => o.Name == "keys" && o.HasElements).FirstOrDefault();


            int rowscount = keydatagrd.Rows.Count;

            //to append new childs to keys
            for (int i = 0; i < rowscount - 1; i++)
            {
                var fiedlNode = fields.Descendants()
                                       .Where(x => x.Name.LocalName == "key")
                                       .FirstOrDefault();
                fields.Add(fiedlNode);
            }

            var KeyNodes = elementsToUpdate.Descendants()
                                 .Where(o => o.Name == "keys" && o.HasElements).ToList();

            int Counted = fields.Descendants().Count();
            var List_keys = fields.Elements().ToList();

            //to assign new values for keys
            for (int i = 0; i < Counted; i++)
            {

                List_keys[i].Value = keydatagrd.Rows[i].Cells["Keycolms"].Value.ToString();

            }


            doc.Save(@"E:\Files\test_trans7.ktr");

            MessageBox.Show("keys Created");
        }
             
            catch (Exception ex)
            {

                MessageBox.Show("Error Occured" + ex.Message);
            }
            
            #endregion

         

        }

        private void btnaddKe_Click(object sender, EventArgs e)
        {
            keydatagrd.Rows.Add();
        }

        private void btnaddVal_Click(object sender, EventArgs e)
        {
            valuedatagrd.Rows.Add();
        }

        private void btnDelKe_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.keydatagrd.SelectedRows)
            {
                keydatagrd.Rows.RemoveAt(item.Index);
            }
        }

        private void btnDelVal_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.valuedatagrd.SelectedRows)
            {
                valuedatagrd.Rows.RemoveAt(item.Index);
            }
        }

        private void btnsaveVal_Click(object sender, EventArgs e)
        {
            try
            {

          
            var elementsToUpdate = doc.Descendants()
                                 .Where(o => o.Name == "step" && o.HasElements).FirstOrDefault();

            var fields = elementsToUpdate.Descendants()
                                     .Where(o => o.Name == "values" && o.HasElements).FirstOrDefault();


            int rowscount = valuedatagrd.Rows.Count;

            //to append new childs to values
            for (int i = 0; i < rowscount - 1; i++)
            {
                var fiedlNode = fields.Descendants()
                                       .Where(x => x.Name.LocalName == "value")
                                       .FirstOrDefault();
                fields.Add(fiedlNode);
            }


            //to assign new values for values
            var fieldsNodes_ = elementsToUpdate.Descendants()
                                 .Where(o => o.Name == "values" && o.HasElements).ToList();

            int Counted = fields.Descendants().Count();
            var List_keys = fields.Elements().ToList();

            //to assign new values for keys
            for (int i = 0; i < Counted; i++)
            {

                List_keys[i].Value = valuedatagrd.Rows[i].Cells["ValueColms"].Value.ToString(); ;

            }


            doc.Save(@"E:\Files\test_trans7.ktr");

            MessageBox.Show("values Created");
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Error in File" + ex.Message);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in Connection)
                {
                    connBox.Items.Add(item.Trim());
                }

                DataGridViewComboBoxColumn dgvCmb = new DataGridViewComboBoxColumn();
                DataGridViewComboBoxColumn UpdCmb = new DataGridViewComboBoxColumn();
                DataGridViewComboBoxColumn keycmb = new DataGridViewComboBoxColumn();
                dgvCmb.HeaderText = "Values Column";
                UpdCmb.HeaderText = "Update";
                keycmb.HeaderText = "Keys Column";

                //For Values datagridView
                foreach (var item in MergeSort.Distinct())
                {
                    dgvCmb.Items.Add(item.Trim());
                }

                //To Filter only matched values ..
                var query = MergeSort.GroupBy(x => x)
                  .Where(g => g.Count() > 1)
                  .Select(y => y.Key)
                  .ToList();

                List<string> UpdatValues = new List<string>
            {
                "N" , "Y"
            };

                //For Keys datagridView
                foreach (var item in query)
                {
                    keycmb.Items.Add(item.Trim());
                }

                //For Update Colms
                foreach (var update_item in UpdatValues)
                {
                    UpdCmb.Items.Add(update_item.Trim());
                }





                dgvCmb.Name = "ValueColms";
                keycmb.Name = "Keycolms";
                UpdCmb.Name = "UpdColms";


                valueSyncGd.Columns.Add(dgvCmb);
                valueSyncGd.Columns.Add(UpdCmb);
                keySyncGd.Columns.Add(keycmb);
                syncPnl.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured " + ex.Message);
            }
          
        }

        private void keysyncAdd_Click(object sender, EventArgs e)
        {
            keySyncGd.Rows.Add();
        }

        private void keySyncDel_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.keySyncGd.SelectedRows)
            {
                keySyncGd.Rows.RemoveAt(item.Index);
            }
        }

        private void valueSyncAdd_Click(object sender, EventArgs e)
        {
            valueSyncGd.Rows.Add();
        }

        private void valueSyncDel_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.valueSyncGd.SelectedRows)
            {
                valueSyncGd.Rows.RemoveAt(item.Index);
            }
        }


        private void btnSaveSync_Click(object sender, EventArgs e)
        {
            try
            {

                var elementsToUpdate = doc.Descendants()
                                         .Where(o => o.Name == "step" && o.HasElements).Skip(1).FirstOrDefault();


                var Keyfields = elementsToUpdate.Descendants()
                                        .Where(o => o.Name == "key" && o.HasElements).FirstOrDefault();

                var ConnectionName = elementsToUpdate.Descendants().Where(z => z.Name == "connection").FirstOrDefault();

                ConnectionName.Value = connBox.SelectedItem.ToString();


                var LookUpfields = elementsToUpdate.Descendants()
                                        .Where(o => o.Name == "lookup" && o.HasElements).FirstOrDefault();

                var TableName = LookUpfields.Descendants().Where(y => y.Name == "table").FirstOrDefault();
                TableName.Value = txtTbleSync.Text;

                MessageBox.Show("saved");
            }
          
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured " + ex.Message);
            }

            
        }

        private void btnSaveSyncKey_Click(object sender, EventArgs e)
        {
            try
            {

          

            var elementsToUpdate = doc.Descendants()
                                     .Where(o => o.Name == "step" && o.HasElements).Skip(1).FirstOrDefault();


            var LookUpfields = elementsToUpdate.Descendants()
                                    .Where(o => o.Name == "lookup" && o.HasElements).FirstOrDefault();

            //to add new Key Childs
            int KeyRowCount = keySyncGd.Rows.Count;

            for (int i = 0; i < KeyRowCount-1; i++)
            {
                var KeyFiledFirstOne = LookUpfields.Descendants()
                                       .Where(x => x.Name.LocalName == "key")
                                       .FirstOrDefault();

                LookUpfields.Add(KeyFiledFirstOne);
            }

            //to assign new values 
            var fieldsNodes = elementsToUpdate.Descendants()
                                 .Where(o => o.Name == "lookup" && o.HasElements).ToList();


            var keystobeupdated = fieldsNodes.Descendants().Where(x => x.Name == "key").ToList();

            int xy = keystobeupdated.Count;

            int Counted = LookUpfields.Descendants().Where(x => x.Name.LocalName == "key").Count();

            for (int i = 0; i < Counted; i++)
            {
                var nam_tst = keystobeupdated[i].Descendants().Where(z => z.Name == "name").FirstOrDefault();

                var field_tst = keystobeupdated[i].Descendants().Where(z => z.Name == "field").FirstOrDefault();
                nam_tst.Value = keySyncGd.Rows[i].Cells["Keycolms"].Value.ToString();
                field_tst.Value = keySyncGd.Rows[i].Cells["Keycolms"].Value.ToString();

            }


            doc.Save(@"E:\Files\test_trans7.ktr");
            MessageBox.Show("Key for Sync Created");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error Occured " + ex.Message);
            }
        }

        private void btnValueSyncSV_Click(object sender, EventArgs e)
        {
            try
            {

               
            var elementsToUpdate = doc.Descendants()
                                    .Where(o => o.Name == "step" && o.HasElements).Skip(1).FirstOrDefault();


            var LookUpfields = elementsToUpdate.Descendants()
                                    .Where(o => o.Name == "lookup" && o.HasElements).FirstOrDefault();

            //to add new Key Childs
            int ValueRowCount = valueSyncGd.Rows.Count;

            int KeyRowsCount = keySyncGd.Rows.Count;

            for (int i = 0; i < ValueRowCount - 1; i++)
            {
                var KeyFiledFirstOne = LookUpfields.Descendants()
                                       .Where(x => x.Name.LocalName == "value")
                                       .FirstOrDefault();

                LookUpfields.Add(KeyFiledFirstOne);
            }

            //to assign new values 
            var fieldsNodes = elementsToUpdate.Descendants()
                                 .Where(o => o.Name == "lookup" && o.HasElements).ToList();


            var valuestobeupdated = fieldsNodes.Descendants().Where(x => x.Name == "value").ToList();


            int Counted = LookUpfields.Descendants().Where(x => x.Name.LocalName == "value").Count();
            
            for (int i = 0; i < Counted; i++)
            {
                var nam_tst = valuestobeupdated[i].Descendants().Where(z => z.Name == "name").FirstOrDefault();



                var field_tst = valuestobeupdated[i].Descendants().Where(z => z.Name == "rename").FirstOrDefault();
                nam_tst.Value = valueSyncGd.Rows[i].Cells["ValueColms"].Value.ToString();
                field_tst.Value = valueSyncGd.Rows[i].Cells["ValueColms"].Value.ToString();



                var update_tg = valuestobeupdated[i].Descendants().Where(z => z.Name == "update").FirstOrDefault();
                update_tg.Value = valueSyncGd.Rows[i].Cells["UpdColms"].Value.ToString();
            }


            doc.Save(@"E:\Files\test_trans7.ktr");
            MessageBox.Show("Value for Sync Created");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error Occured in application " + ex.Message);
            }
        }

        private void SrCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SrCmb.SelectedItem.ToString() == "SAP")
            {
                lbl_SAPJDBC.Visible = true;

                txtSAPJDB.Visible = true;
            }
            else
            {
                lbl_SAPJDBC.Visible = false;

                txtSAPJDB.Visible = false;
            }
        }

        private void btncheck_Click(object sender, EventArgs e)
        {
            try
            {
                dataTableNames.Columns.Clear();
                username_ = txtsrUser.Text;
                password_ = txtsrPsw.Text;
                host = txtsrServer.Text;
                database_ = txtsrDb.Text;
                port_ = txtsrPor.Text;

                if (SrCmb.SelectedItem.ToString() == "MSSQLNATIVE")
                {
                    var databaseTabels = Methods.SQLSERVERGET(host, database_, username_, password_);

                    DataGridViewComboBoxColumn dgvCmb = new DataGridViewComboBoxColumn();
                    dgvCmb.HeaderText = "Database Tables";

                    foreach (var item in databaseTabels)
                    {
                        dgvCmb.Items.Add(item.Trim());

                    }



                    dgvCmb.Name = "TbleName";

                    dataTableNames.Columns.Add(dgvCmb);
                   // dataTableNames.Columns.Add();

                }


            if (SrCmb.SelectedItem.ToString() == "MYSQL")
            {
                var databaseTables = Methods.MySqlGET(username_, password_, host, port_, database_);
                 DataGridViewComboBoxColumn dgvCmb = new DataGridViewComboBoxColumn();
               dgvCmb.HeaderText = "Database Tables";

                foreach (var item in databaseTables)
                {
                   dgvCmb.Items.Add(item.Trim());
                }



                    dgvCmb.Name = "TbleName";

                    dataTableNames.Columns.Add(dgvCmb);


             }
        }
              catch (Exception ex)
            {
                MessageBox.Show("Error Occured" + ex.Message);
            }


        }

        private void btnaddTbleName_Click(object sender, EventArgs e)
        {
            dataTableNames.Rows.Add();
        }
    }


     static class Methods
    {
        static string SqlServer_ConnectionString;

        static string MySql_ConnectionString;
        public static string Before(this string value, string a)
        {
            int posA = value.IndexOf(a);
            if (posA == -1)
            {
                return "";
            }
            return value.Substring(0, posA);
        }

        public  static string PasswordEncrypt(string password , string path )
        {

            string strline = "";
            try
            {
                ProcessStartInfo ps = new ProcessStartInfo
                {
                    FileName = @""+path+" ",
                    //FileName = @"E:\data-integration\Encr.bat",
                    //FileName = "E:\\data-integration\\Encr.bat",
                    Arguments = "-kettle  " + password + " ",
                    CreateNoWindow = true,
                    ErrorDialog = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    //WorkingDirectory = @"E:\data-integration"
                };
                Process p = Process.Start(ps);
                p.WaitForExit();
                StreamReader strm = p.StandardOutput;
              
                while (strm.EndOfStream == false)
                {
                    strline = strm.ReadLine();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Encryption Method : " + ex.Message);
            }


            return strline;

        }



       public static List<string> MySqlGET (string username, string password, string host, string port, string database)
        {
            List<string> TableNames = new List<string>();
            try
            {
                string Connection_str = "User Id = " + username + "; Password = " + password + "; Host = " + host + "; Port = " + port + "; Database = " + database + "; Unicode = False; Persist Security Info = False; Character Set = utf8; Found Rows = True";


                MySqlConnection connection = new MySqlConnection(Connection_str);

                MySql_ConnectionString = Connection_str;

                MySqlCommand command = connection.CreateCommand();
               
                command.CommandText = "SHOW TABLES;";
                MySqlDataReader Reader;
                connection.Open();
                Reader = command.ExecuteReader();
                while (Reader.Read())
                {
                    string row = "";
                    for (int i = 0; i < Reader.FieldCount; i++)
                        row += Reader.GetValue(i).ToString();
                    TableNames.Add(row);
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured in MySQl Connection " + ex.Message);

                TableNames.Add("Not");
            }


            return TableNames;

        }



        public static List<string> SQLSERVERGET(string host, string database, string username, string password)
        {
            List<string> TableNames = new List<string>();

            try
            {
                string connection_string = "Data Source=" + host + ",1433;Network Library=DBMSSOCN;Initial Catalog=" + database + ";User ID=" + username + ";Password=" + password + ";";
                SqlServer_ConnectionString = connection_string;

                using (SqlConnection connection = new SqlConnection(connection_string))
                {
                    connection.Open();
                    DataTable schema = connection.GetSchema("Tables");
                   
                    foreach (DataRow row in schema.Rows)
                    {
                        TableNames.Add(row[2].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured in Sqlserver Connection " + ex.Message);

                TableNames.Add("Not");
            }

            return TableNames;

        }



        public static List<string> SapTables(string word2)
        {
           // string word2 = "jdbc:saperp:Host=10.1.1.52;User=Dina;Password=Da@2020;Client=310;System Number=30;ConnectionType=CLASSIC_UNICODE;SupportEnhancedSQL=True;UseSimpleNames=False;TableMode=All;Tables=MSEG,MKPF,MARA,T001W,T156T,MAKT,T023T,T134T,MCHA,KNA1,AUSP,CABNT;Views=MSEG,MKPF,MARA,T001W,T156T,MAKT,T023T,T134T,MCHA,AUSP,KNA1,CABNT";

            List<string> Tables = new List<string>();
            // string word2 = "Tables=MSEG,MKPF,MARA,T001W,T156T,MAKT,T023T,T134T,MCHA,KNA1,AUSP,CABNT;Views=MSEG,MKPF,MARA,T001W,T156T,MAKT,T023T,T134T,MCHA,AUSP,KNA1,CABNT";
            int start = word2.IndexOf("Tables", 0);
            int End = word2.IndexOf("Views", start);
            string final = word2.Substring(start, End - start);

            string toBeSearched = "Tables=";
            int ix = word2.IndexOf(toBeSearched);

            if (ix != -1)
            {
                string afterSelect = word2.Substring(ix + toBeSearched.Length);
                string FinalWord = Before(afterSelect, "Views");
                string[] Arr = FinalWord.Split(new char[] { ',', ';' });

                Tables = Arr.ToList();
            }

            Tables = Tables.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();


            return Tables;
        }


        public static List<string> ReturnFields(string data_type , string tble_name)
        {
            List<string> FieldsName = new List<string>(); 

            if (data_type == "MSSQLNATIVE")
            {
             
                using (SqlConnection conn = new SqlConnection(SqlServer_ConnectionString))
                {
                    conn.Open();
                    string Query = "SELECT column_name FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" +tble_name+ "' ";
                    SqlCommand command = new SqlCommand(Query, conn);

                    SqlDataReader sqlDataReader = command.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        FieldsName.Add(sqlDataReader[0].ToString());
                    }

                    conn.Close();
                }

            }


            if (data_type == "MYSQL" || data_type == "MARIADB")
            {

                using (MySqlConnection conn = new MySqlConnection(MySql_ConnectionString))
                {
                    conn.Open();
                    DataTable dataTable_ = new DataTable();
                    string Query = "select COLUMN_NAME as 'name' from information_schema.columns where table_name= '" + tble_name + "'   ";
                    MySqlCommand command = new MySqlCommand(Query, conn);

                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);

                    dataAdapter.Fill(dataTable_);

                    foreach (DataRow item in dataTable_.Rows)
                    {
                        FieldsName.Add(item["Name"].ToString());
                    }

                    conn.Close();
                }

            }

            return FieldsName;
        }

        
        public static List<string> ReturnPk(string data_type,string table_name)
        {

            List<string> PrimaryKeys = new List<string>();

            try
            {



                if (data_type == "MYSQL" || data_type == "MARIADB")
                {
                    using (MySqlConnection conn = new MySqlConnection(MySql_ConnectionString))
                    {
                        conn.Open();
                        DataTable dataTable_ = new DataTable();
                        DataTable ukDataTable = new DataTable();
                        //string Query = "SHOW KEYS FROM " + table_name + " WHERE Key_name = 'PRIMARY'";
                        //string UkQuery = "show indexes from "+table_name+" WHERE Key_name != 'PRIMARY'; ";

                        string Query = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu WHERE kcu.TABLE_NAME = '" + table_name + "' AND kcu.CONSTRAINT_SCHEMA = '" + GlobalVariables.DbName + "'; ";

                        MySqlCommand command = new MySqlCommand(Query, conn);


                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);


                        dataAdapter.Fill(dataTable_);

                        foreach (DataRow item in dataTable_.Rows)
                        {
                            PrimaryKeys.Add(item["COLUMN_NAME"].ToString());
                        }

                        conn.Close();
                    }
                }


                if (data_type == "MSSQLNATIVE")
                {
                    using (SqlConnection conn = new SqlConnection(SqlServer_ConnectionString))
                    {
                        conn.Open();
                        // string Query = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGEWHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + QUOTENAME(CONSTRAINT_NAME)), 'IsPrimaryKey') = 1 AND TABLE_NAME = '"+table_name+"' ";
                        string ukQuery = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE WHERE TABLE_NAME = '" + table_name + "'";
                        // SqlCommand command = new SqlCommand(Query, conn);

                        SqlCommand ukcommand = new SqlCommand(ukQuery, conn);

                        //   SqlDataReader sqlDataReader = command.ExecuteReader();

                        SqlDataReader ukReader = ukcommand.ExecuteReader();

                        //while (sqlDataReader.Read())
                        //{
                        //    PrimaryKeys.Add(sqlDataReader[0].ToString());
                        //}

                        while (ukReader.Read())
                        {
                            PrimaryKeys.Add(ukReader[0].ToString());
                        }

                        conn.Close();
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error occured " + exp.Message);
            }

          //  GlobalVariables.PrimaryKeysList = PrimaryKeys.Distinct().ToList();
            return PrimaryKeys.Distinct().ToList();
        }



        public static List<string> SourceSql(string SourceSql)
        {
           List<string>result = new List<string>();
            string SourceStat = SourceSql.ToLower();
            string first = "select ";
            string second = "from";
            int start = SourceStat.IndexOf(first) + first.Length;
            int end = SourceStat.IndexOf(second, start);
            string retString = SourceStat.Substring(start, end - start);
            string[] Arr = retString.Split(',');

            for (int i = 0; i < Arr.Length; i++)
            {
                Arr[i] = Arr[i].Trim();
                string separator = "as ";
                int separatorIndex = Arr[i].IndexOf(separator);
                if (separatorIndex >= 0)
                {
                    result.Add(Arr[i].Substring(separatorIndex + separator.Length));

                }
              
            }

            return result;
        }

    }


}
