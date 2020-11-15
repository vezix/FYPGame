using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NPC : MonoBehaviour
{
    public string npcName;
    public Dialog_Manager dialogmanager;

    public List<string> npcConvo = new List<string>();

    private bool currentInteract = false;
    private bool insideTrigger;
    public GameObject NPCPrompt;
    public GameObject dialogpanel;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
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

    void Update()
    {
        if (insideTrigger == true)
        {
            if (Cursor.lockState == CursorLockMode.Locked && Input.GetKeyDown(KeyCode.Space) && currentInteract == false)
            {
                currentInteract = true;
                NPCPrompt.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                dialogmanager.Start_Dialog(npcName, npcConvo);
            }
            if (!dialogpanel.activeSelf)
            {
                NPCPrompt.SetActive(true);
                currentInteract = false;
            }
        }

    }

    public bool getCurrentInteract()
    {
        return currentInteract;
    }


}
