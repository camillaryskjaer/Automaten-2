using System;
using Automaten.Products;

namespace Automaten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //this is a assignment for school

            //makes a machine whit a gui, and call the Test method
            Machine machine = new Machine( new GUI() );
            machine.Test();                                    
        }
    }
}
