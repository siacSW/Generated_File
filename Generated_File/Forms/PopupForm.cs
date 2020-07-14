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

namespace Generated_File.Forms
{
    public partial class PopupForm : Form
    {
        private readonly MainForm mMainForm;
        public PopupForm(MainForm mainForm_)
        {
            InitializeComponent();
            mMainForm = mainForm_;
        }

        private void PopupForm_Load(object sender, EventArgs e)
        {

        }

        private void custom_chklist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //  mMainForm.CombData.();

        //    mMainForm.CombData.Rows[0].Cells["ColNme"].Value = "123";
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (GlobalVariables.SourceArr != null)
            {
                GlobalVariables.SourceSortValues = custom_chklist.CheckedItems.Cast<string>().ToList();

                string sort_vlues = string.Join(",", GlobalVariables.SourceSortValues);
               mMainForm.CombData.Rows[GlobalVariables.Row_index].Cells["SourceSort"].Value = sort_vlues;
            }


            if (GlobalVariables.TaregtArr != null)
            {
                GlobalVariables.TargetSortValues = custom_chklist.CheckedItems.Cast<string>().ToList();

                string Trg_vlues = string.Join(",", GlobalVariables.TargetSortValues);
               mMainForm.CombData.Rows[GlobalVariables.Row_index].Cells["TrgtSort"].Value = Trg_vlues;
            }



            if (GlobalVariables.MergeKeysArr  !=null)
            {
                GlobalVariables.MergeKeys = custom_chklist.CheckedItems.Cast<string>().ToList();
                string merg_keys = string.Join(",", GlobalVariables.MergeKeys);
                mMainForm.CombData.Rows[GlobalVariables.Row_index].Cells["MrgKey"].Value = merg_keys;
            }


            if (GlobalVariables.MergeValuesArr != null)
            {
                GlobalVariables.MergeValues = custom_chklist.CheckedItems.Cast<string>().ToList();


                string merg_values = string.Join(",", GlobalVariables.MergeValues);
              mMainForm.CombData.Rows[GlobalVariables.Row_index].Cells["MrgValue"].Value = merg_values;
            }


            if (GlobalVariables.ConnList != null)
            {
                GlobalVariables.ConnValues = custom_chklist.CheckedItems.Cast<string>().ToList();

                string connvalues = string.Join(",", GlobalVariables.ConnValues);

                mMainForm.CombData.Rows[GlobalVariables.Row_index].Cells["ConnSync"].Value = connvalues;

               // this.Close();
            }


            if (GlobalVariables.TableList != null)
            {
                GlobalVariables.TbleValues = custom_chklist.CheckedItems.Cast<string>().ToList();

                string TbleValues = string.Join(",", GlobalVariables.TbleValues);

                mMainForm.CombData.Rows[GlobalVariables.Row_index].Cells["TbleMerg"].Value = TbleValues;

               // this.Close();
            }

            if (GlobalVariables.SyncKeyArr != null)
            {
                GlobalVariables.SyncKeys = custom_chklist.CheckedItems.Cast<string>().ToList();


                string sync_key = string.Join(",", GlobalVariables.SyncKeys);
               mMainForm.CombData.Rows[GlobalVariables.Row_index].Cells["SyncKey"].Value = sync_key;
            }

            if (GlobalVariables.SyncValueArr != null)
            {
                GlobalVariables.SyncValues = custom_chklist.CheckedItems.Cast<string>().ToList();

                string sync_values = string.Join(",", GlobalVariables.SyncValues);
                mMainForm.CombData.Rows[GlobalVariables.Row_index].Cells["SyncValue"].Value = sync_values;
            }


       
        }

    }
}
