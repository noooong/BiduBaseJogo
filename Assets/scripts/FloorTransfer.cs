using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorTransfer : Door
{
    public string CenaACarregar;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BiduController>()) 
        { 
            CarregaCena(CenaACarregar);
        }
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        
    }

}
