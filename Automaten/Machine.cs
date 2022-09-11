using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automaten.Products;
using Automaten;
using System.Threading;

namespace Automaten
{
    internal class Machine
    {
        //variable
        ConsoleKeyInfo choice;
        private bool exit = false;
        GUI display;

        //constructor
        public Machine(GUI display)
        {
            this.display = display;
        }

        //create products objects, drinks
        Product p = new Drink("Pepsi Max", 20, "0,5L");
        Product p1 = new Drink("Pepsi Max", 20, "0,5L");
        Product p2 = new Drink("Pepsi Max", 20, "0,5L");
        Product p3 = new Drink("Pepsi Max", 20, "0,5L");
        Product p4 = new Drink("Pepsi Max", 20, "0,5L");

        Product f = new Drink("Faxe kondi Booster", 20, "0,25L");
        Product f1 = new Drink("Faxe kondi Booster", 20, "0,25L");
        Product f2 = new Drink("Faxe kondi Booster", 20, "0,25L");
        Product f3 = new Drink("Faxe kondi Booster", 20, "0,25L");
        Product f4 = new Drink("Faxe kondi Booster", 20, "0,25L");

        //create products objects, snacks
        Product s = new Snack("Snickers", 10, "50g");
        Product s1 = new Snack("Snickers", 10, "50g");
        Product s2 = new Snack("Snickers", 10, "50g");
        Product s3 = new Snack("Snickers", 10, "50g");
        Product s4 = new Snack("Snickers", 10, "50g");

        Product m = new Snack("Mars", 10, "50g");
        Product m1 = new Snack("Mars", 10, "50g");
        Product m2 = new Snack("Mars", 10, "50g");
        Product m3 = new Snack("Mars", 10, "50g");
        Product m4 = new Snack("Mars", 10, "50g");

        //create queues named shelf 1 to 4 used to store the products
        Queue<Product> shelf1 = new Queue<Product>();
        Queue<Product> shelf2 = new Queue<Product>();
        Queue<Product> shelf3 = new Queue<Product>();
        Queue<Product> shelf4 = new Queue<Product>();

        //list named deliveryTrey, when a product is takten out of the queue, put in the trey så the user can take it
        List<Product> deliveryTrey = new List<Product>();

        //method nemed Test, puts our products in queues and containing the methodcalls to the user display
        protected internal void Test()
        {
            //adds the products to the shelves
            shelf1.Enqueue(p);
            shelf1.Enqueue(p1);
            shelf1.Enqueue(p2);
            shelf1.Enqueue(p3);
            shelf1.Enqueue(p4);

            shelf2.Enqueue(f);
            shelf2.Enqueue(f1);
            shelf2.Enqueue(f2);
            shelf2.Enqueue(f3);
            shelf2.Enqueue(f4);

            shelf3.Enqueue(s);
            shelf3.Enqueue(s1);
            shelf3.Enqueue(s2);
            shelf3.Enqueue(s3);
            shelf3.Enqueue(s4);

            shelf4.Enqueue(m);
            shelf4.Enqueue(m1);
            shelf4.Enqueue(m2);
            shelf4.Enqueue(m3);
            shelf4.Enqueue(m4);

            //do/while to start the vending machine 
            do
            {
                //call the userDisplay method
                UserDisplay();

                //use to end the loop
                choice = Console.ReadKey();
                if (choice.Key == ConsoleKey.E)
                {
                    exit = true;
                }

            } while (!exit);

        }
        
        //the method UserDisplay  
        protected internal void UserDisplay()
        {
            //Clear the console
            Console.Clear();

            //call the private methods to output the menu
            display.UserMenuTop();
            display.UserStartMenu();
            display.UserMenuButtom();

            //method switch to read the user input
            StartMenuSwitch();

        }
        
        //method whit a switch to take the user indput from the first UserDisplay menu
        protected internal void StartMenuSwitch()
        {
            choice = Console.ReadKey();
            switch (choice.Key)
            {
                case ConsoleKey.D1:

                    //clear the console and output the UserSelectMenu
                    Console.Clear();

                    display.UserMenuTop();
                    display.UserSelectMenu();
                    display.UserMenuButtom();
                    SelectMenuSwitch();
                    Console.ReadLine();
                    break;

                case ConsoleKey.D0:

                    UserDisplay();

                    break;

                default:
                    break;
            }
        }
        
