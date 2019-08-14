namespace ShoppingCart
{
    public class CartItem
    {
        public Product item { get; private set; }
        public double Quantity { get; private set; }
        public double TotalItemCost { get; private set; }

        public CartItem(Product product, double quantity)
        {
            item = new Product(product.Name, product.PricePerUnit, product.Category);
            this.Quantity = quantity;
            TotalItemCost = GetTotalCost();


        }
        private double GetTotalCost()
        {
            return Quantity * item.PricePerUnit;
        }
    }
}
