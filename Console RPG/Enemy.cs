using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Console_RPG {
    public class Enemy {

        public string name { get; set; }
        public int ACCURACY { get; set; }
        public int BASE_ACCURACY { get; set; }
        public int MAX_HP { get; set; }
        public int HP { get; set; }
        public int DEFENCE { get; set; }
        public int[] ATTACK { get; set; }
        public int[] BASE_ATTACK { get; set; }
        public int BASE_DEFENCE { get; set; }
        public int SPEED { get; set; }
        public int rewardExperience { get; set; }
        public int rewardMoney { get; set; }
        public Random rng { get; set; } = new Random();


        public int level { get; set; } = Player.level;

        public List<Skill> enemySkills { get; set; } = new List<Skill>() { Content.basicAttack };

        public void DamageLog(int dmg) {

            if (dmg <= Player.DEFENCE) {
                Console.WriteLine($"{name} attacked for {dmg} but you blocked it completely.");
            } else {
                if (Player.DEFENCE == 0) {
                    Console.WriteLine($"{name} hit for {dmg}, your hp: {Player.HP}");
                } else {
                    Console.WriteLine($"{name} attackedfor {dmg}, you blocked it partly. hp-{dmg - Player.DEFENCE}, gp: {Player.HP}");
                }
            }
        }
        public void TakeAction() {

            foreach (Skill sk in enemySkills) {
                if (sk.cooldown > 0) { sk.cooldown--; }
            }

            List<Skill> readySkills = new List<Skill>();
            foreach (Skill sk in enemySkills) {
                if (sk.cooldown == 0) { readySkills.Add(sk); }
            }
            int r = rng.Next(0, readySkills.Count);
            enemySkills[enemySkills.IndexOf(readySkills[r])].SetCooldown(readySkills[r].defaultCooldown);
            
            string skillName = readySkills[r].name;
            double dmgMultiplier = readySkills[r].dmgMultiplier;
            double accMultiplier= readySkills[r].accMultiplier;

            if (Equals(skillName, "Stunning Blow")) {
                DealDamage(stun: true, multiplier: dmgMultiplier, accMultiplier: accMultiplier);
            } else if (Equals(skillName, "Piercing Blow")) {
                DealDamage(pierce: true, multiplier: dmgMultiplier, accMultiplier: accMultiplier);
            } else if (Equals(skillName, "Basic Attack")) {
                DealDamage(multiplier: dmgMultiplier, accMultiplier: accMultiplier);
            }

        }

        public void DealDamage(double multiplier = 1.00, double accMultiplier= 1.00, bool pierce = false, bool stun = false) {

            int roll = rng.Next(1, 21);
            if (roll > ACCURACY * accMultiplier) {
                Console.WriteLine($"{name} attacked but missed entirely.");
                return;
            }
            int dmg = (int)(multiplier * rng.Next(ATTACK[0], ATTACK[1] + 1));

            if (pierce) {
                Player.HP -= dmg;
                Console.WriteLine($"{name} attacked and pierced through your armor, hp-{dmg}, your hp: {Player.HP}");
                return;
            }


            if (dmg <= Player.DEFENCE) {
                DamageLog(dmg);
                return;
            } else {
                int netDmg = dmg - Player.DEFENCE;
                Player.HP -= netDmg;
                DamageLog(dmg);
                if (stun) {
                    TakeAction();
                }
                return;
            }


        }


        public void LoadEnemy(string fileName) {
            var fileData = DataManager.Load<Enemy>(fileName);

            ATTACK = fileData.ATTACK;
            HP = fileData.HP;
            name = fileData.name;

        }


    }
}