        //method whit a switch to take the user indput from the Select menu
        public void SelectMenuSwitch()
        {
            choice = Console.ReadKey();
            switch (choice.Key)
            {
                case ConsoleKey.D1:

                    //clear the console and output the UserPayment
                    Console.Clear();
                    display.UserMenuTop();
                    display.UserPayment();
                    display.UserMenuButtom();
                    PaymentShelf1();

                    Console.ReadLine();

                    break;

                case ConsoleKey.D2:

                    //clear the console and output the UserPayment
                    Console.Clear();
                    display.UserMenuTop();
                    display.UserPayment();
                    display.UserMenuButtom();
                    PaymentShelf2();

                    Console.ReadLine();
                    break;

                case ConsoleKey.D3:

                    //clear the console and output the UserPayment
                    Console.Clear();
                    display.UserMenuTop();
                    display.UserPayment();
                    display.UserMenuButtom();
                    PaymentShelf3();

                    Console.ReadLine();
                    break;

                case ConsoleKey.D4:

                    //clear the console and output the UserPayment
                    Console.Clear();
                    display.UserMenuTop();
                    display.UserPayment();
                    display.UserMenuButtom();
                    PaymentShelf4();

                    Console.ReadLine();
                    break;

                case ConsoleKey.D0:

                    UserDisplay();

                    break;

                default:
                    break;
            }
        }
        
        //methods used for the payment
        private void PaymentShelf1()
        {
            int amount = int.Parse(Console.ReadLine());
            int itemCost = 20;
            int change;

            if (shelf1.Count == 0)
            {
                //call sold out method
                display.SoldOut();

                //make the console waite 2 sek
                Thread.Sleep(2000);

                //return to start menu
                UserDisplay();
            }
            else if (amount >= itemCost)
            {
                //checks if the user needs changes back
                change = amount - itemCost;
                if (change > 0)
                {
                    //pay back changes
                    display.Changes();
                }

                //method to remove product from the queue, and add it to the list, and deliver product
                foreach (Product p in shelf1)
                {
                    deliveryTrey.Add(p);
                    break;
                }

                shelf1.Dequeue();

                //output to the user
                display.InStock();

                //make the console waite 2 sek
                Thread.Sleep(2000);

                //the user takes there product
                deliveryTrey.Clear();


            }
            else
            {
                //pay back the money
                //ask for more money
                display.NeedMore();
            }
        }
        private void PaymentShelf2()
        {
            int amount = int.Parse(Console.ReadLine());
            int itemCost = 20;
            int change;

            if (shelf2.Count == 0)
            {
                //call sold out method
                display.SoldOut();

                //make the console waite 2 sek
                Thread.Sleep(2000);

                //return to start menu
                UserDisplay();
            }
            else if (amount >= itemCost)
            {
                //checks if the user needs changes back
                change = amount - itemCost;
                if (change > 0)
                {
                    //pay back changes
                    display.Changes();
                }

                //method to remove product from the queue, and add it to the list, and deliver product
                foreach (Product p in shelf2)
                {
                    deliveryTrey.Add(p);
                    break;
                }
                shelf2.Dequeue();

                //output to the user
                display.InStock();

                //make the console waite 2 sek
                Thread.Sleep(2000);

                //the user takes there product
                deliveryTrey.Clear();
            }
            else
            {
                //pay back the money
                //ask for more money
                display.NeedMore();
            }
        }
        private void PaymentShelf3()
        {
            int amount = int.Parse(Console.ReadLine());
            int itemCost = 10;
            int change;

            if (shelf3.Count == 0)
            {
                //call sold out method
                display.SoldOut();

                //make the console waite 2 sek
                Thread.Sleep(2000);

                //return to start menu
                UserDisplay();
            }
            else if (amount >= itemCost)
            {
                //checks if the user needs changes back
                change = amount - itemCost;
                if (change > 0)
                {
                    //pay back changes
                    display.Changes();
                }

                //method to remove product from the queue, and add it to the list, and deliver product
                foreach (Product p in shelf3)
                {
                    deliveryTrey.Add(p);
                    break;
                }
                shelf3.Dequeue();

                //output to the user
                display.InStock();

                //make the console waite 2 sek
                Thread.Sleep(2000);

                //the user takes there product
                deliveryTrey.Clear();
            }
            else
            {
                //pay back the money
                //ask for more money
                display.NeedMore();
            }
        }
        private void PaymentShelf4()
        {
            int amount = int.Parse(Console.ReadLine());
            int itemCost = 20;
            int change;

            if (shelf4.Count == 0)
            {
                //call sold out method
                display.SoldOut();

                //make the console waite 2 sek
                Thread.Sleep(2000);

                //return to start menu
                UserDisplay();
            }
            else if (amount >= itemCost)
            {
                //checks if the user needs changes back
                change = amount - itemCost;
                if (change > 0)
                {
                    //pay back changes
                    display.Changes();
                }

                //method to remove product from the queue, and add it to the list, and deliver product
                foreach (Product p in shelf4)
                {
                    deliveryTrey.Add(p);
                    break;
                }
                shelf4.Dequeue();

                //output to the user
                display.InStock();

                //make the console waite 2 sek
                Thread.Sleep(2000);

                //the user takes there product
                deliveryTrey.Clear();
            }
            else
            {
                //pay back the money
                //ask for more money
                display.NeedMore();
            }
        }

    }
}
