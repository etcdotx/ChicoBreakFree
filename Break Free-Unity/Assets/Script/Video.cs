using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    public VideoPlayer videos;
    void Start()
    {
        videos = GetComponent<VideoPlayer>();
    }

    
    // Update is called once per frame
    void Update()
    { 
        if (!videos.isPlaying || Input.GetKey(KeyCode.Space)) {
            SceneManager.LoadScene(1);
        }
    }
}
