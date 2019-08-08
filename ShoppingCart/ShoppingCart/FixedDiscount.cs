using System.Collections.Generic;

namespace ShoppingCart
{
    public class FixedDiscount : IDiscount
    {
        private int _discount = 20;

        public double GetTotalDiscount(List<CartItem> itemList)
        {
            double totalDiscount = 0;

            foreach (var item in itemList)
                totalDiscount += (item.TotalItemCost * _discount) / 100;
            
            return totalDiscount;

        }
    }

    }
