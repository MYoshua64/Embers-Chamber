using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance;
    [SerializeField]
    public Inventory inventory = new Inventory();
  //  [SerializeField]
    public List<Riddle> riddles = new List<Riddle>();
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;

        CollectAllRiddlesInRoom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CollectAllRiddlesInRoom()
    {
        riddles.Clear();
        Riddle[] _riddles = FindObjectsOfType<Riddle>();
        for (int counter = 0; counter < _riddles.Length; counter++)
        {
            riddles.Add(_riddles[counter]);
            riddles[counter].GotInteracted.AddListener(RiddleGotSolve);
        }
    }

    void RiddleGotSolve()
    {
        //update phone MSG
        Debug.Log("RiddleGotSolved");
    }
}
