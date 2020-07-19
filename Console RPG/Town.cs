using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Console_RPG {
    public class Town {



        public List<string> activityList { get; set; }
        public Shop blacksmith { get; set; }
        public List<List<Quest>> billboard { get; set; } = new List<List<Quest>>();
        public bool exitGame { get; set; } = false;

        private void DisplayBillboard() {
            Console.WriteLine("Lets see what the townfolk needs doing.");
            Console.WriteLine("check quests of level...");
            Console.WriteLine($"Enter between 1 and {billboard.Count}");


            int input1 = EntryManager.Entry(upperLimit: billboard.Count);

            if (input1 == 0) { return; } else {

                while (true) {

                    for (int i = 0; i < billboard[input1 - 1].Count; i++) {
                        Console.WriteLine((i + 1).ToString() + "- " + billboard[input1 - 1][i].Display());
                    }
                    Console.WriteLine("Choose a quest to inspect.");
                    int input2 = EntryManager.Entry(upperLimit: billboard[input1 - 1].Count);

                    if (input2 == 0) { return; } else {
                        billboard[input1 - 1][input2 - 1].Inspect();
                        Console.WriteLine("Do you want to take this quest? ");
                        Console.WriteLine("1-yes,  2- no");
                        int choice = EntryManager.Entry(LlowerLimit: 1, upperLimit: 2);
                        if (choice == 2) {
                            return;
                        } else {
                            Player.activeQuests.Add(billboard[input1 - 1][input2 - 1]);
                            billboard[input1 - 1].RemoveAt(input2 - 1);
                            return;
                        }

                    }
                }

            }


        }

        private void DisplayMenu() {
            while (true) {
                Console.WriteLine("1- Inventory");
                Console.WriteLine("2- My Quests");
                Console.WriteLine("0- Close Menu");
                Console.WriteLine("3- Save and Quit");
                int input = EntryManager.Entry(upperLimit:3 );

                if (input == 0) { return; }
                if(input == 1) { Player.BrowseInventory(); }
                if (input == 2) { Player.DisplayActiveQuests(); }
                if (input == 3) {
                    exitGame = true; 
                    return;
                

                }
            }

        }

        public void TownLoop() {

            while (true) {
                if (exitGame) { return; }

                Console.WriteLine("You're in the Town, what do you want to do?");
                foreach (string activity in activityList) { Console.WriteLine(activity); }
                Console.WriteLine("Enter 0 to open the menu.");
                int input = EntryManager.Entry(upperLimit: 3);

                if (input == 1) { blacksmith.Enter(); }
                if (input == 0) { DisplayMenu(); }
                if (input == 3) { DisplayBillboard(); }


            }

        }

    }
}
