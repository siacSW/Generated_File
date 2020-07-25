using Generated_File.Classes;
using Generated_File.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Design;
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
      //  public string grid_Count;
        XDocument doc;
        XDocument mySql_Attributes;
        XDocument sqlserver_attributes;
        XDocument Sap_attributes;
        XDocument MariaDb_attributes;
        XElement xElementServer = new XElement("server");
        XElement XElementDb = new XElement("database");

       // List<string> MultiValues = new List<string>();

        List<XElement> ilist = new List<XElement>();

        string SourceSelectionValue;
        string TaregtSelectionValue;

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



            //txtSAPJDB.Text = 
        }

        private void btngenerate_Click(object sender, EventArgs e)
        {
            CombData.Rows.Clear();

            if (SrCmb.SelectedItem.ToString() == "SAP")
            {
                SourceSQL.Visible = true;
            }

            if (TrgCmb.SelectedItem.ToString() == "SAP")
            {
                TargtSQL.Visible = true;
            }

            TrgColumn.Items.Clear();
            SrcColumn.Items.Clear();

         

            SourceSelectionValue = SrCmb.SelectedItem.ToString();
            TaregtSelectionValue = TrgCmb.SelectedItem.ToString();

            try
            {

                this.Cursor = Cursors.WaitCursor;
                CombData.Rows.Add();
              

                var elementsToUpdateSource = doc.Descendants()
                                          .Where(o => o.Name == "connection" && o.HasElements).FirstOrDefault();

                var elementsToUpdateTaregt = doc.Descendants()
                                    .Where(o => o.Name == "connection" && o.HasElements).Skip(1).FirstOrDefault();

                #region SourceRegion
                if (SrCmb.SelectedItem == null)
                {
                    MessageBox.Show("You cannot set SOURCE SELECTION DB to null");

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

                        if (SrCmb.SelectedItem.ToString() == "SAP")
                        {
                            server.ReplaceWith(xElementServer);
                            database.ReplaceWith(XElementDb);
                            type.Value = "GENERIC";
                        }
                        else
                        {
                            server.Value = txtsrServer.Text;
                            database.Value = txtsrDb.Text;
                            type.Value = SrCmb.SelectedItem.ToString();
                        }
                  
                        port.Value = txtsrPor.Text;

                        username.Value = txtsrUser.Text;

                        password.Value = Methods.PasswordEncrypt(txtsrPsw.Text , txtbrowsValue.Text);

                    }

                    ilist.Clear();

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

                            var datasource = Methods.SapTables(txtSAPJDB.Text);

                            foreach (var item in datasource)
                            {
                                SrcColumn.Items.Add(item);
                            }

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
                        //GlobalVariables.ConnList.Add(txtTrgNam.Text);
                        server.Value = txtTrSrV.Text;
                        if (TrgCmb.SelectedItem.ToString() == "SAP")
                        {
                            server.ReplaceWith(xElementServer);
                            database.ReplaceWith(XElementDb);
                            type.Value = "GENERIC";
                        }
                        else
                        {

                            database.Value = txtTrDB.Text;
                            type.Value = TrgCmb.SelectedItem.ToString();
                        }
                       
                        port.Value = txtTRPo.Text;
                        username.Value = txtTrgUs.Text;
                        password.Value = Methods.PasswordEncrypt(txtTrgPs.Text, txtbrowsValue.Text) ;

                      //  password.Value = txtTrgPs.Text;

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

                            var datasource = Methods.SapTables(TrgJdbc.Text);

                            foreach (var item in datasource)
                            {
                                TrgCmb.Items.Add(item);
                            }


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
        }



        private void SrCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SrCmb.SelectedItem.ToString() == "SAP")
            {
                lbl_SAPJDBC.Visible = true;

                txtSAPJDB.Visible = true;

                MessageBox.Show("You have to change the host , username , password , Client , SystemNumber and Tables");
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


                MessageBox.Show("You have to change the host , username , password , Client , SystemNumber and Tables");
            }
            else
            {
                lbl_jdbc.Visible = false;

                TrgJdbc.Visible = false;
            }
        }


        //Cell Content As Button for Saving
        private void CombData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
              e.RowIndex >= 0)
            {
                this.Cursor = Cursors.WaitCursor;
                SaveSourceSort();

                SaveTaregtSort();

                SaveMergeKeys();

                SaveMergeValues();

                SaveSyncKeys();

                SaveSyncValues();

                var final_repot = XDocument.Load(@"E:\Files\test_transGenerate.ktr");

                if (File.Exists(@"E:\Files\test_transGenerate.ktr"))
                {
                    final_repot.Save(@"E:\Files\test_transGenerate.ktr");
                }
                else
                {
                    final_repot.Save(@"E:\Files\test_transGenerate" + e.RowIndex + ".ktr");
                }

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


        void SaveSourceSort()
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


        //Cell Click
        private void CombData_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            GlobalVariables.Row_index = e.RowIndex;
            PopupForm popupForm = new PopupForm(this);

            try
            {
                List<string> ReturnedValues = new List<string>();

                List<string> TargetReturnedValues = new List<string>();


                if (CombData.Columns[e.ColumnIndex].Name == "SourceSort")
                {
                    popupForm.custom_chklist.Items.Clear();
                    GlobalVariables.SourceArr = new List<string>();


                    switch (SourceSelectionValue)
                    {
                        case "MSSQLNATIVE":
                            ReturnedValues = Methods.ReturnFields(SourceSelectionValue, CombData.Rows[e.RowIndex].Cells["SrcColumn"].Value.ToString());

                            GlobalVariables.AllValues = ReturnedValues;
                            break;

                        case "MARIADB":
                        case "MYSQL":
                            ReturnedValues = Methods.ReturnFields(SourceSelectionValue, CombData.Rows[e.RowIndex].Cells["SrcColumn"].Value.ToString());

                            GlobalVariables.AllValues = ReturnedValues;
                            break;

                        default:
                            break;
                    }

                    if (SourceSelectionValue == "SAP")
                    {
                        if (CombData.Rows[e.RowIndex].Cells["SourceSQL"].Visible == true && CombData.Rows[e.RowIndex].Cells["SourceSQL"].Value.ToString() != null)
                        {

                            string SqlSourceStat = CombData.Rows[e.RowIndex].Cells["SourceSQL"].Value.ToString();
                            string toBeSearched = "select ";
                            string Capital = "SELECT ";
                            bool VerifySql = SqlSourceStat.Contains(Capital);
                            int ix = 0;
                            if (VerifySql == true)
                            {
                               ix = SqlSourceStat.IndexOf(Capital);
                                if (ix != -1)
                                {
                                    string afterSelect = SqlSourceStat.Substring(ix + Capital.Length);

                                    string FinalWord = Methods.Before(afterSelect, "FROM ");

                                    string[] Arr = FinalWord.Split(',');
                                    GlobalVariables.AllValues = Arr.ToList();

                                    for (int i = 0; i < Arr.Length; i++)
                                    {
                                        Arr[i] = Arr[i].Trim();
                                        popupForm.custom_chklist.Items.Add(Arr[i]);
                                    }

                                }
                            }
                            else
                            {
                                ix = SqlSourceStat.IndexOf(toBeSearched);
                                if (ix != -1)
                                {
                                    string afterSelect = SqlSourceStat.Substring(ix + toBeSearched.Length);

                                    string FinalWord = Methods.Before(afterSelect, "from ");

                                    string[] Arr = FinalWord.Split(',');
                                    GlobalVariables.AllValues = Arr.ToList();

                                    for (int i = 0; i < Arr.Length; i++)
                                    {
                                        Arr[i] = Arr[i].Trim();
                                        popupForm.custom_chklist.Items.Add(Arr[i]);
                                    }

                                }
                            }

                           
                        }
                    }


                    foreach (var item in ReturnedValues)
                    {
                        popupForm.custom_chklist.Items.Add(item);
                        GlobalVariables.SourceArr.Add(item);
                    }

                    popupForm.WindowState = FormWindowState.Normal;
                    popupForm.Show(this);

                    var elementsToSrcConn = doc.Descendants()
                                .Where(o => o.Name == "step" && o.HasElements).Skip(2).FirstOrDefault();
                    ilist.Add(elementsToSrcConn);

                    if (SourceSelectionValue != "SAP")
                    {
                        string query = string.Join(",", ReturnedValues);
                        var SELECT = query.Insert(0, "SELECT ");
                        var FINAL_SQL = SELECT.Insert(SELECT.Length, " FROM " + CombData.Rows[e.RowIndex].Cells["SrcColumn"].Value.ToString() + " ");

                        foreach (XElement element in ilist)
                        {
                            var connection = element.Descendants().Where(z => z.Name == "connection").FirstOrDefault();
                            var sql = element.Descendants().Where(z => z.Name == "sql").FirstOrDefault();
                            connection.Value = txtsrname.Text;
                            sql.Value = FINAL_SQL;
                        }

                        doc.Save(@"E:\Files\test_transGenerate.ktr");

                        ilist.Clear();
                    }

                    else
                    {
                        foreach (XElement element in ilist)
                        {
                            var connection = element.Descendants().Where(z => z.Name == "connection").FirstOrDefault();
                            var sql = element.Descendants().Where(z => z.Name == "sql").FirstOrDefault();
                            connection.Value = txtsrname.Text;
                            sql.Value = CombData.Rows[e.RowIndex].Cells["SourceSQL"].Value.ToString();
                        }

                        doc.Save(@"E:\Files\test_transGenerate.ktr");

                        ilist.Clear();
                    }

                    

                }


                if (CombData.Columns[e.ColumnIndex].Name == "TrgtSort")
                {
                   
                    popupForm.custom_chklist.Items.Clear();
                    if (GlobalVariables.SourceArr !=null)
                    {
                        if (GlobalVariables.SourceArr.Count > 0)
                        {
                            GlobalVariables.SourceArr.Clear();
                        }
                    }
                    GlobalVariables.TaregtArr = new List<string>();

                    if (TaregtSelectionValue == "MSSQLNATIVE")
                    {
                        TargetReturnedValues = Methods.ReturnFields(TaregtSelectionValue, CombData.Rows[e.RowIndex].Cells["TrgColumn"].Value.ToString());
                       
                    }
                    else if (TaregtSelectionValue == "MARIADB" || TaregtSelectionValue == "MYSQL")
                    {
                        TargetReturnedValues = Methods.ReturnFields(TaregtSelectionValue, CombData.Rows[e.RowIndex].Cells["TrgColumn"].Value.ToString());
                    }

                    if (GlobalVariables.AllValues != null)
                    {
                        if (GlobalVariables.AllValues.Count > 0)
                        {
                            foreach (var item in TargetReturnedValues)
                            {
                                popupForm.custom_chklist.Items.Add(item);
                                GlobalVariables.TaregtArr.Add(item);
                                GlobalVariables.AllValues.Add(item);
                            }
                        }
                    }
                    else if (GlobalVariables.AllValues == null)
                    {
                        foreach (var item in TargetReturnedValues)
                        {
                            popupForm.custom_chklist.Items.Add(item);
                            GlobalVariables.TaregtArr.Add(item);
                        }
                    }

                    popupForm.WindowState = FormWindowState.Normal;
                    popupForm.Show(this);


                    var elementsToTrg = doc.Descendants()
                               .Where(o => o.Name == "step" && o.HasElements).Skip(4).FirstOrDefault();


                    string query = string.Join(",", TargetReturnedValues);
                    var SELECT = query.Insert(0, "SELECT ");
                    var FINAL_SQL = SELECT.Insert(SELECT.Length, " FROM " + CombData.Rows[e.RowIndex].Cells["TrgColumn"].Value.ToString() + " ");

                    ilist.Add(elementsToTrg);
                    foreach (XElement element in ilist)
                    {
                        var connection = element.Descendants().Where(z => z.Name == "connection").FirstOrDefault();
                        var sql_trg = element.Descendants().Where(z => z.Name == "sql").FirstOrDefault();
                        connection.Value = txtTrgNam.Text;
                        sql_trg.Value = FINAL_SQL;
                    }

                    doc.Save(@"E:\Files\test_transGenerate.ktr");

                    ilist.Clear();


                }


                if (CombData.Columns[e.ColumnIndex].Name == "MrgKey")
                {
                    if (GlobalVariables.TaregtArr != null)
                    {
                        if (GlobalVariables.TaregtArr.Count  > 0)
                        {
                            GlobalVariables.TaregtArr.Clear();
                        }
                    }
                    
                    popupForm.custom_chklist.Items.Clear();
                    GlobalVariables.MergeKeysArr = new List<string>();

                    foreach (var item in GlobalVariables.AllValues)
                    {
                        GlobalVariables.MergeKeysArr.Add(item.Trim());

                         popupForm.custom_chklist.Items.Add(item.Trim());
                    }
                   
                    popupForm.WindowState = FormWindowState.Normal;
                    popupForm.Show(this);


                }

                if (CombData.Columns[e.ColumnIndex].Name == "MrgValue")
                {
                    GlobalVariables.MergeKeysArr.Clear();
                    popupForm.custom_chklist.Items.Clear();

                    GlobalVariables.MergeValuesArr = new List<string>();

                    foreach (var item in GlobalVariables.AllValues)
                    {
                        GlobalVariables.MergeValuesArr.Add(item.Trim());

                        popupForm.custom_chklist.Items.Add(item.Trim());
                    }

                    popupForm.WindowState = FormWindowState.Normal;
                    popupForm.Show();

                }
                if (CombData.Columns[e.ColumnIndex].Name == "ConnSync")
                {
                    GlobalVariables.MergeValuesArr.Clear();
                    GlobalVariables.ConnList = new List<string>();
                    GlobalVariables.ConnList.Add(txtsrname.Text);
                    GlobalVariables.ConnList.Add(txtTrgNam.Text);
                    popupForm.custom_chklist.Items.Clear();

                    foreach (var item in GlobalVariables.ConnList)
                    {

                        popupForm.custom_chklist.Items.Add(item);
                    }


                    popupForm.custom_chklist.SelectionMode = SelectionMode.One;
                    popupForm.WindowState = FormWindowState.Normal;
                    popupForm.Show(this);



                }


                if (CombData.Columns[e.ColumnIndex].Name == "TbleMerg")
                {

                    GlobalVariables.MergeValuesArr.Clear();
                    GlobalVariables.ConnList.Clear();
                    GlobalVariables.TableList = new List<string>();
                    GlobalVariables.TableList.Add(CombData.Rows[e.RowIndex].Cells["TrgColumn"].Value.ToString());
                    GlobalVariables.TableList.Add(CombData.Rows[e.RowIndex].Cells["SrcColumn"].Value.ToString());

                    popupForm.custom_chklist.Items.Clear();

                    foreach (var item in GlobalVariables.TableList)
                    {
                        popupForm.custom_chklist.Items.Add(item);
                    }


                    popupForm.custom_chklist.SelectionMode = SelectionMode.One;
                    popupForm.WindowState = FormWindowState.Normal;
                    popupForm.Show(this);
                }


                if (CombData.Columns[e.ColumnIndex].Name == "SyncKey")
                {
                    GlobalVariables.TableList.Clear();
                    GlobalVariables.MergeValuesArr.Clear();
                    popupForm.custom_chklist.Items.Clear();


                    GlobalVariables.SyncKeyArr = new List<string>();
                    foreach (var item in GlobalVariables.AllValues)
                    {
                        GlobalVariables.SyncKeyArr.Add(item.Trim());

                        popupForm.custom_chklist.Items.Add(item.Trim());
                    }


                    popupForm.WindowState = FormWindowState.Normal;
                    popupForm.Show(this);


                }


                if (CombData.Columns[e.ColumnIndex].Name == "SyncValue")
                {
                    GlobalVariables.SyncKeyArr.Clear();
                    popupForm.custom_chklist.Items.Clear();

                    GlobalVariables.SyncValueArr = new List<string>();

                    foreach (var item in GlobalVariables.AllValues)
                    {
                        GlobalVariables.SyncValueArr.Add(item.Trim());

                        popupForm.custom_chklist.Items.Add(item.Trim());
                    }

                    popupForm.WindowState = FormWindowState.Normal;
                    popupForm.Show(this);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured " + ex.Message);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.CombData.SelectedRows)
            {
                CombData.Rows.RemoveAt(item.Index);
            }
        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Encryption bat File",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "bat",
                Filter = "bat files (*.bat)|*.bat",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtbrowsValue.Text = openFileDialog1.FileName;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse pentaho project Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "ktr",
                Filter = "ktr files (*.ktr)|*.ktr",
                FilterIndex = 2,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            List<XElement> SouceList = new List<XElement>();
            List<XElement> TargetList = new List<XElement>();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                XDocument Opened_File = XDocument.Load(openFileDialog1.FileName);

                var elementsToUpdateSource = Opened_File.Descendants()
                                          .Where(o => o.Name == "connection" && o.HasElements).FirstOrDefault();


                var elementsToUpdateTaregt = Opened_File.Descendants()
                                   .Where(o => o.Name == "connection" && o.HasElements).Skip(1).FirstOrDefault();


                var AttributesElementsSap = elementsToUpdateSource.Descendants()
                          .Where(o => o.Name == "attributes" && o.HasElements).FirstOrDefault();


                var AttributesElementsSapTrg = elementsToUpdateTaregt.Descendants()
                         .Where(o => o.Name == "attributes" && o.HasElements).FirstOrDefault();

                var Jdbc_Conn = AttributesElementsSap.Descendants().Where(x => x.Name == "attribute").Skip(3).FirstOrDefault();

                var Jdbc_ConnTrg = AttributesElementsSapTrg.Descendants().Where(x => x.Name == "attribute").Skip(3).FirstOrDefault();

                SouceList.Add(elementsToUpdateSource);

                TargetList.Add(elementsToUpdateTaregt);

                foreach (XElement element in SouceList)
                {
                    var name = element.Descendants().Where(z => z.Name == "name").FirstOrDefault();
                    var server = element.Descendants().Where(z => z.Name == "server").FirstOrDefault();
                    var type = element.Descendants().Where(z => z.Name == "type").FirstOrDefault();

                    var database = element.Descendants().Where(z => z.Name == "database").FirstOrDefault();
                    var port = element.Descendants().Where(z => z.Name == "port").FirstOrDefault();
                    var username = element.Descendants().Where(z => z.Name == "username").FirstOrDefault();
                    var password = element.Descendants().Where(z => z.Name == "password").FirstOrDefault();

                    txtsrname.Text = name.Value;
                    txtsrServer.Text = server.Value;
                    if (type.Value == "GENERIC")
                    {
                        SrCmb.SelectedItem = "SAP";
                        txtSAPJDB.Visible = true;
                        txtSAPJDB.Text = Jdbc_Conn.Value;

                    }
                    else
                    {
                        SrCmb.SelectedItem = type.Value;
                    }
                    txtsrDb.Text = database.Value;
                    txtsrPor.Text = port.Value;
                    txtsrUser.Text = username.Value;
                    txtsrPsw.Text = password.Value;

                }

                foreach (XElement element in TargetList)
                {
                    var name = element.Descendants().Where(z => z.Name == "name").FirstOrDefault();
                    var server = element.Descendants().Where(z => z.Name == "server").FirstOrDefault();
                    var type = element.Descendants().Where(z => z.Name == "type").FirstOrDefault();

                    var database = element.Descendants().Where(z => z.Name == "database").FirstOrDefault();
                    var port = element.Descendants().Where(z => z.Name == "port").FirstOrDefault();
                    var username = element.Descendants().Where(z => z.Name == "username").FirstOrDefault();
                    var password = element.Descendants().Where(z => z.Name == "password").FirstOrDefault();

                    txtTrgNam.Text = name.Value;
                    txtTrSrV.Text = server.Value;
                    if (type.Value == "GENERIC")
                    {
                        TrgCmb.SelectedItem = "SAP";
                        TrgJdbc.Visible = true;
                        TrgJdbc.Text = Jdbc_ConnTrg.Value;
                    }
                    else
                    {
                        TrgCmb.SelectedItem = type.Value;
                    }

                    txtTrDB.Text = database.Value;
                    txtTRPo.Text = port.Value;
                    txtTrgUs.Text = username.Value;
                    txtTrgPs.Text = password.Value;

                }

                SouceList.Clear();
                TargetList.Clear();
            }
        }
    }
}
