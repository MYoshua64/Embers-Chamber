using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem
{ 
    Game loadedGame;
    public Game LoadGame(string _gameName)
    {
        Debug.Log("Loading Game");
        return loadedGame = new Game(_gameName, _gameName);
    }
}
