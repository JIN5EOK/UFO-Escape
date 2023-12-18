using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class Intro : MonoBehaviour
{
    private VideoPlayer _vPlayer;
    private double _videoLength;
    private void Start()
    {
        _vPlayer = GetComponent<VideoPlayer>();
        _vPlayer.Play();
        StartCoroutine("PlayingCheck");
    }

    IEnumerator PlayingCheck()
    {
        bool isPressEsc = false;
        
        while (_vPlayer.isPlaying == true && isPressEsc == false)
        {
            isPressEsc = Input.GetKeyDown(KeyCode.Escape);
            yield return null;
        }
        
        ScenesManager.Instance.LoadScene("MainMenu");
    }
}
