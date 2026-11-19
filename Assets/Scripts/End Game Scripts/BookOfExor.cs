using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookOfExor : MonoBehaviour, Iinteractable
{
    [SerializeField] GameObject _bookOfExorSecond;
    [SerializeField] GameObject _endScreen;

    public bool canUse = false;
    public bool foundBook = false;
    bool searchForBook = false;
    MeshRenderer ren;

    private void Start()
    {
        _bookOfExorSecond.SetActive(false);
        ren = GetComponent<MeshRenderer>();
    }

    public string GetInteractText()
    {
        if (searchForBook) return foundBook ? "Start Ritual AGAIN" : "Need a book";

        return canUse ? "Start Ritual" : "Not Ready Yet";
    }

    public void Interact(Transform interactorTransform)
    {
        if (searchForBook && foundBook)
        {
            _endScreen.SetActive(true);
            Time.timeScale = 0f;

            Debug.Log("Game is over, finnally, you can fuck off now");
            return;
        }

        if (canUse && !searchForBook) TeleportBook();
    }

    void TeleportBook()
    {
        searchForBook = true;
        ren.enabled = false;
        _bookOfExorSecond.SetActive(true);
    }

    public void StartChaseScene()
    {
        SplineManager.Instance.StartChase();
        foundBook = true;
        _bookOfExorSecond.SetActive(false);
    }
}