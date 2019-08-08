using System;
using Xunit;
using ShoppingCart;
using System.Collections.Generic;

namespace SoppingCartXtest
{
    public class UnitTest1
    {
        [Fact]
        public void Items_Should_be_added_to_Cart()
        {
            //make a product
            Cart myCart = new Cart();
            Product rice = new Product("Rice", 45);
            Product wheat = new Product("Wheat", 45);

            //make an addable cart Item by choosing a quantity
            int quantity = 4;
            CartItem item1 = new CartItem(rice, quantity);
            CartItem item2 = new CartItem(wheat, quantity);


            // add to cart
            myCart.AddItem(item1);
            myCart.AddItem(item2);

            //add to expected cart
            List<CartItem> expectedCart = new List<CartItem>();
            expectedCart.Add(item1);
            expectedCart.Add(item2);

            Assert.Equal(expectedCart, myCart.CartItemList);

        }

        [Fact]
        public void Empty_Cart_has_Zero_Total_Cost()
        {
            Cart myCart = new Cart();

            Assert.Equal(0, myCart.TotalCartCost);

        }

        [Fact]
        public void Is_Correct_Cart_Total_Calculated()
        {
            //make a product
            Cart myCart = new Cart();
            Product rice = new Product("Rice", 45);
            Product wheat = new Product("Wheat", 45);

            //make an addable cart Item by choosing a quantity
            int quantity = 4;
            CartItem item1 = new CartItem(rice, quantity);
            CartItem item2 = new CartItem(wheat, quantity);


            // add to cart
            myCart.AddItem(item1);
            myCart.AddItem(item2);

            Assert.Equal(45 * 8, myCart.TotalCartCost);
        }

        [Fact]
        public void Total_Discount_Of_Empty_Cart_Is_Zero()
        {
            Cart myCart = new Cart();

            Assert.Equal(0, myCart.DiscountedTotalCost);
        }

        [Fact]
        public void Is_The_Configurable_Discount_Correct()
        {
            //make a product
            Cart myCart = new Cart();
            Product rice = new Product("rice", 45);
            Product wheat = new Product("wheat", 45);

            //make an addable cart Item by choosing a quantity
            int quantity = 4;
            CartItem item1 = new CartItem(rice, quantity);
            CartItem item2 = new CartItem(wheat, quantity);


            // add to cart
            myCart.AddItem(item1);
            myCart.AddItem(item2);

            // calculate discount
            IDiscount d = new Discounts().GetDiscounts("configurable");
            double dis = d.GetTotalDiscount(myCart.CartItemList);

            
            Assert.Equal(14.76,dis);

        }

        [Fact]
        public void Is_The_Fixed_Discount_Correct()
        {
            //make a product
            Cart myCart = new Cart();
            Product rice = new Product("rice", 45);
            Product wheat = new Product("wheat", 45);

            //make an addable cart Item by choosing a quantity
            int quantity = 4;
            CartItem item1 = new CartItem(rice, quantity);
            CartItem item2 = new CartItem(wheat, quantity);


            // add to cart
            myCart.AddItem(item1);
            myCart.AddItem(item2);

            IDiscount d = new Discounts().GetDiscounts("fixed");
            double dis = d.GetTotalDiscount(myCart.CartItemList);


            Assert.Equal(288, 360-dis);

        }

        [Fact]
        public void Is_The_Categorical_Discount_Correct()
        {
            //make a product
            Cart myCart = new Cart();
            Product rice = new Product("rice", 45,"staple");
            Product wheat = new Product("wheat", 45,"staple");

            //make an addable cart Item by choosing a quantity
            int quantity = 4;
            CartItem item1 = new CartItem(rice, quantity);
            CartItem item2 = new CartItem(wheat, quantity);


            // add to cart
            myCart.AddItem(item1);
            myCart.AddItem(item2);

            IDiscount d = new Discounts().GetDiscounts("categorical");
            double dis = d.GetTotalDiscount(myCart.CartItemList);


            Assert.Equal(288, 360 - dis);

        }
    }
}
