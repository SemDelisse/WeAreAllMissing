using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour,Iinteractable
{
    [SerializeField] int _candleOrderNum;
    //[SerializeField] List<GameObject> _candleLight = new List<GameObject>();
    public bool lit = false;

    public string GetInteractText()
    {
        return lit ? "Ow thats hot" : "Light Candle";
    }

    public Transform GetTransform()
    {
        throw new System.NotImplementedException();
    }

    public void Interact(Transform interactorTransform)
    {
        if (lit) return;
        ToggleCandles(true);
        PentagramSymbols.Instance.ActivateCandle(_candleOrderNum);
    }

    public void ToggleCandles(bool on)
    {
        lit = on;
        foreach (Transform light in transform)
        {
            light.gameObject.SetActive(on);
        }

    }
}
