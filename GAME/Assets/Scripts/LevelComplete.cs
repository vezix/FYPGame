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
    [HideInInspector]
    public float Total;
     float wrongobjective;
    public float minimumScore;
    public int unlocklevel;
    public string win1;
    public string win2;
    public string lose;
    public string proceedScene="level select";
    public bool finalLevel=false;

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
            scoreComments.text = win1 + "\n" + win2;
            if (finalLevel)
            {
                proceedScene = "credit";
            }
            if (unlocklevel > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", unlocklevel);
            }
        }

        else
        {
            scoreComments.text = lose;
        } 



    }

    public void Levelselect()
    {
        SceneManager.LoadScene(proceedScene);
    }

}
