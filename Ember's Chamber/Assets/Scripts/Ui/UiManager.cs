using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//note to self
//all btn must named btn_btnName
//close btn named btn_C_btnName
//all obj must named obj_objName
//all panels must named pan_panName
public class UiManager : MonoBehaviour
{
    [SerializeField]
    SoundManager soundManager;

    public static UiManager instance;

   public CameraMovement cameraMovement; 

    public TutorialUI tutorial;

    private KeyCode pressedKey;

    public  void OnClick()
    {
        soundManager.PlayClickedBtnSound();
    }
    public void OpenMenu(GameObject pan_panName)
    {
        Debug.Log("open " + pan_panName.name);
        pan_panName.SetActive(true);
    }

    public void CloseMenu(GameObject pan_panName)
    {
        Debug.Log("close " + pan_panName.name);
        pan_panName.SetActive(false);
    }

    public void UnLock()
    {
        Cursor.lockState = CursorLockMode.None;
        cameraMovement.enabled = false;
    }
    public void Lock() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        cameraMovement.enabled = true;
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
}
