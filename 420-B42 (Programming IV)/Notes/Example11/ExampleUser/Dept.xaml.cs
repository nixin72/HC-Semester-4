using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ExampleBLL;
using System.Data;

namespace ExampleUser
{
    /// <summary>
    /// Interaction logic for Dept.xaml
    /// </summary>
    public partial class Dept : Window
    {
        public Dept()
        {
            InitializeComponent();
            BindDeptBox(comboBox);
        }

        public void BindDeptBox(ComboBox cmbx)
        {
            Departement dept = new Departement();
            DataSet listDs = dept.fillBox();
            comboBox.ItemsSource = listDs.Tables[0].DefaultView;
            comboBox.DisplayMemberPath = listDs.Tables[0].Columns["DeptName"].ToString();
            comboBox.SelectedValuePath = listDs.Tables[0].Columns["DeptId"].ToString();
        }
    }
}
