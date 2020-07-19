using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Text;

namespace Console_RPG {
    public class Weapon : Item{

        public Skill weaponSkill { get; set; } = null;
        public string[] statBoost { get; set; } = null;
        public int[] Damage { get; set; }
        public override string Display() {
            return $"{name}, Damage {Damage[0]}-{Damage[1]} {description} price: {price} gold";
        }
        public void LoadWeapon(string fileName) {
            var fileData = DataManager.Load<Weapon>(fileName);
            name = fileData.name;
            Damage = fileData.Damage;
            price = fileData.price;

        }
    }
}
