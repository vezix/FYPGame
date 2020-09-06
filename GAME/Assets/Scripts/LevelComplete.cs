using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public Text scoreDisplay;
    public Text scoreTotal;
     float TimerScore;
     float GoldScore;
     float Total;
    public int unlocklevel;

    void Start()
    {
        TimerScore = Score.timeleft;
        GoldScore = Score.gold * 10;
        Total = 1000 + TimerScore + GoldScore;
        scoreDisplay.text = "Score: \nObjective \t=1000 \nTimer " + Score.timeleft.ToString() + "seconds \t =" + TimerScore.ToString() + "\nGold " + Score.gold.ToString() + "\t =" + GoldScore.ToString() ; 
        scoreTotal.text = "Total: " + Total.ToString();
    }

    public void Levelselect()
    {
        if(unlocklevel> PlayerPrefs.GetInt("levelAt")){
            PlayerPrefs.SetInt("levelAt", unlocklevel);
        }
        SceneManager.LoadScene("level select");
    }

}
