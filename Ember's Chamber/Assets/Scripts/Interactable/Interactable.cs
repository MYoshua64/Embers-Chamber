using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Interactable : MonoBehaviour
{

    public UnityEvent GotInteracted;
    [SerializeField]
    public Animator animator;
    private void OnMouseDown()
    {
        Interaction();
    }

    public  virtual void Interaction()
    {
        animator.SetBool("CanPlayAnim", true);
        GotInteracted.Invoke();
    }
}
