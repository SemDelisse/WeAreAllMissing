using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.Video;

public class AI_Interact : MonoBehaviour
{
    public static AI_Interact Instance { get; private set; }

    [SerializeField] BookOfExor BookOfExor;
    [SerializeField] GameObject _bookOfExorSecond;

    PlayerMovement pm;
    [SerializeField] GameObject playerModel;
    public List<SkinnedMeshRenderer> renDemonModel = new List<SkinnedMeshRenderer>();
    [SerializeField] GameObject respawnPoint;
    [SerializeField] SplineAnimate splineAnimate;
    [SerializeField] VideoPlayer videoPlayer;

    public BoxCollider demonBoxCollider;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        demonBoxCollider.enabled = false;
        foreach (SkinnedMeshRenderer mesh in renDemonModel) mesh.enabled = false;

        demonBoxCollider = GetComponent<BoxCollider>();
        pm = FindAnyObjectByType<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(CaughtSequence());
        }
    }

    IEnumerator CaughtSequence()
    {
        BookOfExor.foundBook = false;
        _bookOfExorSecond.SetActive(true);

        pm.lockMovement = true;
        videoPlayer.Play();

        yield return new WaitForSeconds(1f);

        CharacterController cc = playerModel.GetComponent<CharacterController>();
        cc.enabled = false;
        playerModel.transform.position = respawnPoint.transform.position;
        cc.enabled = true;

        splineAnimate.Restart(false);

        yield return new WaitForSeconds(Convert.ToSingle(videoPlayer.length)); //if video is done
        Debug.Log("VideoDone");
        videoPlayer.Stop();
        pm.lockMovement = false;
        foreach (SkinnedMeshRenderer mesh in renDemonModel) mesh.enabled = false;
        demonBoxCollider.enabled = false;
        SplineManager.Instance.BarrierHandler(false);
    }
}
