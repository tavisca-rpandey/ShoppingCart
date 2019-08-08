using System.Collections.Generic;

namespace ShoppingCart
{
    public class AppConfigurations
    {
        public static Dictionary<string, double> GetDiscountConfigurations()
        {
            var discountTable = new Dictionary<string, double>
            {
                { "rice", 4 },
                { "wheat", 4.2 },
                { "keyboard", 16.3 }
            };

            return discountTable;
        }

    }

}
