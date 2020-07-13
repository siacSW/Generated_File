using Generated_File.Classes;
using Generated_File.Forms;
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
using System.Xml.Linq;

namespace Generated_File
{
    public partial class MainForm : Form
    {
        public string grid_Count;
        XDocument doc;
        XDocument mySql_Attributes;
        XDocument sqlserver_attributes;
        XDocument Sap_attributes;
        XDocument MariaDb_attributes;


        List<XElement> ilist = new List<XElement>();



        public MainForm()
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
            catch (Exception ex)
            {
                MessageBox.Show("Error in Reading Template File " + ex.Message);
                Environment.Exit(1);
            }
        }

        private void btngenerate_Click(object sender, EventArgs e)
        {
            CombData.Rows.Add();


            try
            {
                //  btnaddNew.Visible = true;
                this.Cursor = Cursors.WaitCursor;
                CombData.Rows.Clear();

                var elementsToUpdateSource = doc.Descendants()
                                          .Where(o => o.Name == "connection" && o.HasElements).FirstOrDefault();

                var elementsToUpdateTaregt = doc.Descendants()
                                    .Where(o => o.Name == "connection" && o.HasElements).Skip(1).FirstOrDefault();
              
                #region SourceRegion
                if (SrCmb.SelectedItem == null)
                {
                    MessageBox.Show("You cannot set to null");

                }
                else
                {
                    ilist.Add(elementsToUpdateSource);
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
                        GlobalVariables.ConnList.Add(txtsrname.Text);
                       // Connection.Add(txtsrname.Text);
                        server.Value = txtsrServer.Text;

                        if (SrCmb.SelectedItem.ToString() == "SAP")
                        {
                            type.Value = "GENERIC";
                        }
                        else
                        {
                            type.Value = SrCmb.SelectedItem.ToString();
                        }
                      //  type_selectin = type.Value;
                        database.Value = txtsrDb.Text;

                        port.Value = txtsrPor.Text;

                        username.Value = txtsrUser.Text;
                        password.Value = Methods.PasswordEncrypt(txtsrPsw.Text);

                    }

                    ilist.Clear();

                    CombData.Rows.Add();
                    switch (SrCmb.SelectedItem.ToString())
                    {

                        case "MSSQLNATIVE":

                            var AttributesElements = elementsToUpdateSource.Descendants().Where(o => o.Name == "attributes" && o.HasElements).FirstOrDefault();
                            var Port = sqlserver_attributes.Descendants().Where(x => x.Name == "attribute").Skip(13).FirstOrDefault();
                            Port.Value = txtsrPor.Text;
                            sqlserver_attributes.Save(@"E:\Files\SqlServer-Attributes.xml");
                            AttributesElements.ReplaceWith(sqlserver_attributes.Root);

                            var dataCollectionSQlServer = Methods.SQLSERVERGET(txtsrServer.Text, txtsrDb.Text, txtsrUser.Text, txtsrPsw.Text);
                          
                            foreach (var item in dataCollectionSQlServer)
                            {
                                SrcColumn.Items.Add(item);
                            }

                            break;

                        case "MARIADB":
                            var AttributesElementsMaria = elementsToUpdateSource.Descendants()
                                  .Where(o => o.Name == "attributes" && o.HasElements).FirstOrDefault();
                            var Port_Number = MariaDb_attributes.Descendants().Where(x => x.Name == "attribute").Skip(7).FirstOrDefault();
                            Port_Number.Value = txtsrPor.Text;
                            MariaDb_attributes.Save(@"E:\Files\MariaDb-Attributes.xml");
                            AttributesElementsMaria.ReplaceWith(MariaDb_attributes.Root);


                            var dataCollectionMySql = Methods.MySqlGET(txtsrUser.Text, txtsrPsw.Text, txtsrServer.Text, txtsrPor.Text, txtsrDb.Text);
                            foreach (var item in dataCollectionMySql)
                            {
                                SrcColumn.Items.Add(item);
                                //SrcColumn.Items.Add(new CheckComboBox.CheckComboBoxItem(item, true));
                            }


                            break;

                        case "MYSQL":
                            var AttributesElementsMySql = elementsToUpdateSource.Descendants()
                                .Where(o => o.Name == "attributes" && o.HasElements).FirstOrDefault();
                            var Port_Number_ = mySql_Attributes.Descendants().Where(x => x.Name == "attribute").Skip(7).FirstOrDefault();
                            Port_Number_.Value = txtsrPor.Text;
                            mySql_Attributes.Save(@"E:\Files\MySql-attributes.xml");
                            AttributesElementsMySql.ReplaceWith(mySql_Attributes.Root);


                            var dataCollectionMySql_ = Methods.MySqlGET(txtsrUser.Text, txtsrPsw.Text, txtsrServer.Text, txtsrPor.Text, txtsrDb.Text);

                            foreach (var item in dataCollectionMySql_)
                            {
                                SrcColumn.Items.Add(item);
                                //SrcColumn.Items.Add(new CheckComboBox.CheckComboBoxItem(item, true));
                            }
                            break;


                        case "SAP":
                            var AttributesElementsSap = elementsToUpdateSource.Descendants()
                           .Where(o => o.Name == "attributes" && o.HasElements).FirstOrDefault();
                            var Port_NumberSAP = Sap_attributes.Descendants().Where(x => x.Name == "attribute").Skip(13).FirstOrDefault();
                            var Jdbc_Conn = Sap_attributes.Descendants().Where(x => x.Name == "attribute").Skip(3).FirstOrDefault();
                            Port_NumberSAP.Value = txtsrPor.Text;
                            Jdbc_Conn.Value = txtSAPJDB.Text;
                            Sap_attributes.Save(@"E:\Files\Sap-Attributes.xml");
                            AttributesElementsSap.ReplaceWith(Sap_attributes.Root);
                            break;

                        default:
                            break;
                    }
                }

                doc.Save(@"E:\Files\test_transGenerate.ktr");
                ilist.Clear();

                #endregion

                #region TargetRegion
                if (TrgCmb.SelectedItem == null)
                {
                    MessageBox.Show("You cannot set Target Db to null");
                }
                else
                {

                    ilist.Add(elementsToUpdateTaregt);
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
                        GlobalVariables.ConnList.Add(txtTrgNam.Text);
                        server.Value = txtTrSrV.Text;
                        if (TrgCmb.SelectedItem.ToString() == "SAP")
                        {
                            type.Value = "GENERIC";
                        }
                        else
                        {
                            type.Value = TrgCmb.SelectedItem.ToString();
                        }
                       // type_selectin = type.Value;
                        database.Value = txtTrDB.Text;
                        port.Value = txtTRPo.Text;
                        username.Value = txtTrgUs.Text;
                        password.Value = Methods.PasswordEncrypt(txtTrgPs.Text);

                    }

                    ilist.Clear();

                    switch (TrgCmb.SelectedItem.ToString())
                    {
                        case "MSSQLNATIVE":
                            var AttributesElementsSQlServ = elementsToUpdateTaregt.Descendants()
                           .Where(o => o.Name == "attributes" && o.HasElements).FirstOrDefault();
                            var Port = sqlserver_attributes.Descendants().Where(x => x.Name == "attribute").Skip(13).FirstOrDefault();
                            Port.Value = txtTRPo.Text;
                            sqlserver_attributes.Save(@"E:\Files\SqlServer-Attributes.xml");
                            AttributesElementsSQlServ.ReplaceWith(sqlserver_attributes.Root);

                            var dataCollectionSQlServer = Methods.SQLSERVERGET(txtTrSrV.Text, txtTrDB.Text, txtTrgUs.Text, txtTrgPs.Text);

                            foreach (var item in dataCollectionSQlServer)
                            {
                                TrgColumn.Items.Add(item);
                            }
                            break;

                        case "MYSQL":
                            var AttributesElements = elementsToUpdateTaregt.Descendants()
                                   .Where(o => o.Name == "attributes" && o.HasElements).FirstOrDefault();
                            var Port_Number = mySql_Attributes.Descendants().Where(x => x.Name == "attribute").Skip(7).FirstOrDefault();
                            Port_Number.Value = txtTRPo.Text;
                            mySql_Attributes.Save(@"E:\Files\MySql-attributes.xml");
                            AttributesElements.ReplaceWith(mySql_Attributes.Root);

                            var dataCollectionMySql = Methods.MySqlGET(txtTrgUs.Text, txtTrgPs.Text, txtTrSrV.Text, txtTRPo.Text, txtTrDB.Text);

                            foreach (var item in dataCollectionMySql)
                            {
                                TrgColumn.Items.Add(item);
                            }
                            break;

                        case "MARIADB":

                            var AttributesElementsMaria = elementsToUpdateTaregt.Descendants()
                                .Where(o => o.Name == "attributes" && o.HasElements).FirstOrDefault();
                            var Port_NumberMaria = MariaDb_attributes.Descendants().Where(x => x.Name == "attribute").Skip(7).FirstOrDefault();
                            Port_NumberMaria.Value = txtTRPo.Text;
                            MariaDb_attributes.Save(@"E:\Files\MariaDb-Attributes.xml");
                            AttributesElementsMaria.ReplaceWith(MariaDb_attributes.Root);

                            var dataCollectionMaria = Methods.MySqlGET(txtTrgUs.Text, txtTrgPs.Text, txtTrSrV.Text, txtTRPo.Text, txtTrDB.Text);

                            foreach (var item in dataCollectionMaria)
                            {
                                TrgColumn.Items.Add(item);
                            }
                            break;

                        case "SAP":
                            var AttributesElementsSap = elementsToUpdateTaregt.Descendants()
                           .Where(o => o.Name == "attributes" && o.HasElements).FirstOrDefault();
                            var Port_NumberSAP = Sap_attributes.Descendants().Where(x => x.Name == "attribute").Skip(13).FirstOrDefault();
                            var Jdbc_Conn = Sap_attributes.Descendants().Where(x => x.Name == "attribute").Skip(3).FirstOrDefault();
                            Port_NumberSAP.Value = txtTRPo.Text;
                            Jdbc_Conn.Value = TrgJdbc.Text;
                            Sap_attributes.Save(@"E:\Files\Sap-Attributes.xml");
                            AttributesElementsSap.ReplaceWith(Sap_attributes.Root);
                            break;

                        default:
                            break;
                    }
                }


