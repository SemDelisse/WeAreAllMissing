using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteInteraction : MonoBehaviour, Iinteractable
{
    Note note;

    [SerializeField] string _headerText;
    [TextArea(5,10)]
    [SerializeField] string _descriptionText;

    [SerializeField] Sprite _pageImg;

    private void Start()
    {
        note = Note.Instance;
    }

    public void Interact(Transform interactorTransform)
    {
        note.ShowNote(_headerText, _descriptionText, _pageImg);
    }

    public string GetInteractText()
    {
        return "Read Note";
    }
}
