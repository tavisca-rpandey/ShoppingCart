namespace ShoppingCart
{
    public class Discounts
    {
        public IDiscount GetDiscounts(string typeOfDiscount)
        {
            typeOfDiscount = typeOfDiscount.ToLower();

            switch (typeOfDiscount)
            {
                case "fixed": return new FixedDiscount();
                case "configurable": return new ConfigurableDiscount();
                case "categorical": return new CategoricalDiscount();
                default: return new FixedDiscount();
            }
        }

    }
}
