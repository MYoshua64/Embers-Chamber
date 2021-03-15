using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    string roomName;
    public List<RiddleData> riddleDatas = new List<RiddleData>();
    // Start is called before the first frame update
    void Start()
    {
        CollectAllRiddlesInRoom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CollectAllRiddlesInRoom()
    {
        riddleDatas.Clear();
        Riddle[] riddles = FindObjectsOfType<Riddle>();
        for (int counter = 0; counter < riddles.Length; counter++)
        {
           // riddleDatas.Add(riddles[counter].riddleData);
        }
    }
    bool IsRoomSolved()
    {
        int counter = 0;
        while (riddleDatas[counter].getIsSolved() && counter < riddleDatas.Count)
        {
            counter++;
        }
        //if everyone is solved - counter will get to the end of the list with true
        //if one is false - loop will stop and will return false;
        return riddleDatas[counter].getIsSolved();
    }
}
