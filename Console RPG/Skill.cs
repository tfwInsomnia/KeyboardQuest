using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Console_RPG {
    public class Skill {

        public int defaultCooldown { get; set; } = 0;
        public int cooldown { get; set; } = 0;
        public string name { get; set; }
        public int duration { get; set; }
        public int skillLevel { get; set; } = 1;
        public string description { get; set; }
        public double dmgMultiplier { get; set; } = 1.0;
        public double accMultiplier { get; set; } = 1.0;
        
        public void SetCooldown(int value ) {
            cooldown = value;
        }

        public string DisplaySkill(bool inBattle = false) {
            if (inBattle && cooldown>0) {
                return $"{name}, ready in {cooldown} turn(s)";
            }else if(inBattle && cooldown== 0) {
                return $"{name}, ready, cooldown: {defaultCooldown}";
            }

            return $"{name} level{skillLevel}, {description}, cooldown{defaultCooldown}";
        }









    }
}
