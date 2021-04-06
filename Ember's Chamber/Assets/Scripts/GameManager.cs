using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public Game game;
    SaveSystem saveSystem = new SaveSystem();


    public static GameManager instance;
    private void Start()
    {
        if(instance == null)
        {
            instance = this;
            if(game == null)
            {
                game = new Game("test", "tutorial");
            }
        }
        if (game.currentLvl == "tutorial")
        {
           // UiManager.instance.tutorial.StartTutorial();
        }
    }

    private void Update()
    {
        
    }
    public void StartGame(string gameName)
    {
        game = saveSystem.LoadGame(gameName); 
        SceneManager.LoadScene(game.currentLvl);
    }

    public void EndGame()
    {

    }
    public void SaveGame()
    {
        //saveSystem.SaveGame(game);
    }

    public void SkipTutorial()
    {
        Debug.Log("Done with this shet!");
    }
}
