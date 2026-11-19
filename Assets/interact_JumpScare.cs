using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class interact_JumpScare : MonoBehaviour, Iinteractable
{
    public Animator animator;
    private bool isOpen;
    public VideoPlayer videoPlayer;
    //public AudioSource scareAudio;

    private bool hasPlayed = false;

    private void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
        animator.SetBool("IsOpen", isOpen);
    }

    public void Interact(Transform interactorTransform)
    {


        if (!hasPlayed && CompareTag("Player"))
        {
            hasPlayed = true;
            videoPlayer.Play();
            ToggleDoor();
            // if (scareAudio != null)
            //scareAudio.Play();
        }
    }

    public string GetInteractText()
    {
        return "Open/Close Door";
    }

   

    private void OnVideoEnd(VideoPlayer vp)
    {

        videoPlayer.enabled = false;


    }
}
    
