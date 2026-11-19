using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class SplineManager : MonoBehaviour
{
    public static SplineManager Instance { get; private set; }
    AI_Interact AI_Interactor;

    [SerializeField] List<GameObject> chaseBarriers = new List<GameObject>();
    [SerializeField] SplineAnimate splineAnimator;

    private void Awake()
    {
        AI_Interactor = AI_Interact.Instance;
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        BarrierHandler(false);
    }

    public void StartChase()
    {
        AI_Interactor.demonBoxCollider.enabled = true;

        foreach (SkinnedMeshRenderer mesh in AI_Interactor.renDemonModel) mesh.enabled = true;
        BarrierHandler(true);

        splineAnimator.Play();
    }

    public void BarrierHandler(bool active)
    {
        foreach (GameObject barier in chaseBarriers)
        {
            barier.SetActive(active);
        }
    }
}