using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorNumbLock : MonoBehaviour, Iinteractable
{
    public Animator animator;
    private bool isOpen = false;
    private bool isLocked = true;
    public NumberLock NumberLock;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        
    }

    public void Interact(Transform interactorTransform)
    {
        if (isLocked)
        {
            NumberLock.ShowLock();
        }
        else
        {
            ToggleDoor();
        }
    }

    public void UnlockDoor()
    {
        isLocked = false;
        ToggleDoor();
    }

    private void ToggleDoor()
    {
        isOpen = !isOpen;
        animator.SetBool("IsOpen", isOpen);
    }

    public string GetInteractText()
    {
        return isLocked ? "Enter Code" : "Open/Close Door";
    }

}
