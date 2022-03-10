namespace BCSV_Reader
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToCSVcsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importAndUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oFD_Main = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signedIntToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.floatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceColumnValuesByToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareAgainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dGV_Rows = new System.Windows.Forms.DataGridView();
            this.Header_str = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbx_Float = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbx_Int = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbx_String = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_Y = new System.Windows.Forms.TextBox();
            this.tbx_X = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbx_Hash = new System.Windows.Forms.CheckBox();
            this.tbx_CellContent = new System.Windows.Forms.TextBox();
            this.tbx_CellLength = new System.Windows.Forms.TextBox();
            this.tbx_CellHeader = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_ReplaceAuto = new System.Windows.Forms.CheckBox();
            this.cbx_Export = new System.Windows.Forms.CheckBox();
            this.cbx_CSV = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.oFD_Import = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dGV_Main = new System.Windows.Forms.DataGridView();
            this.dGV_Import = new System.Windows.Forms.DataGridView();
            this.pnl_Replace = new System.Windows.Forms.Panel();
            this.cbx_Replace = new System.Windows.Forms.CheckBox();
            this.btn_pnl_Replace_Cancel = new System.Windows.Forms.Button();
            this.btn_pnl_Replace_OK = new System.Windows.Forms.Button();
            this.pnl_Replace_NewValue_tbx = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pnl_Replace_Value_tbx = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pnl_Replace_Column_tbx = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Rows)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Import)).BeginInit();
            this.pnl_Replace.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exportToCSVcsvToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exportToCSVcsvToolStripMenuItem
            // 
            this.exportToCSVcsvToolStripMenuItem.Name = "exportToCSVcsvToolStripMenuItem";
            this.exportToCSVcsvToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.exportToCSVcsvToolStripMenuItem.Text = "Export to CSV (*.csv)";
            this.exportToCSVcsvToolStripMenuItem.Click += new System.EventHandler(this.exportToCSVcsvToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.replaceToolStripMenuItem,
            this.importAndUpdateToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // replaceToolStripMenuItem
            // 
            this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            this.replaceToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.replaceToolStripMenuItem.Text = "Replace Hashed Values";
            this.replaceToolStripMenuItem.Click += new System.EventHandler(this.replaceToolStripMenuItem_Click_1);
            // 
            // importAndUpdateToolStripMenuItem
            // 
            this.importAndUpdateToolStripMenuItem.Name = "importAndUpdateToolStripMenuItem";
            this.importAndUpdateToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.importAndUpdateToolStripMenuItem.Text = "Compare with...";
            this.importAndUpdateToolStripMenuItem.Click += new System.EventHandler(this.importAndUpdateToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // oFD_Main
            // 
            this.oFD_Main.DefaultExt = "*.bcsv";
            this.oFD_Main.FileName = "*.bcsv";
            this.oFD_Main.Filter = "BCSV|*.bcsv|TXT|*.txt|All|*.*";
            this.oFD_Main.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 461);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(53, 17);
            this.toolStripStatusLabel1.Text = "Line(s): -";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(74, 17);
            this.toolStripStatusLabel3.Text = "Column(s): -";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(65, 17);
            this.toolStripStatusLabel2.Text = "Data Size: -";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(12, 17);
            this.toolStripStatusLabel4.Text = "-";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "bcsv";
            this.saveFileDialog1.Filter = "BCSV|*.bcsv";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.showHasToolStripMenuItem,
            this.replaceColumnValuesByToolStripMenuItem,
            this.compareAgainToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(222, 92);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // showHasToolStripMenuItem
            // 
            this.showHasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stringToolStripMenuItem,
            this.intToolStripMenuItem,
            this.signedIntToolStripMenuItem,
            this.floatToolStripMenuItem,
            this.hexToolStripMenuItem});
            this.showHasToolStripMenuItem.Name = "showHasToolStripMenuItem";
            this.showHasToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.showHasToolStripMenuItem.Text = "Show has..";
            // 
            // stringToolStripMenuItem
            // 
            this.stringToolStripMenuItem.Name = "stringToolStripMenuItem";
            this.stringToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.stringToolStripMenuItem.Text = "String";
            this.stringToolStripMenuItem.Click += new System.EventHandler(this.stringToolStripMenuItem_Click);
            // 
            // intToolStripMenuItem
            // 
            this.intToolStripMenuItem.Name = "intToolStripMenuItem";
            this.intToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.intToolStripMenuItem.Text = "Int32";
            this.intToolStripMenuItem.Click += new System.EventHandler(this.intToolStripMenuItem_Click);
            // 
            // signedIntToolStripMenuItem
            // 
            this.signedIntToolStripMenuItem.Name = "signedIntToolStripMenuItem";
            this.signedIntToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.signedIntToolStripMenuItem.Text = "Short Int";
            this.signedIntToolStripMenuItem.Click += new System.EventHandler(this.signedIntToolStripMenuItem_Click);
            // 
            // floatToolStripMenuItem
            // 
            this.floatToolStripMenuItem.Name = "floatToolStripMenuItem";
            this.floatToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.floatToolStripMenuItem.Text = "Float";
            this.floatToolStripMenuItem.Click += new System.EventHandler(this.floatToolStripMenuItem_Click);
            // 
            // hexToolStripMenuItem
            // 
            this.hexToolStripMenuItem.Enabled = false;
            this.hexToolStripMenuItem.Name = "hexToolStripMenuItem";
            this.hexToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.hexToolStripMenuItem.Text = "Hex";
            this.hexToolStripMenuItem.Click += new System.EventHandler(this.hexToolStripMenuItem_Click);
            // 
            // replaceColumnValuesByToolStripMenuItem
            // 
            this.replaceColumnValuesByToolStripMenuItem.Name = "replaceColumnValuesByToolStripMenuItem";
            this.replaceColumnValuesByToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.replaceColumnValuesByToolStripMenuItem.Text = "Replace Column value(s) by";
            this.replaceColumnValuesByToolStripMenuItem.Click += new System.EventHandler(this.replaceColumnValuesByToolStripMenuItem_Click);
            // 
            // compareAgainToolStripMenuItem
            // 
            this.compareAgainToolStripMenuItem.Name = "compareAgainToolStripMenuItem";
            this.compareAgainToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.compareAgainToolStripMenuItem.Text = "Compare again";
            this.compareAgainToolStripMenuItem.Click += new System.EventHandler(this.compareAgainToolStripMenuItem_Click);
            // 
            // dGV_Rows
            // 
            this.dGV_Rows.AllowUserToAddRows = false;
            this.dGV_Rows.AllowUserToDeleteRows = false;
            this.dGV_Rows.AllowUserToResizeColumns = false;
            this.dGV_Rows.AllowUserToResizeRows = false;
            this.dGV_Rows.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGV_Rows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_Rows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Header_str,
            this.Column_Size,
            this.Column_Type});
            this.dGV_Rows.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dGV_Rows.Location = new System.Drawing.Point(755, 27);
            this.dGV_Rows.MultiSelect = false;
            this.dGV_Rows.Name = "dGV_Rows";
            this.dGV_Rows.ReadOnly = true;
            this.dGV_Rows.RowHeadersVisible = false;
            this.dGV_Rows.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dGV_Rows.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGV_Rows.Size = new System.Drawing.Size(241, 147);
            this.dGV_Rows.TabIndex = 9;
            // 
            // Header_str
            // 
            this.Header_str.HeaderText = "Name";
            this.Header_str.Name = "Header_str";
            this.Header_str.ReadOnly = true;
            this.Header_str.Width = 80;
            // 
            // Column_Size
            // 
            this.Column_Size.HeaderText = "Size";
            this.Column_Size.MaxInputLength = 8;
            this.Column_Size.Name = "Column_Size";
            this.Column_Size.ReadOnly = true;
            this.Column_Size.Width = 50;
            // 
            // Column_Type
            // 
            this.Column_Type.HeaderText = "Type";
            this.Column_Type.Name = "Column_Type";
            this.Column_Type.ReadOnly = true;
            this.Column_Type.Width = 120;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbx_Float);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbx_Int);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbx_String);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbx_Y);
            this.groupBox1.Controls.Add(this.tbx_X);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbx_Hash);
            this.groupBox1.Controls.Add(this.tbx_CellContent);
            this.groupBox1.Controls.Add(this.tbx_CellLength);
            this.groupBox1.Controls.Add(this.tbx_CellHeader);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(755, 226);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 232);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // tbx_Float
            // 
            this.tbx_Float.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_Float.Location = new System.Drawing.Point(61, 176);
            this.tbx_Float.Name = "tbx_Float";
            this.tbx_Float.ReadOnly = true;
            this.tbx_Float.Size = new System.Drawing.Size(174, 20);
            this.tbx_Float.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Float:";
            // 
            // tbx_Int
            // 
            this.tbx_Int.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_Int.Location = new System.Drawing.Point(61, 150);
            this.tbx_Int.Name = "tbx_Int";
            this.tbx_Int.ReadOnly = true;
            this.tbx_Int.Size = new System.Drawing.Size(174, 20);
            this.tbx_Int.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Int:";
            // 
            // tbx_String
            // 
            this.tbx_String.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_String.Location = new System.Drawing.Point(61, 124);
            this.tbx_String.Name = "tbx_String";
            this.tbx_String.ReadOnly = true;
            this.tbx_String.Size = new System.Drawing.Size(174, 20);
            this.tbx_String.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "String:";
            // 
            // tbx_Y
            // 
            this.tbx_Y.Location = new System.Drawing.Point(155, 72);
            this.tbx_Y.Name = "tbx_Y";
            this.tbx_Y.ReadOnly = true;
            this.tbx_Y.Size = new System.Drawing.Size(80, 20);
            this.tbx_Y.TabIndex = 12;
            // 
            // tbx_X
            // 
            this.tbx_X.Location = new System.Drawing.Point(61, 72);
            this.tbx_X.Name = "tbx_X";
            this.tbx_X.ReadOnly = true;
            this.tbx_X.Size = new System.Drawing.Size(80, 20);
            this.tbx_X.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Pos:";
            // 
            // cbx_Hash
            // 
            this.cbx_Hash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_Hash.AutoSize = true;
            this.cbx_Hash.Location = new System.Drawing.Point(14, 209);
            this.cbx_Hash.Name = "cbx_Hash";
            this.cbx_Hash.Size = new System.Drawing.Size(51, 17);
            this.cbx_Hash.TabIndex = 9;
            this.cbx_Hash.Text = "Hash";
            this.toolTip1.SetToolTip(this.cbx_Hash, "Hash \"Content\" to CRC32");
            this.cbx_Hash.UseVisualStyleBackColor = true;
            this.cbx_Hash.CheckedChanged += new System.EventHandler(this.cbx_Hash_CheckedChanged);
            // 
            // tbx_CellContent
            // 
            this.tbx_CellContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_CellContent.Location = new System.Drawing.Point(61, 98);
            this.tbx_CellContent.Name = "tbx_CellContent";
            this.tbx_CellContent.Size = new System.Drawing.Size(174, 20);
            this.tbx_CellContent.TabIndex = 7;
            // 
            // tbx_CellLength
            // 
            this.tbx_CellLength.Location = new System.Drawing.Point(61, 45);
            this.tbx_CellLength.Name = "tbx_CellLength";
            this.tbx_CellLength.ReadOnly = true;
            this.tbx_CellLength.Size = new System.Drawing.Size(174, 20);
            this.tbx_CellLength.TabIndex = 6;
            // 
            // tbx_CellHeader
            // 
            this.tbx_CellHeader.Location = new System.Drawing.Point(61, 19);
            this.tbx_CellHeader.Name = "tbx_CellHeader";
            this.tbx_CellHeader.ReadOnly = true;
            this.tbx_CellHeader.Size = new System.Drawing.Size(174, 20);
            this.tbx_CellHeader.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Content:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Length :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Header :";
            // 
            // cbx_ReplaceAuto
            // 
            this.cbx_ReplaceAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_ReplaceAuto.AutoSize = true;
            this.cbx_ReplaceAuto.Location = new System.Drawing.Point(769, 180);
            this.cbx_ReplaceAuto.Name = "cbx_ReplaceAuto";
            this.cbx_ReplaceAuto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbx_ReplaceAuto.Size = new System.Drawing.Size(119, 17);
            this.cbx_ReplaceAuto.TabIndex = 11;
            this.cbx_ReplaceAuto.Text = "Auto Replace Hash";
            this.toolTip1.SetToolTip(this.cbx_ReplaceAuto, "Replace all hashes automatically if hash.csv exist");
            this.cbx_ReplaceAuto.UseVisualStyleBackColor = true;
            // 
            // cbx_Export
            // 
            this.cbx_Export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_Export.AutoSize = true;
            this.cbx_Export.Location = new System.Drawing.Point(769, 203);
            this.cbx_Export.Name = "cbx_Export";
            this.cbx_Export.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbx_Export.Size = new System.Drawing.Size(127, 17);
            this.cbx_Export.TabIndex = 12;
            this.cbx_Export.Text = "Export Unknow Hash";
            this.toolTip1.SetToolTip(this.cbx_Export, "Export all Unknowed Header Hashes to file");
            this.cbx_Export.UseVisualStyleBackColor = true;
            // 
            // cbx_CSV
            // 
            this.cbx_CSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_CSV.AutoSize = true;
            this.cbx_CSV.Location = new System.Drawing.Point(891, 180);
            this.cbx_CSV.Name = "cbx_CSV";
            this.cbx_CSV.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbx_CSV.Size = new System.Drawing.Size(105, 17);
            this.cbx_CSV.TabIndex = 13;
            this.cbx_CSV.Text = "Auto Export CSV";
            this.toolTip1.SetToolTip(this.cbx_CSV, "Export Loaded File to CSV automatically");
            this.cbx_CSV.UseVisualStyleBackColor = true;
            // 
            // oFD_Import
            // 
            this.oFD_Import.DefaultExt = "*.bcsv";
            this.oFD_Import.FileName = "*.bcsv";
            this.oFD_Import.Filter = "BCSV|*.bcsv|TXT|*.txt|All|*.*";
            this.oFD_Import.FileOk += new System.ComponentModel.CancelEventHandler(this.oFD_Import_FileOk);
            // 
            // splitContainer1
            // 
            this.splitContainer1.AllowDrop = true;
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dGV_Main);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dGV_Import);
            this.splitContainer1.Size = new System.Drawing.Size(737, 425);
            this.splitContainer1.SplitterDistance = 708;
            this.splitContainer1.TabIndex = 15;
            // 
            // dGV_Main
            // 
            this.dGV_Main.AllowDrop = true;
            this.dGV_Main.AllowUserToOrderColumns = true;
            this.dGV_Main.CausesValidation = false;
            this.dGV_Main.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dGV_Main.ContextMenuStrip = this.contextMenuStrip1;
            this.dGV_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGV_Main.Location = new System.Drawing.Point(0, 0);
            this.dGV_Main.Name = "dGV_Main";
            this.dGV_Main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dGV_Main.Size = new System.Drawing.Size(708, 425);
            this.dGV_Main.StandardTab = true;
            this.dGV_Main.TabIndex = 16;
            this.dGV_Main.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);

            this.dGV_Main.DragDrop += new System.Windows.Forms.DragEventHandler(this.dGV_Main_DragDrop);
            this.dGV_Main.DragEnter += new System.Windows.Forms.DragEventHandler(this.dGV_Main_DragEnter);
            // 
            // dGV_Import
            // 
            this.dGV_Import.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_Import.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGV_Import.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dGV_Import.Enabled = false;
            this.dGV_Import.Location = new System.Drawing.Point(0, 0);
            this.dGV_Import.Name = "dGV_Import";
            this.dGV_Import.ReadOnly = true;
            this.dGV_Import.Size = new System.Drawing.Size(25, 425);
            this.dGV_Import.TabIndex = 1;
            this.dGV_Import.Visible = false;
            // 
            // pnl_Replace
            // 
            this.pnl_Replace.Controls.Add(this.cbx_Replace);
            this.pnl_Replace.Controls.Add(this.btn_pnl_Replace_Cancel);
            this.pnl_Replace.Controls.Add(this.btn_pnl_Replace_OK);
            this.pnl_Replace.Controls.Add(this.pnl_Replace_NewValue_tbx);
            this.pnl_Replace.Controls.Add(this.label8);
            this.pnl_Replace.Controls.Add(this.pnl_Replace_Value_tbx);
            this.pnl_Replace.Controls.Add(this.label9);
            this.pnl_Replace.Controls.Add(this.pnl_Replace_Column_tbx);
            this.pnl_Replace.Controls.Add(this.label10);
            this.pnl_Replace.Enabled = false;
            this.pnl_Replace.Location = new System.Drawing.Point(241, 59);
            this.pnl_Replace.Name = "pnl_Replace";
            this.pnl_Replace.Size = new System.Drawing.Size(269, 179);
            this.pnl_Replace.TabIndex = 16;
            this.pnl_Replace.Visible = false;
            this.pnl_Replace.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_Replace_Paint);
            // 
            // cbx_Replace
            // 
            this.cbx_Replace.AutoSize = true;
            this.cbx_Replace.Location = new System.Drawing.Point(73, 98);
            this.cbx_Replace.Name = "cbx_Replace";
            this.cbx_Replace.Size = new System.Drawing.Size(115, 17);
            this.cbx_Replace.TabIndex = 16;
            this.cbx_Replace.Text = "Replace All Values";
            this.cbx_Replace.UseVisualStyleBackColor = true;
            this.cbx_Replace.CheckedChanged += new System.EventHandler(this.cbx_Replace_CheckedChanged);
            // 
            // btn_pnl_Replace_Cancel
            // 
            this.btn_pnl_Replace_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_pnl_Replace_Cancel.Location = new System.Drawing.Point(73, 126);
            this.btn_pnl_Replace_Cancel.Name = "btn_pnl_Replace_Cancel";
            this.btn_pnl_Replace_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_pnl_Replace_Cancel.TabIndex = 15;
            this.btn_pnl_Replace_Cancel.Text = "Cancel";
            this.btn_pnl_Replace_Cancel.UseVisualStyleBackColor = true;
            this.btn_pnl_Replace_Cancel.Click += new System.EventHandler(this.btn_pnl_Replace_Cancel_Click);
            // 
            // btn_pnl_Replace_OK
            // 
            this.btn_pnl_Replace_OK.Location = new System.Drawing.Point(171, 126);
            this.btn_pnl_Replace_OK.Name = "btn_pnl_Replace_OK";
            this.btn_pnl_Replace_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_pnl_Replace_OK.TabIndex = 14;
            this.btn_pnl_Replace_OK.Text = "OK";
            this.btn_pnl_Replace_OK.UseVisualStyleBackColor = true;
            this.btn_pnl_Replace_OK.Click += new System.EventHandler(this.btn_pnl_Replace_OK_Click);
            // 
            // pnl_Replace_NewValue_tbx
            // 
            this.pnl_Replace_NewValue_tbx.Location = new System.Drawing.Point(73, 71);
            this.pnl_Replace_NewValue_tbx.Name = "pnl_Replace_NewValue_tbx";
            this.pnl_Replace_NewValue_tbx.Size = new System.Drawing.Size(173, 20);
            this.pnl_Replace_NewValue_tbx.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "With :";
            // 
            // pnl_Replace_Value_tbx
            // 
            this.pnl_Replace_Value_tbx.Location = new System.Drawing.Point(73, 45);
            this.pnl_Replace_Value_tbx.Name = "pnl_Replace_Value_tbx";
            this.pnl_Replace_Value_tbx.Size = new System.Drawing.Size(173, 20);
            this.pnl_Replace_Value_tbx.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Replace :";
            // 
            // pnl_Replace_Column_tbx
            // 
            this.pnl_Replace_Column_tbx.Location = new System.Drawing.Point(73, 17);
            this.pnl_Replace_Column_tbx.Name = "pnl_Replace_Column_tbx";
            this.pnl_Replace_Column_tbx.ReadOnly = true;
            this.pnl_Replace_Column_tbx.Size = new System.Drawing.Size(100, 20);
            this.pnl_Replace_Column_tbx.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "in Column :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 483);
            this.Controls.Add(this.pnl_Replace);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.cbx_CSV);
            this.Controls.Add(this.cbx_Export);
            this.Controls.Add(this.cbx_ReplaceAuto);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dGV_Rows);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1024, 522);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " BCSV Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Rows)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Import)).EndInit();
            this.pnl_Replace.ResumeLayout(false);
            this.pnl_Replace.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.OpenFileDialog oFD_Main;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem exportToCSVcsvToolStripMenuItem;
        private System.Windows.Forms.DataGridView dGV_Rows;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbx_CellContent;
        private System.Windows.Forms.TextBox tbx_CellLength;
        private System.Windows.Forms.TextBox tbx_CellHeader;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbx_Hash;
        private System.Windows.Forms.TextBox tbx_Y;
        private System.Windows.Forms.TextBox tbx_X;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Header_str;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Type;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showHasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem floatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signedIntToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
        private System.Windows.Forms.TextBox tbx_Float;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbx_Int;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbx_String;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbx_ReplaceAuto;
        private System.Windows.Forms.CheckBox cbx_Export;
        private System.Windows.Forms.CheckBox cbx_CSV;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem importAndUpdateToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog oFD_Import;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dGV_Import;
        private System.Windows.Forms.DataGridView dGV_Main;
        private System.Windows.Forms.ToolStripMenuItem replaceColumnValuesByToolStripMenuItem;
        private System.Windows.Forms.Panel pnl_Replace;
        private System.Windows.Forms.Button btn_pnl_Replace_Cancel;
        private System.Windows.Forms.Button btn_pnl_Replace_OK;
        private System.Windows.Forms.TextBox pnl_Replace_NewValue_tbx;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox pnl_Replace_Value_tbx;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox pnl_Replace_Column_tbx;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cbx_Replace;
        private System.Windows.Forms.ToolStripMenuItem compareAgainToolStripMenuItem;
    }
}

