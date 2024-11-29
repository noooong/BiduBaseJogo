using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;



    

public class FastForwardVideo : MonoBehaviour
{
    VideoPlayer videoPlayer;
    [SerializeField] GameObject PauseSimbol;
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        PauseSimbol.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { SceneManager.LoadScene("Main Manu"); }

        if (Input.GetKey(KeyCode.Space) && videoPlayer.playbackSpeed != 0) { videoPlayer.playbackSpeed = 5; }
        if (Input.GetKeyUp(KeyCode.Space) && videoPlayer.playbackSpeed != 0) { videoPlayer.playbackSpeed = 1; }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (videoPlayer.playbackSpeed != 0) { videoPlayer.playbackSpeed = 0; PauseSimbol.SetActive(true); }
            else { videoPlayer.playbackSpeed = 1; PauseSimbol.SetActive(false); }
        }

    }
}

