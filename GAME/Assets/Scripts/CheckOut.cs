﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckOut : MonoBehaviour
{
    Inventory inventory;
    public GameObject counterPanel;
    public Text ItemFound;
    public GameObject Button;
    public GameObject NextSceneButton;

    public Transform ObjectivesParents;
    //public int qualityGoal;
    int checkObjective;
    objective[] Objectives;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        Objectives = ObjectivesParents.GetComponentsInChildren<objective>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { checkObjective = 0;
            for (int i = 0; i < Objectives.Length; i++)
            {
                if (Objectives[i].Check == true)
                {
                    checkObjective++;
                    //totalquality += Objectives[i].reachedQuality;
                }
            }
            //&& totalquality >= qualityGoal (this goes into if statement below) 
            if (checkObjective == Objectives.Length )
            {
                Score.wrongObjectives = inventory.items.Count - FindObjectOfType<GameManager>().numberofitemsObjective;
                Score.gold += FindObjectOfType<GameManager>().currentGold;
                Score.timeleft += FindObjectOfType<GameManager>().timeRemaining;
                ItemFound.text = "All of the item has been found!";
                FindObjectOfType<AudioManager>().stopAllBG();
                FindObjectOfType<AudioManager>().PlaySFX("ItemFound");
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                FindObjectOfType<GameManager>().timerIsRunning = false;
                //Time.timeScale = 0f;
                FindObjectOfType<PlayerController>().enabled = false;
                counterPanel.SetActive(true);
                Debug.Log("Objective Completed");
                Button.SetActive(false);
                StartCoroutine(EndSong());

            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0f;
                counterPanel.SetActive(true);
                FindObjectOfType<AudioManager>().PlaySFX("TryAgain");
                Debug.Log("Item Not Found");
            }
        }
    }

    IEnumerator EndSong()
    {
            yield return new WaitForSeconds(4f);
            NextSceneButton.SetActive(true);
    }

    public void closePanel()
    {
        counterPanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }


    /* void OnTriggerExit(Collider other)
     {
         if (other.CompareTag("Player"))
         {
         }
     }
     */
}
