using Generated_File.Classes;

namespace Generated_File
{
    partial class MainForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_SAPJDBC = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSAPJDB = new System.Windows.Forms.TextBox();
            this.txtsrname = new System.Windows.Forms.TextBox();
            this.txtsrPsw = new System.Windows.Forms.TextBox();
            this.txtsrServer = new System.Windows.Forms.TextBox();
            this.SrCmb = new System.Windows.Forms.ComboBox();
            this.txtsrUser = new System.Windows.Forms.TextBox();
            this.txtsrDb = new System.Windows.Forms.TextBox();
            this.txtsrPor = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TrgJdbc = new System.Windows.Forms.TextBox();
            this.lbl_jdbc = new System.Windows.Forms.Label();
            this.TrgCmb = new System.Windows.Forms.ComboBox();
            this.txtTrgPs = new System.Windows.Forms.TextBox();
            this.txtTrgUs = new System.Windows.Forms.TextBox();
            this.txtTRPo = new System.Windows.Forms.TextBox();
            this.txtTrDB = new System.Windows.Forms.TextBox();
            this.txtTrSrV = new System.Windows.Forms.TextBox();
            this.txtTrgNam = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.CombData = new System.Windows.Forms.DataGridView();
            this.btngenerate = new System.Windows.Forms.Button();
            this.btnaddNew = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.SrcColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TrgColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SourceSql = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrgSql = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SourceSort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrgtSort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MrgKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MrgValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConnSync = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TbleMerg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnsave = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CombData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_SAPJDBC);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSAPJDB);
            this.groupBox1.Controls.Add(this.txtsrname);
            this.groupBox1.Controls.Add(this.txtsrPsw);
            this.groupBox1.Controls.Add(this.txtsrServer);
            this.groupBox1.Controls.Add(this.SrCmb);
            this.groupBox1.Controls.Add(this.txtsrUser);
            this.groupBox1.Controls.Add(this.txtsrDb);
            this.groupBox1.Controls.Add(this.txtsrPor);
            this.groupBox1.Location = new System.Drawing.Point(21, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(626, 447);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source";
            // 
            // lbl_SAPJDBC
            // 
            this.lbl_SAPJDBC.AutoSize = true;
            this.lbl_SAPJDBC.Location = new System.Drawing.Point(225, 16);
            this.lbl_SAPJDBC.Name = "lbl_SAPJDBC";
            this.lbl_SAPJDBC.Size = new System.Drawing.Size(86, 13);
            this.lbl_SAPJDBC.TabIndex = 35;
            this.lbl_SAPJDBC.Text = "JDBC SAP Conn";
            this.lbl_SAPJDBC.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 375);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 322);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "User Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Database";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Name";
            // 
            // txtSAPJDB
            // 
            this.txtSAPJDB.Location = new System.Drawing.Point(228, 64);
            this.txtSAPJDB.Multiline = true;
            this.txtSAPJDB.Name = "txtSAPJDB";
            this.txtSAPJDB.Size = new System.Drawing.Size(381, 182);
            this.txtSAPJDB.TabIndex = 27;
            this.txtSAPJDB.Visible = false;
            // 
            // txtsrname
            // 
            this.txtsrname.Location = new System.Drawing.Point(78, 62);
            this.txtsrname.Name = "txtsrname";
            this.txtsrname.Size = new System.Drawing.Size(121, 20);
            this.txtsrname.TabIndex = 20;
            // 
            // txtsrPsw
            // 
            this.txtsrPsw.Location = new System.Drawing.Point(78, 367);
            this.txtsrPsw.Name = "txtsrPsw";
            this.txtsrPsw.PasswordChar = '*';
            this.txtsrPsw.Size = new System.Drawing.Size(121, 20);
            this.txtsrPsw.TabIndex = 26;
            // 
            // txtsrServer
            // 
            this.txtsrServer.Location = new System.Drawing.Point(78, 108);
            this.txtsrServer.Name = "txtsrServer";
            this.txtsrServer.Size = new System.Drawing.Size(121, 20);
            this.txtsrServer.TabIndex = 21;
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
            this.SrCmb.Location = new System.Drawing.Point(78, 162);
            this.SrCmb.Name = "SrCmb";
            this.SrCmb.Size = new System.Drawing.Size(121, 21);
            this.SrCmb.TabIndex = 22;
            this.SrCmb.SelectedIndexChanged += new System.EventHandler(this.SrCmb_SelectedIndexChanged);
            // 
            // txtsrUser
            // 
            this.txtsrUser.Location = new System.Drawing.Point(78, 311);
            this.txtsrUser.Name = "txtsrUser";
            this.txtsrUser.Size = new System.Drawing.Size(121, 20);
            this.txtsrUser.TabIndex = 25;
            // 
            // txtsrDb
            // 
            this.txtsrDb.Location = new System.Drawing.Point(78, 212);
            this.txtsrDb.Name = "txtsrDb";
            this.txtsrDb.Size = new System.Drawing.Size(121, 20);
            this.txtsrDb.TabIndex = 23;
            // 
            // txtsrPor
            // 
            this.txtsrPor.Location = new System.Drawing.Point(78, 263);
            this.txtsrPor.Name = "txtsrPor";
            this.txtsrPor.Size = new System.Drawing.Size(121, 20);
            this.txtsrPor.TabIndex = 24;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TrgJdbc);
            this.groupBox2.Controls.Add(this.lbl_jdbc);
            this.groupBox2.Controls.Add(this.TrgCmb);
            this.groupBox2.Controls.Add(this.txtTrgPs);
            this.groupBox2.Controls.Add(this.txtTrgUs);
            this.groupBox2.Controls.Add(this.txtTRPo);
            this.groupBox2.Controls.Add(this.txtTrDB);
            this.groupBox2.Controls.Add(this.txtTrSrV);
            this.groupBox2.Controls.Add(this.txtTrgNam);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Location = new System.Drawing.Point(732, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(734, 447);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Target";
            // 
            // TrgJdbc
            // 
            this.TrgJdbc.Location = new System.Drawing.Point(300, 53);
            this.TrgJdbc.Multiline = true;
            this.TrgJdbc.Name = "TrgJdbc";
            this.TrgJdbc.Size = new System.Drawing.Size(429, 182);
            this.TrgJdbc.TabIndex = 38;
            this.TrgJdbc.Visible = false;
            // 
            // lbl_jdbc
            // 
            this.lbl_jdbc.AutoSize = true;
            this.lbl_jdbc.Location = new System.Drawing.Point(297, 16);
            this.lbl_jdbc.Name = "lbl_jdbc";
            this.lbl_jdbc.Size = new System.Drawing.Size(86, 13);
            this.lbl_jdbc.TabIndex = 37;
            this.lbl_jdbc.Text = "JDBC SAP Conn";
            this.lbl_jdbc.Visible = false;
            // 
            // TrgCmb
            // 
            this.TrgCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TrgCmb.FormattingEnabled = true;
            this.TrgCmb.Items.AddRange(new object[] {
            "MARIADB",
            "MSSQLNATIVE",
            "MYSQL",
            "SAP"});
            this.TrgCmb.Location = new System.Drawing.Point(111, 163);
            this.TrgCmb.Name = "TrgCmb";
            this.TrgCmb.Size = new System.Drawing.Size(136, 21);
            this.TrgCmb.TabIndex = 36;
            this.TrgCmb.SelectedIndexChanged += new System.EventHandler(this.TrgCmb_SelectedIndexChanged);
            // 
            // txtTrgPs
            // 
            this.txtTrgPs.Location = new System.Drawing.Point(111, 378);
            this.txtTrgPs.Name = "txtTrgPs";
            this.txtTrgPs.PasswordChar = '*';
            this.txtTrgPs.Size = new System.Drawing.Size(136, 20);
            this.txtTrgPs.TabIndex = 35;
            // 
            // txtTrgUs
            // 
            this.txtTrgUs.Location = new System.Drawing.Point(111, 324);
            this.txtTrgUs.Name = "txtTrgUs";
            this.txtTrgUs.Size = new System.Drawing.Size(136, 20);
            this.txtTrgUs.TabIndex = 34;
            // 
            // txtTRPo
            // 
            this.txtTRPo.Location = new System.Drawing.Point(111, 269);
            this.txtTRPo.Name = "txtTRPo";
            this.txtTRPo.Size = new System.Drawing.Size(136, 20);
            this.txtTRPo.TabIndex = 33;
            // 
            // txtTrDB
            // 
            this.txtTrDB.Location = new System.Drawing.Point(111, 215);
            this.txtTrDB.Name = "txtTrDB";
            this.txtTrDB.Size = new System.Drawing.Size(136, 20);
            this.txtTrDB.TabIndex = 32;
            // 
            // txtTrSrV
            // 
            this.txtTrSrV.Location = new System.Drawing.Point(111, 105);
            this.txtTrSrV.Name = "txtTrSrV";
            this.txtTrSrV.Size = new System.Drawing.Size(136, 20);
            this.txtTrSrV.TabIndex = 31;
            // 
            // txtTrgNam
            // 
            this.txtTrgNam.Location = new System.Drawing.Point(111, 47);
            this.txtTrgNam.Name = "txtTrgNam";
            this.txtTrgNam.Size = new System.Drawing.Size(136, 20);
            this.txtTrgNam.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 382);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Password";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 329);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "User Name";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 220);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Database";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(25, 273);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Port";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(25, 169);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Type";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(25, 109);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 24;
            this.label14.Text = "Server";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(25, 47);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 23;
            this.label15.Text = "Name";
            // 
            // CombData
            // 
            this.CombData.AllowUserToAddRows = false;
            this.CombData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CombData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SrcColumn,
            this.TrgColumn,
            this.SourceSql,
            this.TrgSql,
            this.SourceSort,
            this.TrgtSort,
            this.MrgKey,
            this.MrgValue,
            this.ConnSync,
            this.TbleMerg,
            this.SyncKey,
            this.SyncValue,
            this.btnsave});
            this.CombData.Location = new System.Drawing.Point(10, 523);
            this.CombData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CombData.MultiSelect = false;
            this.CombData.Name = "CombData";
            this.CombData.RowHeadersWidth = 51;
            this.CombData.RowTemplate.Height = 26;
            this.CombData.Size = new System.Drawing.Size(1482, 257);
            this.CombData.TabIndex = 3;
            this.CombData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CombData_CellClick_1);
            this.CombData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CombData_CellContentClick);
            this.CombData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CombData_KeyDown);
            // 
            // btngenerate
            // 
            this.btngenerate.Location = new System.Drawing.Point(650, 474);
            this.btngenerate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btngenerate.Name = "btngenerate";
            this.btngenerate.Size = new System.Drawing.Size(90, 37);
            this.btngenerate.TabIndex = 4;
            this.btngenerate.Text = "Generate";
            this.btngenerate.UseVisualStyleBackColor = true;
            this.btngenerate.Click += new System.EventHandler(this.btngenerate_Click);
            // 
            // btnaddNew
            // 
            this.btnaddNew.Location = new System.Drawing.Point(21, 481);
            this.btnaddNew.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnaddNew.Name = "btnaddNew";
            this.btnaddNew.Size = new System.Drawing.Size(84, 30);
            this.btnaddNew.TabIndex = 5;
            this.btnaddNew.Text = "Add Rows";
            this.btnaddNew.UseVisualStyleBackColor = true;
            this.btnaddNew.Click += new System.EventHandler(this.btnaddNew_Click);
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(1373, 474);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(93, 37);
            this.btndelete.TabIndex = 6;
            this.btndelete.Text = "Delete Row";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // SrcColumn
            // 
            this.SrcColumn.HeaderText = "SourceTable";
            this.SrcColumn.MinimumWidth = 6;
            this.SrcColumn.Name = "SrcColumn";
            this.SrcColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SrcColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
            // SourceSql
            // 
            this.SourceSql.HeaderText = "Source Sql";
            this.SourceSql.MinimumWidth = 6;
            this.SourceSql.Name = "SourceSql";
            this.SourceSql.Width = 125;
            // 
            // TrgSql
            // 
            this.TrgSql.HeaderText = "Target Sql";
            this.TrgSql.MinimumWidth = 6;
            this.TrgSql.Name = "TrgSql";
            this.TrgSql.Width = 125;
            // 
            // SourceSort
            // 
            this.SourceSort.HeaderText = "Source Sort";
            this.SourceSort.MinimumWidth = 6;
            this.SourceSort.Name = "SourceSort";
            this.SourceSort.ReadOnly = true;
            this.SourceSort.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SourceSort.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SourceSort.Width = 125;
            // 
            // TrgtSort
            // 
            this.TrgtSort.HeaderText = "Target Sort";
            this.TrgtSort.MinimumWidth = 6;
            this.TrgtSort.Name = "TrgtSort";
            this.TrgtSort.ReadOnly = true;
            this.TrgtSort.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TrgtSort.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TrgtSort.Width = 125;
            // 
            // MrgKey
            // 
            this.MrgKey.HeaderText = "Merge Keys";
            this.MrgKey.MinimumWidth = 6;
            this.MrgKey.Name = "MrgKey";
            this.MrgKey.ReadOnly = true;
            this.MrgKey.Width = 125;
            // 
            // MrgValue
            // 
            this.MrgValue.HeaderText = "Merge Values";
            this.MrgValue.MinimumWidth = 6;
            this.MrgValue.Name = "MrgValue";
            this.MrgValue.ReadOnly = true;
            this.MrgValue.Width = 125;
            // 
            // ConnSync
            // 
            this.ConnSync.HeaderText = "Sync Connection";
            this.ConnSync.MinimumWidth = 6;
            this.ConnSync.Name = "ConnSync";
            this.ConnSync.ReadOnly = true;
            this.ConnSync.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ConnSync.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ConnSync.Width = 125;
            // 
            // TbleMerg
            // 
            this.TbleMerg.HeaderText = "Sync Table";
            this.TbleMerg.MinimumWidth = 6;
            this.TbleMerg.Name = "TbleMerg";
            this.TbleMerg.ReadOnly = true;
            this.TbleMerg.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TbleMerg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TbleMerg.Width = 125;
            // 
            // SyncKey
            // 
            this.SyncKey.HeaderText = "Sync Key";
            this.SyncKey.MinimumWidth = 6;
            this.SyncKey.Name = "SyncKey";
            this.SyncKey.ReadOnly = true;
            this.SyncKey.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SyncKey.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SyncKey.Width = 125;
            // 
            // SyncValue
            // 
            this.SyncValue.HeaderText = "Sync Value";
            this.SyncValue.MinimumWidth = 6;
            this.SyncValue.Name = "SyncValue";
            this.SyncValue.ReadOnly = true;
            this.SyncValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SyncValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SyncValue.Width = 125;
            // 
            // btnsave
            // 
            this.btnsave.HeaderText = "Save";
            this.btnsave.MinimumWidth = 6;
            this.btnsave.Name = "btnsave";
            this.btnsave.Text = "Save Currently";
            this.btnsave.Width = 125;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1174, 609);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnaddNew);
            this.Controls.Add(this.btngenerate);
            this.Controls.Add(this.CombData);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CombData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btngenerate;
        private System.Windows.Forms.TextBox txtSAPJDB;
        private System.Windows.Forms.TextBox txtsrPsw;
        private System.Windows.Forms.TextBox txtsrUser;
        private System.Windows.Forms.TextBox txtsrPor;
        private System.Windows.Forms.TextBox txtsrDb;
        private System.Windows.Forms.ComboBox SrCmb;
        private System.Windows.Forms.TextBox txtsrServer;
        private System.Windows.Forms.TextBox txtsrname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_SAPJDBC;
        private System.Windows.Forms.ComboBox TrgCmb;
        private System.Windows.Forms.TextBox txtTrgPs;
        private System.Windows.Forms.TextBox txtTrgUs;
        private System.Windows.Forms.TextBox txtTRPo;
        private System.Windows.Forms.TextBox txtTrDB;
        private System.Windows.Forms.TextBox txtTrSrV;
        private System.Windows.Forms.TextBox txtTrgNam;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbl_jdbc;
        private System.Windows.Forms.TextBox TrgJdbc;
        private System.Windows.Forms.Button btnaddNew;
        public System.Windows.Forms.DataGridView CombData;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.DataGridViewComboBoxColumn SrcColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn TrgColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SourceSql;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrgSql;
        private System.Windows.Forms.DataGridViewTextBoxColumn SourceSort;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrgtSort;
        private System.Windows.Forms.DataGridViewTextBoxColumn MrgKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn MrgValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConnSync;
        private System.Windows.Forms.DataGridViewTextBoxColumn TbleMerg;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncValue;
        private System.Windows.Forms.DataGridViewButtonColumn btnsave;
        //  private BIKESTORESDataSetTableAdapters.brandsTableAdapter brandsTableAdapter;
    }
}