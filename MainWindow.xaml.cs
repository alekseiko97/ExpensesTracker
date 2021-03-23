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
        private readonly List<Category> listOfCategories;

        public MainWindow()
        {
            InitializeComponent();

            this.listOfCategories = new List<Category>
            {
                new Category("Food"),
                new Category("Housing"),
                new Category("Beverage"),
                new Category("Other")
            };

            listOfCategories[0].Expenses.Add(new Expense("Meat", 5.50, 1));
            listOfCategories[0].Expenses.Add(new Expense("Juice", 1.20, 1));
            listOfCategories[0].Expenses.Add(new Expense("Lettuce", 1.10, 1));

            listOfCategories.ForEach(x => categories_lb.Items.Add(x));

            // calculate total expenses
            UpdateLabelContent();
        }

        private void UpdateLabelContent(Category selectedCategory = null)
        {
           if (selectedCategory != null) overall_lb.Content = "Overall (per category): " + selectedCategory.GetTotalAmount().ToString();

           total_lb.Content = "Overall: " + listOfCategories.Sum(x => x.GetTotalAmount());
        }

        private bool AddExpense(Expense newExpense) 
        {
            if (categories_lb.SelectedItem is Category selectedCategory)
            {
                // check if modification to the exisiting expense is required, otherwise add a new one
                if (!selectedCategory.ModifyExpense(newExpense)) selectedCategory.Expenses.Add(newExpense);

                // clean up previous expenses in list box
                expenses_lb.Items.Clear();

                // add all expenses from category to the list box
                selectedCategory.Expenses.ForEach(x => expenses_lb.Items.Add(x));

                // update total expenses per category + overall expenses
                UpdateLabelContent(selectedCategory);

                return true;

            }


            return false; 
        }

        /* TODO: */
        private void AddCategory(string name) { return; }

        /* TODO: */
        private void RemoveExpense(Expense expense) { return; }

        /* TODO: */
        private void RemoveCategory(Category category) { return; }



        /* Events */
        private void categories_lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // show all expenses per category in right listBox
            if (categories_lb.SelectedItem is Category selectedCategory)
            {
                expenses_lb.Items.Clear();
                selectedCategory.Expenses.ForEach(x => expenses_lb.Items.Add(x));

                // calculate overall sum spent per category
                UpdateLabelContent(selectedCategory);
            }

        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(name_tb.Text)) { 
                MessageBox.Show("Please enter a valid expense title!!", "Alert", MessageBoxButton.OK);
                return;
            }

            if (!double.TryParse(price_tb.Text, out double price))
            {
                MessageBox.Show("Check price formatting!!", "Alert", MessageBoxButton.OK);
                return;
            }

            if (!int.TryParse(quantity_tb.Text, out int quantity))
            {
                MessageBox.Show("Check price formatting!!", "Alert", MessageBoxButton.OK);
                return;
            }

            this.AddExpense(new Expense(name_tb.Text, price, quantity));
        }

        private void expenses_lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (expenses_lb.SelectedItem is Expense selectedExpense)
            {
                name_tb.Text = selectedExpense.Name;
                price_tb.Text = selectedExpense.Price.ToString();
                quantity_tb.Text = selectedExpense.Quantity.ToString();
            }
        }

        private void remove_btn_Click(object sender, RoutedEventArgs e)
        {
            if (expenses_lb.SelectedItem is Expense ex)
            {
                // remove expense from list and listbox
                expenses_lb.Items.Remove(ex);

                listOfCategories.ForEach(x => x.Expenses.Remove(ex));

                UpdateLabelContent(categories_lb.SelectedItem as Category);
            }
        }
    }

}
