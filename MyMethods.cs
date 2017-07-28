 using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace L5055215.MyMethods
{
    public class MyMethods
    {

        private static string DatabaseConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = J601617_Alex.accdb";
            //"Provider=Microsoft.ACE.OLEDB.12.0; Data Source =C:\\Users\\achapman\\Desktop\\J601617_Alex.accdb";
        //        private static string DatabaseConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source =C:\\Users\\Alex\\Desktop\\WorkingVersion\\L5055215\\L5055215\\bin\\Debug\\J601617_Alex.accdb";

        private static OleDbConnection openNewDatabaseConnection()
        {
            OleDbConnection retVal = new OleDbConnection(DatabaseConnectionString);
            return retVal;
        }
       

        public static int ReturnUserID(string Username , string Password)
        {
        
            // open db conneciton
            openNewDatabaseConnection();
            OleDbConnection cnnAccess = openNewDatabaseConnection();

            int userID = 0;

            //user check SQL
            string sqlString = @"SELECT * FROM tbl_Users WHERE Character_Name = ? AND Password = ?;";


            using (cnnAccess)
            {
                using (OleDbCommand cmd = new OleDbCommand(sqlString, cnnAccess))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("Character_Name", Username);
                    cmd.Parameters.AddWithValue("Password", Password);

                    int IDfromDB = 0;

                    cnnAccess.Open();

                    IDfromDB = (Int32)cmd.ExecuteScalar();

                    if (IDfromDB > 0)
                    {
                        userID = IDfromDB; 

                    }

                }                          
            }
            return userID;
        }

        public static void updateDatabaseWithScore(int userDatabaseId, int difficultyLevel, int score)
        {
            
            //take most recent score
            //send to DB
            //update currentUser.HighScore if new score is higher

        }

        public static List<KeyValuePair<string, string>> GetPreviousHighScores()
        {
            OleDbConnection cnnAccess = openNewDatabaseConnection();
            string sqlString = "SELECT * FROM qry_Get_Top_5_Highscore;";

            List<string> prevUsers = new List<string>();
            List<string> prevScores = new List<string>();         
            List<KeyValuePair<string, string>> retVal = new List<KeyValuePair<string, string>>();
            

            OleDbDataAdapter myCmd = new OleDbDataAdapter(sqlString, cnnAccess);
            cnnAccess.Open();

            DataSet dtSet = new DataSet();
            myCmd.Fill(dtSet, "qry_Get_Top_5_Highscore");
            DataTable dTable = dtSet.Tables[0];

            foreach (DataRow dtRow in dTable.Rows)
            {
                prevUsers.Add(dtRow["Character_Name"].ToString());
                prevScores.Add(dtRow["HighScore"].ToString());
            }

            for (int i = 0; i < prevUsers.Count; i++)
            {
            retVal.Add(new KeyValuePair<string, string>(prevUsers[i], prevScores[i]));
            }

            //MessageBox.Show(retVal[0].Key + " : " + retVal[0].Value);
            //MessageBox.Show(retVal[1].Key + " : " + retVal[1].Value);
            //MessageBox.Show(retVal[2].Key + " : " + retVal[2].Value);
            //MessageBox.Show(retVal[3].Key + " : " + retVal[3].Value);
            //MessageBox.Show(retVal[4].Key + " : " + retVal[4].Value);

            return retVal;
        }

        public static List<string> GetPreviousHighScores(int userDBID)
        {
            OleDbConnection cnnAccess = openNewDatabaseConnection();
            string sqlString = "SELECT qry_Users_Highscore.User_ID, qry_Users_Highscore.Character_Name, qry_Users_Highscore.Level, qry_Users_Highscore.HighScore FROM qry_Users_Highscore WHERE(((qry_Users_Highscore.User_ID) =" + userDBID + "));";

            List<string> prevLevels = new List<string>();
            List<string> prevScores = new List<string>();
            List<string> retVal = new List<string>();

            
            if (userDBID <= 0)
            {
                MessageBox.Show("Error");
            }

            OleDbDataAdapter myCmd = new OleDbDataAdapter(sqlString, cnnAccess);
            cnnAccess.Open();

            DataSet dtSet = new DataSet();

            int dataSetCount = dtSet.Tables.Count;
            

            if (dataSetCount <= 0)
            {
                //fill rows manually.          
                    prevLevels.Add("0");
                    prevScores.Add("0");                            
            }
            else
            {
                //fill rows from db.
                DataTable dTable = dtSet.Tables[0];
                myCmd.Fill(dtSet, "qry_Users_Highscore");             
                foreach (DataRow dtRow in dTable.Rows)
                {
                    prevLevels.Add(dtRow["Level"].ToString());
                    prevScores.Add(dtRow["HighScore"].ToString());
                }
            }

            retVal = prevScores;
            return retVal;
        }

        public static int SetDifficulty(int playerLevelCount)
        {
            // if retVal returns -1 there is an error.
            int retVal = -1;

            switch (playerLevelCount)
            {
                case 1: retVal = 1;
                    break;
                case 2: retVal = 2;
                    break;
                case 3: retVal = 3;
                    break;
                case 4: retVal = 4;
                    break;
                default: Console.WriteLine("Error setting player difficulty level.");                     
                    break;
            }
            return retVal;
        }

        ////REDO THIS ONE using ID
        //public static string GetUserName(string Username, string Password)
        //{

        //    openNewDatabaseConnection();

        //    string retVal = "";

        //    OleDbConnection cnnAccess = openNewDatabaseConnection();

        //    string sqlString = @"SELECT * From tbl_Users WHERE Character_Name = ? AND Password = ?";

        //    using (cnnAccess)
        //    {
        //        using (OleDbCommand cmd = new OleDbCommand(sqlString, cnnAccess))
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            cmd.Parameters.AddWithValue("Character_Name", Username);
        //            cmd.Parameters.AddWithValue("Password", Password);
        //            cnnAccess.Open();


        //            using (OleDbDataReader reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    retVal = (reader["First_Name"].ToString());
        //                }


        //            }


        //        }


        //    }

        //    return retVal;

        //}

        
        //public static List<string> GetHighScore(string userDatabaseID)
        //{

        //    openNewDatabaseConnection();

        //    List<string> retVal = new List<string>();

        //    OleDbConnection cnnAccess = openNewDatabaseConnection();

        //    string sqlString = @"SELECT * From qry_Users_Highscore WHERE User_ID = ?";

        //    using (cnnAccess)
        //    {
        //        using (OleDbCommand cmd = new OleDbCommand(sqlString, cnnAccess))
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            cmd.Parameters.AddWithValue("User_ID", userDatabaseID);
                   
        //            cnnAccess.Open();

        //            OleDbDataReader reader = cmd.ExecuteReader();
                    
        //                while (reader.Read())
        //                {
        //                Console.WriteLine(reader.GetFieldValue);
        //                //retVal.add(reader["High_Score"].ToString());
        //                }

        //        }


        //    }

        //    //    int newRetVal = Int32.Parse(retVal);

        //    //    return newRetVal;

        //    return retVal;
        //}

        //get 16 random words from DB


        public static List<string> GetWords()
        {

            List<string> retVal = new List<string>();
            OleDbConnection cnnAccess = openNewDatabaseConnection();

            string sqlString = "SELECT TOP 16 * From qry_Words";
            OleDbDataAdapter myCmd = new OleDbDataAdapter(sqlString , cnnAccess);
            cnnAccess.Open();
            DataSet dtSet = new DataSet();
            myCmd.Fill(dtSet, "qry_Words");
            DataTable dTable = dtSet.Tables[0];
            

            foreach(DataRow dtRow in dTable.Rows)
            {

                string word = dtRow["WordToUpper"].ToString();
                

            //sql query to update Times_Used in db
                string countUpdateSqlString = @"UPDATE tbl_Words SET Times_Used = Times_Used+1 WHERE Word= ?;";
                
            
                //updating the times used count in the DB
                    using (OleDbCommand cmd = new OleDbCommand(countUpdateSqlString, cnnAccess))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("Word", word);
                        cmd.ExecuteNonQuery();
                    }

                retVal.Add(word);

            }



            return retVal;


        }

        public static List<string> GetWords(int wordLength)
        {
            OleDbConnection cnnAccess = openNewDatabaseConnection();

            List<string> lstWords = new List<string>();
            List<string> retVal = new List<string>();

            //default select all words
            string sqlString = "SELECT tbl_Words.WordId, tbl_Words.WordText FROM tbl_Words";

            if (wordLength >= 1)
            {
                sqlString = "SELECT tbl_Words.Word_ID, tbl_Words.Word, Len([Word]) AS LenWord FROM tbl_Words WHERE ((Len([Word])) = '" + wordLength + "')";
            }

            OleDbDataAdapter myCmd = new OleDbDataAdapter(sqlString, cnnAccess);
            cnnAccess.Open();
            DataSet dtSet = new DataSet();
            myCmd.Fill(dtSet, "tblWords");
            DataTable dTable = dtSet.Tables[0];

            foreach (DataRow dtRow in dTable.Rows)
            {
                lstWords.Add(dtRow["Word"].ToString());

            }

            // select only 16 words form the list
            int wordSelectorValue = 0;
            Random randWordSelector = new Random();
             

            for (int i = 0; i < 16 ; i++)
            {
                //done in loop to get random number each pass
                wordSelectorValue = randWordSelector.Next(0, lstWords.Count);
                retVal.Add(lstWords[wordSelectorValue]);
            }

            return (retVal);

        }


        //public static List<string> GetWords(int numOfChars)
        //{

        //    List<string> retVal = new List<string>();
        //    OleDbConnection cnnAccess = openNewDatabaseConnection();

        //    string sqlString = "SELECT TOP 16 * From qry_Words";
        //    OleDbDataAdapter myCmd = new OleDbDataAdapter(sqlString, cnnAccess);
        //    cnnAccess.Open();
        //    DataSet dtSet = new DataSet();
        //    myCmd.Fill(dtSet, "qry_WordsPrm");
        //    DataTable dTable = dtSet.Tables[0];


        //    foreach (DataRow dtRow in dTable.Rows)
        //    {

        //        string word = dtRow["WordToUpper"].ToString();


        //        //sql query to update Times_Used in db
        //        string countUpdateSqlString = @"UPDATE tbl_Words SET Times_Used = Times_Used+1 WHERE Word= ?;";


        //        //updating the times used count in the DB
        //        using (OleDbCommand cmd = new OleDbCommand(countUpdateSqlString, cnnAccess))
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            cmd.Parameters.AddWithValue("Word", word);
        //            cmd.ExecuteNonQuery();
        //        }

        //        retVal.Add(word);

        //    }



        //    return retVal;


        //}

        public static List<string> GetWordsFourLetters()
        {

            List<string> retVal = new List<string>();
            OleDbConnection cnnAccess = openNewDatabaseConnection();

            string sqlString = "SELECT * From qry_Words_Len_4";

            OleDbDataAdapter myCmd = new OleDbDataAdapter(sqlString, cnnAccess);

            cnnAccess.Open();
            DataSet dtSet = new DataSet();

            myCmd.Fill(dtSet, "qry_Words_Len_4");
            DataTable dTable = dtSet.Tables[0];

            foreach (DataRow dtRow in dTable.Rows)
            {

                string word = dtRow["WordToUpper"].ToString();
                retVal.Add(word);

            }

            return retVal;


        }

        public static List<string> GetWordsFiveLetters()
        {

            List<string> retVal = new List<string>();
            OleDbConnection cnnAccess = openNewDatabaseConnection();

            string sqlString = "SELECT * From qry_Words_Len_5";

            OleDbDataAdapter myCmd = new OleDbDataAdapter(sqlString, cnnAccess);

            cnnAccess.Open();
            DataSet dtSet = new DataSet();

            myCmd.Fill(dtSet, "qry_Words_Len_5");
            DataTable dTable = dtSet.Tables[0];

            foreach (DataRow dtRow in dTable.Rows)
            {

                string word = dtRow["WordToUpper"].ToString();
                retVal.Add(word);

            }

            return retVal;


        }

        public static List<string> GetWordsSixLetters()
        {

            List<string> retVal = new List<string>();
            OleDbConnection cnnAccess = openNewDatabaseConnection();

            string sqlString = "SELECT * From qry_Words_Len_6";

            OleDbDataAdapter myCmd = new OleDbDataAdapter(sqlString, cnnAccess);

            cnnAccess.Open();
            DataSet dtSet = new DataSet();

            myCmd.Fill(dtSet, "qry_Words_Len_6");
            DataTable dTable = dtSet.Tables[0];

            foreach (DataRow dtRow in dTable.Rows)
            {

                string word = dtRow["WordToUpper"].ToString();
                retVal.Add(word);

            }

            return retVal;


        }

        public static List<string> GetWordsSevenLetters()
        {

            List<string> retVal = new List<string>();
            OleDbConnection cnnAccess = openNewDatabaseConnection();

            string sqlString = "SELECT * From qry_Words_Len_7";

            OleDbDataAdapter myCmd = new OleDbDataAdapter(sqlString, cnnAccess);

            cnnAccess.Open();
            DataSet dtSet = new DataSet();

            myCmd.Fill(dtSet, "qry_Words_Len_7");
            DataTable dTable = dtSet.Tables[0];

            foreach (DataRow dtRow in dTable.Rows)
            {

                string word = dtRow["WordToUpper"].ToString();
                retVal.Add(word);

            }

            return retVal;


        }

        public static string RandomCharGenerator(string lblWord)
        {
            int returnWordLength = lblWord.Length;
            string randomChars = "";
            StringBuilder builder = new StringBuilder();
            StringBuilder randChars = new StringBuilder();
            Random chars = new Random();
            int charSelector; ;

            // list of random chracters
            List<char> charList = new List<char>();
            charList.Add('!'); charList.Add('£'); charList.Add('$'); charList.Add('%'); charList.Add('^');
            charList.Add('&'); charList.Add('*'); charList.Add('('); charList.Add(')'); charList.Add('[');
            charList.Add('{'); charList.Add('}'); charList.Add('@'); charList.Add('?'); charList.Add('>');

            for (int i = 0; i < returnWordLength; i++)
            {
                charSelector = chars.Next(0,15);
                builder.Append(charList[charSelector]);
                randomChars += builder[i];
            }
            return randomChars;
        }

        public static int NumberLettersMatch(string playerGuess, string correctWord)
        {

            int wordLength = correctWord.Length;
            int letterCounter = 0;
            
            for ( int i = 0; i < wordLength; i++)
            { 
                if (correctWord[i] == playerGuess[i])
                {
                    letterCounter ++;
                }
            }
            return letterCounter;
        }

      

        
        public static string CheckUserInput(string firstName, string characterName, string password, string passwordConfirm)
        {

            string messageToUser = "";

          //  if 
          //  {
               
                
         //   }

        

            // success 
            return messageToUser;
        }


        public static string RegisterUser(string firstName,string characterName , string password , string passwordConfirm)
        {

            // inputs

            string realFirstName = firstName;
            string chosenCharacterName = characterName;
            string passwordField1 = password;
            string passwordField2 = passwordConfirm;
    
            if (passwordField1 == passwordField2)
            {
                OleDbConnection cnnAccess = openNewDatabaseConnection();
                string sqlString = "INSERT into tbl_Users (`First_Name`, `Password`, `Character_Name`) VALUES (@First_Name, @Password, @Character_Name)";
                OleDbDataAdapter myCmd = new OleDbDataAdapter(sqlString, cnnAccess);
                cnnAccess.Open();

                    using (OleDbCommand cmd = new OleDbCommand(sqlString, cnnAccess))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@First_Name", realFirstName);
                        cmd.Parameters.AddWithValue("@Password", passwordField1);
                        cmd.Parameters.AddWithValue("@Chracter_Name", chosenCharacterName); 
                        cmd.ExecuteNonQuery();
                    }

                // register sucess
                return " You Have Registered";

            } else
            {

                //show label
                // fill out label text
                return "Your Passwords Do Not Match";

            }
            

        }


        private static char[] randomChars = "*!£$%^&*(){}[];:@#<>?/".ToCharArray();

        public static bool ContainsRandomChars(string text)
        {
            return text.IndexOfAny(randomChars) >= 0;
        }

    }


}
