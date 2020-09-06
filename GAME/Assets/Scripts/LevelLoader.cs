using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public string levelname;
    
    public void LoadLevel()
    {
        StartCoroutine(LoadAsynchronously(levelname));
    }

    IEnumerator LoadAsynchronously(string levelname)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelname);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("level select");
    }

}
