using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automaten.Products;
using Automaten;

namespace Automaten
{

    internal class GUI
    {
        public GUI()
        {

        }

        //the methods below is all private
        //method shows the top part of the user menu
        protected internal void UserMenuTop()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine();
            Console.WriteLine("         welcome to the vending machine");
            Console.WriteLine();
            Console.WriteLine("==================================================");
            Console.WriteLine();
            Console.WriteLine("Press a number ");
            Console.WriteLine();
        }

        //method show the bottom part of the user menu
        protected internal void UserMenuButtom()
        {
            Console.WriteLine("0. Exit");
            Console.WriteLine();
            Console.WriteLine("Please select your choice:");
        }

        //info to the user, how to start their purchase
        protected internal void UserStartMenu()
        {
            Console.WriteLine("1. To get started");
        }

        //displays the products and prices
        protected internal void UserSelectMenu()
        {
            Console.WriteLine("1. Pepsi Max 20kr");
            Console.WriteLine("2. Faxe kondi Booster 25kr");
            Console.WriteLine("3. Snickers 10kr");
            Console.WriteLine("4. Mars 10kr");
        }

        //methods used for output about patment
        protected internal void UserPayment()
        {
            Console.WriteLine("Please insert coins");
        }
        protected internal void Changes()
        {
            Console.Clear();
            Console.WriteLine("Please remember your changes");
        }
        protected internal void NeedMore()
        {
            Console.WriteLine("Here is your money back, place insert an higher amount");
        }

        //if sold out method
        protected internal void SoldOut()
        {
            Console.WriteLine("Sorry we are soldout");
        }
        //if product in stock
        protected internal void InStock()
        {
            Console.WriteLine("Please remenber your drink/snack");
        }

    }
}
