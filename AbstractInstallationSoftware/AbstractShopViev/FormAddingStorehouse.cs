using AbstractInstallationSoftBusinessLogic.BindingModels;
using AbstractInstallationSoftBusinessLogic.BusinessLogics;
using AbstractInstallationSoftBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace AbstractInstallationSoftView
{
    public partial class FormAddingStorehouse : Form
    {
        [Unity.Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ComponentLogic _logicC;
        private readonly StorehouseLogic _logicS;
        public int StoreId { get { return Convert.ToInt32(comboBoxStore.SelectedValue); } set { comboBoxStore.SelectedValue = value; } }
        public int ComponentId { get { return Convert.ToInt32(comboBoxComponent.SelectedValue); } set { comboBoxComponent.SelectedValue = value; } }
        public int Count { get { return Convert.ToInt32(textBoxCount.Text); } set { textBoxCount.Text = value.ToString(); } }

        public FormAddingStorehouse(ComponentLogic logicC, StorehouseLogic logicS)
        {
            InitializeComponent();
            _logicC = logicC;
            _logicS = logicS;
        }
        private void FormAddStorehouse_Load(object sender, EventArgs e)
        {
            try
            {
                List<StorehouseViewModel> listStore = _logicS.Read(null);
                if (listStore != null)
                {
                    comboBoxStore.DisplayMember = "StoreHouseName";
                    comboBoxStore.ValueMember = "Id";
                    comboBoxStore.DataSource = listStore;
                    comboBoxStore.SelectedItem = null;
                }
                List<ComponentViewModel> listComponent = _logicC.Read(null);
                if (listComponent != null)
                {
                    comboBoxComponent.DisplayMember = "ComponentName";
                    comboBoxComponent.ValueMember = "Id";
                    comboBoxComponent.DataSource = listComponent;
                    comboBoxComponent.SelectedItem = null;
                }
                else
                {
                    throw new Exception("Не удалось загрузить список изделий");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxComponent.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (comboBoxStore.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                int countComponent = Convert.ToInt32(textBoxCount.Text);
                if (countComponent < 1)
                {
                    throw new Exception("Нельзя пополнить склад отприцательным количеством");
                }
                _logicS.FillStore(new StorehouseBindingModel
                {
                    Id = Convert.ToInt32(comboBoxStore.SelectedValue)
                }, Convert.ToInt32(comboBoxComponent.SelectedValue), Convert.ToInt32(textBoxCount.Text));
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
