using Practic_1.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Practic_1
{

    public partial class Page1 : Page
    {
        
        CarsTableAdapter Cars = new CarsTableAdapter();
        
        public Page1()
        {
            InitializeComponent();
            CarsGrid.ItemsSource = Cars.GetData();
            CarsComboBox.ItemsSource = Cars.GetData();
            CarsComboBox.DisplayMemberPath = "Name";
            CarsComboBox.SelectedValuePath = "Id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            short Price = Convert.ToInt16(CarsPrice.Text);
            Cars.InsertQuery(CarsName.Text,Price,CarsColor.Text);
            CarsGrid.ItemsSource = Cars.GetData();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int id = (int)(CarsGrid.SelectedItem as DataRowView).Row[0];
            Cars.DeleteQuery(id);
            CarsGrid.ItemsSource = Cars.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (CarsGrid.SelectedItem != null)
            {
                int id = (int)(CarsGrid.SelectedItem as DataRowView).Row[0];
                Cars.UpdateQuery(CarsName.Text, Convert.ToInt32(CarsPrice.Text), CarsColor.Text, id);
                CarsGrid.ItemsSource = Cars.GetData();
            }
        }

        private void CarsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          if (CarsGrid.SelectedItem != null)
            {
               var item = CarsGrid.SelectedItem as DataRowView;
               CarsName.Text = (string)item.Row[1];
               CarsPrice.Text = Convert.ToString(item.Row[2]);
               CarsColor.Text = (string)item.Row[3];
            }
        }
    }
}
