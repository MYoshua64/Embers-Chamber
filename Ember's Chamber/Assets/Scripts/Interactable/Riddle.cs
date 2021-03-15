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
            if (riddleData.doIOpenUI)
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
}
