using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class DoorKey : MonoBehaviour,Iinteractable
{
    public Animator animator;
    private bool isOpen = false;
    private bool hasKey = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetHasKey(bool value)
    {
        hasKey = value;
    }

    public void ToggleDoor()
    {
        if (!hasKey)
        {
            Debug.Log("The door is locked. You need a key.");
            return;
        }

        isOpen = !isOpen;
        animator.SetBool("IsOpen", isOpen);
    }

    public void Interact(Transform interactorTransform)
    {
        ToggleDoor();
    }

    public string GetInteractText()
    {
        return hasKey ? "Open/Close Door" : "Door Locked";
    }

}
