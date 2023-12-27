namespace WinFormsClient
{
    partial class MainMenuForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.butOpen = new System.Windows.Forms.Button();
            this.tbCreateDBName = new System.Windows.Forms.TextBox();
            this.tbAddTableName = new System.Windows.Forms.TextBox();
            this.tbAddColumnName = new System.Windows.Forms.TextBox();
            this.butSaveDB = new System.Windows.Forms.Button();
            this.butCreate = new System.Windows.Forms.Button();
            this.butAddTable = new System.Windows.Forms.Button();
            this.butDeleteTable = new System.Windows.Forms.Button();
            this.butAddColumn = new System.Windows.Forms.Button();
            this.cbTypes = new System.Windows.Forms.ComboBox();
            this.butDeleteColumn = new System.Windows.Forms.Button();
            this.tbTypeInterval = new System.Windows.Forms.TextBox();
            this.butAddRow = new System.Windows.Forms.Button();
            this.butDeleteRow = new System.Windows.Forms.Button();
            this.butJoinTables = new System.Windows.Forms.Button();
            this.cbJoinTables1Table = new System.Windows.Forms.ComboBox();
            this.cbJoinTables2Table = new System.Windows.Forms.ComboBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.sfdSaveDB = new System.Windows.Forms.SaveFileDialog();
            this.ofdOpenDB = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // butOpen
            // 
            this.butOpen.Location = new System.Drawing.Point(12, 12);
            this.butOpen.Name = "butOpen";
            this.butOpen.Size = new System.Drawing.Size(75, 23);
            this.butOpen.TabIndex = 0;
            this.butOpen.Text = "Open";
            this.butOpen.UseVisualStyleBackColor = true;
            this.butOpen.Click += new System.EventHandler(this.butOpen_Click);
            // 
            // tbCreateDBName
            // 
            this.tbCreateDBName.Location = new System.Drawing.Point(175, 39);
            this.tbCreateDBName.Name = "tbCreateDBName";
            this.tbCreateDBName.Size = new System.Drawing.Size(151, 20);
            this.tbCreateDBName.TabIndex = 1;
            // 
            // tbAddTableName
            // 
            this.tbAddTableName.Location = new System.Drawing.Point(332, 39);
            this.tbAddTableName.Name = "tbAddTableName";
            this.tbAddTableName.Size = new System.Drawing.Size(152, 20);
            this.tbAddTableName.TabIndex = 2;
            // 
            // tbAddColumnName
            // 
            this.tbAddColumnName.Location = new System.Drawing.Point(490, 39);
            this.tbAddColumnName.Name = "tbAddColumnName";
            this.tbAddColumnName.Size = new System.Drawing.Size(150, 20);
            this.tbAddColumnName.TabIndex = 3;
            // 
            // butSaveDB
            // 
            this.butSaveDB.Location = new System.Drawing.Point(93, 12);
            this.butSaveDB.Name = "butSaveDB";
            this.butSaveDB.Size = new System.Drawing.Size(75, 23);
            this.butSaveDB.TabIndex = 4;
            this.butSaveDB.Text = "Save";
            this.butSaveDB.UseVisualStyleBackColor = true;
            this.butSaveDB.Click += new System.EventHandler(this.butSaveDB_Click);
            // 
            // butCreate
            // 
            this.butCreate.Location = new System.Drawing.Point(214, 11);
            this.butCreate.Name = "butCreate";
            this.butCreate.Size = new System.Drawing.Size(75, 23);
            this.butCreate.TabIndex = 5;
            this.butCreate.Text = "New DB";
            this.butCreate.UseVisualStyleBackColor = true;
            this.butCreate.Click += new System.EventHandler(this.butCreate_Click);
            // 
            // butAddTable
            // 
            this.butAddTable.Location = new System.Drawing.Point(370, 11);
            this.butAddTable.Name = "butAddTable";
            this.butAddTable.Size = new System.Drawing.Size(75, 23);
            this.butAddTable.TabIndex = 6;
            this.butAddTable.Text = "Add Table";
            this.butAddTable.UseVisualStyleBackColor = true;
            this.butAddTable.Click += new System.EventHandler(this.butAddTable_Click);
            // 
            // butDeleteTable
            // 
            this.butDeleteTable.Location = new System.Drawing.Point(366, 65);
            this.butDeleteTable.Name = "butDeleteTable";
            this.butDeleteTable.Size = new System.Drawing.Size(83, 23);
            this.butDeleteTable.TabIndex = 7;
            this.butDeleteTable.Text = "Delete Table";
            this.butDeleteTable.UseVisualStyleBackColor = true;
            this.butDeleteTable.Click += new System.EventHandler(this.butDeleteTable_Click);
            // 
            // butAddColumn
            // 
            this.butAddColumn.Location = new System.Drawing.Point(527, 10);
            this.butAddColumn.Name = "butAddColumn";
            this.butAddColumn.Size = new System.Drawing.Size(75, 23);
            this.butAddColumn.TabIndex = 8;
            this.butAddColumn.Text = "Add Column";
            this.butAddColumn.UseVisualStyleBackColor = true;
            this.butAddColumn.Click += new System.EventHandler(this.butAddColumn_Click);
            // 
            // cbTypes
            // 
            this.cbTypes.FormattingEnabled = true;
            this.cbTypes.Items.AddRange(new object[] {
            "Integer",
            "Real",
            "Char",
            "String",
            "CharInvl",
            "String(CharInvl)"});
            this.cbTypes.Location = new System.Drawing.Point(490, 65);
            this.cbTypes.Name = "cbTypes";
            this.cbTypes.Size = new System.Drawing.Size(150, 21);
            this.cbTypes.TabIndex = 9;
            this.cbTypes.SelectedIndexChanged += new System.EventHandler(this.cbTypes_SelectedIndexChanged);
            // 
            // butDeleteColumn
            // 
            this.butDeleteColumn.Location = new System.Drawing.Point(523, 92);
            this.butDeleteColumn.Name = "butDeleteColumn";
            this.butDeleteColumn.Size = new System.Drawing.Size(85, 23);
            this.butDeleteColumn.TabIndex = 10;
            this.butDeleteColumn.Text = "Delete Column";
            this.butDeleteColumn.UseVisualStyleBackColor = true;
            this.butDeleteColumn.Click += new System.EventHandler(this.butDeleteColumn_Click);
            // 
            // tbTypeInterval
            // 
            this.tbTypeInterval.Location = new System.Drawing.Point(646, 65);
            this.tbTypeInterval.Name = "tbTypeInterval";
            this.tbTypeInterval.Size = new System.Drawing.Size(142, 20);
            this.tbTypeInterval.TabIndex = 11;
            this.tbTypeInterval.Text = "Interval";
            // 
            // butAddRow
            // 
            this.butAddRow.Location = new System.Drawing.Point(713, 7);
            this.butAddRow.Name = "butAddRow";
            this.butAddRow.Size = new System.Drawing.Size(75, 23);
            this.butAddRow.TabIndex = 12;
            this.butAddRow.Text = "Add Row";
            this.butAddRow.UseVisualStyleBackColor = true;
            this.butAddRow.Click += new System.EventHandler(this.butAddRow_Click);
            // 
            // butDeleteRow
            // 
            this.butDeleteRow.Location = new System.Drawing.Point(713, 36);
            this.butDeleteRow.Name = "butDeleteRow";
            this.butDeleteRow.Size = new System.Drawing.Size(75, 23);
            this.butDeleteRow.TabIndex = 13;
            this.butDeleteRow.Text = "Delete Row";
            this.butDeleteRow.UseVisualStyleBackColor = true;
            this.butDeleteRow.Click += new System.EventHandler(this.butDeleteRow_Click);
            // 
            // butJoinTables
            // 
            this.butJoinTables.Location = new System.Drawing.Point(12, 92);
            this.butJoinTables.Name = "butJoinTables";
            this.butJoinTables.Size = new System.Drawing.Size(75, 23);
            this.butJoinTables.TabIndex = 14;
            this.butJoinTables.Text = "Join Tables";
            this.butJoinTables.UseVisualStyleBackColor = true;
            this.butJoinTables.Click += new System.EventHandler(this.butJoinTables_Click);
            // 
            // cbJoinTables1Table
            // 
            this.cbJoinTables1Table.FormattingEnabled = true;
            this.cbJoinTables1Table.Location = new System.Drawing.Point(93, 93);
            this.cbJoinTables1Table.Name = "cbJoinTables1Table";
            this.cbJoinTables1Table.Size = new System.Drawing.Size(121, 21);
            this.cbJoinTables1Table.TabIndex = 15;
            // 
            // cbJoinTables2Table
            // 
            this.cbJoinTables2Table.FormattingEnabled = true;
            this.cbJoinTables2Table.Location = new System.Drawing.Point(220, 93);
            this.cbJoinTables2Table.Name = "cbJoinTables2Table";
            this.cbJoinTables2Table.Size = new System.Drawing.Size(121, 21);
            this.cbJoinTables2Table.TabIndex = 16;
            // 
            // tabControl
            // 
            this.tabControl.Location = new System.Drawing.Point(12, 135);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(776, 27);
            this.tabControl.TabIndex = 17;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 162);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(776, 341);
            this.dataGridView.TabIndex = 18;
            this.dataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEndEdit);
            // 
            // ofdOpenDB
            // 
            this.ofdOpenDB.FileName = "openFileDialog1";
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 515);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.cbJoinTables2Table);
            this.Controls.Add(this.cbJoinTables1Table);
            this.Controls.Add(this.butJoinTables);
            this.Controls.Add(this.butDeleteRow);
            this.Controls.Add(this.butAddRow);
            this.Controls.Add(this.tbTypeInterval);
            this.Controls.Add(this.butDeleteColumn);
            this.Controls.Add(this.cbTypes);
            this.Controls.Add(this.butAddColumn);
            this.Controls.Add(this.butDeleteTable);
            this.Controls.Add(this.butAddTable);
            this.Controls.Add(this.butCreate);
            this.Controls.Add(this.butSaveDB);
            this.Controls.Add(this.tbAddColumnName);
            this.Controls.Add(this.tbAddTableName);
            this.Controls.Add(this.tbCreateDBName);
            this.Controls.Add(this.butOpen);
            this.Name = "MainMenuForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butOpen;
        private System.Windows.Forms.TextBox tbCreateDBName;
        private System.Windows.Forms.TextBox tbAddTableName;
        private System.Windows.Forms.TextBox tbAddColumnName;
        private System.Windows.Forms.Button butSaveDB;
        private System.Windows.Forms.Button butCreate;
        private System.Windows.Forms.Button butAddTable;
        private System.Windows.Forms.Button butDeleteTable;
        private System.Windows.Forms.Button butAddColumn;
        private System.Windows.Forms.ComboBox cbTypes;
        private System.Windows.Forms.Button butDeleteColumn;
        private System.Windows.Forms.TextBox tbTypeInterval;
        private System.Windows.Forms.Button butAddRow;
        private System.Windows.Forms.Button butDeleteRow;
        private System.Windows.Forms.Button butJoinTables;
        private System.Windows.Forms.ComboBox cbJoinTables1Table;
        private System.Windows.Forms.ComboBox cbJoinTables2Table;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.SaveFileDialog sfdSaveDB;
        private System.Windows.Forms.OpenFileDialog ofdOpenDB;
    }
}

