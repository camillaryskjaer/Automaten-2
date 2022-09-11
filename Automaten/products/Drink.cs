using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automaten;

namespace Automaten.Products
{
    internal class Drink : Product
    {
        //property
        private string size;

        //encapsulation
        protected internal string Size;

        //constructor
        public Drink(string name, int cost, string size) : base(name, cost)
        {
            this.size = size;
        }
    }
}
