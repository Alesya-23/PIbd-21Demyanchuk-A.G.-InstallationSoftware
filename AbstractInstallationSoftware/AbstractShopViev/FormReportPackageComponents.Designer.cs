namespace AbstractInstallationSoftView
{
    partial class FormReportPackageComponents
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
            this.saveExelButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Package = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.component = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // saveExelButton
            // 
            this.saveExelButton.Location = new System.Drawing.Point(22, 13);
            this.saveExelButton.Name = "saveExelButton";
            this.saveExelButton.Size = new System.Drawing.Size(211, 33);
            this.saveExelButton.TabIndex = 0;
            this.saveExelButton.Text = "Сохранить в Excel";
            this.saveExelButton.UseVisualStyleBackColor = true;
            this.saveExelButton.Click += new System.EventHandler(this.ButtonSaveToExcel_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Package,
            this.component,
            this.count});
            this.dataGridView.Location = new System.Drawing.Point(2, 66);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.Size = new System.Drawing.Size(567, 385);
            this.dataGridView.TabIndex = 1;
            // 
            // Package
            // 
            this.Package.HeaderText = "Пакет";
            this.Package.MinimumWidth = 8;
            this.Package.Name = "Package";
            this.Package.Width = 150;
            // 
            // component
            // 
            this.component.HeaderText = "Компонент";
            this.component.MinimumWidth = 8;
            this.component.Name = "component";
            this.component.Width = 150;
            // 
            // count
            // 
            this.count.HeaderText = "Количество";
            this.count.MinimumWidth = 8;
            this.count.Name = "count";
            this.count.Width = 150;
            // 
            // FormReportPackageComponents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 473);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.saveExelButton);
            this.Name = "FormReportPackageComponents";
            this.Text = "Отчет изделия по компонентам";
            this.Load += new System.EventHandler(this.FormReportPackageComponents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button saveExelButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Package;
        private System.Windows.Forms.DataGridViewTextBoxColumn component;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
    }
}