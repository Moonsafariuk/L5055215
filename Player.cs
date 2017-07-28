using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5055215.MyClasses
{
    public class Player
    {
        public string CharacterName;
        public int CurrentScore;
        public int HighScore;
   
        public int UserDatabaseID;
        public int HighscoreLevel1;
        public int HighscoreLevel2;
        public int HighscoreLevel3;
        public int HighscoreLevel4;
        public int PlayerLevelCount;

        public Player() {
            CharacterName = "emptyCharacterName";
            CurrentScore = -1;
            HighScore = -1;
        }

        public Player(string characterName , int currentScore, int highScore, int databaseID)
        {
            this.CharacterName = characterName;
            this.CurrentScore = currentScore;
            this.HighScore = highScore;
            this.UserDatabaseID = databaseID;

        }

        public Player(string name, string characterName, int currentScore, int highScore)
        {
            this.CharacterName = characterName;
            this.CurrentScore = currentScore;
            this.HighScore = highScore;         
        }

        public Player(string characterName, int userDatabaseID, List<string> prevHighScores) {

            this.CharacterName = characterName;
            this.UserDatabaseID = userDatabaseID;
            this.PlayerLevelCount = prevHighScores.Count();
           
            //set previous highscore levels - 4 levels          
          
            switch (PlayerLevelCount)
            {
                case 1:
                    HighscoreLevel1 = Int32.Parse(prevHighScores[0]);
                    this.HighScore = HighscoreLevel1;
                    break; 
                case 2:
                    HighscoreLevel1 = Int32.Parse(prevHighScores[0]);
                    HighscoreLevel2 = Int32.Parse(prevHighScores[1]);
                    this.HighScore = HighscoreLevel2;
                    break;
                case 3:
                    HighscoreLevel1 = Int32.Parse(prevHighScores[0]);
                    HighscoreLevel2 = Int32.Parse(prevHighScores[1]);
                    HighscoreLevel3 = Int32.Parse(prevHighScores[2]);
                    this.HighScore = HighscoreLevel3;
                    break;
                case 4:
                    HighscoreLevel1= Int32.Parse(prevHighScores[0]);
                    HighscoreLevel2= Int32.Parse(prevHighScores[1]);
                    HighscoreLevel3= Int32.Parse(prevHighScores[2]);
                    HighscoreLevel4= Int32.Parse(prevHighScores[3]);
                    this.HighScore = HighscoreLevel4;
                    break;

                default:
                    break;
            }

        }

        #region manualSetMethods
        // manual set methods

        //public void setName(string userName)
        //{
        //    this.Name = userName;
        //}

        public void setCharacterName(string userCharacterName)
        {
            CharacterName = userCharacterName;
        }


        public void setCurrentScore(int userGameScore)
        {
            CurrentScore = userGameScore;

        }


        public void setHighScore(int UserHighScore)
        {
            HighScore = UserHighScore;
        }
        // end manual set methods
        #endregion











    }
}
