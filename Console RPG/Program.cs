using System;

namespace Console_RPG {
    class Program {
        static void Main(string[] args) {
            
                string basePath = @"..\..\..\saveData\";

            Game test= new Game();
            //test.LoadGame(basePath + "test");
            var pd = new PlayerData();
            pd.LoadPlayerData(basePath + "player");
test.town.TownLoop();
            DataManager.Save<Game>(basePath + "test", test);
            pd.SavePlayerData();
            DataManager.Save<PlayerData>(basePath+"player", pd);
        
        }
        




    }
}
