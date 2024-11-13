using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    [SerializeField] UnityEvent OnInteract;
    [SerializeField] GameObject UI;
    [SerializeField] bool InTrigger;


    void Start()
    {
        UI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BiduController>())
        {
            InTrigger = true;
            UI.SetActive(true);
 
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<BiduController>())
        {
            InTrigger = false;
            UI.SetActive(false);
        }
    }

    private void Update()
    {
        if (InTrigger)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {

                OnInteract.Invoke();


            }

        }

    
    }





}

