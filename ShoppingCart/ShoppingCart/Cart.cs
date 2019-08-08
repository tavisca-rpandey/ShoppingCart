using System.Collections.Generic;

namespace ShoppingCart
{
    public class Cart
    {
        public List<CartItem> CartItemList { get; private set; }
        public double TotalCartCost { get; private set; }

        public double DiscountedTotalCost { get; private set; }

        private IDiscount _discount;

        public Cart(string discountType = "fixed")
        {
            // Constructor for the Cart objects
            CartItemList = new List<CartItem>();
            TotalCartCost = 0;
            DiscountedTotalCost = 0;
            _discount = new Discounts().GetDiscounts(discountType);

        }

        public void AddItem(CartItem cartItem)
        {
            CartItemList.Add(cartItem);
            TotalCartCost += cartItem.TotalItemCost;
            UpdateDiscountedTotalCost();
        }

        public void RemoveItem(CartItem cartItem)
        {
            CartItemList.Remove(cartItem);
            TotalCartCost -= cartItem.TotalItemCost;
            UpdateDiscountedTotalCost();
        }

        private void UpdateDiscountedTotalCost()
        {
            var discount = _discount.GetTotalDiscount(this.CartItemList);
            DiscountedTotalCost = TotalCartCost - discount;
        }

    }
}
