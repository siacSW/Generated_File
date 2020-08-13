using Devart.Common;
using Generated_File.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Generated_File.Forms
{
    public partial class WizardForm : Form
    {


        XDocument doc;
        XDocument mySql_Attributes;
        XDocument sqlserver_attributes;
        XDocument Sap_attributes;
        XDocument MariaDb_attributes;
        XElement xElementServer = new XElement("server");
        XElement XElementDb = new XElement("database");


        List<XElement> ilist = new List<XElement>();

        List<string> XValues = new List<string>();

        string SourceSelectionValue = string.Empty;
        string TaregtSelectionValue = string.Empty;
        public WizardForm()
        {
            InitializeComponent();
            try
            {
                doc = XDocument.Load(@"C:\Files\test_trans7-Copy.ktr");
                mySql_Attributes = XDocument.Load(@"C:\Files\MySql-attributes.xml");
                sqlserver_attributes = XDocument.Load(@"C:\Files\SqlServer-Attributes.xml");
                Sap_attributes = XDocument.Load(@"C:\Files\Sap-Attributes.xml");
                MariaDb_attributes = XDocument.Load(@"C:\Files\MariaDb-Attributes.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Reading Template File " + ex.Message);
                Environment.Exit(1);
            }
        }

        private void wizardControl1_Finished(object sender, EventArgs e)
        {


            try
            {
                var elementsToSrcConn = doc.Descendants()
                               .Where(o => o.Name == "step" && o.HasElements).Skip(2).FirstOrDefault();
                ilist.Add(elementsToSrcConn);

                if (SourceSelectionValue != "SAP")
                {
                    string query = string.Join(",", GlobalVariables.SourceArr);
                    var SELECT = query.Insert(0, "SELECT ");
                    var FINAL_SQL = SELECT.Insert(SELECT.Length, " FROM " + CombData.Rows[GlobalVariables.Row_index].Cells["SrcColumn"].Value.ToString() + " ");

                    foreach (XElement element in ilist)
                    {
                        var connection = element.Descendants().Where(z => z.Name == "connection").FirstOrDefault();
                        var sql = element.Descendants().Where(z => z.Name == "sql").FirstOrDefault();
                        connection.Value = txtsrname.Text;
                        sql.Value = CombData.Rows[GlobalVariables.Row_index].Cells["SrcColumn"].Value.ToString();
                    }

                    doc.Save(@"E:\WizardGenerator\test_trans" + GlobalVariables.Row_index + ".ktr");

                    ilist.Clear();
                }

                else
                {
                    foreach (XElement element in ilist)
                    {
                        var connection = element.Descendants().Where(z => z.Name == "connection").FirstOrDefault();
                        var sql = element.Descendants().Where(z => z.Name == "sql").FirstOrDefault();
                        connection.Value = txtsrname.Text;
                        sql.Value = CombData.Rows[GlobalVariables.Row_index].Cells["SrcColumn"].Value.ToString();
                    }

                    doc.Save(@"E:\WizardGenerator\test_trans" + GlobalVariables.Row_index + ".ktr");

                    ilist.Clear();
                }







                var elementsToTrg = doc.Descendants()
                        .Where(o => o.Name == "step" && o.HasElements).Skip(4).FirstOrDefault();

                ilist.Add(elementsToTrg);

                if (TaregtSelectionValue != "SAP")
                {
                    string query = string.Join(",", XValues);
                    var SELECT = query.Insert(0, "SELECT ");
                    var FINAL_SQL = SELECT.Insert(SELECT.Length, " FROM " + CombData.Rows[GlobalVariables.Row_index].Cells["TrgColumn"].Value.ToString() + " ");



                    ilist.Add(elementsToTrg);

                    if (CombData.Rows[GlobalVariables.Row_index].Cells["whereTrg"].Value == null)
                    {
                        foreach (XElement element in ilist)
                        {
                            var connection = element.Descendants().Where(z => z.Name == "connection").FirstOrDefault();
                            var sql_trg = element.Descendants().Where(z => z.Name == "sql").FirstOrDefault();
                            connection.Value = txtTrgName.Text;
                            sql_trg.Value = FINAL_SQL;
                        }
                    }
                    else
                    {
                        var WhereClause = FINAL_SQL.Insert(FINAL_SQL.Length, "WHERE " + CombData.Rows[GlobalVariables.Row_index].Cells["whereTrg"].Value.ToString() + " ");

                        foreach (XElement element in ilist)
                        {
                            var connection = element.Descendants().Where(z => z.Name == "connection").FirstOrDefault();
                            var sql_trg = element.Descendants().Where(z => z.Name == "sql").FirstOrDefault();
                            connection.Value = txtTrgName.Text;
                            sql_trg.Value = WhereClause;
                        }
                    }

                   

                    doc.Save(@"E:\WizardGenerator\test_trans" + GlobalVariables.Row_index + ".ktr");


                    ilist.Clear();


                    SaveSourceSort();

                    SaveTaregtSort();

                    SaveMergeKeys();

                    SaveMergeValues();

                    SaveSyncKeys();

                    SaveSyncValues();



                }


            }
            catch (Exception x)
            {
                MessageBox.Show("Error Occured : ", x.Message);
            }

            MessageBox.Show("Files Created");
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

        private void wizardControl1_SelectedPageChanged(object sender, EventArgs e)
        {


            if (wizardControl1.SelectedPage == configwizard)
            {

                SourceSelectionValue = SrCmb.SelectedItem.ToString();
                TaregtSelectionValue = TrgCmbe.SelectedItem.ToString();


                CombData.Rows.Clear();

                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    CombData.Rows.Add();
                    TrgColumn.Items.Clear();

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

                            password.Value = Methods.PasswordEncrypt(txtsrPsw.Text, txtbrowsValue.Text);

                        }

                        ilist.Clear();

                        switch (SrCmb.SelectedItem.ToString())
                        {

                            case "MSSQLNATIVE":

                                var AttributesElements = elementsToUpdateSource.Descendants().Where(o => o.Name == "attributes" && o.HasElements).FirstOrDefault();
                                var Port = sqlserver_attributes.Descendants().Where(x => x.Name == "attribute").Skip(13).FirstOrDefault();
                                Port.Value = txtsrPor.Text;
                                sqlserver_attributes.Save(@"C:\Files\SqlServer-Attributes.xml");
                                AttributesElements.ReplaceWith(sqlserver_attributes.Root);

                                break;

                            case "MARIADB":
                                var AttributesElementsMaria = elementsToUpdateSource.Descendants()
                                      .Where(o => o.Name == "attributes" && o.HasElements).FirstOrDefault();
                                var Port_Number = MariaDb_attributes.Descendants().Where(x => x.Name == "attribute").Skip(7).FirstOrDefault();
                                Port_Number.Value = txtsrPor.Text;
                                MariaDb_attributes.Save(@"C:\Files\MariaDb-Attributes.xml");
                                AttributesElementsMaria.ReplaceWith(MariaDb_attributes.Root);

                                break;

                            case "MYSQL":
                                var AttributesElementsMySql = elementsToUpdateSource.Descendants()
                                    .Where(o => o.Name == "attributes" && o.HasElements).FirstOrDefault();
                                var Port_Number_ = mySql_Attributes.Descendants().Where(x => x.Name == "attribute").Skip(7).FirstOrDefault();
                                Port_Number_.Value = txtsrPor.Text;
                                mySql_Attributes.Save(@"C:\Files\MySql-attributes.xml");
                                AttributesElementsMySql.ReplaceWith(mySql_Attributes.Root);
                                break;


                            case "SAP":

                                var AttributesElementsSap = elementsToUpdateSource.Descendants()
                              .Where(o => o.Name == "attributes" && o.HasElements).FirstOrDefault();
                                var Port_NumberSAP = Sap_attributes.Descendants().Where(x => x.Name == "attribute").Skip(13).FirstOrDefault();
                                Port_NumberSAP.Value = "1521";
                                var Jdbc_Conn = Sap_attributes.Descendants().Where(x => x.Name == "attribute").Skip(3).FirstOrDefault();
                                string Jdbc_conn_ = "jdbc:saperp:Host=" + txtsrServer.Text + ";User=" + txtsrUser.Text + ";Password=" + txtsrPsw.Text + ";Client=" + txtsapclient.Text + ";System Number=" + txtsrPor.Text + ";ConnectionType=CLASSIC_UNICODE;SupportEnhancedSQL=True;UseSimpleNames=False;TableMode=All;Tables=" + txtsaptbles.Text + ";Views=" + txtsapviews.Text + ""; 
                               
                                Jdbc_Conn.Value = Jdbc_conn_;
                                Sap_attributes.Save(@"C:\Files\Sap-Attributes.xml");
                                AttributesElementsSap.ReplaceWith(Sap_attributes.Root);
                                break;


                            default:
                                break;
                        }
                    }

                    // ilist.Clear();

                    #endregion

                    #region TargetRegion
                    if (TrgCmbe.SelectedItem == null)
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

                            name.Value = txtTrgName.Text;
                            server.Value = txtTrSrVe.Text;
                            if (TrgCmbe.SelectedItem.ToString() == "SAP")
                            {
                                server.ReplaceWith(xElementServer);
                                database.ReplaceWith(XElementDb);
                                type.Value = "GENERIC";
                            }
                            else
                            {

                                database.Value = txtTrDBt.Text;

                                GlobalVariables.DbName = txtTrDBt.Text;
                                type.Value = TrgCmbe.SelectedItem.ToString();
                            }

                            port.Value = txtTRPot.Text;
                            username.Value = txtTrgUse.Text;
                            password.Value = Methods.PasswordEncrypt(txtTrgPst.Text, txtbrowsValue.Text);

                            

                        }

                        ilist.Clear();

                        switch (TrgCmbe.SelectedItem.ToString())
                        {
                            case "MSSQLNATIVE":
                                var AttributesElementsSQlServ = elementsToUpdateTaregt.Descendants()
                               .Where(o => o.Name == "attributes" && o.HasElements).FirstOrDefault();
                                var Port = sqlserver_attributes.Descendants().Where(x => x.Name == "attribute").Skip(13).FirstOrDefault();
                                Port.Value = txtTRPo.Text;
                                sqlserver_attributes.Save(@"C:\Files\SqlServer-Attributes.xml");
                                AttributesElementsSQlServ.ReplaceWith(sqlserver_attributes.Root);

                                var dataCollectionSQlServer = Methods.SQLSERVERGET(txtTrSrVe.Text, txtTrDBt.Text, txtTrgUse.Text, txtTrgPst.Text);

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
                                mySql_Attributes.Save(@"C:\Files\MySql-attributes.xml");
                                AttributesElements.ReplaceWith(mySql_Attributes.Root);

                                var dataCollectionMySql = Methods.MySqlGET(txtTrgUse.Text, txtTrgPst.Text, txtTrSrVe.Text, txtTRPot.Text, txtTrDBt.Text);

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
                                MariaDb_attributes.Save(@"C:\Files\MariaDb-Attributes.xml");
                                AttributesElementsMaria.ReplaceWith(MariaDb_attributes.Root);

                                var dataCollectionMaria = Methods.MySqlGET(txtTrgUse.Text, txtTrgPst.Text, txtTrSrVe.Text, txtTRPot.Text, txtTrDBt.Text);

                                foreach (var item in dataCollectionMaria)
                                {
                                    TrgColumn.Items.Add(item);
                                }
                                break;

                            case "SAP":
                                var AttributesElementsSap = elementsToUpdateSource.Descendants()
                               .Where(o => o.Name == "attributes" && o.HasElements).FirstOrDefault();
                                var Port_NumberSAP = Sap_attributes.Descendants().Where(x => x.Name == "attribute").Skip(13).FirstOrDefault();
                                var Jdbc_Conn = Sap_attributes.Descendants().Where(x => x.Name == "attribute").Skip(3).FirstOrDefault();
                                Port_NumberSAP.Value = txtsrPor.Text;
                                string Jdbc_conn_ = "jdbc:saperp:Host=" + txtsrServer.Text + ";User=" + txtsrUser.Text + ";Password=" + txtsrPsw.Text + ";Client=" + txtsapclient.Text + ";System Number=" + txtsrPor.Text + ";ConnectionType=CLASSIC_UNICODE;SupportEnhancedSQL=True;UseSimpleNames=False;TableMode=All;Tables=" + txtsaptbles.Text + ";Views=" + txtsapviews.Text + "";

                                Jdbc_Conn.Value = Jdbc_conn_;
                                Sap_attributes.Save(@"C:\Files\Sap-Attributes.xml");
                                AttributesElementsSap.ReplaceWith(Sap_attributes.Root);

                                break;

                            default:
                                break;
                        }
                    }

                    #endregion
                    doc.Save(@"E:\Files\test_transGenerate1.ktr");

                    ilist.Clear();

                    this.Cursor = Cursors.Default;
                }

                catch (Exception ee)
                {
                    MessageBox.Show("Error Occured : " + ee.Message);
                }
            }
        }

        private void SrCmb_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (SrCmb.SelectedItem.ToString() == "SAP")
            {
                lblserver.Text = "HOST";
                lblport.Text = "System_Number";
                lblclient.Visible = true;
                lbltbles.Visible = true;
                lblviews.Visible = true;
                txtsapclient.Visible = true;
                txtsaptbles.Visible = true;
                txtsapviews.Visible = true;

                txtsrDb.Visible = false;
                lbldb.Visible = false;

            }
            else
            {
                lblserver.Text = "Server";
                lblport.Text = "Port";
                lblclient.Visible = false;
                lbltbles.Visible = false;
                lblviews.Visible = false;
                txtsapclient.Visible = false;
                txtsaptbles.Visible = false;
                txtsapviews.Visible = false;

                txtsrDb.Visible = true;
                lbldb.Visible = true;
            }
        }

        private void CombData_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            try
            {

                GlobalVariables.Row_index = e.RowIndex;
                PopupForm popupForm = new PopupForm(this);
                List<string> TargetReturnedValues = new List<string>();

                if (CombData.Columns[e.ColumnIndex].Name == "SourceSort")
                {

                    popupForm.custom_chklist.Items.Clear();
                    GlobalVariables.TaregtArr = new List<string>();

                    GlobalVariables.AllValues = new List<string>();


                    GlobalVariables.SourceArr = Methods.SourceSql(CombData.Rows[e.RowIndex].Cells["SrcColumn"].Value.ToString());

                    switch (TaregtSelectionValue)
                    {
                        case "MSSQLNATIVE":
                        case "MARIADB":
                        case "MYSQL":
                            TargetReturnedValues = Methods.ReturnPk(TaregtSelectionValue, CombData.Rows[e.RowIndex].Cells["TrgColumn"].Value.ToString());
                            break;

                        default:
                            break;
                    }


                    foreach (var item in TargetReturnedValues)
                    {
                        popupForm.custom_chklist.Items.Add(item);
                        GlobalVariables.TaregtArr.Add(item);
                    }

                    foreach (var item in GlobalVariables.SourceArr)
                    {
                        GlobalVariables.AllValues.Add(item);
                    }

                   

                    popupForm.WindowState = FormWindowState.Normal;
                    popupForm.Show(this);
                    XValues = TargetReturnedValues;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured  : " + ex.Message);
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

                // File_Opend_Path = openFileDialog1.FileName;
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

                    txtsrname.Text = name.Value;
                    txtsrServer.Text = server.Value;
                    if (type.Value == "GENERIC")
                    {
                        SrCmb.SelectedItem = "SAP";
                    }
                    else
                    {
                        SrCmb.SelectedItem = type.Value;
                    }
                    txtsrDb.Text = database.Value;
                    txtsrPor.Text = port.Value;
                    txtsrUser.Text = username.Value;

                }

                foreach (XElement element in TargetList)
                {
                    var name = element.Descendants().Where(z => z.Name == "name").FirstOrDefault();
                    var server = element.Descendants().Where(z => z.Name == "server").FirstOrDefault();
                    var type = element.Descendants().Where(z => z.Name == "type").FirstOrDefault();

                    var database = element.Descendants().Where(z => z.Name == "database").FirstOrDefault();
                    var port = element.Descendants().Where(z => z.Name == "port").FirstOrDefault();
                    var username = element.Descendants().Where(z => z.Name == "username").FirstOrDefault();
                    //  var password = element.Descendants().Where(z => z.Name == "password").FirstOrDefault();



                    TrgCmbe.SelectedItem = type.Value;

                    txtTrgName.Text = name.Value;
                    txtTrSrVe.Text = server.Value;


                    txtTrDBt.Text = database.Value;
                    txtTRPot.Text = port.Value;
                    txtTrgUse.Text = username.Value;
                    // txtTrgPs.Text = password.Value;

                }

                SouceList.Clear();
                TargetList.Clear();
            }
        }


        private void btnadd_Click(object sender, EventArgs e)
        {
            CombData.Rows.Add();

            try
            {

                var elementsToSrcConn = doc.Descendants()
                              .Where(o => o.Name == "step" && o.HasElements).Skip(2).FirstOrDefault();
                ilist.Add(elementsToSrcConn);

                if (SourceSelectionValue != "SAP")
                {
                    string query = string.Join(",", GlobalVariables.SourceArr);
                    var SELECT = query.Insert(0, "SELECT ");
                    var FINAL_SQL = SELECT.Insert(SELECT.Length, " FROM " + CombData.Rows[GlobalVariables.Row_index].Cells["SrcColumn"].Value.ToString() + " ");

                    foreach (XElement element in ilist)
                    {
                        var connection = element.Descendants().Where(z => z.Name == "connection").FirstOrDefault();
                        var sql = element.Descendants().Where(z => z.Name == "sql").FirstOrDefault();
                        connection.Value = txtsrname.Text;
                        sql.Value = FINAL_SQL;
                    }

                    doc.Save(@"E:\WizardGenerator\test_trans" + GlobalVariables.Row_index + ".ktr");

                    ilist.Clear();
                }

                else
                {
                    foreach (XElement element in ilist)
                    {
                        var connection = element.Descendants().Where(z => z.Name == "connection").FirstOrDefault();
                        var sql = element.Descendants().Where(z => z.Name == "sql").FirstOrDefault();
                        connection.Value = txtsrname.Text;
                        sql.Value = CombData.Rows[GlobalVariables.Row_index].Cells["SrcColumn"].Value.ToString();
                    }

                    doc.Save(@"E:\WizardGenerator\test_trans" + GlobalVariables.Row_index + ".ktr");

                    ilist.Clear();
                }


                var elementsToTrg = doc.Descendants()
                            .Where(o => o.Name == "step" && o.HasElements).Skip(4).FirstOrDefault();

                    ilist.Add(elementsToTrg);



                    if (TaregtSelectionValue != "SAP")
                    {
                        string query = string.Join(",", XValues);
                        var SELECT = query.Insert(0, "SELECT ");
                        var FINAL_SQL = SELECT.Insert(SELECT.Length, " FROM " + CombData.Rows[GlobalVariables.Row_index].Cells["TrgColumn"].Value.ToString() + " ");

                        var WhereClause = FINAL_SQL.Insert(FINAL_SQL.Length, "WHERE " + CombData.Rows[GlobalVariables.Row_index].Cells["whereTrg"].Value.ToString() + " ");

                        ilist.Add(elementsToTrg);
                        foreach (XElement element in ilist)
                        {
                            var connection = element.Descendants().Where(z => z.Name == "connection").FirstOrDefault();
                            var sql_trg = element.Descendants().Where(z => z.Name == "sql").FirstOrDefault();
                            connection.Value = txtTrgName.Text;
                            sql_trg.Value = WhereClause;
                        }

                        doc.Save(@"E:\WizardGenerator\test_trans" + GlobalVariables.Row_index + ".ktr");

                        ilist.Clear();

                        SaveSourceSort();

                        SaveTaregtSort();

                        SaveMergeKeys();

                        SaveMergeValues();

                        SaveSyncKeys();

                        SaveSyncValues();

                }


            }
            catch (Exception x)
            {
                MessageBox.Show("Error Occured : ", x.Message);
            }
        }



        private void srcwizard_Commit(object sender, AeroWizard.WizardPageConfirmEventArgs e)
        {

            try
            {

                switch (SrCmb.SelectedItem.ToString())
                {

                    case "MSSQLNATIVE":
                        var dataCollectionSQlServer = Methods.SQLSERVERGET(txtsrServer.Text, txtsrDb.Text, txtsrUser.Text, txtsrPsw.Text);
                        if (dataCollectionSQlServer.Contains("Not"))
                        {
                            this.wizardControl1.SelectedPage.NextPage = srcwizard;
                        }
                        break;

                    case "MARIADB":
                    case "MYSQL":
                        var dataCollectionMySql = Methods.MySqlGET(txtsrUser.Text, txtsrPsw.Text, txtsrServer.Text, txtsrPor.Text, txtsrDb.Text);
                        if (dataCollectionMySql.Contains("Not"))
                        {
                            this.wizardControl1.SelectedPage.NextPage = srcwizard;
                        }
                        break;


                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Source Properties " + ex.Message);
            }

        }

        private void Trgtwizard_Commit(object sender, AeroWizard.WizardPageConfirmEventArgs e)
        {

            switch (TrgCmbe.SelectedItem.ToString())
            {
                case "MSSQLNATIVE":
                    
                    var dataCollectionSQlServer = Methods.SQLSERVERGET(txtTrSrVe.Text, txtTrDBt.Text, txtTrgUse.Text, txtTrgPst.Text);

                    if (dataCollectionSQlServer.Contains("Not"))
                    {
                        this.wizardControl1.SelectedPage.NextPage = Trgtwizard;
                    }

                    break;

                case "MYSQL":
                case "MARIADB":

                    var dataCollectionMySql = Methods.MySqlGET(txtTrgUse.Text, txtTrgPst.Text, txtTrSrVe.Text, txtTRPot.Text, txtTrDBt.Text);

                    if (dataCollectionMySql.Contains("Not"))
                    {
                        this.wizardControl1.SelectedPage.NextPage = Trgtwizard;
                    }
                    break;



                case "SAP":
                    
                    break;

                default:
                    break;
            }
        }



        void SaveTaregtSort()
        {

            try
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

                //if (FileOpened == true)
                //{
                //    doc.Save(File_Opend_Path);
                //}
                //else
                //{
                //    doc.Save(New_Path);
                //}
                doc.Save(@"E:\WizardGenerator\test_trans" + GlobalVariables.Row_index + ".ktr");

                #endregion


            }
            catch (Exception exp)
            {
                MessageBox.Show("Error Occured " + exp.Message);
            }

        }


        void SaveSourceSort()
        {


            #region sourcesortvalues
            var elementsToUpdate = doc.Descendants()
                                  .Where(o => o.Name == "step" && o.HasElements).Skip(3).FirstOrDefault();

            var fields = elementsToUpdate.Descendants()
                                     .Where(o => o.Name == "fields" && o.HasElements).FirstOrDefault();


            int rowscount = GlobalVariables.TargetSortValues.Count();

            foreach (var item in GlobalVariables.TargetSortValues)
            {
                GlobalVariables.AllValues.Add(item);
            }

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
                nam_tst.Value = GlobalVariables.TargetSortValues[i].ToString();

            }

            //if (FileOpened == true)
            //{
            //    doc.Save(File_Opend_Path);
            //}
            //else
            //{
            //    doc.Save(New_Path);
            //}

            doc.Save(@"E:\WizardGenerator\test_trans" + GlobalVariables.Row_index + ".ktr");
            #endregion



        }
        void SaveMergeKeys()
        {
            try
            {


                var elementsToUpdate = doc.Descendants()
                                    .Where(o => o.Name == "step" && o.HasElements).FirstOrDefault();

                var fields = elementsToUpdate.Descendants()
                                         .Where(o => o.Name == "keys" && o.HasElements).FirstOrDefault();


                int rowscount = GlobalVariables.TargetSortValues.Count();

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

                    List_keys[i].Value = GlobalVariables.TargetSortValues[i].ToString();

                }

                //if (FileOpened == true)
                //{
                //    doc.Save(File_Opend_Path);
                //}
                //else
                //{
                //    doc.Save(New_Path);
                //}

                doc.Save(@"E:\WizardGenerator\test_trans" + GlobalVariables.Row_index + ".ktr");





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


                GlobalVariables.AllValues = GlobalVariables.AllValues.Select(y => y.ToString()).Distinct().ToList();

                int rowscount = GlobalVariables.AllValues.Count();

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

                    List_keys[i].Value = GlobalVariables.AllValues[i].ToString();

                }


                doc.Save(@"E:\WizardGenerator\test_trans" + GlobalVariables.Row_index + ".ktr");





                //if (FileOpened == true)
                //{
                //    doc.Save(File_Opend_Path);
                //}
                //else
                //{
                //    doc.Save(New_Path);
                //}
                // doc.Save(@"E:\Files\test_transGenerate1.ktr");

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

                ConnectionName.Value = txtTrgName.Text;


                var LookUpfields = elementsToUpdate.Descendants()
                                        .Where(o => o.Name == "lookup" && o.HasElements).FirstOrDefault();

                var TableName = LookUpfields.Descendants().Where(y => y.Name == "table").FirstOrDefault();
                TableName.Value = CombData.Rows[row_number].Cells["TrgColumn"].Value.ToString();




                // to add new Key Childs
                int KeyRowCount = GlobalVariables.TargetSortValues.Count();

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
                    nam_tst.Value = GlobalVariables.TargetSortValues[i].ToString();
                    field_tst.Value = GlobalVariables.TargetSortValues[i].ToString();

                }




                //if (FileOpened == true)
                //{
                //    doc.Save(File_Opend_Path);
                //}
                //else
                //{
                //    doc.Save(New_Path);
                //}
                // doc.Save(@"E:\Files\test_transGenerate1.ktr");


                doc.Save(@"E:\WizardGenerator\test_trans" + row_number + ".ktr");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured " + ex.Message);
            }

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
                GlobalVariables.AllValues = GlobalVariables.AllValues.Select(y => y.ToString()).Distinct().ToList();

                int ValueRowCount = GlobalVariables.AllValues.Count();

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
                    nam_tst.Value = GlobalVariables.AllValues[i].ToString();
                    field_tst.Value = GlobalVariables.AllValues[i].ToString();

                    var update_tg = valuestobeupdated[i].Descendants().Where(z => z.Name == "update").FirstOrDefault();

                    string PkValue = "";
                    GlobalVariables.PrimaryKeysList = GlobalVariables.PrimaryKeysList.ConvertAll(d => d.ToLower());
                    for (int z = 0; z < GlobalVariables.PrimaryKeysList.Count; z++)
                    {
                        PkValue = GlobalVariables.PrimaryKeysList[z].ToString();
                    }

                    if (GlobalVariables.AllValues[i].ToString() == PkValue)
                    {
                        update_tg.Value = "N";
                    }

                    else
                    {

                        update_tg.Value = "Y";
                    }



                }


                doc.Save(@"E:\WizardGenerator\test_trans" + GlobalVariables.Row_index + ".ktr");

                //if (FileOpened == true)
                //{
                //    doc.Save(File_Opend_Path);
                //}
                //else
                //{
                //    doc.Save(New_Path);
                //}

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error Occured in application " + ex.Message);
            }
        }
    }
}
