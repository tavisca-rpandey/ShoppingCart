namespace ShoppingCart
{
    public class Product
    {
        public string Name { get; private set; }
        public double PricePerUnit { get; private set; }
        public Product(string name, double price)
        {
            this.Name = name.ToLower();
            this.PricePerUnit = price;
        }

    }
}
