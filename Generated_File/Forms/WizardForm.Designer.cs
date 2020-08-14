namespace Generated_File.Forms
{
    partial class WizardForm
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
            this.wizardControl1 = new AeroWizard.WizardControl();
            this.srcwizard = new AeroWizard.WizardPage();
            this.txtsapviews = new System.Windows.Forms.TextBox();
            this.txtsaptbles = new System.Windows.Forms.TextBox();
            this.lblviews = new System.Windows.Forms.Label();
            this.lbltbles = new System.Windows.Forms.Label();
            this.txtsapclient = new System.Windows.Forms.TextBox();
            this.lblclient = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtsrPsw = new System.Windows.Forms.TextBox();
            this.txtsrUser = new System.Windows.Forms.TextBox();
            this.lbldb = new System.Windows.Forms.Label();
            this.lblport = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblserver = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtsrname = new System.Windows.Forms.TextBox();
            this.txtsrServer = new System.Windows.Forms.TextBox();
            this.SrCmb = new System.Windows.Forms.ComboBox();
            this.txtsrDb = new System.Windows.Forms.TextBox();
            this.txtsrPor = new System.Windows.Forms.TextBox();
            this.Trgtwizard = new AeroWizard.WizardPage();
            this.txtTrgPst = new System.Windows.Forms.TextBox();
            this.txtTrgUse = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.TrgCmbe = new System.Windows.Forms.ComboBox();
            this.txtTRPot = new System.Windows.Forms.TextBox();
            this.txtTrDBt = new System.Windows.Forms.TextBox();
            this.txtTrSrVe = new System.Windows.Forms.TextBox();
            this.txtTrgName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.Encrypt = new AeroWizard.WizardPage();
            this.txtbrowsValue = new System.Windows.Forms.TextBox();
            this.btnbrowse = new System.Windows.Forms.Button();
            this.configwizard = new AeroWizard.WizardPage();
            this.btnadd = new System.Windows.Forms.Button();
            this.CombData = new System.Windows.Forms.DataGridView();
            this.SrcColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrgColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SourceSort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.whereTrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTrgNam = new System.Windows.Forms.TextBox();
            this.txtTrSrV = new System.Windows.Forms.TextBox();
            this.txtTrDB = new System.Windows.Forms.TextBox();
            this.TrgCmb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTrgUs = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTrgPs = new System.Windows.Forms.TextBox();
            this.txtTRPo = new System.Windows.Forms.TextBox();
            this.TrgWizard = new AeroWizard.WizardPage();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.srcwizard.SuspendLayout();
            this.Trgtwizard.SuspendLayout();
            this.Encrypt.SuspendLayout();
            this.configwizard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CombData)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.TrgWizard.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.BackColor = System.Drawing.Color.White;
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wizardControl1.Location = new System.Drawing.Point(0, 28);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.Pages.Add(this.srcwizard);
            this.wizardControl1.Pages.Add(this.Trgtwizard);
            this.wizardControl1.Pages.Add(this.Encrypt);
            this.wizardControl1.Pages.Add(this.configwizard);
            this.wizardControl1.Size = new System.Drawing.Size(1005, 500);
            this.wizardControl1.TabIndex = 0;
            this.wizardControl1.Text = "Pentaho Integration";
            this.wizardControl1.Title = "Pentaho Integration";
            this.wizardControl1.Finished += new System.EventHandler(this.wizardControl1_Finished);
            this.wizardControl1.SelectedPageChanged += new System.EventHandler(this.wizardControl1_SelectedPageChanged);
            // 
            // srcwizard
            // 
            this.srcwizard.Controls.Add(this.txtsapviews);
            this.srcwizard.Controls.Add(this.txtsaptbles);
            this.srcwizard.Controls.Add(this.lblviews);
            this.srcwizard.Controls.Add(this.lbltbles);
            this.srcwizard.Controls.Add(this.txtsapclient);
            this.srcwizard.Controls.Add(this.lblclient);
            this.srcwizard.Controls.Add(this.label8);
            this.srcwizard.Controls.Add(this.label7);
            this.srcwizard.Controls.Add(this.txtsrPsw);
            this.srcwizard.Controls.Add(this.txtsrUser);
            this.srcwizard.Controls.Add(this.lbldb);
            this.srcwizard.Controls.Add(this.lblport);
            this.srcwizard.Controls.Add(this.label4);
            this.srcwizard.Controls.Add(this.lblserver);
            this.srcwizard.Controls.Add(this.label2);
            this.srcwizard.Controls.Add(this.txtsrname);
            this.srcwizard.Controls.Add(this.txtsrServer);
            this.srcwizard.Controls.Add(this.SrCmb);
            this.srcwizard.Controls.Add(this.txtsrDb);
            this.srcwizard.Controls.Add(this.txtsrPor);
            this.srcwizard.Name = "srcwizard";
            this.srcwizard.NextPage = this.Trgtwizard;
            this.srcwizard.Size = new System.Drawing.Size(958, 326);
            this.srcwizard.TabIndex = 4;
            this.srcwizard.Text = "Souce Properties";
            this.srcwizard.Commit += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.srcwizard_Commit);
            // 
            // txtsapviews
            // 
            this.txtsapviews.Location = new System.Drawing.Point(712, 173);
            this.txtsapviews.Multiline = true;
            this.txtsapviews.Name = "txtsapviews";
            this.txtsapviews.Size = new System.Drawing.Size(214, 78);
            this.txtsapviews.TabIndex = 72;
            this.txtsapviews.Visible = false;
            // 
            // txtsaptbles
            // 
            this.txtsaptbles.Location = new System.Drawing.Point(712, 45);
            this.txtsaptbles.Multiline = true;
            this.txtsaptbles.Name = "txtsaptbles";
            this.txtsaptbles.Size = new System.Drawing.Size(214, 78);
            this.txtsaptbles.TabIndex = 71;
            this.txtsaptbles.Visible = false;
            // 
            // lblviews
            // 
            this.lblviews.AutoSize = true;
            this.lblviews.Location = new System.Drawing.Point(644, 220);
            this.lblviews.Name = "lblviews";
            this.lblviews.Size = new System.Drawing.Size(47, 20);
            this.lblviews.TabIndex = 70;
            this.lblviews.Text = "Views";
            this.lblviews.Visible = false;
            // 
            // lbltbles
            // 
            this.lbltbles.AutoSize = true;
            this.lbltbles.Location = new System.Drawing.Point(644, 48);
            this.lbltbles.Name = "lbltbles";
            this.lbltbles.Size = new System.Drawing.Size(50, 20);
            this.lbltbles.TabIndex = 69;
            this.lbltbles.Text = "Tables";
            this.lbltbles.Visible = false;
            // 
            // txtsapclient
            // 
            this.txtsapclient.Location = new System.Drawing.Point(448, 217);
            this.txtsapclient.Name = "txtsapclient";
            this.txtsapclient.Size = new System.Drawing.Size(140, 27);
            this.txtsapclient.TabIndex = 68;
            this.txtsapclient.Visible = false;
            // 
            // lblclient
            // 
            this.lblclient.AutoSize = true;
            this.lblclient.Location = new System.Drawing.Point(321, 227);
            this.lblclient.Name = "lblclient";
            this.lblclient.Size = new System.Drawing.Size(47, 20);
            this.lblclient.TabIndex = 67;
            this.lblclient.Text = "Client";
            this.lblclient.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 20);
            this.label8.TabIndex = 66;
            this.label8.Text = "Password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(307, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 20);
            this.label7.TabIndex = 65;
            this.label7.Text = "User Name";
            // 
            // txtsrPsw
            // 
            this.txtsrPsw.Location = new System.Drawing.Point(116, 224);
            this.txtsrPsw.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtsrPsw.Name = "txtsrPsw";
            this.txtsrPsw.PasswordChar = '*';
            this.txtsrPsw.Size = new System.Drawing.Size(140, 27);
            this.txtsrPsw.TabIndex = 64;
            // 
            // txtsrUser
            // 
            this.txtsrUser.Location = new System.Drawing.Point(448, 157);
            this.txtsrUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtsrUser.Name = "txtsrUser";
            this.txtsrUser.Size = new System.Drawing.Size(140, 27);
            this.txtsrUser.TabIndex = 63;
            // 
            // lbldb
            // 
            this.lbldb.AutoSize = true;
            this.lbldb.Location = new System.Drawing.Point(29, 160);
            this.lbldb.Name = "lbldb";
            this.lbldb.Size = new System.Drawing.Size(72, 20);
            this.lbldb.TabIndex = 62;
            this.lbldb.Text = "Database";
            // 
            // lblport
            // 
            this.lblport.AutoSize = true;
            this.lblport.Location = new System.Drawing.Point(321, 103);
            this.lblport.Name = "lblport";
            this.lblport.Size = new System.Drawing.Size(35, 20);
            this.lblport.TabIndex = 61;
            this.lblport.Text = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(328, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 20);
            this.label4.TabIndex = 60;
            this.label4.Text = "Type";
            // 
            // lblserver
            // 
            this.lblserver.AutoSize = true;
            this.lblserver.Location = new System.Drawing.Point(31, 103);
            this.lblserver.Name = "lblserver";
            this.lblserver.Size = new System.Drawing.Size(50, 20);
            this.lblserver.TabIndex = 59;
            this.lblserver.Text = "Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 58;
            this.label2.Text = "Name";
            // 
            // txtsrname
            // 
            this.txtsrname.Location = new System.Drawing.Point(116, 39);
            this.txtsrname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtsrname.Name = "txtsrname";
            this.txtsrname.Size = new System.Drawing.Size(140, 27);
            this.txtsrname.TabIndex = 53;
            // 
            // txtsrServer
            // 
            this.txtsrServer.Location = new System.Drawing.Point(116, 96);
            this.txtsrServer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtsrServer.Name = "txtsrServer";
            this.txtsrServer.Size = new System.Drawing.Size(140, 27);
            this.txtsrServer.TabIndex = 54;
            // 
            // SrCmb
            // 
            this.SrCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SrCmb.FormattingEnabled = true;
            this.SrCmb.Items.AddRange(new object[] {
            "MARIADB",
            "MSSQLNATIVE",
            "MYSQL",
            "SAP"});
            this.SrCmb.Location = new System.Drawing.Point(448, 39);
            this.SrCmb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SrCmb.Name = "SrCmb";
            this.SrCmb.Size = new System.Drawing.Size(140, 28);
            this.SrCmb.TabIndex = 55;
            this.SrCmb.SelectedIndexChanged += new System.EventHandler(this.SrCmb_SelectedIndexChanged_1);
            // 
            // txtsrDb
            // 
            this.txtsrDb.Location = new System.Drawing.Point(116, 157);
            this.txtsrDb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtsrDb.Name = "txtsrDb";
            this.txtsrDb.Size = new System.Drawing.Size(140, 27);
            this.txtsrDb.TabIndex = 56;
            // 
            // txtsrPor
            // 
            this.txtsrPor.Location = new System.Drawing.Point(448, 96);
            this.txtsrPor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtsrPor.Name = "txtsrPor";
            this.txtsrPor.Size = new System.Drawing.Size(140, 27);
            this.txtsrPor.TabIndex = 57;
            // 
            // Trgtwizard
            // 
            this.Trgtwizard.Controls.Add(this.txtTrgPst);
            this.Trgtwizard.Controls.Add(this.txtTrgUse);
            this.Trgtwizard.Controls.Add(this.label17);
            this.Trgtwizard.Controls.Add(this.label18);
            this.Trgtwizard.Controls.Add(this.TrgCmbe);
            this.Trgtwizard.Controls.Add(this.txtTRPot);
            this.Trgtwizard.Controls.Add(this.txtTrDBt);
            this.Trgtwizard.Controls.Add(this.txtTrSrVe);
            this.Trgtwizard.Controls.Add(this.txtTrgName);
            this.Trgtwizard.Controls.Add(this.label5);
            this.Trgtwizard.Controls.Add(this.label12);
            this.Trgtwizard.Controls.Add(this.label6);
            this.Trgtwizard.Controls.Add(this.label10);
            this.Trgtwizard.Controls.Add(this.label16);
            this.Trgtwizard.Name = "Trgtwizard";
            this.Trgtwizard.Size = new System.Drawing.Size(958, 326);
            this.Trgtwizard.TabIndex = 5;
            this.Trgtwizard.Text = "Taregt Properties";
            this.Trgtwizard.Commit += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.Trgtwizard_Commit);
            // 
            // txtTrgPst
            // 
            this.txtTrgPst.Location = new System.Drawing.Point(131, 251);
            this.txtTrgPst.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTrgPst.Name = "txtTrgPst";
            this.txtTrgPst.PasswordChar = '*';
            this.txtTrgPst.Size = new System.Drawing.Size(158, 27);
            this.txtTrgPst.TabIndex = 50;
            // 
            // txtTrgUse
            // 
            this.txtTrgUse.Location = new System.Drawing.Point(452, 147);
            this.txtTrgUse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTrgUse.Name = "txtTrgUse";
            this.txtTrgUse.Size = new System.Drawing.Size(158, 27);
            this.txtTrgUse.TabIndex = 49;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(31, 254);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 20);
            this.label17.TabIndex = 48;
            this.label17.Text = "Password";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(352, 153);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(82, 20);
            this.label18.TabIndex = 47;
            this.label18.Text = "User Name";
            // 
            // TrgCmbe
            // 
            this.TrgCmbe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TrgCmbe.FormattingEnabled = true;
            this.TrgCmbe.Items.AddRange(new object[] {
            "MARIADB",
            "MSSQLNATIVE",
            "MYSQL",
            "SAP"});
            this.TrgCmbe.Location = new System.Drawing.Point(452, 10);
            this.TrgCmbe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TrgCmbe.Name = "TrgCmbe";
            this.TrgCmbe.Size = new System.Drawing.Size(158, 28);
            this.TrgCmbe.TabIndex = 46;
            // 
            // txtTRPot
            // 
            this.txtTRPot.Location = new System.Drawing.Point(452, 82);
            this.txtTRPot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTRPot.Name = "txtTRPot";
            this.txtTRPot.Size = new System.Drawing.Size(158, 27);
            this.txtTRPot.TabIndex = 45;
            // 
            // txtTrDBt
            // 
            this.txtTrDBt.Location = new System.Drawing.Point(131, 171);
            this.txtTrDBt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTrDBt.Name = "txtTrDBt";
            this.txtTrDBt.Size = new System.Drawing.Size(158, 27);
            this.txtTrDBt.TabIndex = 44;
            // 
            // txtTrSrVe
            // 
            this.txtTrSrVe.Location = new System.Drawing.Point(131, 84);
            this.txtTrSrVe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTrSrVe.Name = "txtTrSrVe";
            this.txtTrSrVe.Size = new System.Drawing.Size(158, 27);
            this.txtTrSrVe.TabIndex = 43;
            // 
            // txtTrgName
            // 
            this.txtTrgName.Location = new System.Drawing.Point(131, 13);
            this.txtTrgName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTrgName.Name = "txtTrgName";
            this.txtTrgName.Size = new System.Drawing.Size(158, 27);
            this.txtTrgName.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 41;
            this.label5.Text = "Database";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(382, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 20);
            this.label12.TabIndex = 40;
            this.label12.Text = "Port";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(377, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 20);
            this.label6.TabIndex = 39;
            this.label6.Text = "Type";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 20);
            this.label10.TabIndex = 38;
            this.label10.Text = "Server";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(31, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 20);
            this.label16.TabIndex = 37;
            this.label16.Text = "Name";
            // 
            // Encrypt
            // 
            this.Encrypt.Controls.Add(this.txtbrowsValue);
            this.Encrypt.Controls.Add(this.btnbrowse);
            this.Encrypt.Name = "Encrypt";
            this.Encrypt.Size = new System.Drawing.Size(958, 326);
            this.Encrypt.TabIndex = 2;
            this.Encrypt.Text = "Encryption Browsing";
            // 
            // txtbrowsValue
            // 
            this.txtbrowsValue.Location = new System.Drawing.Point(308, 127);
            this.txtbrowsValue.Name = "txtbrowsValue";
            this.txtbrowsValue.ReadOnly = true;
            this.txtbrowsValue.Size = new System.Drawing.Size(539, 27);
            this.txtbrowsValue.TabIndex = 10;
            // 
            // btnbrowse
            // 
            this.btnbrowse.Location = new System.Drawing.Point(90, 122);
            this.btnbrowse.Name = "btnbrowse";
            this.btnbrowse.Size = new System.Drawing.Size(153, 33);
            this.btnbrowse.TabIndex = 9;
            this.btnbrowse.Text = "Browse Encryption";
            this.btnbrowse.UseVisualStyleBackColor = true;
            this.btnbrowse.Click += new System.EventHandler(this.btnbrowse_Click);
            // 
            // configwizard
            // 
            this.configwizard.Controls.Add(this.btnadd);
            this.configwizard.Controls.Add(this.CombData);
            this.configwizard.Name = "configwizard";
            this.configwizard.Size = new System.Drawing.Size(958, 326);
            this.configwizard.TabIndex = 3;
            this.configwizard.Text = "Configurations";
