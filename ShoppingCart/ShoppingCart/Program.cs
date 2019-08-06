using System;

namespace ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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

            Discounts d = new Discounts();
            double dis = d.GetTotalDiscount(myCart.CartItemList);

            Console.WriteLine(dis);
        }
    }
}
