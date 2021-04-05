using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeUI : MonoBehaviour
{

    public GameObject pan_Code;
    public int[] solution;
    
    public void OpenPan()
    {
        pan_Code.SetActive(true);
        UIManager.instance.UnLock();
    }
    public void ClosePan()
    {
        pan_Code.SetActive(false);
        UIManager.instance.Lock();
    }
    public void CheckSoulotin()
    {

    }
    private void Solved()
    {

    }
}
