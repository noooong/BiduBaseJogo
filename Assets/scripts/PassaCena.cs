using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PassaCena : MonoBehaviour
{

    [SerializeField] VideoPlayer videoPlayer;
    public string SceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        StartCoroutine(NextScene());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneToLoad);
        }
    }

    IEnumerator NextScene()
    {
        while (videoPlayer.frame < (long)videoPlayer.frameCount - 2) { 
        Debug.Log("frame: " + videoPlayer.frame + " de: " + videoPlayer.frameCount);
            yield return null;
        }
        SceneManager.LoadScene(SceneToLoad);
    }
}
