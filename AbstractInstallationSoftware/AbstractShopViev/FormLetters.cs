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
            try
            {
                Program.ConfigGrid(logic.Read(null), dataGridView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}