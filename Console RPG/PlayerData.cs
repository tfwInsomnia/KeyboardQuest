using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG {
    public class PlayerData {

        public List<Weapon> Weapons { get; set; } = new List<Weapon>();
        public List<Misc> miscItems { get; set; } = new List<Misc>();
        public List<Quest> activeQuests { get; set; } = new List<Quest>();
        public List<Quest> finishedQuests { get; set; } = new List<Quest>();

        public Weapon equippedWeapon { get; set; } = null;
        public List<Armor> Armors { get; set; } = new List<Armor>();
        public Armor equippedArmor { get; set; } = null;

        public int BASE_ACCURACY { get; set; } = 14;
        public int MAX_HP { get; set; } = 10;
        public int HP { get; set; } = 10;
        public int[] BASE_ATTACK { get; set; } = new int[] { 1, 1 };

        public int Accuracy { get; set; } = 14;
        public int BASE_DEFENCE { get; set; } = 0;

        public int BASE_SPEED { get; set; } = 5;
        public int SPEED { get; set; } = 5;

        //Character stats
        public int MONEY { get; set; } = 100;
        public int level { get; set; } = 1;
        public int experience { get; set; } = 0;

        //Perks 
        public int barter { get; set; } = 20;
        public int speech { get; set; } = 20;
        public int perception { get; set; } = 20;
        public int nextLevel { get; set; } = 100;
        public Random rng { get; set; } = new Random();





        public void SavePlayerData() {
            this.Weapons = Player.Weapons;
            this.Armors = Player.Armors;
            this.BASE_ATTACK = Player.BASE_ATTACK;
            this.BASE_DEFENCE = Player.BASE_DEFENCE;
            this.SPEED = Player.SPEED;
            this.BASE_SPEED = Player.BASE_SPEED;
            this.Accuracy = Player.Accuracy;
            this.BASE_ACCURACY = Player.BASE_ACCURACY;
            this.MONEY = Player.MONEY;
            this.level = Player.level;
            this.experience = Player.experience;
            this.nextLevel = Player.nextLevel;
            this.equippedWeapon = Player.equippedWeapon;
            this.equippedArmor = Player.equippedArmor;
            this.speech = Player.speech;
            this.barter = Player.barter;
            this.perception = Player.perception;
            this.rng = Player.rng;
            this.miscItems = Player.miscItems;
            this.activeQuests = Player.activeQuests;
            this.finishedQuests = Player.finishedQuests;

        }

        public void LoadPlayerData(string fileName) {
            var f = DataManager.Load<PlayerData>(fileName);


            //transfer data

            Player.Weapons = f.Weapons;
            Player.Armors = f.Armors;
            Player.BASE_ATTACK = f.BASE_ATTACK;
            Player.BASE_DEFENCE = f.BASE_DEFENCE;
            Player.SPEED = f.SPEED;
            Player.BASE_SPEED = f.BASE_SPEED;
            Player.Accuracy = f.Accuracy;
            Player.BASE_ACCURACY = f.BASE_ACCURACY;
            Player.MONEY = f.MONEY;
            Player.level = f.level;
            Player.experience = f.experience;
            Player.nextLevel = f.nextLevel;
            Player.equippedWeapon = f.equippedWeapon;
            Player.equippedArmor = f.equippedArmor;
            Player.speech = f.speech;
            Player.barter = f.barter;
            Player.perception = f.perception;
            Player.rng = f.rng;
            Player.miscItems = f.miscItems;
            Player.activeQuests = f.activeQuests;
            Player.finishedQuests = f.finishedQuests;


        }


    }
}
