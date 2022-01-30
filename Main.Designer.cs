
namespace SearchRegex
{
  partial class Main
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
      this.lblAfterUrl = new System.Windows.Forms.Label();
      this.txtAfter = new System.Windows.Forms.TextBox();
      this.btnView = new System.Windows.Forms.Button();
      this.btnChange = new System.Windows.Forms.Button();
      this.txtRegex = new System.Windows.Forms.TextBox();
      this.lblRegex = new System.Windows.Forms.Label();
      this.lblTable = new System.Windows.Forms.Label();
      this.txtTable = new System.Windows.Forms.TextBox();
      this.lblKeyColumn = new System.Windows.Forms.Label();
      this.txtKeyColumn = new System.Windows.Forms.TextBox();
      this.lblValColumn = new System.Windows.Forms.Label();
      this.txtValColumn = new System.Windows.Forms.TextBox();
      this.lblWhere = new System.Windows.Forms.Label();
      this.txtWhere = new System.Windows.Forms.TextBox();
      this.btnSave = new System.Windows.Forms.Button();
      this.btnClear = new System.Windows.Forms.Button();
      this.dgvList = new System.Windows.Forms.DataGridView();
      this.ColKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColContext = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColChange = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColChangeAfter = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColAfterContext = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.rbTypeNomal = new System.Windows.Forms.RadioButton();
      this.rbTypeFile = new System.Windows.Forms.RadioButton();
      this.gbType = new System.Windows.Forms.GroupBox();
      this.lblExplane1 = new System.Windows.Forms.Label();
      this.lblExplane2 = new System.Windows.Forms.Label();
      this.lblDB = new System.Windows.Forms.Label();
      this.txtDBConn = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
      this.gbType.SuspendLayout();
      this.SuspendLayout();
      // 
      // lblAfterUrl
      // 
      this.lblAfterUrl.AutoSize = true;
      this.lblAfterUrl.Location = new System.Drawing.Point(8, 287);
      this.lblAfterUrl.Name = "lblAfterUrl";
      this.lblAfterUrl.Size = new System.Drawing.Size(62, 20);
      this.lblAfterUrl.TabIndex = 2;
      this.lblAfterUrl.Text = "AfterUrl";
      // 
      // txtAfter
      // 
      this.txtAfter.Location = new System.Drawing.Point(8, 310);
      this.txtAfter.Name = "txtAfter";
      this.txtAfter.Size = new System.Drawing.Size(922, 27);
      this.txtAfter.TabIndex = 3;
      // 
      // btnView
      // 
      this.btnView.Location = new System.Drawing.Point(836, 95);
      this.btnView.Name = "btnView";
      this.btnView.Size = new System.Drawing.Size(94, 29);
      this.btnView.TabIndex = 4;
      this.btnView.Text = "View";
      this.btnView.UseVisualStyleBackColor = true;
      this.btnView.Click += new System.EventHandler(this.btnView_Click);
      // 
      // btnChange
      // 
      this.btnChange.Location = new System.Drawing.Point(836, 131);
      this.btnChange.Name = "btnChange";
      this.btnChange.Size = new System.Drawing.Size(94, 29);
      this.btnChange.TabIndex = 5;
      this.btnChange.Text = "Change";
      this.btnChange.UseVisualStyleBackColor = true;
      this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
      // 
      // txtRegex
      // 
      this.txtRegex.Location = new System.Drawing.Point(7, 257);
      this.txtRegex.Name = "txtRegex";
      this.txtRegex.Size = new System.Drawing.Size(923, 27);
      this.txtRegex.TabIndex = 8;
      // 
      // lblRegex
      // 
      this.lblRegex.AutoSize = true;
      this.lblRegex.Location = new System.Drawing.Point(7, 229);
      this.lblRegex.Name = "lblRegex";
      this.lblRegex.Size = new System.Drawing.Size(50, 20);
      this.lblRegex.TabIndex = 9;
      this.lblRegex.Text = "Regex";
      // 
      // lblTable
      // 
      this.lblTable.AutoSize = true;
      this.lblTable.Location = new System.Drawing.Point(4, 134);
      this.lblTable.Name = "lblTable";
      this.lblTable.Size = new System.Drawing.Size(46, 20);
      this.lblTable.TabIndex = 10;
      this.lblTable.Text = "Table";
      // 
      // txtTable
      // 
      this.txtTable.Location = new System.Drawing.Point(63, 131);
      this.txtTable.Name = "txtTable";
      this.txtTable.Size = new System.Drawing.Size(174, 27);
      this.txtTable.TabIndex = 11;
      // 
      // lblKeyColumn
      // 
      this.lblKeyColumn.AutoSize = true;
      this.lblKeyColumn.Location = new System.Drawing.Point(243, 134);
      this.lblKeyColumn.Name = "lblKeyColumn";
      this.lblKeyColumn.Size = new System.Drawing.Size(87, 20);
      this.lblKeyColumn.TabIndex = 12;
      this.lblKeyColumn.Text = "KeyColumn";
      // 
      // txtKeyColumn
      // 
      this.txtKeyColumn.Location = new System.Drawing.Point(336, 131);
      this.txtKeyColumn.Name = "txtKeyColumn";
      this.txtKeyColumn.Size = new System.Drawing.Size(175, 27);
      this.txtKeyColumn.TabIndex = 13;
      // 
      // lblValColumn
      // 
      this.lblValColumn.AutoSize = true;
      this.lblValColumn.Location = new System.Drawing.Point(517, 134);
      this.lblValColumn.Name = "lblValColumn";
      this.lblValColumn.Size = new System.Drawing.Size(102, 20);
      this.lblValColumn.TabIndex = 14;
      this.lblValColumn.Text = "ValueColumn";
      // 
      // txtValColumn
      // 
      this.txtValColumn.Location = new System.Drawing.Point(634, 131);
      this.txtValColumn.Name = "txtValColumn";
      this.txtValColumn.Size = new System.Drawing.Size(196, 27);
      this.txtValColumn.TabIndex = 15;
      // 
      // lblWhere
      // 
      this.lblWhere.AutoSize = true;
      this.lblWhere.Location = new System.Drawing.Point(4, 171);
      this.lblWhere.Name = "lblWhere";
      this.lblWhere.Size = new System.Drawing.Size(53, 20);
      this.lblWhere.TabIndex = 16;
      this.lblWhere.Text = "Where";
      // 
      // txtWhere
      // 
      this.txtWhere.Location = new System.Drawing.Point(63, 168);
      this.txtWhere.Name = "txtWhere";
      this.txtWhere.Size = new System.Drawing.Size(767, 27);
      this.txtWhere.TabIndex = 17;
      // 
      // btnSave
      // 
      this.btnSave.Location = new System.Drawing.Point(836, 166);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(94, 29);
      this.btnSave.TabIndex = 18;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // btnClear
      // 
      this.btnClear.Location = new System.Drawing.Point(836, 201);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(94, 29);
      this.btnClear.TabIndex = 19;
      this.btnClear.Text = "Clear";
      this.btnClear.UseVisualStyleBackColor = true;
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // dgvList
      // 
      this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
      this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColKey,
            this.ColContext,
            this.ColChange,
            this.ColChangeAfter,
            this.ColAfterContext});
      this.dgvList.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.dgvList.Location = new System.Drawing.Point(0, 343);
      this.dgvList.Name = "dgvList";
      this.dgvList.RowHeadersWidth = 51;
      this.dgvList.RowTemplate.Height = 29;
      this.dgvList.Size = new System.Drawing.Size(942, 296);
      this.dgvList.TabIndex = 20;
      // 
      // ColKey
      // 
      this.ColKey.HeaderText = "Key";
      this.ColKey.MinimumWidth = 6;
      this.ColKey.Name = "ColKey";
      this.ColKey.ReadOnly = true;
      this.ColKey.Width = 62;
      // 
      // ColContext
      // 
      this.ColContext.HeaderText = "Context";
      this.ColContext.MinimumWidth = 6;
      this.ColContext.Name = "ColContext";
      this.ColContext.ReadOnly = true;
      this.ColContext.Width = 91;
      // 
      // ColChange
      // 
      this.ColChange.HeaderText = "ChangeContext";
      this.ColChange.MinimumWidth = 6;
      this.ColChange.Name = "ColChange";
      this.ColChange.ReadOnly = true;
      this.ColChange.Width = 144;
      // 
      // ColChangeAfter
      // 
      this.ColChangeAfter.HeaderText = "ChangeAfterContext";
      this.ColChangeAfter.MinimumWidth = 6;
      this.ColChangeAfter.Name = "ColChangeAfter";
      this.ColChangeAfter.ReadOnly = true;
      this.ColChangeAfter.Width = 177;
      // 
      // ColAfterContext
      // 
      this.ColAfterContext.HeaderText = "AfterContext";
      this.ColAfterContext.MinimumWidth = 6;
      this.ColAfterContext.Name = "ColAfterContext";
      this.ColAfterContext.Width = 124;
      // 
      // rbTypeNomal
      // 
      this.rbTypeNomal.AutoSize = true;
      this.rbTypeNomal.Location = new System.Drawing.Point(6, 26);
      this.rbTypeNomal.Name = "rbTypeNomal";
      this.rbTypeNomal.Size = new System.Drawing.Size(75, 24);
      this.rbTypeNomal.TabIndex = 23;
      this.rbTypeNomal.TabStop = true;
      this.rbTypeNomal.Text = "Nomal";
      this.rbTypeNomal.UseVisualStyleBackColor = true;
      this.rbTypeNomal.CheckedChanged += new System.EventHandler(this.rbTypeNomal_CheckedChanged);
      // 
      // rbTypeFile
      // 
      this.rbTypeFile.AutoSize = true;
      this.rbTypeFile.Location = new System.Drawing.Point(87, 26);
      this.rbTypeFile.Name = "rbTypeFile";
      this.rbTypeFile.Size = new System.Drawing.Size(131, 24);
      this.rbTypeFile.TabIndex = 24;
      this.rbTypeFile.TabStop = true;
      this.rbTypeFile.Text = "LeaveFileName";
      this.rbTypeFile.UseVisualStyleBackColor = true;
      this.rbTypeFile.CheckedChanged += new System.EventHandler(this.rbTypeFile_CheckedChanged);
      // 
      // gbType
      // 
      this.gbType.Controls.Add(this.rbTypeNomal);
      this.gbType.Controls.Add(this.rbTypeFile);
      this.gbType.Location = new System.Drawing.Point(8, 12);
      this.gbType.Name = "gbType";
      this.gbType.Size = new System.Drawing.Size(250, 57);
      this.gbType.TabIndex = 25;
      this.gbType.TabStop = false;
      this.gbType.Text = "Type";
      // 
      // lblExplane1
      // 
      this.lblExplane1.AutoSize = true;
      this.lblExplane1.Location = new System.Drawing.Point(265, 23);
      this.lblExplane1.Name = "lblExplane1";
      this.lblExplane1.Size = new System.Drawing.Size(268, 20);
      this.lblExplane1.TabIndex = 26;
      this.lblExplane1.Text = "Type Nomal is Nomal Regex Change. ";
      // 
      // lblExplane2
      // 
      this.lblExplane2.AutoSize = true;
      this.lblExplane2.Location = new System.Drawing.Point(265, 45);
      this.lblExplane2.MaximumSize = new System.Drawing.Size(600, 0);
      this.lblExplane2.Name = "lblExplane2";
      this.lblExplane2.Size = new System.Drawing.Size(591, 40);
      this.lblExplane2.TabIndex = 27;
      this.lblExplane2.Text = "Type LeaveFileName is Among the contents found by regular expression, \"/\" is sepa" +
    "rated to leave the last part, and the other part is changed to a change characte" +
    "r.";
      // 
      // lblDB
      // 
      this.lblDB.AutoSize = true;
      this.lblDB.Location = new System.Drawing.Point(4, 98);
      this.lblDB.Name = "lblDB";
      this.lblDB.Size = new System.Drawing.Size(113, 20);
      this.lblDB.TabIndex = 28;
      this.lblDB.Text = "DB Connection";
      // 
      // txtDBConn
      // 
      this.txtDBConn.Location = new System.Drawing.Point(131, 95);
      this.txtDBConn.Name = "txtDBConn";
      this.txtDBConn.Size = new System.Drawing.Size(699, 27);
      this.txtDBConn.TabIndex = 29;
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(942, 639);
      this.Controls.Add(this.txtDBConn);
      this.Controls.Add(this.lblDB);
      this.Controls.Add(this.lblExplane2);
      this.Controls.Add(this.lblExplane1);
      this.Controls.Add(this.gbType);
      this.Controls.Add(this.dgvList);
      this.Controls.Add(this.btnClear);
      this.Controls.Add(this.btnSave);
      this.Controls.Add(this.txtWhere);
      this.Controls.Add(this.lblWhere);
      this.Controls.Add(this.txtValColumn);
      this.Controls.Add(this.lblValColumn);
      this.Controls.Add(this.txtKeyColumn);
      this.Controls.Add(this.lblKeyColumn);
      this.Controls.Add(this.txtTable);
      this.Controls.Add(this.lblTable);
      this.Controls.Add(this.lblRegex);
      this.Controls.Add(this.txtRegex);
      this.Controls.Add(this.btnChange);
      this.Controls.Add(this.btnView);
      this.Controls.Add(this.txtAfter);
      this.Controls.Add(this.lblAfterUrl);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Main";
      this.Text = "Search Regex";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
      ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
      this.gbType.ResumeLayout(false);
      this.gbType.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label lblAfterUrl;
    private System.Windows.Forms.TextBox txtAfter;
    private System.Windows.Forms.Button btnView;
    private System.Windows.Forms.Button btnChange;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label lblRegex;
    private System.Windows.Forms.TextBox txtRegex;
    private System.Windows.Forms.Label lblTable;
    private System.Windows.Forms.TextBox txtTable;
    private System.Windows.Forms.Label lblKeyColumn;
    private System.Windows.Forms.TextBox txtKeyColumn;
    private System.Windows.Forms.Label lblValColumn;
    private System.Windows.Forms.TextBox txtValColumn;
    private System.Windows.Forms.Label lblWhere;
    private System.Windows.Forms.TextBox txtWhere;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.DataGridView dgvList;
    private System.Windows.Forms.RadioButton rbTypeNomal;
    private System.Windows.Forms.RadioButton rbTypeFile;
    private System.Windows.Forms.GroupBox gbType;
    private System.Windows.Forms.Label lblExplane1;
    private System.Windows.Forms.Label lblExplane2;
    private System.Windows.Forms.DataGridViewTextBoxColumn ColKey;
    private System.Windows.Forms.DataGridViewTextBoxColumn ColContext;
    private System.Windows.Forms.DataGridViewTextBoxColumn ColChange;
    private System.Windows.Forms.DataGridViewTextBoxColumn ColChangeAfter;
    private System.Windows.Forms.DataGridViewTextBoxColumn ColAfterContext;
    private System.Windows.Forms.Label lblDB;
    private System.Windows.Forms.TextBox txtDBConn;
  }
}

