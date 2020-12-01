using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public Button[] lvlButtons;
    public string level1cutscenename;
    public string level2cutscenename;
    public string level3cutscenename;

    // Start is called before the first frame update
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 1);
        
        for (int i = 0; i< lvlButtons.Length; i++)
        {
            if (i +1> levelAt)
                lvlButtons[i].interactable = false;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void level1()
    {
        SceneManager.LoadScene(level1cutscenename);
    }

    public void level2()
    {
        SceneManager.LoadScene(level1cutscenename);
    }
    public void level3()
    {
        SceneManager.LoadScene(level3cutscenename);
    }

    public void levelTuto()
    {
        SceneManager.LoadScene("TutoLevel");
    }

}
