using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    public GameObject pan_BearsTextMSG;
    public TextMeshProUGUI text;
    public string[] textForTutorial;
    public GameObject btn_Skip;

    int nextText = 0;
    bool isDoneExplain;

    public void StartTutorial()
    {
        isDoneExplain = false;
        pan_BearsTextMSG.SetActive(true);
        UIManager.instance.UnLock();
        Next();
    }

    public void Next()
    {
        if(nextText == 1) // if we are starting Tutorial explain movement
        {
            btn_Skip.SetActive(false);
        }
        if(isDoneExplain)// if we are done the explaination
        {
            Debug.Log("in here");
            pan_BearsTextMSG.SetActive(false);
            UIManager.instance.Lock();
        }
        if(textForTutorial.Length > nextText)
        text.text = textForTutorial[nextText];
        nextText++;
        Debug.Log("in here: " + nextText);
        if (nextText == 1)
        {
            isDoneExplain = true;
        }
    }
    public void Skip()
    {
        Debug.Log("skipping tutorial, save point");
    }
}
