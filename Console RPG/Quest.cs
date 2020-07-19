using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG {
    public class Quest {

        public string name { get; set; }
        public int level { get; set; }
        public int questLength { get; set; }
        public string description { get; set; }
        public string goal { get; set; }
        public Enemy finalEnemy { get; set; }
        public int rewardExperience { get; set; } = 0;
        public int rewardMoney { get; set; } = 0;
        public Weapon rewardWeapon { get; set; } = null;
        public Armor rewardArmor { get; set; } = null;
        public string[] map { get; set; }
        public Random rng { get; set; } = new Random();
        public string questCompleteDialog { get; set; }
        public void Inspect() {
            Console.WriteLine($"{description}");
            Console.WriteLine($"reward | {rewardMoney} gold | {rewardWeapon?.name ?? ""} {rewardArmor?.name ?? ""} | experience: {rewardExperience} ");
            Console.WriteLine($"This is a level {level} quest.");

        }
        public string Display() {
            string s = (name + " ");
            s += (rewardMoney + " " + "gold. ");
            s += rewardWeapon?.name;
            s += (" " + rewardArmor?.name);

            return s;
        }

        public void Embark() {
            string e;
            Console.WriteLine("Another day, another quest.");
            Console.WriteLine("You can abandon the quest anytime except during battles by entering a.");
            for (int i = 0; i < map.Length; i++) {
                Console.WriteLine($"Progress {i}/{map.Length}");

                string input = Console.ReadLine().ToLower();
                while (!(Equals(input, "c") || Equals(input, "i") || Equals(input, "a") || Equals(input, "s"))) {
                    Console.WriteLine("Invalid entry enter c/i/a ");
                    input = Console.ReadLine().ToLower();
                }

                while (!Equals(input, "c")) {
                    if (Equals(input, "i")) { Player.BrowseInventory(); }
                    if (Equals(input, "s")) { Player.PrintStats(); }
                    if (Equals(input, "a")) {
                        Console.WriteLine("Are you sure you want to abandon the quest? y/n");
                        string input2 = Console.ReadLine().ToLower();
                        while (!Equals(input2, "y") || !Equals(input2, "n")) {
                            input2 = Console.ReadLine().ToLower();
                        }
                        if (Equals(input2, "y")) {
                            Console.WriteLine("Live to fight another day.");
                            return;
                        }
                        break;
                    }

                }
                e = map[i];
                EvaluateEvent(e);


            }

            Console.WriteLine(questCompleteDialog);
            if (rewardWeapon != null) {
                Player.Weapons.Add(rewardWeapon);
            }
            if (rewardArmor != null) {
                Player.Armors.Add(rewardArmor);
            }
            Player.MONEY += rewardMoney;
            Player.GainExperience(rewardExperience);

        }

        private void GetRandomEvent() {
            int r = Player.rng.Next(1, 11);
            if (r > 6) {
                Battle b = new Battle(Content.strayDog);
                return;
            } else if (r > 3) {
                //nothing
                return;
            } else if (r > 1) {
                //perception check
                return;
            } else {
                //shop
                return;
            }

        }

        private void EvaluateEvent(string e) {
            string ev = e.ToLower();
            if (Equals(ev, "random")) {
                GetRandomEvent();
                return;
            } else if (Equals(e, "finalEnemy")) {
                Battle finalBattle = new Battle(finalEnemy);
                return;
            }



        }


    }
}
