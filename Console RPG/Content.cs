using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Console_RPG {
    public static class Content {

        public static Weapon rustyDagger { get; set; } = new Weapon {
            name = "Rusty Dagger",
            price = 35,
            description = "Almost harmless...",
            durability = 7,
            Damage = new int[] { 1, 2 }
        };

        public static Weapon hardStick { get; set; } = new Weapon {
            name = "Hard Stick",
            description = "Just a hard stick.",
            price = 50,
            Damage = new int[] { 2, 2 },
            durability = 10

        };

        public static Weapon pitchfork { get; set; } = new Weapon {
            name = "Pitchfork",
            description = "Time to rebel.",
            price = 60,
            Damage = new int[] { 1, 3 },
            durability = 10
        };

        public static Weapon shortSword { get; set; } = new Weapon {
            name = "Short Sword",
            description = "It's a short sword.",
            price = 90,
            durability = 15,
            Damage = new int[] { 2, 3 },
            level = 2
        };

        public static Weapon steelDagger { get; set; } = new Weapon {
            name = "Steel Dagger",
            description = "Not a joke.",
            statBoost = new string[] { "speed", "1" },
            Damage = new int[] { 2, 3 },
            durability = 20,
            price = 125,
            level = 2
        };

        public static Weapon shortSpear { get; set; } = new Weapon {
            name = "Short Spear",
            description = "Has a nice piercing thrust to it.",
            price = 175,
            weaponSkill = new Skill { name = "Piercing Blow", defaultCooldown = 3, dmgMultiplier = 0.7, accMultiplier = 1.15 },
            Damage = new int[] { 2, 5 },
            durability = 8,
            level = 2

        };

        public static Skill basicAttack { get; set; } = new Skill {
            name = "Basic Attack",
            description = "Normal attack.",
            accMultiplier = 0.85,
            skillLevel = 1
        };

        public static Armor paesantClothes { get; set; } = new Armor {
            name = "Paesant Clothes",
            description = "Quite plebian.",
            Defence = 1,
            price = 50
        };

        public static Armor oldLeatherVest { get; set; } = new Armor {
            name = "Old Leather Vest",
            description = "Grandpa used to wear something like this...",
            price = 80,
            Defence = 2
        };

        public static Shop merchant1 { get; set; } = new Shop {
            weapons = new List<Weapon>() { rustyDagger, hardStick, shortSword, pitchfork, shortSpear, steelDagger },
            armors = new List<Armor>() { paesantClothes, oldLeatherVest }

        };

        public static Enemy strayDog { get; set; } = new Enemy {
            name = "Stray Dog",
            level = 1,
            SPEED = 5,
            BASE_DEFENCE = 1,
            DEFENCE = 1,
            MAX_HP = 10,
            HP = 10,
            ATTACK = new int[] { 2, 3 },
            BASE_ATTACK = new int[] { 2, 3 }

        };
        public static Enemy giantRat { get; set; } = new Enemy {
            name = "Giant Rat",
            MAX_HP = 6,
            HP = 6, DEFENCE = 0,
            BASE_DEFENCE = 0,
            BASE_ATTACK = new int[] { 1, 2 },
            ATTACK = new int[] { 1, 2 },
            level = 1,
            SPEED = 4

        };
        public static Quest ratTrouble { get; set; } = new Quest {
            name = "Rat Trouble",
            description = "I have a giant rat in my basement and i'm too scared to kill it, can you take care of it?",
            rewardMoney = 20,
            rewardExperience = 10,
            map = new string[] { "finalEnemy" },
            finalEnemy = giantRat,
            questCompleteDialog = "Thank you,"
        };
        public static List<List<Quest>> billboard { get; set; } = new List<List<Quest>>() { new List<Quest>() { ratTrouble } };





    }
}