using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeUI : MonoBehaviour
{

    public GameObject pan_Code;
    public int[] solution;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenPan()
    {
        pan_Code.SetActive(true);
        UiManager.instance.UnLock();
    }
    public void ClosePan()
    {
        pan_Code.SetActive(false);
        UiManager.instance.Lock();
    }
    public void CheckSoulotin()
    {

    }
    private void Solved()
    {

    }
}
