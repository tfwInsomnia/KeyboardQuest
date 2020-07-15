using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG {
    public class PlayerData { 



        public int BASE_ACCURACY { get; set; } = 70;
    public int MAX_HP { get; set; } = 10;
    public int HP { get; set; } = 10;
    public int[] ATTACK { get; set; } = new int[] { 1, 1 };
    public int[] BASE_ATTACK { get; set; } = new int[] { 1, 1 };
    public int Accuracy { get; set; } = 70;
    public int BASE_DEFENCE { get; set; } = 0;
    public int DEFENCE { get; set; } = 0;
    public int BASE_SPEED { get; set; } = 5;
    public int SPEED { get; set; } = 5;

    //Character stats
    public int MONEY { get; set; } = 100;
    public int level { get; set; } = 1;
    public int experience { get; set; } = 0;
    public List<Weapon> Weapons { get; set; } = new List<Weapon>();
    public Weapon equippedWeapon { get; set; } = null;
    public List<Armor> Armors { get; set; } = new List<Armor>();
    public Armor equippedArmor { get; set; } = null;



    //Perks 
    public int barter { get; set; } = 20;
    public int speech { get; set; } = 20;
    public int perception { get; set; } = 20;



    public Random rng = new Random();

    public void SavePlayerData() {
        Weapons = Player.Weapons;
        Armors = Player.Armors;
        BASE_ATTACK = Player.BASE_ATTACK;
        ATTACK = Player.ATTACK;
        DEFENCE = Player.DEFENCE;
        BASE_DEFENCE = Player.BASE_DEFENCE;
        SPEED = Player.SPEED;
        BASE_SPEED = Player.BASE_SPEED;
        Accuracy = Player.Accuracy;
        BASE_ACCURACY = Player.BASE_ACCURACY;
        MONEY = Player.MONEY;
        level = Player.level;
        experience = Player.experience;
        equippedWeapon = Player.equippedWeapon;
        equippedArmor = Player.equippedArmor;
        speech = Player.speech;
        barter = Player.barter;
        perception = Player.perception;
        rng = Player.rng;
        
    }

        public void LoadPlayerData(string fileName) {
            var f = DataManager.Load<PlayerData>(fileName);


            Weapons = f.Weapons;
            Armors = f.Armors;
            BASE_ATTACK = f.BASE_ATTACK;
            ATTACK = f.ATTACK;
            DEFENCE = f.DEFENCE;
            BASE_DEFENCE = f.BASE_DEFENCE;
            SPEED = f.SPEED;
            BASE_SPEED = f.BASE_SPEED;
            Accuracy = f.Accuracy;
            BASE_ACCURACY = f.BASE_ACCURACY;
            MONEY = f.MONEY;
            level = f.level;
            experience = f.experience;
            equippedWeapon = f.equippedWeapon;
            equippedArmor = f.equippedArmor;
            speech = f.speech;
            barter = f.barter;
            perception = f.perception;
            rng = f.rng;

            //transfer data

            Player.Weapons = Weapons;
            Player.Armors = Armors;
            Player.BASE_ATTACK = BASE_ATTACK;
            Player.ATTACK = ATTACK;
            Player.DEFENCE = DEFENCE;
            Player.BASE_DEFENCE = BASE_DEFENCE;
            Player.SPEED = SPEED;
            Player.BASE_SPEED = BASE_SPEED;
            Player.Accuracy = Accuracy;
            Player.BASE_ACCURACY = BASE_ACCURACY;
            Player.MONEY = MONEY;
            Player.level = level;
            Player.experience = experience;
            Player.equippedWeapon = equippedWeapon;
            Player.equippedArmor = equippedArmor;
            Player.speech = speech;
            Player.barter = barter;
            Player.perception = perception;
            Player.rng = rng;


        }


    }
}
