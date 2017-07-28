using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5055215.MyMethods
{

    public void guessPanelManager(int playerGuessCounter, string currentPlayerGuess, int numberLettersCorrect)
    {

        //******************** algorothm to imporve *******************************************

        switch (playerGuessCounter)
        {
            case 1:
                lblGuessWord1.Text = currentPlayerGuess;
                lblGuessLetter1.Text = numberLettersCorrect.ToString();
                lblGuessNumber.Text = playerGuessCounter.ToString();

                break;
            case 2:
                lblGuessWord2.Text = currentPlayerGuess;
                lblGuessLetter2.Text = numberLettersCorrect.ToString();
                lblGuessNumber.Text = playerGuessCounter.ToString();

                break;
            case 3:
                lblGuessWord3.Text = currentPlayerGuess;
                lblGuessLetter3.Text = numberLettersCorrect.ToString();
                lblGuessNumber.Text = playerGuessCounter.ToString();

                break;
            case 4:
                lblGuessWord4.Text = currentPlayerGuess;
                lblGuessLetter4.Text = numberLettersCorrect.ToString();
                lblGuessNumber.Text = playerGuessCounter.ToString();

                break;
            case 5:
                lblGuessWord5.Text = currentPlayerGuess;
                lblGuessLetter5.Text = numberLettersCorrect.ToString();
                lblGuessNumber.Text = playerGuessCounter.ToString();

                break;
            case 6:
                lblGuessWord6.Text = currentPlayerGuess;
                lblGuessLetter6.Text = numberLettersCorrect.ToString();
                lblGuessNumber.Text = playerGuessCounter.ToString();

                break;
            case 7:
                lblGuessWord7.Text = currentPlayerGuess;
                lblGuessLetter7.Text = numberLettersCorrect.ToString();
                lblGuessNumber.Text = playerGuessCounter.ToString();

                break;
            case 8:
                lblGuessWord8.Text = currentPlayerGuess;
                lblGuessLetter8.Text = numberLettersCorrect.ToString();
                lblGuessNumber.Text = playerGuessCounter.ToString();

                break;
            case 9:
                lblGuessWord9.Text = currentPlayerGuess;
                lblGuessLetter9.Text = numberLettersCorrect.ToString();
                lblGuessNumber.Text = playerGuessCounter.ToString();

                break;
            case 10:
                lblGuessWord10.Text = currentPlayerGuess;
                lblGuessLetter10.Text = numberLettersCorrect.ToString();
                lblGuessNumber.Text = playerGuessCounter.ToString();

                break;
            case 11:
                lblGuessWord11.Text = currentPlayerGuess;
                lblGuessLetter11.Text = numberLettersCorrect.ToString();
                lblGuessNumber.Text = playerGuessCounter.ToString();

                break;
            case 12:
                lblGuessWord12.Text = currentPlayerGuess;
                lblGuessLetter12.Text = numberLettersCorrect.ToString();
                lblGuessNumber.Text = playerGuessCounter.ToString();

                break;
            case 13:
                lblGuessWord13.Text = currentPlayerGuess;
                lblGuessLetter13.Text = numberLettersCorrect.ToString();
                lblGuessNumber.Text = playerGuessCounter.ToString();

                break;
            case 14:
                lblGuessWord14.Text = currentPlayerGuess;
                lblGuessLetter14.Text = numberLettersCorrect.ToString();
                lblGuessNumber.Text = playerGuessCounter.ToString();

                break;
            case 15:
                lblGuessWord15.Text = currentPlayerGuess;
                lblGuessLetter15.Text = numberLettersCorrect.ToString();
                lblGuessNumber.Text = playerGuessCounter.ToString();

                break;
            case 16:
                lblGuessWord16.Text = currentPlayerGuess;
                lblGuessLetter16.Text = numberLettersCorrect.ToString();
                lblGuessNumber.Text = playerGuessCounter.ToString();
                break;

            default:
                MessageBox.Show("playerGuess() switch statment has failed");
                break;
        }


    }

}
