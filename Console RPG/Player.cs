using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Text;

namespace Console_RPG {
    public static class Player {

        public static int BASE_ACCURACY { get; set; } = 70;
        public static int MAX_HP { get; set; } = 10;
        public static int HP { get; set; } = 10;
        public static int[] ATTACK { get; set; } = new int[] { 1, 1 };
        public static int[] BASE_ATTACK { get; set; } = new int[] { 1, 1 };
        public static int Accuracy { get; set; } = 70;
        public static int BASE_DEFENCE { get; set; } = 0;
        public static int DEFENCE { get; set; } = 0;
        public static int BASE_SPEED { get; set; } = 5;
        public static int SPEED { get; set; } = 5;

        //Character stats
        public static int MONEY { get; set; } = 100;
        public static int level { get; set; } = 1;
        public static int experience { get; set; } = 0;
        public static List<Weapon> Weapons { get; set; } = new List<Weapon>();
        public static Weapon equippedWeapon { get; set; } = null;
        public static List<Armor> Armors { get; set; } = new List<Armor>();
        public static Armor equippedArmor { get; set; } = null;



        //Perks 
        public static int barter { get; set; } = 20;
        public static int speech { get; set; } = 20;
        public static int perception { get; set; } = 20;



        public static Random rng = new Random();

        public static void Heal(int amount) {
            if (HP + amount >= MAX_HP) { HP = MAX_HP; } else { HP += amount; }
        }
        public static int DealDamage() { return rng.Next(ATTACK[0], ATTACK[1] + 1); }
        public static void DisplayArmors() {
            if (Armors.Count == 0) { Console.WriteLine("You don't have any armor.");return; }

            while (true) {
                for(int i =0; i< Armors.Count; i++) {
                    if (Armors[i] == equippedArmor) { Console.Write("(Equipped) ");}
                    Console.WriteLine((i + 1).ToString() + "- " + Armors[i].Display());
                }
                Console.WriteLine("Enter the index of the Armor to equip it. Enter 0 to return.");
                int input = Int32.Parse(Console.ReadLine());
                while(input>Armors.Count || input < 0) {
                    Console.WriteLine("Invalid entry, enter again.");
                    input = Int32.Parse(Console.ReadLine());
                }

                if (input == 0) {
                    return;
                } else {
                    equippedArmor = Armors[input - 1];
                    Console.WriteLine("You equippped " + equippedArmor.name);
                }

            }


        }
        
        
        public static void DisplayWeapons() {
            if (Weapons.Count == 0) { Console.WriteLine("You have no weapons."); return; }

            while (true) {
                
                for (int i = 0; i < Weapons.Count; i++) {
                    if (Weapons[i] == equippedWeapon) { Console.Write("(Equipped) "); }
                    Console.WriteLine((i + 1).ToString() + "- " + Weapons[i].Display());
                }
                Console.WriteLine("Enter the index of the weapon to equip it. Enter 0 to return.");
                int input = Int32.Parse(Console.ReadLine());
                while (input < 0 || input > Weapons.Count) {
                    Console.WriteLine("Invalid entry, try again.");
                    input = Int32.Parse(Console.ReadLine());
                }
                if (input == 0) { return; } else {
                    equippedWeapon = Weapons[input - 1];
                    Console.WriteLine("You equipped " + equippedWeapon.name);
                }

            }

        }

public static void BrowseInventory (){

            while (true) {
                Console.WriteLine("1- My Weapons");
                Console.WriteLine("2-My Armors");
                Console.WriteLine("3- My Misc Items");
                Console.WriteLine("4- Return");
                int input = Int32.Parse(Console.ReadLine());
            while(input<1 || input > 4) {
                    Console.WriteLine("Invalid entry, enter 1-4");
                    input = Int32.Parse(Console.ReadLine());
                }
                if (input == 4) { return; }
                if (input == 1) {DisplayWeapons();}
                if (input == 2) { DisplayArmors(); }   
            
            
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


    }


}

