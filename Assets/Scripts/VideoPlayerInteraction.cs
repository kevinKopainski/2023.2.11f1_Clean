using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerInteraction : MonoBehaviour
{
    private bool CanInteractWithVideo = false;

    [SerializeField] private GameObject Videoplayer;
    [SerializeField] private string URL;
    [SerializeField] private GameObject UI;

    private void Start()
    {
        Videoplayer.GetComponent<VideoPlayer>().url = URL;
        UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(CanInteractWithVideo == true)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                StartStopVideo();
            }

            if(Input.GetKeyDown(KeyCode.M))
            {
                MuteUnMuteVideo();
            }

            if(Input.GetKeyDown(KeyCode.R))
            {
                ResetVideo();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CanInteractWithVideo = true;
            UI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CanInteractWithVideo = false;
            UI.SetActive(false);
        }
    }

    private void StartStopVideo()
    {
        if(Videoplayer.GetComponent<VideoPlayer>().isPlaying)
        {
            Videoplayer.GetComponent<VideoPlayer>().Pause();
        }
        else
        {
            Videoplayer.GetComponent<VideoPlayer>().Play();
        }
    }

    private void MuteUnMuteVideo()
    {
        if (Videoplayer.GetComponent<VideoPlayer>().GetDirectAudioMute(0) == true)
        {
            Videoplayer.GetComponent<VideoPlayer>().SetDirectAudioMute(0, false);
        }
        else
        {
            Videoplayer.GetComponent<VideoPlayer>().SetDirectAudioMute(0, true);
        }
    }

    private void ResetVideo()
    {
        Videoplayer.GetComponent<VideoPlayer>().frame = (long)1;
        Videoplayer.GetComponent<VideoPlayer>().Play();
    }
}
