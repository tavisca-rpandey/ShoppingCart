using System.Collections.Generic;

namespace ShoppingCart
{
    public class Discounts
    {
        public Dictionary<string, double> discountTable { get; private set; }

        public Discounts()
        {
            //Hard Coding the discount Table 
            discountTable = new Dictionary<string, double>();
            discountTable.Add("rice", 4);
            discountTable.Add("wheat", 4.2);
            discountTable.Add("keyboard", 16.3);
        }

        public double GetTotalDiscount(List<CartItem> itemList)
        {
            double totalDiscount = 0;

            foreach (var item in itemList)
            {
                if (discountTable.ContainsKey(item.item.Name))
                {
                    totalDiscount += (item.TotalItemCost * discountTable[item.item.Name])/100; 
                }
            }
            return totalDiscount;

        }
    }
}
