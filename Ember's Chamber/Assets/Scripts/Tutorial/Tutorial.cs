using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public Riddle OpenInventory;
    public PlayerActions FirstDetact;

    public GameObject textMSG;
    string[] text;
    int counter = 0;

    public GameObject NormalRoom;
    public GameObject StrangeRoom;

    // Start is called before the first frame update
     void Start()
    {
        FirstDetact.FirstDetact.AddListener(DetactInteractable);
        OpenInventory.GotInteracted.AddListener(InventoryWasOpen);
        StartTutorial();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InventoryWasOpen()
    {
        text = new string[2];
        text[0] = "Hey, You found the Inventory.";
        text[1] = "Press I every time you want to see what you collected.";
        UIManager.instance.OpenWindow(textMSG, text[counter], false);
        counter++;
        NormalRoom.SetActive(false);
        StrangeRoom.SetActive(true);
    }

    void StartTutorial()
    {
        text = new string[5];
        text[0] = "Hey, lets learn to play";
        text[1] = "You can move you charcter wuth the arrows on the right side and with the wasd keys.";
        text[2] = "you should know that your mouse will alway be in the middle.";
        text[3] = "when the mouse is on an object and is white thats mean you cannot click on the object.";
        text[4] = "if the mouse turn green  you can click on it, now lets find something to click on it.";

        UIManager.instance.OpenWindow(textMSG, text[counter], false);
        counter++;

    }
    public void DetactInteractable()
    {
        text = new string[2];
        text[0] = "Hey, You found your first clickable object.";
        text[1] = "Now lets find inventory.";
        UIManager.instance.OpenWindow(textMSG, text[counter], false);
        counter++;
    }

    public void Next()
    {
        if (counter + 1 > text.Length)
        {
            UIManager.instance.CloseWindow(textMSG);
            counter = 0;
        }
        else
        {
            UIManager.instance.UpdateTextMSG(textMSG, text[counter]);
            counter++;
        }
    }
}
