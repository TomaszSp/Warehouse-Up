namespace TutorialDBForms
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.mssDBDataSet = new TutorialDBForms.mssDBDataSet();
            this.dokboxTableAdapter1 = new TutorialDBForms.mssDBDataSetTableAdapters.dokboxTableAdapter();
            this.xkeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrdokDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mssDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xkeyDataGridViewTextBoxColumn,
            this.nrdokDataGridViewTextBoxColumn,
            this.typDataGridViewTextBoxColumn});
            this.dataGridView1.DataMember = "dokbox";
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.Location = new System.Drawing.Point(2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(416, 436);
            this.dataGridView1.TabIndex = 0;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.mssDBDataSet;
            this.bindingSource1.Position = 0;
            // 
            // mssDBDataSet
            // 
            this.mssDBDataSet.DataSetName = "mssDBDataSet";
            this.mssDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dokboxTableAdapter1
            // 
            this.dokboxTableAdapter1.ClearBeforeFill = true;
            // 
            // xkeyDataGridViewTextBoxColumn
            // 
            this.xkeyDataGridViewTextBoxColumn.DataPropertyName = "xkey";
            this.xkeyDataGridViewTextBoxColumn.HeaderText = "xkey";
            this.xkeyDataGridViewTextBoxColumn.Name = "xkeyDataGridViewTextBoxColumn";
            // 
            // nrdokDataGridViewTextBoxColumn
            // 
            this.nrdokDataGridViewTextBoxColumn.DataPropertyName = "nrdok";
            this.nrdokDataGridViewTextBoxColumn.HeaderText = "nrdok";
            this.nrdokDataGridViewTextBoxColumn.Name = "nrdokDataGridViewTextBoxColumn";
            // 
            // typDataGridViewTextBoxColumn
            // 
            this.typDataGridViewTextBoxColumn.DataPropertyName = "typ";
            this.typDataGridViewTextBoxColumn.HeaderText = "typ";
            this.typDataGridViewTextBoxColumn.Name = "typDataGridViewTextBoxColumn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mssDBDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private mssDBDataSet mssDBDataSet;
        private mssDBDataSetTableAdapters.dokboxTableAdapter dokboxTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn xkeyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrdokDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typDataGridViewTextBoxColumn;
    }
}

