using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L5055215.MyClasses
{
    public class ClassCheckAnswer 
    {
        private string guess = "";
        private string correctAnswer = "";
        private int numLettersCorrect = -1;

        public int CheckAnswer(string guess, string correctAnswer)
        {
            this.guess = guess;
            this.correctAnswer = correctAnswer;
            numLettersCorrect = MyMethods.MyMethods.NumberLettersMatch(guess,correctAnswer);
            return numLettersCorrect;
        }
    }
}



//public int NumLettersCorrect = 0;

//public int CheckAnswer(string answer, string wordCorrect, int playerLives)
//{
//    // returns -2 if fails, -1 if player score to be reduced , or 1 if anwser is incorrect and 2 if answer is correct and 3 if word has chars but not free life.
//    string currentPlayerGuess = "";
//    int isCorrectQ = -2;
//    NumLettersCorrect = 0;
//    //&& answer.Text.Contains("!")

//    if ((answer.Contains("?")) && playerLives > 0 && playerLives < 4)
//    {
//        isCorrectQ = -1;
//        return isCorrectQ;

//    }
//    else if (MyMethods.MyMethods.ContainsRandomChars(answer))
//    {
//        // if word put in contains chracters... 

//        return 3;


//    }
//    else if (!MyMethods.MyMethods.ContainsRandomChars(answer))
//    {

//        if (answer == wordCorrect)
//        {

//            MessageBox.Show("That is NumberWang! GG");
//            isCorrectQ = 2;
//            return isCorrectQ;

//        }
//        else
//        {
//            //answer checker block
//            currentPlayerGuess = answer;
//            NumLettersCorrect = MyMethods.MyMethods.CheckButtonAnswer(currentPlayerGuess, wordCorrect);
//            // end answer checker block

//            isCorrectQ = -1;
//            return isCorrectQ;
//        }

//    }

//    return isCorrectQ;
//}



