using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class JumpScare : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    //public AudioSource scareAudio;

    private bool hasPlayed = false;

    private void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed && other.CompareTag("Player"))
        {
            hasPlayed = true;
            videoPlayer.Play();

           // if (scareAudio != null)
               //scareAudio.Play();
        }
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        
        videoPlayer.enabled = false;

        
    }
}
