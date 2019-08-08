using System.Collections.Generic;

namespace ShoppingCart
{
    public interface IDiscount
    {
        double GetTotalDiscount(List<CartItem> itemList);
    }


}
