using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;

namespace ExpensesTracker
{
    public class Category
    {
        public string Name { get; }
        public List<Expense> Expenses { get; set; }
        public Category(string name)
        {
            Name = name;
            Expenses = new List<Expense>();
        }

        public bool ModifyExpense(Expense e)
        {
            foreach (Expense ex in this.Expenses)
            {
                // if expense with that name already exists, update its properties 
                if (ex.Name.ToLower() == e.Name.ToLower())
                {
                    // if quanity of product is set to 0, remove it from the list
                    if (e.Quantity == 0)
                        this.Expenses.Remove(ex);

                    // update properties
                    ex.Price = e.Price;
                    ex.Quantity = e.Quantity;

                    return true;
                }
            }

            return false;
        }

        public double GetTotalAmount()
        {
            return Expenses.Sum(x => x.Price * x.Quantity);
        }

        public override string ToString()
        {
            return Name;
        }

    }
}