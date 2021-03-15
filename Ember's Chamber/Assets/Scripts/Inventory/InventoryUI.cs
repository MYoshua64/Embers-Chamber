using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    public GameObject pan_Inventory;
    public static InventoryUI instance;
    public bool isOpen;
    public GameObject[] itemSloths;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenInventory()
    {
        pan_Inventory.SetActive(true);
        isOpen = true;
        UiManager.instance.UnLock();
    }
    public void CloseInventory()
    {
        pan_Inventory.SetActive(false);
        isOpen = false;
        UiManager.instance.Lock();
    }

    public void AddItem(Sprite image, int itemCount)
    {
        itemSloths[itemCount].GetComponentInChildren<Image>().sprite = image;
    }
}
