namespace Generated_File.Forms
{
    partial class PopupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.custom_chklist = new System.Windows.Forms.CheckedListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // custom_chklist
            // 
            this.custom_chklist.CheckOnClick = true;
            this.custom_chklist.FormattingEnabled = true;
            this.custom_chklist.Location = new System.Drawing.Point(71, 14);
            this.custom_chklist.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.custom_chklist.Name = "custom_chklist";
            this.custom_chklist.Size = new System.Drawing.Size(277, 346);
            this.custom_chklist.TabIndex = 0;
            this.custom_chklist.SelectedIndexChanged += new System.EventHandler(this.custom_chklist_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(30, 446);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 80);
            this.button2.TabIndex = 2;
            this.button2.Text = "Ok";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(261, 446);
            this.btnclose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(133, 80);
            this.btnclose.TabIndex = 3;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.button3_Click);
            // 
            // PopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 572);
            this.ControlBox = false;
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.custom_chklist);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.Name = "PopupForm";
            this.Text = "PopupForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.PopupForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.CheckedListBox custom_chklist;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnclose;
    }
}