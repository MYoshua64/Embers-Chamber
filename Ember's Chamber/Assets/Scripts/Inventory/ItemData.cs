using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemData 
{
    public string name;
    public string descripton;
    public Sprite pic;

    public ItemData()
    {

    }
    public ItemData(string _name,string _description)
    {
        name = _name;
        descripton = _description;
    }
}
