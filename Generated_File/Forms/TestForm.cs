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
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProgressBar pBar = new ProgressBar
            {
                Location = new System.Drawing.Point(25, 125),
                Name = "progressBar1",
                Width = 350,
                Height = 30,
                Minimum = 0,
                Maximum = 100,
                Value = 30
            };

            pBar.Style = ProgressBarStyle.Marquee;

            Controls.Add(pBar);
        }
    }
}
