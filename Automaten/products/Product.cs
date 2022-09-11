using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automaten;

namespace Automaten.Products
{
    internal class Product
    {
        //property
        private string name;
        private int cost;

        //encapsulation
        protected internal string Name { get { return name; } set { name = value;} }
        protected internal int Cost { get { return cost; } set { cost = value; } }

        //constructor
        public Product(string name, int cost)
        {
            this.name = name;
            this.cost = cost;
        }
        
        //override tostring
        public override string ToString()
        {
            return name;
        }
    }
}
