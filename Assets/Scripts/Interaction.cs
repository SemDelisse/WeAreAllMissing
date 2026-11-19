using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    
    [SerializeField] private float InterActionDistance = 3f;


    [SerializeField] private LayerMask InterActionLayer;


    [SerializeField] private Camera Camera;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Iinteractable interactable = GetInteractableObject();
            if (interactable != null)
            {
                interactable.Interact(transform);
            }

        }
    }


    public Iinteractable GetInteractableObject()
    {
        Ray ray = new Ray(Camera.transform.position, Camera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, InterActionDistance, InterActionLayer))
        {
            if (hit.collider.TryGetComponent(out Iinteractable interactable))
            {
                return interactable;
            }
        }

        return null;
    }

}
