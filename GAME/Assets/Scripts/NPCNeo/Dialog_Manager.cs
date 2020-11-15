using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialog_Manager : MonoBehaviour
{
    public GameObject dialogpanel;
    public TextMeshProUGUI npcNameText;
    public TextMeshProUGUI dialogText;
    public PlayerController PController;

    private List<string> conversation;
    private int convoIndex;

    public float typingSpeed;
    public GameObject continueButton;

    //public void Start()
    //{
    //    dialogpanel.SetActive(false);
    //}
    private void Start()
    {
        continueButton.GetComponent<Button>().onClick.AddListener(NextSentence);
    }
    public void Start_Dialog(string _npcName, List<string> _convo)
    {
        npcNameText.text = _npcName;
        conversation = new List<string>(_convo);
        dialogpanel.SetActive(true);
        convoIndex = 0;
        //ShowText();
        Displaytext();
        PController.enabled = false;
    }

    public void Update()
    {
        if (dialogpanel.activeSelf) { 
        if (dialogText.text == conversation[convoIndex])
            continueButton.SetActive(true);
        }
    }

    //public void  StopDialog()
    //{
    //    dialogpanel.SetActive(false);
    //}
    //public void ShowText()
    //{
    //    dialogText.text = conversation[convoIndex];
    //}
    //public void Next()
    //{
    //    if (convoIndex < conversation.Count - 1)
    //    {
    //        convoIndex += 1;
    //        ShowText();
    //    }
    //}

    void Displaytext()
    {
        dialogpanel.SetActive(true);
        dialogText.text = "";
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        //if (hasInteract == false)
        foreach (char letter in conversation[convoIndex].ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (convoIndex < conversation.Count - 1)
        {
            convoIndex++;
            dialogText.text = "";
            StartCoroutine(Type());
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            dialogpanel.SetActive(false);
            PController.enabled = true;
            //hasInteract = true;
            dialogText.text = "";
            convoIndex = 0;
        }
    }

}
