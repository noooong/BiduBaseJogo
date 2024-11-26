using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Teste : MonoBehaviour
{
    
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        PlayerPrefs.SetString("LastDoor", "");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
