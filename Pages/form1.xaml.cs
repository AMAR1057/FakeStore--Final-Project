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
using Microsoft.EntityFrameworkCore;

namespace FakeStore.Models
{
    /// <summary>
    /// Interaction logic for form1.xaml
    /// </summary>
    public partial class form1 : Window
    {
        public form1()
        {
            db();
            InitializeComponent();
            LoadComboBox();
        }
        //db
        private void db()
        {
            using var dbContext = new SqliteDBContext();
            dbContext.Database.EnsureCreated();
        }



        int itemsOrdered;
        const int numberOfProducts = 4;
        Product[] products = new Product[numberOfProducts];

        private void LoadComboBox()
        {

            // do stuff
            products[0] = new Product("iPad Mini", 789.5);
            products[1] = new Product("iPad Latest", 999);
            products[2] = new Product("Macbook Pro", 2222.69);
            products[3] = new Product("Macbook Air", 1999.96);

            for (int i = 0; i < numberOfProducts; i++)
            {
                dudProducts.Items.Add(products[i].Description);

            }
            dudProducts.SelectedIndex = 1;


        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            products[dudProducts.SelectedIndex].NumberOrdered++;
            itemsOrdered++;
            lblItemsOrdered.Content = "Items Ordered: " + itemsOrdered.ToString();
            double totalCost = 0;
            lstProducts.Items.Clear();
            dudProducts.SelectedIndex = 1;
            for (int i = 0; i < numberOfProducts; i++)
            {
                if (products[i].NumberOrdered != 0)
                {
                    lstProducts.Items.Add(products[i].NumberOrdered.ToString() + " " + products[i-1].Description);
                    totalCost += products[i].Cost * products[i].NumberOrdered;
                }
            }
            lblTotalCost.Content = "Total Cost: $" + string.Format("{0:f2}", totalCost);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            itemsOrdered = 0;
            lblItemsOrdered.Content = "Items Ordered: 0";

            for (int i = 0; i < numberOfProducts; i++)
            {
                products[i].NumberOrdered = 0;
            }
            dudProducts.SelectedIndex = 1;
            lstProducts.Items.Clear();
            lblTotalCost.Content = "Total Cost";

        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
          
        }
    }

}
