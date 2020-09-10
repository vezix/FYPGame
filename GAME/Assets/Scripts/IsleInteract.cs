using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsleInteract : MonoBehaviour
{
    public GameObject IslePanel;
    public GameObject PanelPrompt;
    public PlayerController PController;
    private bool triggerEntered = false;
    public Item[] item = new Item[3];
    public int[] quantity = new int[3];
    public ItemIsleDisplay[] display = new ItemIsleDisplay[3];
    public bool[] Discount = new bool[] {false,false,false};

    //private int[] Maxquantity = new int[3];
/*    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            Maxquantity[i] = quantity[i];
        }
    }

    public int returnMax(int i)
    {
        return Maxquantity[i];
    }
*/
    private void Update()
    {
         if (Cursor.lockState == CursorLockMode.Locked && triggerEntered == true && Input.GetKeyDown(KeyCode.LeftShift))
            {
                ItemSets();
                IslePanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                PController.enabled = false;
                //Time.timeScale = 0f;
        }
    }

    void ItemSets()
    {
        display[0].triggerArea = this;
        display[0].itemIsleSet();
        display[1].triggerArea = this;
        display[1].itemIsleSet();
        display[2].triggerArea = this;
        display[2].itemIsleSet();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PanelPrompt.SetActive(true);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerEntered = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PanelPrompt.SetActive(false);
            triggerEntered = false;
        }
    }
    public void closePanel()
    {
        IslePanel.SetActive(false);
        //Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        triggerEntered = false;
        PController.enabled = true;
    }

}
