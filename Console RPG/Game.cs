using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Console_RPG {
    public class Game {
        public Town town { get; set; }
        public Shop shop { get; set; }

        public Game() {
            
    Player.MONEY = 100;
            Player.Weapons = new List<Weapon>();
            shop = new Shop();
            shop.weapons = new List<Weapon>();
            Weapon w1 = new Weapon();
            Weapon w2 = new Weapon();
            Weapon w3 = new Weapon();
            w1.name = "dagger";
            w1.price = 40;
            w1.Damage = new int[] { 2, 2 };
            w2.name = "sword";
            w2.Damage = new int[] { 2, 3 };
            w2.price = 60;
            w3.name = "spear";
            w3.price = 60;
            w3.Damage = new int[] { 1, 3 };
            shop.weapons.Add(w1);
            shop.weapons.Add(w2);
            shop.weapons.Add(w3);
            
            town = new Town();
            
            town.blacksmith = shop;
            town.activityList = new List<string>() { "1-Go to the Blacksmith's Shop.", "2- Go to the Tavern.", "3- Check the Town Billboard." };
            

        }
        


        public void LoadGame(string fileName) {
            var fileData = DataManager.Load<Game>(fileName);
            
            town = fileData.town;


        }

    }
}
