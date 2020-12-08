using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public GameObject Button;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(creditsroll());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator creditsroll()
    {
        yield return new WaitForSeconds(19);
        Button.SetActive(true);
        anim.enabled = false;
        
    }

    public void returnMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
