using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{
    //public bool hasInteract = false;
    private bool currentInteract = false;
    private bool insideTrigger;
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index = 0;
    public float typingSpeed;
    public PlayerController PController;

    public GameObject DialoguePanel;
    public GameObject NPCPrompt;
    public GameObject continueButton;

    public bool getCurrentInteract()
    {
        return currentInteract;
    }

    void OnTriggerEnter(Collider Other)
    {
        if (Other.CompareTag("Player"))
        {
            NPCPrompt.SetActive(true);
            insideTrigger = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            NPCPrompt.SetActive(false);
            insideTrigger = false;
        }
    }
    private void Start()
    {
        continueButton.GetComponent<Button>().onClick.AddListener(NextSentence);
    }
    void Update()
    {
        if(insideTrigger == true){
        if (Cursor.lockState == CursorLockMode.Locked && Input.GetKeyDown(KeyCode.LeftShift) && currentInteract == false){
            index = 0;
            currentInteract = true;
            NPCPrompt.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Displaytext();
            PController.enabled = false;
        }
        }
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
            //continueButton.onClick.AddListener(NextSentence();
        }
        if (!DialoguePanel.activeSelf)
        {
            currentInteract = false;
        }
    }

    IEnumerator Type()
    {
        //if (hasInteract == false)
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }
    }

    void Displaytext()
    {
        DialoguePanel.SetActive(true);
        textDisplay.text = "";
        StartCoroutine(Type());
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            NPCPrompt.SetActive(true);
            DialoguePanel.SetActive(false);
            PController.enabled = true;
            //hasInteract = true;
            textDisplay.text = "";
        }
    }
}
