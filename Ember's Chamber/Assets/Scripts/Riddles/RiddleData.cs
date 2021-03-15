using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RiddleData 
{
    public string name;
    public string descripton;
    public bool isSolved;

    //for solution
    public bool doINeedItem;
    public bool doIHaveItem;
    public string neededItem;

    //
    public bool doIGiveItem;
    public List<ItemData> itemRecived;

    //for code riddles
    public bool doIOpenUI;
    public GameObject uiToOpen;
    RiddleData()
    {
        
    }
    public RiddleData(string _name, string _description, bool _isSolved)
    {
        name = _name;
        descripton = _description;
        isSolved = _isSolved;
    }
    public RiddleData(string _name, string _description, bool _isSolved, string _itemNeededForThisRiddle)
    {
        name = _name;
        descripton = _description;
        isSolved = _isSolved;
        //itemNeededForThisRiddle = _itemNeededForThisRiddle;
    }
    public void setIsSolved(bool _isSolved)
    {
        isSolved = _isSolved;
    }
    public bool getIsSolved()
    {
        return isSolved;
    }
}
