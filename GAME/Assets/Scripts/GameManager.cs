using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public float currentGold;
    public Text goldText;
    public GameObject cartDisplay;

    public float timeRemaining;
    public Text timeText;
    bool timerIsRunning = false;

    public GameObject GameoverDisplay;
    public GameObject PauseDisplay;
    public string lvlcomplete;
    public PlayerController PController;

    //forcalculating wrong items at checkout/score 
    public int numberofitemsObjective;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        goldText.text = "Money: " + currentGold;
        timerIsRunning = true;
        Score.gold = 0;
        Score.timeleft = 0;
        Score.wrongObjectives = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Cursor.lockState == CursorLockMode.Locked && Input.GetKeyDown(KeyCode.V))
        {
            cartDisplay.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            PController.enabled = false;
            //Time.timeScale = 0f;
        }

        if (Cursor.lockState == CursorLockMode.Locked && Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }


        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                Gameover();

            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void AddGold(float goldToAdd)
    {
        currentGold += goldToAdd;
        currentGold = Mathf.Round(currentGold * 100) / 100;
        goldText.text = "Money:" + currentGold;
    }

    public void RemoveGold(float goldToRemove)
    {
        currentGold -= goldToRemove;
        currentGold = Mathf.Round(currentGold * 100)/100;
        goldText.text = "Money:" + currentGold;
    }

    public void Gameover()
    {

        GameoverDisplay.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void Pause()
    {
        PauseDisplay.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }
    public void closePause()
    {
        PauseDisplay.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void gamerestart()
    {
        SceneManager.LoadScene("Level1");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void levelSelect()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void levelcomplete()
    {
        SceneManager.LoadScene(lvlcomplete);
    }
}
