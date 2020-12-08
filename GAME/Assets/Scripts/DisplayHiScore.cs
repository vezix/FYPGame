using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHiScore : MonoBehaviour
{
    float highscore1;
    float highscore2;
    float highscore3;
    public Text score1;
    public Text score2;
    public Text score3;
    // Start is called before the first frame update
    void Start()
    {
        highscore1 = PlayerPrefs.GetFloat("level1score", 0);
        highscore2 = PlayerPrefs.GetFloat("level2score", 0);
        highscore3 = PlayerPrefs.GetFloat("level3score", 0);

        score1.text = "Hi Score :" + highscore1.ToString();
        score2.text = "Hi Score :" + highscore2.ToString();
        score3.text = "Hi Score :" + highscore3.ToString();
    }

}
