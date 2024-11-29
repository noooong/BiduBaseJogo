using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CordeiroConversa : MonoBehaviour
{
    
    void Start()
    {
        if(GameManager.Instance.estadoCordeiro != EstadoCordeiro.Neutro)
        {
            gameObject.SetActive(false);
        }

            //gameObject.SetActive(GameManager.Instance.JaConversouCordeiro);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
