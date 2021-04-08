using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : Interactable
{
    [SerializeField]
    private ItemData item;
   // public bool canItakeIt;

    public ItemData GetItem()
    {
        return item;
    }

    public override void Interaction()
    {
        PlayerData.instance.inventory.Add(GetItem());
        Destroy(this.gameObject);
    }
}
