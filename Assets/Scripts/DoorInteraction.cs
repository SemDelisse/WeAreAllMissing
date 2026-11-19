using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DoorInteraction : MonoBehaviour, Iinteractable
{

    public Animator animator;
    private bool isOpen;
  

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
        animator.SetBool("IsOpen", isOpen);
    }

    public void Interact(Transform interactorTransform)
    {

            ToggleDoor();
        
    }

    public string GetInteractText()
    {
        return "Open/Close Door";
    }

   

}