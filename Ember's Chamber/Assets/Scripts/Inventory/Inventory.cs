using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System;


[Serializable]
public class Inventory
{

    public List<ItemData> itemDatas = new List<ItemData>();
    public UnityEvent itemWasAdded;
    public UnityEvent itemWasUsed;

    public void Add(ItemData newItem)
    {
        itemDatas.Add(newItem);
        itemWasAdded.Invoke();
        InventoryUI.instance.AddItem(newItem.pic, itemDatas.Count - 1);
    }

    public void Remove(string usedItemName)
    {
        foreach (ItemData item in itemDatas)
        {
            if (item.name == usedItemName)
            {
                itemWasUsed.Invoke();
                itemDatas.Remove(item);
            }
        }
    }
    public List<string> GetItemsNameOnInventory()
    {
        List<string> itemsName = new List<string>();
        foreach(ItemData item in itemDatas)
        {
            itemsName.Add(item.name);
        }
        return itemsName;
    }
}
