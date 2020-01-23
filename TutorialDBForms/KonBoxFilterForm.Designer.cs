namespace TutorialDBForms
{
    partial class KonBoxFilterForm
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
            this.mssDBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mssDBDataSet = new TutorialDBForms.mssDBDataSet();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dokboxBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dokboxTableAdapter = new TutorialDBForms.mssDBDataSetTableAdapters.dokboxTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ziarboxBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ziarboxTableAdapter = new TutorialDBForms.mssDBDataSetTableAdapters.ziarboxTableAdapter();
            this.kierboxTableAdapter = new TutorialDBForms.mssDBDataSetTableAdapters.kierboxTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.mssDBDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mssDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dokboxBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ziarboxBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // mssDBDataSetBindingSource
            // 
            this.mssDBDataSetBindingSource.DataSource = this.mssDBDataSet;
            this.mssDBDataSetBindingSource.Position = 0;
            // 
            // mssDBDataSet
            // 
            this.mssDBDataSet.DataSetName = "mssDBDataSet";
            this.mssDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(110, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(303, 20);
            this.textBox1.TabIndex = 0;
            // 
            // dokboxBindingSource
            // 
            this.dokboxBindingSource.DataMember = "dokbox";
            this.dokboxBindingSource.DataSource = this.mssDBDataSet;
            // 
            // dokboxTableAdapter
            // 
            this.dokboxTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kontrahent";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(1, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(421, 34);
            this.panel1.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(135, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Wstecz";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Filtruj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "kierbox";
            this.bindingSource1.DataSource = this.mssDBDataSet;
            // 
            // ziarboxBindingSource
            // 
            this.ziarboxBindingSource.DataMember = "ziarbox";
            this.ziarboxBindingSource.DataSource = this.mssDBDataSetBindingSource;
            // 
            // ziarboxTableAdapter
            // 
            this.ziarboxTableAdapter.ClearBeforeFill = true;
            // 
            // kierboxTableAdapter
            // 
            this.kierboxTableAdapter.ClearBeforeFill = true;
            // 
            // KonBoxFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 78);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "KonBoxFilterForm";
            this.Text = "Filtr kontrahentów";
            ((System.ComponentModel.ISupportInitialize)(this.mssDBDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mssDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dokboxBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ziarboxBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource mssDBDataSetBindingSource;
        private mssDBDataSet mssDBDataSet;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.BindingSource dokboxBindingSource;
        private mssDBDataSetTableAdapters.dokboxTableAdapter dokboxTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource ziarboxBindingSource;
        private mssDBDataSetTableAdapters.ziarboxTableAdapter ziarboxTableAdapter;
        private mssDBDataSetTableAdapters.kierboxTableAdapter kierboxTableAdapter;
    }
}