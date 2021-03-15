using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game 
{
    string gameName;
    public string currentLvl { get; }
    public  Game(string _gameName, string _currentLvl)
    {
        gameName = _gameName;
        currentLvl = _currentLvl;
    }
}
