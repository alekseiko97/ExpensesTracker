namespace ExpensesTracker
{
    public class Expense
    {

        public string Name { get; }
        public double Price { get; }
        public int Quantity { get; }

        public Expense(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"{Name}: {Price} x {Quantity}";
        }
    }
}