using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiScore : MonoBehaviour
{
    public string LevelScore;
    LevelComplete Score;
    private float highscore;
    public GameObject NewHighDisplay;

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetFloat(LevelScore,0);
        Score = gameObject.GetComponent<LevelComplete>();
        if (Score.Total > highscore)
        {
            PlayerPrefs.SetFloat(LevelScore, Score.Total);
            NewHighDisplay.SetActive(true);
        }

    }
}
