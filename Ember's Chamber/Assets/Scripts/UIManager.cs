using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
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
}