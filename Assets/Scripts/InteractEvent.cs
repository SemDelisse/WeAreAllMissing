using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractEvent : MonoBehaviour
{
    public delegate void InteractHandler();
    public event InteractHandler HasInteracted;

    public void CallInteractEvent() => HasInteracted?.Invoke();
}
