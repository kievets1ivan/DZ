using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary;

namespace ConsoleApp1
{
    class ProgramForShop
    {       

        public enum OperationType
        {
            AddProduct = 1,
            DropProduct = 2,
            ToCashier = 3,
        }

        public static void ShowMenu(ref OperationType op)
        {
            Console.WriteLine("1 - add product to basket\n" +
                    "2 - drop from basket\n" +
                    "3 - to cashier");

            Enum.TryParse(Console.ReadLine(), out op);
        }

        static class ShopCaptionConst
        {
            public const string AddProductCaption = "Enter name of product that u wanna add: ";
            public const string DropProductCaption = "Enter name of product that u wanna drop: ";
            public const string GetQuantatyCaption = "Enter quantity: ";
            public const string NonexistentProduct = "There is not this product";

        }

        public static string GetAddPrductAsString(string caption)
        {
            try
            {
                Console.WriteLine(caption);
                    var value = Console.ReadLine();
                return value;
            }
            catch
            {
                Console.WriteLine("Wrong input");
                return null;
            }
        }

        public static string GetDropPrductAsString(string caption)
        {
            try
            {
                Console.WriteLine(caption);
                var value = Console.ReadLine();
                return value;
            }
            catch
            {
                Console.WriteLine("Wrong input");
                return null;
            }
        }

        public static uint GetQuantatyAsInt(string caption)
        {
            try
            {
                Console.WriteLine(caption);
                var value = Convert.ToUInt32(Console.ReadLine());
                return value;
            }
            catch
            {
                Console.WriteLine("Wrong input");
                return 0;
            }
        }

        static void Main(string[] args)
        {
            
            Shop shop = new Shop();
            Cashier cashier = new Cashier();
            shop.PrintProducts();
            shop.ApplyDiscountByType(ProductType.Milk, 0.9);

            bool exit = false;

            Buyer b = new Buyer(100);


            Console.WriteLine("-------------------------------------------------------------------------------");
            OperationType operation = 0;

            do
            {
                ShowMenu(ref operation);


                switch (operation)
                {
                    case OperationType.AddProduct:
                        Product p;
                        string s = GetAddPrductAsString(ShopCaptionConst.AddProductCaption);

                        uint temoQuantity = GetQuantatyAsInt(ShopCaptionConst.GetQuantatyCaption);

                        p = shop.GetProductFromShop(s, (int)temoQuantity);

                        /*if (b.CheckExpirationDate(p))
                            p = shop.ApplyDiscountByProduct(p, 0.8);*/

                        if (b.AddToBasket(p))
                            Console.WriteLine("Product has added");
                        else
                            Console.WriteLine(ShopCaptionConst.NonexistentProduct);
                        break;

                    case OperationType.DropProduct:
                        s = GetDropPrductAsString(ShopCaptionConst.DropProductCaption);

                        p = b.GetProductFromBasket(s);

                        temoQuantity = GetQuantatyAsInt(ShopCaptionConst.GetQuantatyCaption);

                        if (b.DropFromBasket(p, (int)temoQuantity))
                            Console.WriteLine("Product has droped");
                        else
                            Console.WriteLine(ShopCaptionConst.NonexistentProduct);
                        break;

                    case OperationType.ToCashier:
                        break;

                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }
            } while (operation != OperationType.ToCashier);


            while (!exit)
            {
                if(b.HasEnoughMoney(cashier.calculateBasket(b.Basket)))
                {
                    cashier.PrintCheck(b.Basket);
                    exit = true;
                }
                else
                {
                    Console.WriteLine("You dont have enough money to pay");
                    Console.WriteLine("Drop smth");
                    cashier.PrintCheck(b.Basket);

                    Console.WriteLine($"You shoud drop items on {cashier.MissingMoney(cashier.calculateBasket(b.Basket), b._quantatyOfMoney)}");

                    string s = GetDropPrductAsString(ShopCaptionConst.DropProductCaption);
                    Product p = b.GetProductFromBasket(s);
                    uint temoQuantity = GetQuantatyAsInt(ShopCaptionConst.GetQuantatyCaption);

                    if (b.DropFromBasket(p, (int)temoQuantity))
                        Console.WriteLine("Product has droped");
                    else
                        Console.WriteLine(ShopCaptionConst.NonexistentProduct);


                }
            }
        }
    }
}
