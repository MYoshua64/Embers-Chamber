using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Events;

public class Riddle : Interactable
{
    [SerializeField]
    private RiddleData riddleData;

    //private void Start()
    //{
    //    if (riddleData.doINeedItem)
    //        riddleData.neededItem.GotInteracted.AddListener(GotTheNeededItem);
    //}
    public override void Interaction()
    {
        if (!riddleData.getIsSolved())
        {
            if (riddleData.doINeedCode)
            {
                UIManager.instance.OpenCodeWindow(this);
            }
            else if (riddleData.doIOpenUI)
            {
                UIManager.instance.OpenWindow(riddleData.uiToOpen);
            }
            else
            {
                if (riddleData.doINeedItem)
                {
                    if (DoIHaveItem())
                    {
                        riddleData.setIsSolved(true);
                    }
                }
                else
                {
                    riddleData.setIsSolved(true);
                }

                if (riddleData.getIsSolved())
                {
                    base.Interaction();
                    if (riddleData.doIGiveItem)
                    {
                        foreach (ItemData itemData in riddleData.itemRecived)
                            PlayerData.instance.inventory.Add(itemData);
                    }
                }
            }
        }
        else
        {
            Debug.Log("Riddle already solved!");
        }
    }
    private void GotTheNeededItem()
    {
        riddleData.doIHaveItem = true;
    }

    public RiddleData GetRiddleData()
    {
        return riddleData;
    }

    bool DoIHaveItem()
    {
        List<string> itemNames = PlayerData.instance.inventory.GetItemsNameOnInventory();
        foreach (string name in itemNames)
        {
            if (name == riddleData.neededItem)
            {
                return true;
            }
        }

        return false;
    }

    public void CheckSolution(int[] code)
    {
        bool match = true;
        for (int i = 0; i < code.Length && match; i++)
        {
            match = code[i] == riddleData.codeToOpen[i];
        }
        if (match)
        {
            Debug.Log("Code entered successfully!");
            riddleData.setIsSolved(true);
            //need to play animation of open door
            //close code ui
            //check if moving to other scene
            //if (riddleData.doIGiveItem)
            //{
            //    foreach (ItemData itemData in riddleData.itemRecived)
            //        PlayerData.instance.inventory.Add(itemData);
            //}
            UIManager.instance.CloseCodeWindow();
        }
        else
        {
            Debug.Log("WRONG CODE!");
        }
    }
}
