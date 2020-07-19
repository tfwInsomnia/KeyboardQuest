using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace Console_RPG {
    public class Battle {

        public Enemy enemy { get; set; }
        public bool escape { get; set; } = false;
        public Battle(Enemy e) {
            enemy = e;
            for(int i = 1; true; i++) {
                Console.WriteLine($"turn {i}");

                PlayerTurn();
                if (enemy.HP <= 0) {
                    Console.WriteLine($"you are victorious.");
                    return;
                }
                enemy.TakeAction();
            }

        }


        private void PlayerDealDamage(bool stun = false, double multiplier = 1.00, double accuracyMultiplier = 1.00, bool pierce =false ) {
            int roll = Player.rng.Next(1, 21);
            if (roll > Player.Accuracy * accuracyMultiplier) {
                Console.WriteLine("You missed entirely...");
                return;
            }
            int dmg = (int)(Player.DealDamage() * multiplier);

            if (stun) {
                if (enemy.DEFENCE >= dmg) {
                    Console.WriteLine($"You tried to stun {enemy.name} but the enemy completely blocked your attack.");
                    return;
                } else {
                    int netDmg = dmg - enemy.DEFENCE;
                    enemy.HP -= netDmg;
                    Console.WriteLine($"You hit and stun for {netDmg}, enemy hp {enemy.HP}");
                    PlayerTurn(enemyStunned : true);
                    return;
                }

            }

            if (pierce) {
                enemy.HP -= (int)(dmg * multiplier);
                Console.WriteLine($"You struck past the enemy armor and hit for {dmg}, enemy hp{enemy.HP}");
                return;
            }


            if (enemy.DEFENCE >= dmg) {
                Console.WriteLine($"You attacked for {dmg} but {enemy.name} blocked it all.");
                return;
            } else {
                int netDmg = dmg - enemy.DEFENCE;
                Console.WriteLine($"You attacked for {dmg}, {enemy.name} hp -{netDmg}, enemy has{enemy.HP-netDmg} hp left.");
                enemy.HP -= netDmg;
            }
        }
        private void UpdateCooldowns() {
            
            foreach (Skill sk in Player.skills) {
                if (sk.cooldown > 0) {
                    sk.cooldown--;
                }

            }
        }
        private void PlayerTurn(bool enemyStunned= false) {

            UpdateCooldowns();

            while (true) {
                if (enemyStunned) {
                    Console.WriteLine("You can escape while the enemy is stunned");
                }

                Console.WriteLine("1- attack, 2- use item, 3-try to escape (20%) 0-Display stats");

                int input = EntryManager.Entry(3);
                if (input == 0) {
                    Console.WriteLine($"Player | hp {Player.HP}/{Player.MAX_HP} | Attack {Player.ATTACK[0]}-{Player.ATTACK[1]} | Defence {Player.DEFENCE}");
                    Console.WriteLine($"Enemy | HP {enemy.HP}/{enemy.MAX_HP} | Attack {enemy.ATTACK[0]}-{enemy.ATTACK[1]} | Defence {enemy.DEFENCE}");
                } else if (input == 3) {
                    if (enemyStunned) {
                        Console.WriteLine("You escape while you have the chance");
                        //end battle
                        escape = true;

                        return;
                    }
                    int r = Player.rng.Next(1, 6);
                    if (r == 5) {
                        Console.WriteLine("You managed to escape.");
                        escape = true;
                    } else {
                        Console.WriteLine("You tried to escape but couldn't.");
                    }
                    return;

                } else if (input == 1) {

                    while (true) {
                        Player.DisplaySkills(inBattle : true);
                        string strInput = Console.ReadLine();
                        while (!EntryManager.IsDigitsOnly(strInput)) {
                            strInput = Console.ReadLine();
                        }
                        int input2 = Int32.Parse(strInput);
                        if (input2 < 0 || input2 > Player.skills.Count || Player.skills[input2 - 1].cooldown != 0) {

                            Console.WriteLine($"you can't do that , enter 0-{Player.skills.Count}.");
                            continue;
                        }

                        if (input2 == 0) {
                            break;
                        } else {
                            //handle skills here
                            if (Equals(Player.skills[input2 - 1].name, "Basic Attack")) {
                                PlayerDealDamage();
                                return;
                            } else if (Equals(Player.skills[input2 - 1].name, "Heavy Attack")) {
                                PlayerDealDamage(multiplier : Player.skills[input2 - 1].dmgMultiplier, accuracyMultiplier:Player.skills[input2-1].accMultiplier);
                                Player.skills[input2 - 1].cooldown = Player.skills[input2 - 1].defaultCooldown;
                                return;
                            } else if (Equals(Player.skills[input2 - 1].name, "Piercing Blow")) {
                                Console.WriteLine($"you strike ignoring your enemy's armor.");
                                Player.skills[input2 - 1].cooldown = Player.skills[input2 - 1].defaultCooldown;
                                PlayerDealDamage(multiplier : Player.skills[input2 - 1].dmgMultiplier, accuracyMultiplier : Player.skills[input2 - 1].accMultiplier, pierce : true);
                                return;
                            } else if (Equals(Player.skills[input2 - 1].name, "Stunning Blow")) {
                                Player.skills[input2 - 1].cooldown = Player.skills[input2 - 1].defaultCooldown;
                                PlayerDealDamage(multiplier : Player.skills[input2 - 1].dmgMultiplier, accuracyMultiplier : Player.skills[input2 - 1].accMultiplier, stun : true);

                            }
                        }

                    }


                } else if (input == 2) {

                    while (true) {

                        Player.DisplayMisc();
                        if (Player.miscItems.Count == 0) { break; }
                        int input2 = Int32.Parse(Console.ReadLine());
                        while (input2 < 0 || input2 > Player.miscItems.Count) {
                            Console.WriteLine($"Invalid entry, enter 0-{Player.miscItems.Count}.");
                            input2 = Int32.Parse(Console.ReadLine());
                        }
                        if (input2 == 0) {
                            break;
                        } else {

                            Player.miscItems[input2 - 1].Use();
                            Player.miscItems.RemoveAt(input2 - 1);
                            return;

                        }
                    }

                }

            }
        }

    }
}