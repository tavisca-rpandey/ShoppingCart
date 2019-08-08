using System.Collections.Generic;

namespace ShoppingCart
{
    public class CategoricalDiscount : IDiscount
    {
        Dictionary<string, double> _discountTable;
        public CategoricalDiscount()
        {
            _discountTable = new Dictionary<string, double>
            {
                { "dairy", 7 },
                { "staple", 20 },
                { "electronics", 16.3 },
                { "Medicine",15},
                { "educational",10},
                { "default",5}
            };
        }

        public double GetTotalDiscount(List<CartItem> itemList)
        {
            double totalDiscount = 0;
            double discountRate = 5;
            
            foreach (var item in itemList)
            {
                if (_discountTable.ContainsKey(item.item.Category))
                {
                    discountRate = _discountTable[item.item.Category];
                }
                totalDiscount += item.TotalItemCost*discountRate/100 ; 
            }
            return totalDiscount;
        }
    }

}
