using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Console_RPG {
    public class Enemy {

        public string name { get; set; }
        public int[] ATTACK { get; set; }
        public int MAX_HP { get; set; }
        public int HP { get; set; }
        public int SPEED { get; set; }
        public int ACCURACY { get; set; }
        public int[] LOOT_MONEY_POOL { get; set; }
        public Random rng = new Random();
        public int DEFENCE { get; set; }
        public int BASE_DEFENCE { get; set; }
        public int BASE_ACCURACY { get; set; }
        public int[] BASE_ATTACK { get; set; }
        public int EXPERIENCE { get; set; }


        public int DealDamage() { return rng.Next(ATTACK[0], ATTACK[1] + 1); }
        
        public void LoadEnemy(string fileName) {
            var fileData =DataManager.Load<Enemy>(fileName);

            ATTACK = fileData.ATTACK;
            HP = fileData.HP;
            name = fileData.name;

        }
    
    
    }
}
