using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CordeiroConversa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.Instance.estadoCordeiro != EstadoCordeiro.Neutro)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
