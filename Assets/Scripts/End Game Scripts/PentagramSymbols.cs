using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PentagramSymbols : MonoBehaviour, Iinteractable
{
    public static PentagramSymbols Instance { get; private set; }

    [SerializeField] BookOfExor _bookOfExor;
    [SerializeField] List<GameObject> Symbol = new List<GameObject>();
    [SerializeField] List<GameObject> Candles = new List<GameObject>();

    public int SymbolsFound = 0;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ToggleSymbols(false);
        foreach (GameObject candle in Candles)
        {
            candle.SetActive(false);
        }
    }

    #region Interaction
    public string GetInteractText()
    {
        return "Read Book";
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact(Transform interactorTransform)
    {
        Note.Instance.ShowNote(
            "If the demon is ever summoned, perform this ritual!",

            "Investigate the symbols and put them in order \n" +
            "1. Kitchen \n" +
            "2. Music Room \n" +
            "3. Pink Room \n" +
            "4. Bedroom \n" +
            "5. Boiler Room \n" +
            "\n" +
            "The candles must stay on in order to start the ritual propperly! \n" +
            "If the book dissapears, look in the house to find it again. The demon may trick you to make it harder to exorsice it! \n" +
            "dont worry about looking for ages, the book will be flying in the middle of a room. \n" +
            "\n" +
            "Good luck, Sincerely \n" +
            "Ludwig"

            , null);
        ToggleSymbols(true);
    }
    #endregion

    public void ToggleSymbols(bool show)
    {
        //Debug.Log("Interacted with symbols");
        foreach (GameObject symbol in Symbol)
        {
            symbol.SetActive(show);
        }
    }

    public void FindSymbol()
    {
        SymbolsFound++;
        if (SymbolsFound == Symbol.Count)
        {
            EnableCandles();

            foreach (GameObject candle in Candles)
            {
                Candle candleScript = candle.GetComponent<Candle>();
                if (candleScript != null) candleScript.ToggleCandles(false);
            }
        }
    }

    List<int> candleOrder = new List<int>();
    public void EnableCandles()
    {
        foreach (GameObject candle in Candles)
        {
            candle.SetActive(true);
        }
    }

    public void ActivateCandle(int orderNum)
    {
        candleOrder.Add(orderNum);
        if (candleOrder.Count == 5)
        {
            for (int i = 0; i < candleOrder.Count; i++)
            {
                if (candleOrder[i] != i + 1)
                {
                    foreach (GameObject candle in Candles)
                    {
                        Candle candleScript = candle.GetComponent<Candle>();
                        if (candleScript != null) candleScript.ToggleCandles(false);
                    }

                    candleOrder.Clear();
                    Debug.Log("False Order!");
                    return;
                }
            }

            _bookOfExor.canUse = true;
            Debug.Log("Correct Order!");
        }
    }


}
