using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using Morozova_BindingNavigator.ADO_.NET_EMD;


namespace Morozova_BindingNavigator
{
    public partial class Form1 : Form
    {
        ModelEF model1 = new ModelEF();

        private void StartLoadData()
        {
            model1.Users.Load();
            role_NameComboBox.DataSource = model1.Roles.ToList();
            usersBindingSource.DataSource = model1.Users.Local.ToBindingList();
        }
        private void SaveData()
        {
            try
            {
                Validate();
                usersBindingSource.EndEdit();
                usersBindingSource.ResetBindings(true);
                model1.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                StartLoadData();
            }
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            role_NameComboBox.SelectedIndex = 0;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void usersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartLoadData();
        }
    }
}
