using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    //When a note is picked up it should display the right text
    //a method that is public and can be triggered for text to show up + the note
    //A method for closing the note

    public static Note Instance { get; private set; }

    PlayerMovement PMScript;

    [Header("Refs")]
    [SerializeField] TMP_Text _headerTMP;
    [SerializeField] TMP_Text _descriptionTMP;
    [SerializeField] Image _pageImage;
    [SerializeField] GameObject _canvas;

    private void Awake() {
        Instance = this;
    }

    void Start() {
        PMScript = FindAnyObjectByType<PlayerMovement>();
        _canvas.SetActive(false);
    }

    public void ShowNote(string _headerText, string _descriptionText, Sprite _pageImg) {
        //Using Header Txt Check
        if (_headerText != null) _headerTMP.text = _headerText;
        else _headerTMP.text = null;

        //Using Description Txt Check
        if (_descriptionText != null) _descriptionTMP.text = _descriptionText;
        else _descriptionTMP.text = null;

        //Using Img Check
        if (_pageImg != null)
        {
            _pageImage.gameObject.SetActive(true);
            _pageImage.sprite = _pageImg;
        }
        else _pageImage.gameObject.SetActive(false);

        PMScript.lockMovement = true;
        _canvas.SetActive(true);
    }
    public void HideNote() {
        PMScript.lockMovement = false;
        _canvas.SetActive(false);
    }
}
