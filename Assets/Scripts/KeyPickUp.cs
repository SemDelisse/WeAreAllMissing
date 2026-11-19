using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour, Iinteractable
{
    [SerializeField] InventoryItem _inventoryItem;

    public DoorKey door;

    public void Interact(Transform interactorTransform)
    {
        if (door != null)
        {
            door.SetHasKey(true);
            Debug.Log("Key Collected!");
        }

        if (InventoryManager.Instance) InventoryManager.Instance.AddItemToInventory(_inventoryItem);
        Destroy(gameObject);
    }

    public string GetInteractText()
    {
        return "Press E to pick up the key";
    }
}
