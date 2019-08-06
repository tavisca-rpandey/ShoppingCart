using System.Collections.Generic;

namespace ShoppingCart
{
    public class Cart
    {
        public List<CartItem> CartItemList{ get; private set; }
        public double TotalCartCost { get; private set; }

        public double DiscountedTotalCost { get; private set; }

        private Discounts _discounts;

        public Cart()
        {
                // Constructor for the Cart objects
            CartItemList = new List<CartItem>();
            TotalCartCost = 0;
            DiscountedTotalCost = 0;
            _discounts = new Discounts();

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
            var discount = _discounts.GetTotalDiscount(this.CartItemList);
            DiscountedTotalCost = TotalCartCost - discount;
        }

    }
}
