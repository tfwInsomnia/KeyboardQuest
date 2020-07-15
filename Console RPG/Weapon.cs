using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Text;

namespace Console_RPG {
    public class Weapon : Item{


        public int[] Damage { get; set; }
public string Display() {
            string s = this.name;
            s += (" Damage: " + Damage[0].ToString() +"-"+ Damage[1].ToString());
            return s;
        }

        public void LoadWeapon(string fileName) {
            var fileData = DataManager.Load<Weapon>(fileName);
            name = fileData.name;
            Damage = fileData.Damage;
            price = fileData.price;

        }
    }
}
