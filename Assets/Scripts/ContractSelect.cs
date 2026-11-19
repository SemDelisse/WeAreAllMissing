using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContractSelect : MonoBehaviour
{
    PlayerMovement _pmScript;

    [SerializeField] private DialogManager dialogManager;
    [SerializeField] List<GameObject> _contractButtons = new List<GameObject>();
    [SerializeField] List<GameObject> _signatures = new List<GameObject>();

    [SerializeField] AudioSource _scribbleSFX;
    [SerializeField] float _closingDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.SetActive(true);
        _pmScript = FindAnyObjectByType<PlayerMovement>();
        if (_pmScript) _pmScript.lockMovement = true;

        if (_signatures != null)
        {
            foreach (GameObject signature in _signatures)
            {
                signature.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AcceptContract(int _contractNum)
    {

        _scribbleSFX.Play();
        _signatures[_contractNum - 1].SetActive(true);
        foreach (GameObject contract in _contractButtons)
        {
            contract.SetActive(false);
        }
        Invoke("removeObj", _closingDelay);
    }

    void removeObj()
    {
        this.gameObject.SetActive(false);
        dialogManager.gameObject.SetActive(true);
    }
}
