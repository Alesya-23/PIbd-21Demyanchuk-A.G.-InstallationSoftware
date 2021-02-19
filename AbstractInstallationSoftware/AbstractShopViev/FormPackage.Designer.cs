namespace AbstractInstallstionSoftView
{
    partial class FormPackage
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
            this.labelNamePackage = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.textBoxNamePackage = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.groupBoxComponents = new System.Windows.Forms.GroupBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonChange = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.NameComponent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountComponent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdComponent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSava = new System.Windows.Forms.Button();
            this.groupBoxComponents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNamePackage
            // 
            this.labelNamePackage.AutoSize = true;
            this.labelNamePackage.Location = new System.Drawing.Point(23, 13);
            this.labelNamePackage.Name = "labelNamePackage";
            this.labelNamePackage.Size = new System.Drawing.Size(83, 20);
            this.labelNamePackage.TabIndex = 0;
            this.labelNamePackage.Text = "Название";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(23, 47);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(48, 20);
            this.labelPrice.TabIndex = 1;
            this.labelPrice.Text = "Цена";
            // 
            // textBoxNamePackage
            // 
            this.textBoxNamePackage.Location = new System.Drawing.Point(128, 10);
            this.textBoxNamePackage.Name = "textBoxNamePackage";
            this.textBoxNamePackage.Size = new System.Drawing.Size(233, 26);
            this.textBoxNamePackage.TabIndex = 2;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(128, 47);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(100, 26);
            this.textBoxPrice.TabIndex = 3;
            // 
            // groupBoxComponents
            // 
            this.groupBoxComponents.Controls.Add(this.buttonUpdate);
            this.groupBoxComponents.Controls.Add(this.buttonDelete);
            this.groupBoxComponents.Controls.Add(this.buttonChange);
            this.groupBoxComponents.Controls.Add(this.buttonAdd);
            this.groupBoxComponents.Controls.Add(this.dataGridView);
            this.groupBoxComponents.Location = new System.Drawing.Point(27, 102);
            this.groupBoxComponents.Name = "groupBoxComponents";
            this.groupBoxComponents.Size = new System.Drawing.Size(576, 232);
            this.groupBoxComponents.TabIndex = 4;
            this.groupBoxComponents.TabStop = false;
            this.groupBoxComponents.Text = "Компоненты";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(443, 183);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(106, 33);
            this.buttonUpdate.TabIndex = 4;
            this.buttonUpdate.Text = "Обновить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.ButtonUpd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(443, 132);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(106, 33);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDel_Click);
            // 
            // buttonChange
            // 
            this.buttonChange.Location = new System.Drawing.Point(443, 80);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(106, 33);
            this.buttonChange.TabIndex = 2;
            this.buttonChange.Text = "Изменить";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.ButtonRef_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(443, 25);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(106, 33);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameComponent,
            this.CountComponent,
            this.IdComponent});
            this.dataGridView.Location = new System.Drawing.Point(7, 44);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.Size = new System.Drawing.Size(365, 182);
            this.dataGridView.TabIndex = 0;
            // 
            // NameComponent
            // 
            this.NameComponent.HeaderText = "Название";
            this.NameComponent.MinimumWidth = 8;
            this.NameComponent.Name = "NameComponent";
            this.NameComponent.Width = 150;
            // 
            // CountComponent
            // 
            this.CountComponent.HeaderText = "Количество";
            this.CountComponent.MinimumWidth = 8;
            this.CountComponent.Name = "CountComponent";
            this.CountComponent.Width = 150;
            // 
            // IdComponent
            // 
            this.IdComponent.HeaderText = "ID";
            this.IdComponent.MinimumWidth = 8;
            this.IdComponent.Name = "IdComponent";
            this.IdComponent.Visible = false;
            this.IdComponent.Width = 150;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(405, 369);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(106, 33);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonSava
            // 
            this.buttonSava.Location = new System.Drawing.Point(255, 369);
            this.buttonSava.Name = "buttonSava";
            this.buttonSava.Size = new System.Drawing.Size(106, 33);
            this.buttonSava.TabIndex = 6;
            this.buttonSava.Text = "Сохранить";
            this.buttonSava.UseVisualStyleBackColor = true;
            this.buttonSava.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // FormPackage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 442);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSava);
            this.Controls.Add(this.groupBoxComponents);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.textBoxNamePackage);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelNamePackage);
            this.Name = "FormPackage";
            this.Text = "Изделие";
            this.Load += new System.EventHandler(this.FormPackage_Load);
            this.Click += new System.EventHandler(this.FormPackage_Load);
            this.groupBoxComponents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNamePackage;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.TextBox textBoxNamePackage;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.GroupBox groupBoxComponents;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameComponent;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountComponent;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdComponent;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSava;
    }
}