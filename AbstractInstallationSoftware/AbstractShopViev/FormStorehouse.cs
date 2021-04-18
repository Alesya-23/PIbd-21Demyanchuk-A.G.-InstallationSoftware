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
    public partial class FormStorehouse : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly StorehouseLogic logic;
        private int? id;
        private Dictionary<int, (string, int)> storehouseComponents;
        public FormStorehouse(StorehouseLogic service)
        {
            InitializeComponent();
            this.logic = service;
        }
        private void FormStore_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    StorehouseViewModel view = logic.Read(new StorehouseBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxNameStore.Text = view.StoreHouseName;
                        textBoxResponce.Text = view.FullNameResponsiblePerson.ToString();
                        dateTimePickerDateCreate.Value = view.DateGreate;
                        storehouseComponents = view.StorehouseComponents ?? new Dictionary<int, (string, int)>();
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                storehouseComponents = new Dictionary<int, (string, int)>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (storehouseComponents != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var pc in storehouseComponents)
                    {
                        dataGridView.Rows.Add(new object[] { pc.Value.Item1, pc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNameStore.Text))
            {
                MessageBox.Show("Заполните название склада", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxResponce.Text))
            {
                MessageBox.Show("Заполните ФИО ответственного", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new StorehouseBindingModel
                {
                    Id = id,
                    StoreHouseName = textBoxNameStore.Text,
                    FullNameResponsiblePerson = textBoxResponce.Text,
                    StorehouseComponents = storehouseComponents ?? new Dictionary<int, (string, int)>(),
                    DateCreate = dateTimePickerDateCreate.Value
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
