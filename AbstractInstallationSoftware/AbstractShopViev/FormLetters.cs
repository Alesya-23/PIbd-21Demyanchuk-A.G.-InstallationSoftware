using AbstractInstallationSoftBusinessLogic.BusinessLogics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbstractInstallationSoftView
{
    public partial class FormLetters : Form
    {
        private readonly MailLogic logic;
        public FormLetters(MailLogic mailLogic)
        {
            this.logic = mailLogic;
            InitializeComponent();
        }

        private void FormLetter_Load(object sender, EventArgs e)
        {
            var list = logic.Read(null);
            if (list != null)
            {
                dataGridView.DataSource = list;
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    }
}
