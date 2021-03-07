namespace AbstractInstallationSoftView
{
    partial class FormStorehouse
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
            this.groupBoxComponents = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.textBoxResponce = new System.Windows.Forms.TextBox();
            this.textBoxNameStore = new System.Windows.Forms.TextBox();
            this.labelResponce = new System.Windows.Forms.Label();
            this.labelNameStore = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSava = new System.Windows.Forms.Button();
            this.dateTimePickerDateCreate = new System.Windows.Forms.DateTimePicker();
            this.labelDateCreat = new System.Windows.Forms.Label();
            this.Component = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxComponents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxComponents
            // 
            this.groupBoxComponents.Controls.Add(this.dataGridView);
            this.groupBoxComponents.Location = new System.Drawing.Point(15, 96);
            this.groupBoxComponents.Name = "groupBoxComponents";
            this.groupBoxComponents.Size = new System.Drawing.Size(523, 232);
            this.groupBoxComponents.TabIndex = 11;
            this.groupBoxComponents.TabStop = false;
            this.groupBoxComponents.Text = "Компоненты";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Component,
            this.Count});
            this.dataGridView.Location = new System.Drawing.Point(7, 44);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.Size = new System.Drawing.Size(387, 182);
            this.dataGridView.TabIndex = 0;
            // 
            // textBoxResponce
            // 
            this.textBoxResponce.Location = new System.Drawing.Point(147, 38);
            this.textBoxResponce.Name = "textBoxResponce";
            this.textBoxResponce.Size = new System.Drawing.Size(100, 26);
            this.textBoxResponce.TabIndex = 10;
            // 
            // textBoxNameStore
            // 
            this.textBoxNameStore.Location = new System.Drawing.Point(147, 4);
            this.textBoxNameStore.Name = "textBoxNameStore";
            this.textBoxNameStore.Size = new System.Drawing.Size(233, 26);
            this.textBoxNameStore.TabIndex = 9;
            // 
            // labelResponce
            // 
            this.labelResponce.AutoSize = true;
            this.labelResponce.Location = new System.Drawing.Point(11, 41);
            this.labelResponce.Name = "labelResponce";
            this.labelResponce.Size = new System.Drawing.Size(121, 20);
            this.labelResponce.TabIndex = 8;
            this.labelResponce.Text = "Отвественный";
            // 
            // labelNameStore
            // 
            this.labelNameStore.AutoSize = true;
            this.labelNameStore.Location = new System.Drawing.Point(11, 7);
            this.labelNameStore.Name = "labelNameStore";
            this.labelNameStore.Size = new System.Drawing.Size(83, 20);
            this.labelNameStore.TabIndex = 7;
            this.labelNameStore.Text = "Название";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(393, 363);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(106, 33);
            this.buttonCancel.TabIndex = 12;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonSava
            // 
            this.buttonSava.Location = new System.Drawing.Point(243, 363);
            this.buttonSava.Name = "buttonSava";
            this.buttonSava.Size = new System.Drawing.Size(106, 33);
            this.buttonSava.TabIndex = 13;
            this.buttonSava.Text = "Сохранить";
            this.buttonSava.UseVisualStyleBackColor = true;
            this.buttonSava.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // dateTimePickerDateCreate
            // 
            this.dateTimePickerDateCreate.Location = new System.Drawing.Point(195, 73);
            this.dateTimePickerDateCreate.Name = "dateTimePickerDateCreate";
            this.dateTimePickerDateCreate.Size = new System.Drawing.Size(200, 26);
            this.dateTimePickerDateCreate.TabIndex = 19;
            // 
            // labelDateCreat
            // 
            this.labelDateCreat.AutoSize = true;
            this.labelDateCreat.Location = new System.Drawing.Point(13, 73);
            this.labelDateCreat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDateCreat.Name = "labelDateCreat";
            this.labelDateCreat.Size = new System.Drawing.Size(124, 20);
            this.labelDateCreat.TabIndex = 18;
            this.labelDateCreat.Text = "Дата создания";
            // 
            // Component
            // 
            this.Component.HeaderText = "Компонент";
            this.Component.MinimumWidth = 8;
            this.Component.Name = "Component";
            this.Component.Width = 150;
            // 
            // Count
            // 
            this.Count.HeaderText = "Количество";
            this.Count.MinimumWidth = 8;
            this.Count.Name = "Count";
            this.Count.Width = 150;
            // 
            // FormStorehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 425);
            this.Controls.Add(this.dateTimePickerDateCreate);
            this.Controls.Add(this.labelDateCreat);
            this.Controls.Add(this.groupBoxComponents);
            this.Controls.Add(this.textBoxResponce);
            this.Controls.Add(this.textBoxNameStore);
            this.Controls.Add(this.labelResponce);
            this.Controls.Add(this.labelNameStore);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSava);
            this.Name = "FormStorehouse";
            this.Text = "Создание склада";
            this.Load += new System.EventHandler(this.FormStore_Load);
            this.groupBoxComponents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxComponents;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox textBoxResponce;
        private System.Windows.Forms.TextBox textBoxNameStore;
        private System.Windows.Forms.Label labelResponce;
        private System.Windows.Forms.Label labelNameStore;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSava;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateCreate;
        private System.Windows.Forms.Label labelDateCreat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Component;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
    }
}