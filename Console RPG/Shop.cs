using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG {
    public class Shop {




        public List<Weapon> weapons { get; set; }
 public        List<Armor> armors { get; set; }
        List<Misc> miscItems { get; set; }


        public Random rng = new Random();

        private void Greetings() {
            string[] greetingList = new string[] {
                "Come in sire,  check out our merchendise.",
                "How can i help you sire?"
            };

            Console.WriteLine(greetingList[rng.Next(0, greetingList.Length)]);
        }

        public void Enter() {
            Greetings();
            while (true) {
                Console.WriteLine("1- Buy");
                Console.WriteLine("2- Sell");
                Console.WriteLine("0- Leave");
                int input = EntryManager.Entry(upperLimit: 2);

                if (input == 0) { Console.WriteLine("Come back again later..."); return; }
                if (input == 1) { BuyScreen(); }

            }

        }

        private void BuyScreen() {

            Console.WriteLine("Okay what do you need?");
            while (true) {


                Console.WriteLine("1- Weapons  2- Armors  3- Misc  0-Nevermind...");
                int input = EntryManager.Entry(upperLimit: 3);

                if (input == 0) { return; }

                if (input == 1) { BrowseWeapons(); } else if (input == 2) { BrowseArmors(); }



            }
        }

        private void BrowseArmors() {
            if (armors.Count == 0) {
                Console.WriteLine("I don't have any armors for now, you have to wait for the next shipment.");
                return;
            }
            Console.WriteLine("Sure, lets see if we can find a fit for you.");

            while (true) {

                for (int i = 0; i < armors.Count; i++) {
                    Console.WriteLine($" {i + 1}- {armors[i].Display()}");
                }
                int input = EntryManager.Entry(upperLimit: armors.Count);
                if (input == 0) {
                    return;
                } else {
                    if (armors[input - 1].price > Player.MONEY) {
                        Console.WriteLine("You need more gold for that.");
                        continue;
                    }
                    Player.Armors.Add(armors[input - 1]);
                    Player.MONEY -= armors[input - 1].price;
                    Console.WriteLine($"You bought {armors[input - 1].name}, you now have {Player.MONEY} gold left.");
                    armors.RemoveAt(input - 1);
                    return;
                }


            }

        }

        private void BrowseWeapons() {

            if (weapons.Count == 0) {
                Console.WriteLine("I don't have any weapons for sale right now, you have to wait for the next shipment.");
                return;
            }
            Console.WriteLine("Take a look");
            while (true) {
                for (int i = 0; i < weapons.Count; i++) {
                    Console.WriteLine($"{i + 1}- {weapons[i].Display()}");
                }
                Console.WriteLine("You have " + Player.MONEY.ToString() + " gold.");
                int input = EntryManager.Entry(upperLimit: weapons.Count);

                if (input == 0) { return; }

                if (weapons[input - 1].price > Player.MONEY) { Console.WriteLine("You don't have enough money for that."); } else {
                    Player.Weapons.Add(weapons[input - 1]);
                    Console.WriteLine("Thank you for your purchase!");
                    Console.WriteLine("Gold -" + weapons[input - 1].price.ToString());
                    Player.MONEY -= weapons[input - 1].price;
                    weapons.RemoveAt(input - 1);
                    return;
                }

            }

        }


        public void LoadShop(string fileName) {
            var fileData = DataManager.Load<Shop>(fileName);
            weapons = fileData.weapons;

        }
    }

}