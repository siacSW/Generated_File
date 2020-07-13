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
        private MainForm mMainForm;
        public PopupForm()
        {
            InitializeComponent();
            mMainForm = new MainForm();
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
                GlobalVariables.SourceSortValues = custom_chklist.CheckedItems.Cast<string>().ToList();
            }


            if (GlobalVariables.TaregtArr != null)
            {
                GlobalVariables.TargetSortValues = custom_chklist.CheckedItems.Cast<string>().ToList();
            }



            if (GlobalVariables.MergeKeysArr  !=null)
            {
                GlobalVariables.MergeKeys = custom_chklist.CheckedItems.Cast<string>().ToList();
            }


            if (GlobalVariables.MergeValuesArr != null)
            {
                GlobalVariables.MergeValues = custom_chklist.CheckedItems.Cast<string>().ToList();
            }


            if (GlobalVariables.SyncKeyArr != null)
            {
                GlobalVariables.SyncKeys = custom_chklist.CheckedItems.Cast<string>().ToList();
            }

            if (GlobalVariables.SyncValueArr != null)
            {
                GlobalVariables.SyncValues = custom_chklist.CheckedItems.Cast<string>().ToList();
            }


            //if (GlobalVariables.Merge.Count() > 0)
            //{
            //    GlobalVariables.Merge = custom_chklist.CheckedItems.Cast<string>().ToList();
            //}


            //if (GlobalVariables.TaregtArr.Count() > 0)
            //{
            //   GlobalVariables.TaregtArr = custom_chklist.CheckedItems.Cast<string>().ToList();
            //}
       
        }

    }
}
