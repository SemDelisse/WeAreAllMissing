using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBookOfExor : MonoBehaviour, Iinteractable
{
    [SerializeField] BookOfExor bookOfExor;
    public string GetInteractText()
    {
        return "Grab Book";
    }

    public void Interact(Transform interactorTransform)
    {
        bookOfExor.StartChaseScene();
    }
}