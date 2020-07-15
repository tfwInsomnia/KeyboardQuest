using System;

namespace Console_RPG {
    class Program {
        static void Main(string[] args) {
            
                string basePath = @"..\..\..\saveData\";

            Game test= new Game();

            Player.LoadPlayer(basePath + "player");

            test.LoadGame(basePath + "test");
            
            test.town.TownLoop();

            Console.WriteLine("Saving the progress....");
            DataManager.Save<Game>(basePath + "test", test);
            Player.SavePlayerData(basePath + "player");
            Console.WriteLine("done");
        }
        




    }
}
