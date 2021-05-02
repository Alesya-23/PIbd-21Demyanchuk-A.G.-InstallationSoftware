
namespace AbstractInstallationSoftView
{
    partial class FormImplementer
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

        private void InitializeComponent()
        {
            this.labelFIO = new System.Windows.Forms.Label();
            this.labelTimeToOrder = new System.Windows.Forms.Label();
            this.labelTimeToRest = new System.Windows.Forms.Label();
            this.textBoxFIO = new System.Windows.Forms.TextBox();
            this.textBoxTimeToWork = new System.Windows.Forms.TextBox();
            this.textBoxTimeToRest = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelFIO
            // 
            this.labelFIO.AutoSize = true;
            this.labelFIO.Location = new System.Drawing.Point(28, 42);
            this.labelFIO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFIO.Name = "labelFIO";
            this.labelFIO.Size = new System.Drawing.Size(157, 20);
            this.labelFIO.TabIndex = 0;
            this.labelFIO.Text = "ФИО Исполнителя:";
            // 
            // labelTimeToOrder
            // 
            this.labelTimeToOrder.AutoSize = true;
            this.labelTimeToOrder.Location = new System.Drawing.Point(52, 114);
            this.labelTimeToOrder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTimeToOrder.Name = "labelTimeToOrder";
            this.labelTimeToOrder.Size = new System.Drawing.Size(130, 20);
            this.labelTimeToOrder.TabIndex = 1;
            this.labelTimeToOrder.Text = "Время на заказ:";
            // 
            // labelTimeToRest
            // 
            this.labelTimeToRest.AutoSize = true;
            this.labelTimeToRest.Location = new System.Drawing.Point(32, 178);
            this.labelTimeToRest.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTimeToRest.Name = "labelTimeToRest";
            this.labelTimeToRest.Size = new System.Drawing.Size(153, 20);
            this.labelTimeToRest.TabIndex = 2;
            this.labelTimeToRest.Text = "Время на перерыв:";
            // 
            // textBoxFIO
            // 
            this.textBoxFIO.Location = new System.Drawing.Point(198, 37);
            this.textBoxFIO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxFIO.Name = "textBoxFIO";
            this.textBoxFIO.Size = new System.Drawing.Size(212, 26);
            this.textBoxFIO.TabIndex = 3;
            // 
            // textBoxTimeToWork
            // 
            this.textBoxTimeToWork.Location = new System.Drawing.Point(198, 109);
            this.textBoxTimeToWork.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxTimeToWork.Name = "textBoxTimeToWork";
            this.textBoxTimeToWork.Size = new System.Drawing.Size(212, 26);
            this.textBoxTimeToWork.TabIndex = 4;
            // 
            // textBoxTimeToRest
            // 
            this.textBoxTimeToRest.Location = new System.Drawing.Point(198, 178);
            this.textBoxTimeToRest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxTimeToRest.Name = "textBoxTimeToRest";
            this.textBoxTimeToRest.Size = new System.Drawing.Size(212, 26);
            this.textBoxTimeToRest.TabIndex = 5;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(140, 242);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(112, 35);
            this.buttonSave.TabIndex = 19;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(300, 242);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 35);
            this.buttonCancel.TabIndex = 18;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // FormImplementer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 295);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxTimeToRest);
            this.Controls.Add(this.textBoxTimeToWork);
            this.Controls.Add(this.textBoxFIO);
            this.Controls.Add(this.labelTimeToRest);
            this.Controls.Add(this.labelTimeToOrder);
            this.Controls.Add(this.labelFIO);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormImplementer";
            this.Text = "Исполнитель";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label labelFIO;
        private System.Windows.Forms.Label labelTimeToOrder;
        private System.Windows.Forms.Label labelTimeToRest;
        private System.Windows.Forms.TextBox textBoxFIO;
        private System.Windows.Forms.TextBox textBoxTimeToWork;
        private System.Windows.Forms.TextBox textBoxTimeToRest;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}