using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] UnityEvent OnInteract;
    [SerializeField] GameObject UI;
    // Start is called before the first frame update
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.GetComponent<BiduController>())
        {
            if (Input.GetKeyDown(KeyCode.E)) { 
                Debug.Log(collision.gameObject.name);
                OnInteract.Invoke();
            }
        }
    }
}
