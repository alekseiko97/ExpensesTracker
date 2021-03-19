using System.Collections.Generic;
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

        public override string ToString()
        {
            return Name;
        }

    }
}