using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    MeshRenderer meshRenderer;
    [SerializeField] bool useDebugMat;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        if (!useDebugMat) DisableBarrierDebugMat();
    }

    //public void EnableBarrierDebugMat()
    //{
    //    meshRenderer.enabled = true;
    //}
    public void DisableBarrierDebugMat()
    {
        meshRenderer.enabled = false;
    }
}
