using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour, Iinteractable
{
    private MeshRenderer sphereMeshRenderer;
    public Material blueMaterial;
    public Material yellowMaterial;

    private bool isColorYellow;

    private void SetColorBlue()
    {
        sphereMeshRenderer.material = blueMaterial;
    }

    private void SetColorYellow()
    {
        sphereMeshRenderer.material = yellowMaterial;
    }

    private void ToggleColor()
    {
        isColorYellow = !isColorYellow;
        if (isColorYellow)
        {
            SetColorYellow();
        }
        else
        {
            SetColorBlue();
        }
    }

    public void PushButton()
    {
        ToggleColor();
    }

    public void Interact(Transform interactorTransform)
    {
        PushButton();
    }

    public string GetInteractText()
    {
        return "Push button";
    }

}
