using AbstractInstallationSoftBusinessLogic.BindingModels;
using AbstractInstallationSoftBusinessLogic.BusinessLogics;
using System;
using System.Windows.Forms;
using Unity;

namespace AbstractInstallationSoftView
{
    public partial class FormClient : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly ClientLogic logic;

        private int? id;
        public FormClient(ClientLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormClient_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = logic.Read(new ClientBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxFullName.Text = view.ClientFullName;
                        textBoxEmail.Text = view.Email;
                        textBoxPassword.Text = view.Password;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFullName.Text) || string.IsNullOrEmpty(textBoxEmail.Text) ||
                string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Не все поля заполнены. Заполните их", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new ClientBindingModel
                {
                    Id = id,
                    ClientFullName = textBoxFullName.Text,
                    Email = textBoxEmail.Text,
                    Password = textBoxPassword.Text,
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}