//            this.configwizard.Rollback += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.configwizard_Rollback);
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(3, 13);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(106, 43);
            this.btnadd.TabIndex = 2;
            this.btnadd.Text = "New Row";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // CombData
            // 
            this.CombData.AllowUserToAddRows = false;
            this.CombData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CombData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SrcColumn,
            this.TrgColumn,
            this.SourceSort,
            this.whereTrg});
            this.CombData.Location = new System.Drawing.Point(3, 71);
            this.CombData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CombData.MultiSelect = false;
            this.CombData.Name = "CombData";
            this.CombData.RowHeadersWidth = 51;
            this.CombData.RowTemplate.Height = 26;
            this.CombData.Size = new System.Drawing.Size(955, 255);
            this.CombData.TabIndex = 4;
            this.CombData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CombData_CellClick);
            // 
            // SrcColumn
            // 
            this.SrcColumn.HeaderText = "Source Sql";
            this.SrcColumn.MinimumWidth = 6;
            this.SrcColumn.Name = "SrcColumn";
            this.SrcColumn.Width = 125;
            // 
            // TrgColumn
            // 
            this.TrgColumn.HeaderText = "TargetTable";
            this.TrgColumn.MinimumWidth = 6;
            this.TrgColumn.Name = "TrgColumn";
            this.TrgColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TrgColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.TrgColumn.Width = 125;
            // 
            // SourceSort
            // 
            this.SourceSort.HeaderText = "Sort";
            this.SourceSort.MinimumWidth = 6;
            this.SourceSort.Name = "SourceSort";
            this.SourceSort.ReadOnly = true;
            this.SourceSort.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SourceSort.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SourceSort.Width = 125;
            // 
            // whereTrg
            // 
            this.whereTrg.HeaderText = "Where Clause For Target";
            this.whereTrg.MinimumWidth = 6;
            this.whereTrg.Name = "whereTrg";
            this.whereTrg.Width = 250;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Info;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1005, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(80, 24);
            this.toolStripMenuItem1.Text = "File Exist";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 17);
            this.label15.TabIndex = 37;
            this.label15.Text = "Name";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 96);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 17);
            this.label14.TabIndex = 38;
            this.label14.Text = "Server";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(342, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 17);
            this.label13.TabIndex = 39;
            this.label13.Text = "Type";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 170);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 17);
            this.label11.TabIndex = 41;
            this.label11.Text = "Database";
            // 
            // txtTrgNam
            // 
            this.txtTrgNam.Location = new System.Drawing.Point(113, 25);
            this.txtTrgNam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTrgNam.Name = "txtTrgNam";
            this.txtTrgNam.Size = new System.Drawing.Size(158, 24);
            this.txtTrgNam.TabIndex = 42;
            // 
            // txtTrSrV
            // 
            this.txtTrSrV.Location = new System.Drawing.Point(113, 93);
            this.txtTrSrV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTrSrV.Name = "txtTrSrV";
            this.txtTrSrV.Size = new System.Drawing.Size(158, 24);
            this.txtTrSrV.TabIndex = 43;
            // 
            // txtTrDB
            // 
            this.txtTrDB.Location = new System.Drawing.Point(113, 163);
            this.txtTrDB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTrDB.Name = "txtTrDB";
            this.txtTrDB.Size = new System.Drawing.Size(158, 24);
            this.txtTrDB.TabIndex = 44;
            // 
            // TrgCmb
            // 
            this.TrgCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TrgCmb.FormattingEnabled = true;
            this.TrgCmb.Items.AddRange(new object[] {
            "MARIADB",
            "MSSQLNATIVE",
            "MYSQL"});
            this.TrgCmb.Location = new System.Drawing.Point(428, 22);
            this.TrgCmb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TrgCmb.Name = "TrgCmb";
            this.TrgCmb.Size = new System.Drawing.Size(158, 25);
            this.TrgCmb.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(342, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 17);
            this.label3.TabIndex = 47;
            this.label3.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(325, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 48;
            this.label1.Text = "User Name";
            // 
            // txtTrgUs
            // 
            this.txtTrgUs.Location = new System.Drawing.Point(428, 160);
            this.txtTrgUs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTrgUs.Name = "txtTrgUs";
            this.txtTrgUs.Size = new System.Drawing.Size(158, 24);
            this.txtTrgUs.TabIndex = 50;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 234);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 17);
            this.label9.TabIndex = 51;
            this.label9.Text = "Password";
            // 
            // txtTrgPs
            // 
            this.txtTrgPs.Location = new System.Drawing.Point(113, 227);
            this.txtTrgPs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTrgPs.Name = "txtTrgPs";
            this.txtTrgPs.PasswordChar = '*';
            this.txtTrgPs.Size = new System.Drawing.Size(158, 24);
            this.txtTrgPs.TabIndex = 52;
            // 
            // txtTRPo
            // 
            this.txtTRPo.Location = new System.Drawing.Point(428, 96);
            this.txtTRPo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTRPo.Name = "txtTRPo";
            this.txtTRPo.Size = new System.Drawing.Size(158, 24);
            this.txtTRPo.TabIndex = 53;
            // 
            // TrgWizard
            // 
            this.TrgWizard.Controls.Add(this.txtTRPo);
            this.TrgWizard.Controls.Add(this.txtTrgPs);
            this.TrgWizard.Controls.Add(this.label9);
            this.TrgWizard.Controls.Add(this.txtTrgUs);
            this.TrgWizard.Controls.Add(this.label1);
            this.TrgWizard.Controls.Add(this.label3);
            this.TrgWizard.Controls.Add(this.TrgCmb);
            this.TrgWizard.Controls.Add(this.txtTrDB);
            this.TrgWizard.Controls.Add(this.txtTrSrV);
            this.TrgWizard.Controls.Add(this.txtTrgNam);
            this.TrgWizard.Controls.Add(this.label11);
            this.TrgWizard.Controls.Add(this.label13);
            this.TrgWizard.Controls.Add(this.label14);
            this.TrgWizard.Controls.Add(this.label15);
            this.TrgWizard.Name = "TrgWizard";
            this.TrgWizard.NextPage = this.Encrypt;
            this.TrgWizard.Size = new System.Drawing.Size(958, 326);
            this.TrgWizard.TabIndex = 1;
            this.TrgWizard.Text = "Target Property";
            // 
            // WizardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 528);
            this.Controls.Add(this.wizardControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "WizardForm";
            this.Text = "WizardForm";
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.srcwizard.ResumeLayout(false);
            this.srcwizard.PerformLayout();
            this.Trgtwizard.ResumeLayout(false);
            this.Trgtwizard.PerformLayout();
            this.Encrypt.ResumeLayout(false);
            this.Encrypt.PerformLayout();
            this.configwizard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CombData)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.TrgWizard.ResumeLayout(false);
            this.TrgWizard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private AeroWizard.WizardControl wizardControl1;
        private AeroWizard.WizardPage Encrypt;
        private System.Windows.Forms.TextBox txtbrowsValue;
        private System.Windows.Forms.Button btnbrowse;
        private AeroWizard.WizardPage configwizard;
        private AeroWizard.WizardPage srcwizard;
        private System.Windows.Forms.TextBox txtsapviews;
        private System.Windows.Forms.TextBox txtsaptbles;
        private System.Windows.Forms.Label lblviews;
        private System.Windows.Forms.Label lbltbles;
        private System.Windows.Forms.TextBox txtsapclient;
        private System.Windows.Forms.Label lblclient;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtsrPsw;
        private System.Windows.Forms.TextBox txtsrUser;
        private System.Windows.Forms.Label lbldb;
        private System.Windows.Forms.Label lblport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblserver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtsrname;
        private System.Windows.Forms.TextBox txtsrServer;
        private System.Windows.Forms.ComboBox SrCmb;
        private System.Windows.Forms.TextBox txtsrDb;
        private System.Windows.Forms.TextBox txtsrPor;
        public System.Windows.Forms.DataGridView CombData;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrcColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn TrgColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SourceSort;
        private System.Windows.Forms.DataGridViewTextBoxColumn whereTrg;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTrgNam;
        private System.Windows.Forms.TextBox txtTrSrV;
        private System.Windows.Forms.TextBox txtTrDB;
        private System.Windows.Forms.ComboBox TrgCmb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTrgUs;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTrgPs;
        private System.Windows.Forms.TextBox txtTRPo;
        private AeroWizard.WizardPage TrgWizard;
        private AeroWizard.WizardPage Trgtwizard;
        private System.Windows.Forms.ComboBox TrgCmbe;
        private System.Windows.Forms.TextBox txtTRPot;
        private System.Windows.Forms.TextBox txtTrDBt;
        private System.Windows.Forms.TextBox txtTrSrVe;
        private System.Windows.Forms.TextBox txtTrgName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtTrgPst;
        private System.Windows.Forms.TextBox txtTrgUse;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        //private ActiveQueryBuilder.View.WinForms.QueryView.TextAreaColumn Column1;

        #endregion
        //  private AdvancedWizardControl.WizardPages.AdvancedWizardPage advancedWizardPage2;
    }
}