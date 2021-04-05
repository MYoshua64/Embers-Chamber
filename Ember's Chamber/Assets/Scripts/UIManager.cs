using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    //================================================
    // CREATED BY DATE: FIRST SEMESTER
    //================================================

    public static UIManager instance;

    public Image circle;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //for Mouse Detactable
    public void OnInteractable()
    {
        //Change to green
        circle.color = new Color32(96, 159, 92, 150);
    }

    public void OffInteractable()
    {
        //Change to white
        circle.color = new Color32(255, 255, 255, 150);
    }

    //Open window
    public void OpenWindow(GameObject windowToOpen)
    {
        windowToOpen.SetActive(true);
        PlayerActions.instance.UnLock();
    }

    //only for tutorial - might for phone msg
    public void OpenWindow(GameObject windowToOpen, string  text, bool isPhoneMSG)
    {
        PlayerActions.instance.UnLock();
        windowToOpen.SetActive(true);
        windowToOpen.GetComponentInChildren<TextMeshProUGUI>().text = text;
        if (isPhoneMSG)
        {
            StopCoroutine("DisapperTextMSG");
            StartCoroutine("DisapperTextMSG", windowToOpen);
        }
    }

    public void CloseWindow(GameObject windowToClose)
    {
        windowToClose.SetActive(false);
        PlayerActions.instance.Lock();
    }
    public void UpdateTextMSG(GameObject windowToUpdate, string text)
    {
        windowToUpdate.GetComponentInChildren<TextMeshProUGUI>().text = text;
    }
    IEnumerable DisapperTextMSG(GameObject windowToDisapper)
    {
        yield return null;
        windowToDisapper.SetActive(false);
    }

    //================================================
    // CREATED BY DATE: Apr 2
    //================================================

    [SerializeField]
    SoundManager soundManager;

    public CameraMovement cameraMovement;

    public TutorialUI tutorial;

    private KeyCode pressedKey;

    public void OnClick()
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
}