                doc.Save(@"E:\Files\test_transGenerate.ktr");
                ilist.Clear();

                this.Cursor = Cursors.Default;
                #endregion

            }

            catch (Exception ee)
            {
                MessageBox.Show("Error Occured : " + ee.Message);
            }


        }

        private void btnaddNew_Click(object sender, EventArgs e)
        {


            CombData.Rows.Add();

          //  int row_number = CombData.CurrentCell.RowIndex;

            //PopupForm popupForm = new PopupForm();
            ////   popupForm.ShowDialog();

            //popupForm.StartPosition = FormStartPosition.CenterParent;
            //popupForm.ShowDialog(this);
            // GlobalVariables.row_count = CombData.Rows.Count.ToString();
            //MessageBox.Show(checkedListBox1)
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

        private void TrgCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TrgCmb.SelectedItem.ToString() == "SAP")
            {
                lbl_jdbc.Visible = true;

                TrgJdbc.Visible = true;
            }
            else
            {
                lbl_jdbc.Visible = false;

                TrgJdbc.Visible = false;
            }
        }

        private void CombData_KeyDown(object sender, KeyEventArgs e)
        {
            PopupForm popupForm = new PopupForm();
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int row_number = CombData.CurrentCell.RowIndex;
                    int columnIndex = CombData.CurrentCell.ColumnIndex;

                    GlobalVariables.TableList.Add(CombData.Rows[row_number].Cells["SrcColumn"].Value.ToString());

                    if (CombData.Rows[row_number].Cells["SourceSql"].Value.ToString() != null && columnIndex == 4)
                    {
                        var elementsToSrcConn = doc.Descendants()
                                    .Where(o => o.Name == "step" && o.HasElements).Skip(2).FirstOrDefault();
                        ilist.Add(elementsToSrcConn);

                        foreach (XElement element in ilist)
                        {
                            var connection = element.Descendants().Where(z => z.Name == "connection").FirstOrDefault();
                            var sql = element.Descendants().Where(z => z.Name == "sql").FirstOrDefault();
                            connection.Value = txtsrname.Text;
                            sql.Value = CombData.Rows[row_number].Cells["SourceSql"].Value.ToString();
                        }

                        doc.Save(@"E:\Files\test_transGenerate.ktr");

                        popupForm.StartPosition = FormStartPosition.CenterParent;
                        popupForm.Show(this);
                        string SqlSourceStat = CombData.Rows[row_number].Cells["SourceSql"].Value.ToString();
                        string toBeSearched = "select ";
                        int ix = SqlSourceStat.IndexOf(toBeSearched);

                        if (ix != -1)
                        {
                            string afterSelect = SqlSourceStat.Substring(ix + toBeSearched.Length);
                            string FinalWord = Methods.Before(afterSelect, "from ");
                            string[] Arr = FinalWord.Split(',');
                            GlobalVariables.SourceArr = Arr.ToList();
                            for (int i = 0; i < Arr.Length; i++)
                            {
                                Arr[i] = Arr[i].Trim();
                                popupForm.custom_chklist.Items.Add(Arr[i]);
                            }
                        }

                        if (GlobalVariables.SourceSortValues != null)
                        {
                            string sort_vlues = string.Join(",", GlobalVariables.SourceSortValues);
                            CombData.Rows[row_number].Cells["SourceSort"].Value = sort_vlues;
                        }
                    }

                    if (CombData.Rows[row_number].Cells["TrgSql"].Value.ToString() != null && columnIndex == 5)
                    {
                        GlobalVariables.TableList.Add(CombData.Rows[row_number].Cells["TrgColumn"].Value.ToString());

                        popupForm.custom_chklist.Items.Clear();
                        var elementsToTrg = doc.Descendants()
                                  .Where(o => o.Name == "step" && o.HasElements).Skip(4).FirstOrDefault();

                        ilist.Add(elementsToTrg);
                        foreach (XElement element in ilist)
                        {
                            var connection = element.Descendants().Where(z => z.Name == "connection").FirstOrDefault();
                            var sql_trg = element.Descendants().Where(z => z.Name == "sql").FirstOrDefault();

                            connection.Value = txtTrgNam.Text;
                            sql_trg.Value = CombData.Rows[row_number].Cells["TrgSql"].Value.ToString();

                        }

                        doc.Save(@"E:\Files\test_transGenerate.ktr");

                        popupForm.StartPosition = FormStartPosition.CenterParent;
                        popupForm.Show(this);

                        string SqlSourceStat = CombData.Rows[row_number].Cells["TrgSql"].Value.ToString();
                        string toBeSearched = "select ";
                        int ix = SqlSourceStat.IndexOf(toBeSearched);

                        if (ix != -1)
                        {
                            string afterSelect = SqlSourceStat.Substring(ix + toBeSearched.Length);

                            string FinalWord = Methods.Before(afterSelect, "from ");

                            string[] Arr = FinalWord.Split(',');
                            GlobalVariables.TaregtArr = Arr.ToList();

                            for (int i = 0; i < Arr.Length; i++)
                            {
                                Arr[i] = Arr[i].Trim();
                                popupForm.custom_chklist.Items.Add(Arr[i]);
                            }

                        }

                        if (GlobalVariables.TargetSortValues != null)
                        {
                            CombData.Refresh();
                            string Trg_vlues = string.Join(",", GlobalVariables.TargetSortValues);
                            CombData.Rows[row_number].Cells["TrgtSort"].Value = Trg_vlues;
                        }

                    }

                    if (columnIndex == 6)
                    {
                       popupForm.custom_chklist.Items.Clear();

                        GlobalVariables.Merge = GlobalVariables.SourceArr.Joins(GlobalVariables.TaregtArr);
                        foreach (var item in GlobalVariables.Merge)
                        {
                            popupForm.custom_chklist.Items.Add(item);
                        }


                        popupForm.StartPosition = FormStartPosition.CenterParent;
                        popupForm.Show(this);


                        if (GlobalVariables.SourceArr != null && GlobalVariables.TaregtArr != null)
                        {
                            CombData.Refresh();
                            string merg_keys = string.Join(",", GlobalVariables.MergeKeys);
                            CombData.Rows[row_number].Cells["MrgKey"].Value = merg_keys;
                        }


                    }



                    if (columnIndex == 7)
                    {
                        popupForm.custom_chklist.Items.Clear();

                        GlobalVariables.Merge = GlobalVariables.SourceArr.Joins(GlobalVariables.TaregtArr);
                        foreach (var item in GlobalVariables.Merge)
                        {
                            popupForm.custom_chklist.Items.Add(item);
                        }


                        popupForm.StartPosition = FormStartPosition.CenterParent;
                        popupForm.Show(this);


                        if (GlobalVariables.SourceArr != null && GlobalVariables.TaregtArr != null)
                        {
                            CombData.Refresh();
                            string merg_values = string.Join(",", GlobalVariables.MergeValues);
                            CombData.Rows[row_number].Cells["MrgValue"].Value = merg_values;
                        }


                    }


                    if (columnIndex == 8)
                    {
                        foreach (var item in GlobalVariables.ConnList)
                        {
                            ConnSync.Items.Add(item);
                        }
                    }

                    if (columnIndex == 9)
                    {
                        foreach (var item in GlobalVariables.TableList)
                        {
                            TbleMerg.Items.Add(item);
                        }
                    }


                    if (columnIndex == 10)
                    {
                        popupForm.custom_chklist.Items.Clear();

                        GlobalVariables.Sync = GlobalVariables.SourceArr.Joins(GlobalVariables.TaregtArr);
                        foreach (var item in GlobalVariables.Sync)
                        {
                            popupForm.custom_chklist.Items.Add(item);
                        }


                        popupForm.StartPosition = FormStartPosition.CenterParent;
                        popupForm.Show(this);


                        if (GlobalVariables.SourceArr != null && GlobalVariables.TaregtArr != null)
                        {
                            CombData.Refresh();
                            string sync_key= string.Join(",", GlobalVariables.SyncKeys);
                            CombData.Rows[row_number].Cells["MrgValue"].Value = sync_key;
                        }
                    }

                    if (columnIndex == 11)
                    {
                        popupForm.custom_chklist.Items.Clear();

                        GlobalVariables.Sync = GlobalVariables.SourceArr.Joins(GlobalVariables.TaregtArr);
                        foreach (var item in GlobalVariables.Sync)
                        {
                            popupForm.custom_chklist.Items.Add(item);
                        }


                        popupForm.StartPosition = FormStartPosition.CenterParent;
                        popupForm.Show(this);


                        if (GlobalVariables.SourceArr != null && GlobalVariables.TaregtArr != null)
                        {
                            CombData.Refresh();
                            string sync_values = string.Join(",", GlobalVariables.SyncValues);
                            CombData.Rows[row_number].Cells["MrgValue"].Value = sync_values;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void CombData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
              e.RowIndex >=0) 
            {
                this.Cursor = Cursors.WaitCursor;
                SaveSourceTarget();

                SaveTaregtSort();

                SaveMergeKeys();

                SaveMergeValues();

                SaveSyncKeys();

                SaveSyncValues();

                var final_repot = XDocument.Load(@"E:\Files\test_transGenerate.ktr");

                final_repot.Save(@"E:\Files\test_transGenerate"+e.RowIndex+".ktr");

                MessageBox.Show("file created");


                this.Cursor = Cursors.Default;

            }
        }




        void SaveMergeKeys()
        {
            try
            {


                var elementsToUpdate = doc.Descendants()
                                        .Where(o => o.Name == "step" && o.HasElements).FirstOrDefault();

                var fields = elementsToUpdate.Descendants()
                                         .Where(o => o.Name == "keys" && o.HasElements).FirstOrDefault();


                int rowscount = GlobalVariables.MergeKeys.Count();

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

                    List_keys[i].Value = GlobalVariables.MergeKeys[i].ToString();

                }

                doc.Save(@"E:\Files\test_transGenerate.ktr");

            }

            catch (Exception ex)
            {

                MessageBox.Show("Error Occured" + ex.Message);
            }


        }


        void SaveMergeValues()
        {

            try
            {


                var elementsToUpdate = doc.Descendants()
                                     .Where(o => o.Name == "step" && o.HasElements).FirstOrDefault();

                var fields = elementsToUpdate.Descendants()
                                         .Where(o => o.Name == "values" && o.HasElements).FirstOrDefault();


                int rowscount = GlobalVariables.MergeValues.Count();

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

                    List_keys[i].Value = GlobalVariables.MergeValues[i].ToString();

                }

                doc.Save(@"E:\Files\test_transGenerate.ktr");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error" + ex.Message);
            }
        }


        void SaveSyncKeys()
        {

            try
            {
                int row_number = CombData.CurrentCell.RowIndex;
                var elementsToUpdate = doc.Descendants()
                                         .Where(o => o.Name == "step" && o.HasElements).Skip(1).FirstOrDefault();


                var Keyfields = elementsToUpdate.Descendants()
                                        .Where(o => o.Name == "key" && o.HasElements).FirstOrDefault();

                var ConnectionName = elementsToUpdate.Descendants().Where(z => z.Name == "connection").FirstOrDefault();

                ConnectionName.Value = CombData.Rows[row_number].Cells["ConnSync"].Value.ToString();


                var LookUpfields = elementsToUpdate.Descendants()
                                        .Where(o => o.Name == "lookup" && o.HasElements).FirstOrDefault();

                var TableName = LookUpfields.Descendants().Where(y => y.Name == "table").FirstOrDefault();
                TableName.Value = CombData.Rows[row_number].Cells["TbleMerg"].Value.ToString();


                //to add new Key Childs
                int KeyRowCount = GlobalVariables.SyncKeys.Count();

                for (int i = 0; i < KeyRowCount - 1; i++)
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
                    nam_tst.Value = GlobalVariables.SyncKeys[i].ToString();
                    field_tst.Value = GlobalVariables.SyncKeys[i].ToString();

                }


                doc.Save(@"E:\Files\test_transGenerate.ktr");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured " + ex.Message);
            }

        }


        void SaveTaregtSort()
        {
            #region targetsortvalues
            var elementsToUpdateTrgt = doc.Descendants()
                               .Where(o => o.Name == "step" && o.HasElements).Skip(5).FirstOrDefault();

            var fieldsTarget = elementsToUpdateTrgt.Descendants()
                                     .Where(o => o.Name == "fields" && o.HasElements).FirstOrDefault();


            int rowscountTaregt = GlobalVariables.TargetSortValues.Count();
            //to append new childs
            for (int i = 0; i < rowscountTaregt - 1; i++)
            {
                var fiedlNode = fieldsTarget.Descendants()
                                       .Where(x => x.Name.LocalName == "field")
                                       .FirstOrDefault();
                fieldsTarget.Add(fiedlNode);
            }

            //to assign new values 
            var fieldsNodesTrg = elementsToUpdateTrgt.Descendants()
                                 .Where(o => o.Name == "field" && o.HasElements).ToList();

            for (int i = 0; i < fieldsNodesTrg.Count; i++)
            {
                var nam_tst = fieldsNodesTrg[i].Descendants().Where(z => z.Name == "name").FirstOrDefault();
                nam_tst.Value = GlobalVariables.TargetSortValues[i].ToString();
            }


            doc.Save(@"E:\Files\test_transGenerate.ktr");

            #endregion
        }


        void SaveSourceTarget()
        {
            #region sourcesortvalues
            var elementsToUpdate = doc.Descendants()
                                  .Where(o => o.Name == "step" && o.HasElements).Skip(3).FirstOrDefault();

            var fields = elementsToUpdate.Descendants()
                                     .Where(o => o.Name == "fields" && o.HasElements).FirstOrDefault();




            int rowscount = GlobalVariables.SourceSortValues.Count();

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
                nam_tst.Value = GlobalVariables.SourceSortValues[i].ToString();

            }
            doc.Save(@"E:\Files\test_transGenerate.ktr");
            #endregion
        }



        void SaveSyncValues()
        {

            try
            {


                var elementsToUpdate = doc.Descendants()
                                        .Where(o => o.Name == "step" && o.HasElements).Skip(1).FirstOrDefault();


                var LookUpfields = elementsToUpdate.Descendants()
                                        .Where(o => o.Name == "lookup" && o.HasElements).FirstOrDefault();

                //to add new Key Childs
                int ValueRowCount = GlobalVariables.SyncValues.Count();

                //int KeyRowsCount = keySyncGd.Rows.Count;

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
                    nam_tst.Value = GlobalVariables.SyncValues[i].ToString();
                    field_tst.Value = GlobalVariables.SyncValues[i].ToString();



                    var update_tg = valuestobeupdated[i].Descendants().Where(z => z.Name == "update").FirstOrDefault();
                    update_tg.Value = "Y";
                }


                doc.Save(@"E:\Files\test_transGenerate.ktr");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error Occured in application " + ex.Message);
            }
        }
        private void CombData_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            PopupForm popupForm = new PopupForm();
            if (CombData.Columns[e.ColumnIndex].Name == "SourceSort")
            {

                if (CombData.Rows[e.RowIndex].Cells["SourceSql"].Value.ToString() != null)
                {
                    var elementsToSrcConn = doc.Descendants()
                                .Where(o => o.Name == "step" && o.HasElements).Skip(2).FirstOrDefault();
                    ilist.Add(elementsToSrcConn);

                    foreach (XElement element in ilist)
                    {
                        var connection = element.Descendants().Where(z => z.Name == "connection").FirstOrDefault();
                        var sql = element.Descendants().Where(z => z.Name == "sql").FirstOrDefault();
                        connection.Value = txtsrname.Text;
                        sql.Value = CombData.Rows[e.RowIndex].Cells["SourceSql"].Value.ToString();
                    }

                    doc.Save(@"E:\Files\test_transGenerate.ktr");

                    popupForm.StartPosition = FormStartPosition.CenterParent;
                    popupForm.Show(this);
                    string SqlSourceStat = CombData.Rows[e.RowIndex].Cells["SourceSql"].Value.ToString();
                    string toBeSearched = "select ";
                    int ix = SqlSourceStat.IndexOf(toBeSearched);

                    if (ix != -1)
                    {
                        string afterSelect = SqlSourceStat.Substring(ix + toBeSearched.Length);
                        string FinalWord = Methods.Before(afterSelect, "from ");
                        string[] Arr = FinalWord.Split(',');
                        GlobalVariables.SourceArr = Arr.ToList();
                        for (int i = 0; i < Arr.Length; i++)
                        {
                            Arr[i] = Arr[i].Trim();
                            popupForm.custom_chklist.Items.Add(Arr[i]);
                        }
                    }

                    if (GlobalVariables.SourceSortValues != null)
                    {
                        string sort_vlues = string.Join(",", GlobalVariables.SourceSortValues);
                        CombData.Rows[e.RowIndex].Cells["SourceSort"].Value = sort_vlues;
                    }
                }
            }


            if (CombData.Columns[e.ColumnIndex].Name == "TrgtSort")
            {
                GlobalVariables.TableList.Add(CombData.Rows[e.RowIndex].Cells["TrgColumn"].Value.ToString());

                if (CombData.Rows[e.RowIndex].Cells["TrgSql"].Value.ToString() != null)
                {

                    popupForm.custom_chklist.Items.Clear();
                    var elementsToTrg = doc.Descendants()
                              .Where(o => o.Name == "step" && o.HasElements).Skip(4).FirstOrDefault();

                    ilist.Add(elementsToTrg);
                    foreach (XElement element in ilist)
                    {
                        var connection = element.Descendants().Where(z => z.Name == "connection").FirstOrDefault();
                        var sql_trg = element.Descendants().Where(z => z.Name == "sql").FirstOrDefault();

                        connection.Value = txtTrgNam.Text;
                        sql_trg.Value = CombData.Rows[e.RowIndex].Cells["TrgSql"].Value.ToString();

                    }

                    doc.Save(@"E:\Files\test_transGenerate.ktr");

                    popupForm.StartPosition = FormStartPosition.CenterParent;
                    popupForm.Show(this);

                    string SqlSourceStat = CombData.Rows[e.RowIndex].Cells["TrgSql"].Value.ToString();
                    string toBeSearched = "select ";
                    int ix = SqlSourceStat.IndexOf(toBeSearched);

                    if (ix != -1)
                    {
                        string afterSelect = SqlSourceStat.Substring(ix + toBeSearched.Length);

                        string FinalWord = Methods.Before(afterSelect, "from ");

                        string[] Arr = FinalWord.Split(',');
                        GlobalVariables.TaregtArr = Arr.ToList();

                        for (int i = 0; i < Arr.Length; i++)
                        {
                            Arr[i] = Arr[i].Trim();
                            popupForm.custom_chklist.Items.Add(Arr[i]);
                        }

                    }

                    if (GlobalVariables.TargetSortValues != null)
                    {
                        CombData.Refresh();
                        string Trg_vlues = string.Join(",", GlobalVariables.TargetSortValues);
                        CombData.Rows[e.RowIndex].Cells["TrgtSort"].Value = Trg_vlues;
                    }
                }

            }

        }
    }
}
