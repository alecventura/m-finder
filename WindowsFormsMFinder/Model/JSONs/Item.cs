using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.JSONs
{
    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }

        public Item(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
