using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Console_RPG {
    public class Game {
        public Town town { get; set; }
        
        public Game() {
            town = new Town {
                blacksmith = Content.merchant1,
            billboard = Content.billboard
        };        
    
            town.activityList = new List<string>() { "1-Go to the Blacksmith's Shop.", "2- Go to the Tavern.", "3- Check the Town Billboard." };


        
        }
        


        public void LoadGame(string fileName) {
            var fileData = DataManager.Load<Game>(fileName);
            
            town = fileData.town;


        }

    }
}
