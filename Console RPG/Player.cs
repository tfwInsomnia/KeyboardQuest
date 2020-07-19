using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace Console_RPG {
    public static class Player {

        public static List<Weapon> Weapons { get; set; } = new List<Weapon>();

        public static List<Misc> miscItems { get; set; } = new List<Misc>();
        public static List<Quest> activeQuests { get; set; } = new List<Quest>();
        public static List<Quest> finishedQuests { get; set; } = new List<Quest>();
        public static List<Skill> skills { get { return new List<Skill>() { Content.basicAttack}; } set { skills = value; } }
        public static Weapon equippedWeapon { get; set; } = null;
        public static List<Armor> Armors { get; set; } = new List<Armor>();
        public static Armor equippedArmor { get; set; } = null;

        public static int BASE_ACCURACY { get; set; } = 14;
        public static int MAX_HP { get; set; } = 10;
        public static int HP { get; set; } = 10;
        public static int[] BASE_ATTACK { get; set; } = new int[] { 1, 1 };
        public static int[] ATTACK { get { return new int[] { BASE_ATTACK[0] + equippedWeapon?.Damage[0] ?? 0, BASE_ATTACK[1] + equippedWeapon?.Damage[1] ?? 0 }; } set { ATTACK = value; } }

        public static int Accuracy { get; set; } = 14;
        public static int BASE_DEFENCE { get; set; } = 0;
        public static int DEFENCE { get { return BASE_DEFENCE + equippedArmor?.Defence ?? 0; } set { DEFENCE = value; } }

        public static int BASE_SPEED { get; set; } = 5;
        public static int SPEED { get; set; } = 5;

        //Character stats
        public static int MONEY { get; set; } = 100;
        public static int level { get; set; } = 1;
        public static int experience { get; set; } = 0;

        //Perks 
        public static int barter { get; set; } = 20;
        public static int speech { get; set; } = 20;
        public static int perception { get; set; } = 20;
        public static int nextLevel { get; set; } = 100;


        public static void DisplaySkills(bool inBattle = false) {
            UpdateSkills();
            for (int i = 0; i < skills.Count; i++) {
                Console.WriteLine($"{i + 1}- {skills[i].DisplaySkill(inBattle)}");
            }
            if (!inBattle) {
                Console.WriteLine("enter anything to go back");
                string input = Console.ReadLine();
            }
        }


        public static void DisplayActiveQuests() {
            if (activeQuests.Count == 0) { Console.WriteLine("You have no active quests available. Check the town billboard."); return; }
            while (true) {
                for (int i = 0; i < activeQuests.Count; i++) {
                    Console.WriteLine((i + 1).ToString() + "- " + activeQuests[i].name + ". Level " + activeQuests[i].level.ToString());
                }
                Console.WriteLine("Choose a quest to view details of.");
                int input = EntryManager.Entry(upperLimit: activeQuests.Count);

                if (input == 0) { return; } else {
                    activeQuests[input - 1].Inspect();
                    Console.WriteLine("Embark?");
                    Console.WriteLine("1-Yes  2- No");

                    int choice = EntryManager.Entry(LlowerLimit: 1, upperLimit: 2);
                    if (choice == 2) { return; } else {
                        activeQuests[input - 1].Embark();
                    }
                }

            }


        }

        public static void DisplayMisc(bool use = false) {
            if (miscItems.Count == 0) { Console.WriteLine("you have no misc items."); return; }

            for (int i = 0; i < miscItems.Count; i++) {
                Console.WriteLine($"{i + 1}- {miscItems[i].name}");
            }
            if (!use) {
                Console.WriteLine("Enter anything to go back.");
                string input = Console.ReadLine();
            }
        }
        public static void UseMisc() {
            DisplayMisc(use : true);
            Console.WriteLine("Choose an item to use. 0 to return.");
            int input = EntryManager.Entry(upperLimit: miscItems.Count);

            if (input == 0) {
                return;
            } else {
                miscItems[input - 1].Use();
                miscItems.RemoveAt(input - 1);

            }

        }
        public static void LevelUp() {
            Console.WriteLine("Level Up!");
            level++;
            Console.WriteLine("You are level " + level);
            Console.WriteLine("You have 1 stat point and 5 perk points.");
            Console.WriteLine("Choose a stat to spend your stat point on.");
            Console.WriteLine("1- Attack: " + BASE_ATTACK[0]);
            Console.WriteLine("2- Defence :" + BASE_DEFENCE);
            Console.WriteLine("3- HP x 5 : " + MAX_HP);
            int input = EntryManager.Entry(upperLimit: 3, LlowerLimit: 1);

            if (input == 1) {
                BASE_ATTACK[0]++;
                BASE_ATTACK[1]++;
            } else if (input == 2) {
                BASE_DEFENCE++;
            } else if (input == 3) {
                MAX_HP += 5;
            }

            Console.WriteLine("Choose a perk to put your perk points on.");
            Console.WriteLine("1- Speech: " + speech);
            Console.WriteLine("2- Barter: " + barter);
            Console.WriteLine("3- Perception: " + perception);
            input = EntryManager.Entry(upperLimit: 3, LlowerLimit: 1);

            if (input == 1) { speech += 5; } else if (input == 2) { barter += 5; } else if (input == 3) { perception += 5; }

            HP = MAX_HP;
            Console.WriteLine("Done");
        }

        public static void GainExperience(int amount) {
            experience += amount;
            if (experience >= nextLevel) {
                experience = experience % nextLevel;
                LevelUp();
            }

        }

        public static Random rng = new Random();

        public static void Heal(int amount) {
            if (HP + amount >= MAX_HP) { HP = MAX_HP; } else { HP += amount; }
        }
        public static int DealDamage() { return rng.Next(ATTACK[0], ATTACK[1] + 1); }
        public static void DisplayArmors() {
            if (Armors.Count == 0) { Console.WriteLine("You don't have any armor."); return; }


            for (int i = 0; i < Armors.Count; i++) {
                Console.WriteLine((i + 1).ToString() + "- " + Armors[i].Display());
                if (Armors[i] == equippedArmor) { Console.Write(" (Equipped) "); }

            }
            Console.WriteLine("Enter the index of the Armor to equip it. Enter 0 to return.");
            int input = EntryManager.Entry(upperLimit: Armors.Count);

            if (input == 0) {
                return;
            } else {
                equippedArmor = Armors[input - 1];
                Console.WriteLine("You equippped " + equippedArmor.name);
                return;
            }



        }


        public static void DisplayWeapons() {
            if (Weapons.Count == 0) { Console.WriteLine("You have no weapons."); return; }

            for (int i = 0; i < Weapons.Count; i++) {

                Console.WriteLine((i + 1).ToString() + "- " + Weapons[i].Display());
                if (Weapons[i] == equippedWeapon) {
                    Console.Write(" (Equipped) ");
                }
            }
            int input = EntryManager.Entry(upperLimit: Weapons.Count);

            if (input == 0) { return; } else {
                equippedWeapon = Weapons[input - 1];
                Console.WriteLine("You equipped " + equippedWeapon.name);
                return;
            }


        }
        public static void PrintStats() {
            Console.WriteLine($"Player HP: {HP}/{MAX_HP} Attack: {ATTACK[0]}-{ATTACK[1]} Defence: {DEFENCE} Speed: {SPEED} Accuracy: {Accuracy} .");
        }

        public static void BrowseInventory() {

            while (true) {
                Console.WriteLine("1- My Weapons");
                Console.WriteLine("2-My Armors");
                Console.WriteLine("3- My Misc Items");
                Console.WriteLine("0- Return");
                int input = EntryManager.Entry(upperLimit: 3);

                if (input == 0) { return; }
                if (input == 1) { DisplayWeapons(); }
                if (input == 2) { DisplayArmors(); }
                if (input == 3) { DisplayMisc(); }

            }

        }



        public static void LoadPlayer(string fileName) {
            var pd = new PlayerData();
            pd.LoadPlayerData(fileName);
        }
        public static void SavePlayerData(string fileName) {
            var pd = new PlayerData();
            pd.SavePlayerData();
            DataManager.Save<PlayerData>(fileName, pd);

        }
        public static void UpdateSkills() {
            skills.RemoveAll(item => item == null);
        }


    }


}

