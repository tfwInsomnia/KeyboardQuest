using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG {
    public class Shop {



        public List<Weapon> weapons { get; set; }
        List<Item> armors { get; set; }
        List<Item> miscItems { get; set; }


        public Random rng = new Random();

        private void Greetings() {
            string[] greetingList = new string[] { "Come in, come in, it's 0% off day!", "Oh it's you again...", "What can i do for you?", "Caviat emptor." };


            //Console.WriteLine(greetingList[rng.Next(0, greetingList.Length + 1)]);
            Console.WriteLine("Welcome sire, how may i help you?");
        }

        public void Enter() {
            Greetings();
            while (true) {
                Console.WriteLine("1- Buy");
                Console.WriteLine("2- Sell");
                Console.WriteLine("3- Leave");
                int input = Int32.Parse(Console.ReadLine());
                while (input < 1 || input > 3) {
                    Console.WriteLine("Invalid entry. Enter 1, 2 or 3.");
                    input = Int32.Parse(Console.ReadLine());
                }
                if (input == 3) { Console.WriteLine("Come back again later..."); return; }
                if (input == 1) { BuyScreen(); }

            }


        }

        private void BuyScreen() {

            Console.WriteLine("Okay what do you need?");

            while (true) {
                Console.WriteLine("1- Weapons  2- Armors  3- Misc  4-Nevermind...");
                int input = Int32.Parse(Console.ReadLine());
                while (input < 1 || input > 4) {
                    Console.WriteLine("Invalid input, enter 1-4.");
                    input = Int32.Parse(Console.ReadLine()); input = Int32.Parse(Console.ReadLine());
                }
                if (input == 4) { return; }
                if (input == 1) { BrowseWeapons(); }

            }

        }

        private void BrowseWeapons() {


            Console.WriteLine("Enter the index of the weapon you want to buy. Enter 0 to return.");
            while (true) {
                for (int i = 1; i <= weapons.Count; i++) {
                    Console.WriteLine(i.ToString() + "- " + weapons[i - 1].Display() + weapons[i - 1].price.ToString() + " gold");
                }

                Console.WriteLine("You have " + Player.MONEY.ToString() + " gold.");
                int input = Int32.Parse(Console.ReadLine());

                while (input > weapons.Count || input < 0) {
                    Console.WriteLine("Invalid entry. Enter again:");
                    input = Int32.Parse(Console.ReadLine());
                }
                if (input == 0) { return; }

                if (weapons[input - 1].price > Player.MONEY) { Console.WriteLine("You don't have enough money for that."); } else {
                    Player.Weapons.Add(weapons[input - 1]);
                    Console.WriteLine("Thank you for your purchase!");
                    Player.MONEY -= weapons[input - 1].price;
                    weapons.RemoveAt(input - 1);

                }

            }

        }


        public void LoadShop(string fileName) {
            var fileData = DataManager.Load<Shop>(fileName);
            weapons = fileData.weapons;

        }
    }

}