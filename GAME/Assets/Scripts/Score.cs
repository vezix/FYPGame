﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    static public float gold=0;
    static public float timeleft=0;
    static public int wrongObjectives=0;
    public float displayGold;
    public float displayTime;


    private void Update()
    {
        timeleft = Mathf.Round(timeleft);
        displayTime = timeleft;
        displayGold = gold;
    }
}
