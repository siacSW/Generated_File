using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generated_File
{
    public partial class DevExpressForm : Form
    {
        public DevExpressForm()
        {
            InitializeComponent();
            gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
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

        private void gridSplitContainer1Grid_Click(object sender, EventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

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

        private void btngenerate_Click(object sender, EventArgs e)
        {

            CombData.Visible = true;
            newRow.Visible = true;

            try
            {
                #region SourceRegion
                if (SrCmb.SelectedItem == null)
                {
                    MessageBox.Show("You cannot set to null");

                }
                else
                {
                    gridView1.AddNewRow();
                    //  CombData.Rows.Add();
                    switch (SrCmb.SelectedItem.ToString())
                    {

                        case "MSSQLNATIVE":
                            var dataCollectionSQlServer = Methods.SQLSERVERGET(txtsrServer.Text, txtsrDb.Text, txtsrUser.Text, txtsrPsw.Text);
                            //GridMultiSelectComboBoxColumn gridMultiSelectComboBoxColumn = new GridMultiSelectComboBoxColumn();
                            foreach (var item in dataCollectionSQlServer)
                            {

                                SrcColumn.Items.Add(item);
                                // item = DevExpress.Data.SummaryItemType.Custom;
                                //  SourCeTble.Summary.Add(new DevExpress.Data.SummaryItemType());
                                //gridView1.Columns[""].
                                //  SourCeTble.Items.Add(item);
                                // SourCeTble.Summary.Add.to;
                                //  gridMultiSelectComboBoxColumn.DataSource = item;
                            }

                            //sfDataGrid1.Columns.Add(gridMultiSelectComboBoxColumn);
                            // CombData.Columns.Add(gridMultiSelectComboBoxColumn);
                            break;

                        case "MYSQL":
                        case "MARIADB":
                            var dataCollectionMySql = Methods.MySqlGET(txtsrUser.Text, txtsrPsw.Text, txtsrServer.Text, txtsrPor.Text, txtsrDb.Text);

                            foreach (var item in dataCollectionMySql)
                            {

                                   SrcColumn.Items.Add(item);
                                //SrcColumn.Items.Add(new CheckComboBox.CheckComboBoxItem(item, true));
                            }
                            break;



                        default:
                            break;
                    }
                }

                #endregion
                //Target 
                #region TargetRegion
                if (TrgCmb.SelectedItem == null)
                {
                    MessageBox.Show("You cannot set Target Db to null");
                }
                else
                {

                    switch (TrgCmb.SelectedItem.ToString())
                    {
                        case "MSSQLNATIVE":
                            var dataCollectionSQlServer = Methods.SQLSERVERGET(txtTrSrV.Text, txtTrDB.Text, txtTrgUs.Text, txtTrgPs.Text);

                            foreach (var item in dataCollectionSQlServer)
                            {
                                TrgColumn.Items.Add(item);
                            }
                            break;

                        case "MYSQL":
                        case "MARIADB":
                            var dataCollectionMySql = Methods.MySqlGET(txtTrgUs.Text, txtTrgPs.Text, txtTrSrV.Text, txtTRPo.Text, txtTrDB.Text);

                            foreach (var item in dataCollectionMySql)
                            {
                                TrgColumn.Items.Add(item);
                            }
                            break;



                        default:
                            break;
                    }
                }

                #endregion

            }

            catch (Exception ee)
            {
                MessageBox.Show("Error Occured : " + ee.Message);
            }

        }

        private void CombData_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void newRow_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();

        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            int row_number = gridView1.FocusedRowHandle;
            try
            {
                if (e.KeyCode == Keys.Tab)
                {

                    TrgtSort.Items.Clear();
                    SourceSort.Items.Clear();


                    if (SourceSql.ToString() != null)
                    {
                        string SqlSourceStat = "";
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
                                SourceSort.Items.Add(Arr[i]);
                            }

                        }
                    }

                    if (TrgSql.ToString() != null)
                    {
                        string SqlSourceStat = TrgSql.ToString();
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
                                TrgtSort.Items.Add(Arr[i]);
                            }

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }
    }
}
