using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ReplaceScene : MonoBehaviour
{
    public string[] sceneName;
    public static ReplaceScene instance;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(instance );
        }

        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ChangeLevelAtRandom()
    {
        SceneManager.LoadScene(sceneName[(int)Random.Range(0, sceneName.Length)]);
        //os labirintos vão ser puxados aleatoriamente de acordo com a quantidade de cenas colocadas na string
    }

    public void ChangeLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
