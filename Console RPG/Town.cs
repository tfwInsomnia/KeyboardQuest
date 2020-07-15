using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Console_RPG {
    public class Town {



        public List<string> activityList { get; set; }
        public Shop blacksmith { get; set; }

        private void DisplayMenu() {
            while (true) {
                Console.WriteLine("1- Inventory");
                Console.WriteLine("2- My Quests");
                Console.WriteLine("3- Close Menu");
                Console.WriteLine("4- Save and Quit");
                int input = Int32.Parse(Console.ReadLine());
                while (input < 1 || input > 4) {
                    Console.WriteLine("Invalid entry, enter 1-4");
                    input = Int32.Parse(Console.ReadLine());
                }
                if (input == 3) { return; }
                if (input == 1) { Player.BrowseInventory(); }

            }

        }

        public void TownLoop() {

            while (true) {

                Console.WriteLine("You're in the Town, what do you want to do?");
                foreach (string activity in activityList) { Console.WriteLine(activity); }
                Console.WriteLine("Enter 0 to open the menu.");
                int input = Int32.Parse(Console.ReadLine());
                if (input == -1) { return; }
                while (input > activityList.Count || input < 0) {
                    Console.WriteLine("Invalid entry. Enter again: ");
                    input = Int32.Parse(Console.ReadLine());
                }
                if (input == 1) { blacksmith.Enter(); }
                if (input == 0) { DisplayMenu(); }
            }



        }

    }
}
