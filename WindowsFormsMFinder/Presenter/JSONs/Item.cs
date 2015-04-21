using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.JSONs
{
    public class Item
    {
        private int id { get; set; }
        private string name { get; set; }

        public Item(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
