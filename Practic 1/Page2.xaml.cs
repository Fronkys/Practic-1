using MaterialDesignThemes.Wpf;
using Practic_1.DataSet1TableAdapters;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;


namespace Practic_1
{
    
    public partial class Page2 : Page
    {
        BuyersTableAdapter Buyers = new BuyersTableAdapter();
        public Page2()
        {
            InitializeComponent();
            BuyersGrid.ItemsSource = Buyers.GetData();
            BuyersComboBox.ItemsSource = Buyers.GetData();
            BuyersComboBox.DisplayMemberPath = "Name";
            BuyersComboBox.SelectedValuePath = "Id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)BuyersComboBox.SelectedValue;
            Buyers.InsertQuery(NameUser.Text, SurnameUser.Text, id);
            BuyersGrid.ItemsSource = Buyers.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int id = (int)(BuyersGrid.SelectedItem as DataRowView).Row[0];
            Buyers.DeleteQuery(id);
            BuyersGrid.ItemsSource = Buyers.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (BuyersGrid.SelectedItem != null)
            {
                //var item = CarsGrid.SelectedItem as DataRowView;
                int true_id = (int)(BuyersGrid.SelectedItem as DataRowView).Row[0];
                int id = (int)BuyersComboBox.SelectedValue;
                Buyers.UpdateQuery(NameUser.Text, SurnameUser.Text, id, true_id);
                BuyersGrid.ItemsSource = Buyers.GetData();
            }
    
        }

        private void BuyersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BuyersGrid.SelectedItem != null)
            {
                var item = BuyersGrid.SelectedItem as DataRowView;
                NameUser.Text = (string)item.Row[1];
                SurnameUser.Text = (string)item.Row[2];
                BuyersComboBox.SelectedValue = (int)item.Row[3];
                }
            }
    }   

}
