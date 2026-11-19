using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractionUI : MonoBehaviour
{
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private Interaction Interaction;
    [SerializeField] private TextMeshProUGUI interactTextMeshProUGUI;

    private void Update()
    {
        if (Interaction.GetInteractableObject() != null)
        {
            Show(Interaction.GetInteractableObject());
        }
        else
        {
            Hide();
        }
    }

    private void Show(Iinteractable interactable) {
        containerGameObject.SetActive(true);
        interactTextMeshProUGUI.text = interactable.GetInteractText();
    }

    private void Hide()
    {
        containerGameObject.SetActive(false);
    }
}
