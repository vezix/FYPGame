using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public Text scoreDisplay;
    public Text scoreTotal;
    public Text scoreComments;
     float TimerScore;
     float GoldScore;
     float Total;
     float wrongobjective;
    public float minimumScore;
    public int unlocklevel;

    void Start()
    {
        TimerScore = Score.timeleft;
        GoldScore = Score.gold * 10;
        wrongobjective = (float)Score.wrongObjectives * -10;
        Total = 100 + TimerScore + GoldScore + wrongobjective;
        scoreDisplay.text = "Score:\nObjective = 100 \nTimer " + Score.timeleft.ToString() + " seconds = " + TimerScore.ToString() + "\nGold " + Score.gold.ToString() + " = " + GoldScore.ToString() +"\nWrong items " + Score.wrongObjectives.ToString() + " = " + wrongobjective.ToString(); 
        scoreTotal.text = "Total: " + Total.ToString();

        if (Total>= minimumScore)
        {
            scoreComments.text = "you've learned the importance of time and focusing objectives while shopping! \ngoodjob! let's proceed onto next objective!";
            if (unlocklevel > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", unlocklevel);
            }
        }

        else
        {
            scoreComments.text = " nice try... \n but i believe you can do better, lets try again!";
        } 



    }

    public void Levelselect()
    {
        SceneManager.LoadScene("level select");
    }

}
