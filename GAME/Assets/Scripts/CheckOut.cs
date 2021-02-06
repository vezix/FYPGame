using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckOut : MonoBehaviour
{
    Inventory inventory;
    public GameObject counterPanel;
    public GameObject star;
    public GameObject star1;
    public GameObject star2;
    public float startime;
    public float star1time;
    public float star2time;

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
                DisplayStar(Score.timeleft);
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

    void DisplayStar(float time)
    {
        if (time > startime) star.SetActive(true);
        if (time > star1time) star1.SetActive(true);
        if (time > star2time) star2.SetActive(true);

    }


    /* void OnTriggerExit(Collider other)
     {
         if (other.CompareTag("Player"))
         {
         }
     }
     */
}
