using MaterialDesignThemes.Wpf;
using Practic_1.DataSet1TableAdapters;
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
    }
}
