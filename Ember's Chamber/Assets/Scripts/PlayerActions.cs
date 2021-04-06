using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerActions : MonoBehaviour
{

    public static PlayerActions instance;
    public bool isTutorial;
    bool isFirstDetact;
    public UnityEvent FirstDetact;

    public CameraMovement cameraMovement;
    public GameObject mouseDeatactor;


    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //catch key pressed

        if (GameManager.instance.game.currentLvl != "MainMenu")
        {
            
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (!UIManager.instance.uiInventory.isOpen)
                    UIManager.instance.uiInventory.OpenInventory();
                else
                    UIManager.instance.uiInventory.CloseInventory();
            }
        }


        if (CheckIfOnInteractable())
        {
            UIManager.instance.OnInteractable();
        }
        else
        {
            UIManager.instance.OffInteractable();
        }

    }

    bool CheckIfOnInteractable()
    {

        bool isOnInteractable = false;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.transform.tag == "Interactable")
            {
                isOnInteractable = true;
                if(!isFirstDetact&& isTutorial)
                {
                    FirstDetact.Invoke();
                    isFirstDetact = true;
                }
            }
        }
        return isOnInteractable;
    }

    public void UnLock()
    {
        Cursor.lockState = CursorLockMode.None;
        cameraMovement.enabled = false;
        mouseDeatactor.SetActive(false);
    }
    public void Lock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cameraMovement.enabled = true;
        mouseDeatactor.SetActive(true);
    }
}
