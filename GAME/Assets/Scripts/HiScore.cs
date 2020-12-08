using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiScore : MonoBehaviour
{
    public string LevelScore;
    LevelComplete Score;
    private float highscore;

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetFloat(LevelScore,0);
        Score = gameObject.GetComponent<LevelComplete>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Score.Total > highscore)
        {
            PlayerPrefs.SetFloat(LevelScore, Score.Total);
        }
        
    }
}
