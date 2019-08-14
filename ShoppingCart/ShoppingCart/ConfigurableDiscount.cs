using System.Collections.Generic;

namespace ShoppingCart
{
    public class ConfigurableDiscount:IDiscount
    {
        public Dictionary<string, double> _discountTable { get; private set; }

        public ConfigurableDiscount()
        {
            //Hard Coding the initial discount Table 
            _discountTable = AppConfigurations.GetDiscountConfigurations();
        }



        public double GetTotalDiscount(List<CartItem> itemList)
        {
            double totalDiscount = 0;

            foreach (var item in itemList)
            {
                if (_discountTable.ContainsKey(item.item.Name))
                {
                    totalDiscount += (item.TotalItemCost * _discountTable[item.item.Name]) / 100;
                }
            }
            return totalDiscount;

        }
    }

}
