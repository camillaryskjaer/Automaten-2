using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automaten;

namespace Automaten.Products
{
    internal class Snack : Product
    {
        //property
        private string weight;

        //encapsulation
        protected internal string Weight;
        
        //constructor
        public Snack(string name, int cost, string weight) : base(name, cost)
        {
            this.weight = weight;
        }
    }
}
