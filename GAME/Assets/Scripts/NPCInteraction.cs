using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCInteraction : MonoBehaviour
{
    public bool hasInteract = false;
   // bool hasEntered = false;

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject DialoguePanel;
    public GameObject NPCPrompt;

    // Check cutscene Script, frankenstein your way into this script!!!
    // Check PlayerMovement Make sure it wont move 

    void OnTriggerEnter(Collider Other)
    {
        if (Other.CompareTag("Player"))
        {
            NPCPrompt.SetActive(true);
           // hasEntered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            NPCPrompt.SetActive(false);
          //  hasEntered = false;
        }
    }
    void Update()
    {/*
            if (hasEntered == true && Input.GetKeyDown(KeyCode.Space) && hasInteract == false)
            {
                Displaytext();
            }
            if (textDisplay.text == sentences[index] && Input.GetKeyDown(KeyCode.LeftShift) && hasInteract == false)
            {
                NextSentence();
            }

            if (hasEntered == true && Input.GetKeyDown(KeyCode.Space) && hasInteract == true)
            {

                HasInteractSentence();
            }*/
    }

    public void HasInteractSentence()
    {
        DialoguePanel.SetActive(true);
        textDisplay.text = "I have Spoken";
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DialoguePanel.SetActive(false);
            textDisplay.text = "";
        }
    }

        IEnumerator Type()
    {

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
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            DialoguePanel.SetActive(false);
            hasInteract = true;
            textDisplay.text = "";
        }
    }
}
