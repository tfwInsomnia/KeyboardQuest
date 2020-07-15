using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG {
    public class Armor:Item {

        public int Defence { get; set; }

        public string Display() {
            string s = name;
            s+= ("Defence: " + Defence.ToString());
            return s;
        }
    }
}
