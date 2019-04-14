using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace pdB42Test2_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            pdB42Test2_2.dsTest2Part2 dsTest2Part2 = ((pdB42Test2_2.dsTest2Part2)(this.FindResource("dsTest2Part2")));
            // Load data into the table HVK_OWNER. You can modify this code as needed.
            pdB42Test2_2.dsTest2Part2TableAdapters.HVK_OWNERTableAdapter dsTest2Part2HVK_OWNERTableAdapter = new pdB42Test2_2.dsTest2Part2TableAdapters.HVK_OWNERTableAdapter();
            dsTest2Part2HVK_OWNERTableAdapter.Fill(dsTest2Part2.HVK_OWNER);
            System.Windows.Data.CollectionViewSource hVK_OWNERViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hVK_OWNERViewSource")));
            hVK_OWNERViewSource.View.MoveCurrentToFirst();
            // Load data into the table HVK_PET. You can modify this code as needed.
            pdB42Test2_2.dsTest2Part2TableAdapters.HVK_PETTableAdapter dsTest2Part2HVK_PETTableAdapter = new pdB42Test2_2.dsTest2Part2TableAdapters.HVK_PETTableAdapter();
            dsTest2Part2HVK_PETTableAdapter.Fill(dsTest2Part2.HVK_PET);
            System.Windows.Data.CollectionViewSource hVK_PETViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hVK_PETViewSource")));
            hVK_PETViewSource.View.MoveCurrentToFirst();

            // Load data into the table HVK_PET_VACCINATION. You can modify this code as needed.
            pdB42Test2_2.dsTest2Part2TableAdapters.HVK_PET_VACCINATIONTableAdapter dsTest2Part2HVK_PET_VACCINATIONTableAdapter = new pdB42Test2_2.dsTest2Part2TableAdapters.HVK_PET_VACCINATIONTableAdapter();
            dsTest2Part2HVK_PET_VACCINATIONTableAdapter.Fill(dsTest2Part2.HVK_PET_VACCINATION);
            System.Windows.Data.CollectionViewSource hVK_PET_VACCINATIONViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hVK_PET_VACCINATIONViewSource")));
            hVK_PET_VACCINATIONViewSource.View.MoveCurrentToFirst();
        }

        private void hVK_OWNERDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            hVK_PETDataGrid.Visibility = Visibility.Visible;

            DataGrid dg = sender as DataGrid;
            DataRowView row = (DataRowView)dg.SelectedItems[0];
            int numberSent = (int)row["OWNER_NUMBER"];

            dsTest2Part2.HVK_PETDataTable petTable = new dsTest2Part2.HVK_PETDataTable();
            dsTest2Part2TableAdapters.HVK_PETTableAdapter adapter = new dsTest2Part2TableAdapters.HVK_PETTableAdapter();
            adapter.FillByOwnerNumber(petTable, numberSent);
            CollectionViewSource petVS = (CollectionViewSource)(this.FindResource("hVK_PETViewSource"));
            petVS.View.MoveCurrentToFirst();
        }

        private void hVK_PETDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            hVK_PET_VACCINATIONDataGrid.Visibility = Visibility.Visible;
            hVK_PETDataGrid1.Visibility = Visibility.Visible;
            
            DataGrid dg = sender as DataGrid;
            DataRowView row = (DataRowView)dg.SelectedItems[0];
            int numberSent = (int)row["PET_NUMBER"];

            dsTest2Part2.HVK_PET_VACCINATIONDataTable petVaccTable = new dsTest2Part2.HVK_PET_VACCINATIONDataTable();
            dsTest2Part2TableAdapters.HVK_PET_VACCINATIONTableAdapter adapter = new dsTest2Part2TableAdapters.HVK_PET_VACCINATIONTableAdapter();
            adapter.FillByPetNumber(petVaccTable, numberSent);
            hVK_PETDataGrid.ItemsSource = petVaccTable;//.DefaultView;

            dsTest2Part2.HVK_PETDataTable petDetails = new dsTest2Part2.HVK_PETDataTable();
            dsTest2Part2TableAdapters.HVK_PETTableAdapter adapter2 = new dsTest2Part2TableAdapters.HVK_PETTableAdapter();
            adapter2.FillByNotPic(petDetails, numberSent);
            CollectionViewSource petVaccVS = (CollectionViewSource)this.FindResource("hVK_PETViewSource");
            petVaccVS.View.MoveCurrentToFirst();
            //hVK_PETDataGrid1.ItemsSource = petDetails;//.DefaultView;
        }
    }

    public class PetSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString() == "L")
                return "Large";
            else if (value.ToString() == "M")
                return "Medium";
            else if (value.ToString() == "S")
                return "Small";
            else
                return "Unknow";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class PetSexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString() == "M")
                return "Male";
            else if (value.ToString() == "F")
                return "Female";
            else
                return "Unknown";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
