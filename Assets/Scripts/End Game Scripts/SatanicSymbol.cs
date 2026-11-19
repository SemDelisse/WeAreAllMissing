using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatanicSymbol : MonoBehaviour, Iinteractable
{
    bool hasBeenFound = false;
    public string GetInteractText()
    {
        return hasBeenFound ? null : "Investigate symbol";
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact(Transform interactorTransform)
    {
       if(!hasBeenFound) PentagramSymbols.Instance.FindSymbol();
       hasBeenFound = true;
        Destroy(this);
    }
}
