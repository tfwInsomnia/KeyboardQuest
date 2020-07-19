using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG {
    public abstract class Item {

        public string name { get; set; }
        public int price { get; set; }
        public string description { get; set; }
        public int level { get; set; } = 1;
        public int durability { get; set; } = 10;


        private string DESCRIPTION;

        public abstract string Display();
        
        }
    }

