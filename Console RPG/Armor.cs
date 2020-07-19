using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG {
    public class Armor:Item {

        public int Defence { get; set; } = 1;
        
        public string[] statBoost { get; set; } = null;
        public Skill armorSkill { get; set; } = null;
        

        public override string Display() {
            return $"{name} , armor {Defence}, description: {description}, price: {price} gold";
        }
    }
}
