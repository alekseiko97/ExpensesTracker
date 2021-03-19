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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExpensesTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
        public MainWindow()
        {
            InitializeComponent();
            CreateDummyCategories();
        }

        private void CreateDummyCategories() 
        {
            Category c1 = new Category("Food");
            Category c2 = new Category("Housing");
            Category c3 = new Category("Beverage");
            Category c4 = new Category("Other");

            c1.Expenses.Add(new Expense("Meat", 5.50, 1));

            categories_lb.Items.Add(c1);
            categories_lb.Items.Add(c2);
            categories_lb.Items.Add(c3);
            categories_lb.Items.Add(c4);

            
            return; 
        }

        private bool AddExpense(Expense e) 
        {
            if (categories_lb.SelectedItem is Category selectedCategory)
            {
                selectedCategory.Expenses.Add(e);

                expenses_lb.Items.Clear();

                foreach (Expense ex in selectedCategory.Expenses)
                {
                    expenses_lb.Items.Add(ex);
                }
                return true;
            }


            return false; 
        }

        private void AddCategory(Category category) { return; }

        private void RemoveExpense() { return; }

        private void RemoveCategory() { return; }

        private double GetTotalByCategory() { return 0.0; }

        private void categories_lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (categories_lb.SelectedItem is Category selectedCategory)
            {
                expenses_lb.Items.Clear();
                selectedCategory.Expenses.ForEach(x => expenses_lb.Items.Add(x));
            }
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            AddExpense(new Expense(name_tb.Text, double.Parse(price_tb.Text), int.Parse(quantity_tb.Text)));
            
        }
    }

}
