using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG {
    public class Misc : Item {


        int amount { get; set; } = 5;

        public override string Display() {
            string s = name;
            if (Equals(name, "Heal Potion")) {
                s += (" " + description + " " + amount.ToString() + " HP.");
            }

            return s;
        }

        public void Use() {
            if (Equals(name, "Heal Potion")) {
                Player.Heal(amount);

                Console.WriteLine($"Used heal potion +{amount}");
                return;
            }

        }
    }
}