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

        private readonly WizardForm wizardForm;

        public PopupForm(WizardForm _wizardForm)
        {
            InitializeComponent();
            wizardForm = _wizardForm;
        }

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
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (GlobalVariables.SourceArr != null)
            {
                if (GlobalVariables.SourceArr.Count > 0)
                {
                    GlobalVariables.SourceSortValues = custom_chklist.CheckedItems.Cast<string>().ToList();

                   // string sort_vlues = string.Join(",", GlobalVariables.SourceSortValues);
                   // mMainForm.CombData.Rows[GlobalVariables.Row_index].Cells["SourceSort"].Value = sort_vlues;

                   // wizardForm.CombData.Rows[GlobalVariables.Row_index].Cells["SourceSort"].Value = sort_vlues;

                    this.Close();
                }
            }



            if (GlobalVariables.TaregtArr != null)
            {
                if (GlobalVariables.TaregtArr.Count > 0)
                {
                    

                    GlobalVariables.TargetSortValues = custom_chklist.CheckedItems.Cast<string>().ToList();

                    string Trg_vlues = string.Join(",", GlobalVariables.TargetSortValues);
                    // mMainForm.CombData.Rows[GlobalVariables.Row_index].Cells["TrgtSort"].Value = Trg_vlues;

                    GlobalVariables.TargetSortValues = GlobalVariables.TargetSortValues.ConvertAll(d => d.ToLower());
                    GlobalVariables.PrimaryKeysList = GlobalVariables.TargetSortValues;
                    wizardForm.CombData.Rows[GlobalVariables.Row_index].Cells["SourceSort"].Value = Trg_vlues;
                   

                    this.Close();
                }

            }

            if (GlobalVariables.MergeKeysArr != null)
            {
                if (GlobalVariables.MergeKeysArr.Count > 0)
                {
                    GlobalVariables.MergeKeys = custom_chklist.CheckedItems.Cast<string>().ToList();
                    string merg_keys = string.Join(",", GlobalVariables.MergeKeys);
                    mMainForm.CombData.Rows[GlobalVariables.Row_index].Cells["MrgKey"].Value = merg_keys;

                    this.Close();
                }
            }

            if (GlobalVariables.MergeValuesArr != null)
            {
                if (GlobalVariables.MergeValuesArr.Count > 0)
                {
                    GlobalVariables.MergeValues = custom_chklist.CheckedItems.Cast<string>().ToList();
                    string merg_values = string.Join(",", GlobalVariables.MergeValues);
                    mMainForm.CombData.Rows[GlobalVariables.Row_index].Cells["MrgValue"].Value = merg_values;

                    this.Close();
                }
            }

            if (GlobalVariables.ConnList != null)
            {
                if (GlobalVariables.ConnList.Count > 0)
                {

                    GlobalVariables.ConnValues = custom_chklist.CheckedItems.Cast<string>().ToList();

                    string connvalues = string.Join(",", GlobalVariables.ConnValues);

                    mMainForm.CombData.Rows[GlobalVariables.Row_index].Cells["ConnSync"].Value = connvalues;

                    this.Close();
                }

            }


            if (GlobalVariables.TableList != null)
            {
                if (GlobalVariables.TableList.Count > 0)
                {
                    GlobalVariables.TbleValues = custom_chklist.CheckedItems.Cast<string>().ToList();

                    string TbleValues = string.Join(",", GlobalVariables.TbleValues);

                    mMainForm.CombData.Rows[GlobalVariables.Row_index].Cells["TbleMerg"].Value = TbleValues;

                    this.Close();
                }

            }


            if (GlobalVariables.SyncKeyArr != null)
            {
                if (GlobalVariables.SyncKeyArr.Count > 0)
                {
                    GlobalVariables.SyncKeys = custom_chklist.CheckedItems.Cast<string>().ToList();

                    string sync_key = string.Join(",", GlobalVariables.SyncKeys);
                    mMainForm.CombData.Rows[GlobalVariables.Row_index].Cells["SyncKey"].Value = sync_key;

                    this.Close();
                }
            }



            if (GlobalVariables.SyncValueArr != null)
            {
                if (GlobalVariables.SyncValueArr.Count > 0)
                {
                    GlobalVariables.SyncValues = custom_chklist.CheckedItems.Cast<string>().ToList();

                    string sync_values = string.Join(",", GlobalVariables.SyncValues);
                    mMainForm.CombData.Rows[GlobalVariables.Row_index].Cells["SyncValue"].Value = sync_values;

                    this.Close();
                }
                GlobalVariables.SyncValueArr.Clear();
            }

        }

    }
}
