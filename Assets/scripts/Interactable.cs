using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    [SerializeField] UnityEvent OnInteract;
    [SerializeField] GameObject UI;
    [SerializeField]
    

    void Start()
    {
        UI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BiduController>())
        {
            UI.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<BiduController>())
        {
            UI.SetActive(false);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        

        if (collision.gameObject.tag == "Player")
        {
           
            if (Input.GetKey(KeyCode.E))
            {
                
                OnInteract.Invoke();
                
                //SceneManager.LoadScene(nomeQuarto);
            }
        }

    }

    

    /*
    private void EntrarNoQuarto()
    {
        SceneManager.LoadScene(nomeQuarto);
    }
    */
}

