using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Advertisements;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Music_continue : MonoBehaviour

{
    private static Music_continue instance;
    public GameObject Music_Controller;
    public AudioSource BGM;
    public AudioClip Track01;

    void Awake()
    {
        if (instance==null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(Music_Controller);
            Debug.Log("socorro");
        }

    } 
}