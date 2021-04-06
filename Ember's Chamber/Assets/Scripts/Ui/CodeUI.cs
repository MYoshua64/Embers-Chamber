using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CodeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] digitTexts;

    private Riddle ownerRiddle;
    private int[] code = new int[3];

    private void OnEnable()
    {
        code = new int[3];
    }

    public void IncrementDigit(int index)
    {
        code[index] = (code[index] + 1) % 10;
        digitTexts[index].text = code[index].ToString();
    }

    public void DecrementDigit(int index)
    {
        code[index] = (10 + code[index] - 1) % 10;
        digitTexts[index].text = code[index].ToString();
    }

    public void TryOpen()
    {
        ownerRiddle.CheckSolution(code);
    }

    public void SetRiddleData(Riddle sender)
    {
        ownerRiddle = sender;
    }
}
