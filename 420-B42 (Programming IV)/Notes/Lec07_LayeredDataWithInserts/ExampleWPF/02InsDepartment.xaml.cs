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
using System.Data;
using ExampleBLL;

namespace ExampleWPF
{
    /// <summary>
    /// Interaction logic for _02InsDepartment.xaml
    /// </summary>
    public partial class _02InsDepartment : Window
    {
        public _02InsDepartment()
        {
            InitializeComponent();
            BindDeptBox(cbxDepartments);
        }

        private void BindDeptBox(ComboBox cbxName)
        {
            Department dept = new Department();
            DataSet listDS = dept.fillBox();
            cbxName.ItemsSource = listDS.Tables[0].DefaultView;
            cbxName.DisplayMemberPath = listDS.Tables[0].Columns["DeptName"].ToString();
            cbxName.SelectedValuePath = listDS.Tables[0].Columns["DeptID"].ToString();
        }


        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Department dept = new Department(txtDeptName.Text, txtLoc.Text);
            dept.insertDepartment();
            BindDeptBox(cbxDepartments);
            Console.Write("Done");
        }
    }
}
