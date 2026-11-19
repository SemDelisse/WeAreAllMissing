using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseSceneActivator : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           SplineManager.Instance.StartChase();
        }
    }
}
