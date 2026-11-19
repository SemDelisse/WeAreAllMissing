using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    public static Reticle Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
}
