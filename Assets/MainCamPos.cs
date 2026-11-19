using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamPos : MonoBehaviour
{
    public static MainCamPos Instance { get; private set; }
    [SerializeField] GameObject mainCam;

    [HideInInspector] public bool inPuzzle = false;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Reticle.Instance.gameObject.SetActive(!inPuzzle);
        if (!inPuzzle) transform.rotation = mainCam.transform.rotation;

    }
}
