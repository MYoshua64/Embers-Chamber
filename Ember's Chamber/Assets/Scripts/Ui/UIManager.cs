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

    private KeyCode pressedKey;

    public void OnClick()
    {
        soundManager.PlayClickedBtnSound();
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

    //================================================
    // CREATED BY DATE: Apr 6
    //================================================

    [SerializeField] private Button skipButton;

    public void DisableSkipButton()
    {
        skipButton.gameObject.SetActive(false);
    }

    [System.Serializable]
    public class InventoryUI
    {
        public GameObject pan_Inventory;
        public bool isOpen;
        public GameObject[] itemSloths;

        public void OpenInventory()
        {
            pan_Inventory.SetActive(true);
            isOpen = true;
            instance.UnLock();
        }
        public void CloseInventory()
        {
            pan_Inventory.SetActive(false);
            isOpen = false;
            instance.Lock();
        }

        public void AddItem(Sprite image, int itemCount)
        {
            itemSloths[itemCount].GetComponentInChildren<Image>().sprite = image;
        }
    }

    public InventoryUI uiInventory;
    public CodeUI codeWindow;

    public void OpenCodeWindow(Riddle sender)
    {
        codeWindow.gameObject.SetActive(true);
        codeWindow.SetRiddleData(sender);
        PlayerActions.instance.UnLock();
    }

    public void CloseCodeWindow()
    {
        codeWindow.gameObject.SetActive(false);
        PlayerActions.instance.Lock();
    }
}