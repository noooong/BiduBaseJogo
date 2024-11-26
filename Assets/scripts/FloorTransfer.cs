using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorTransfer : MonoBehaviour
{

    [SerializeField]
    private string nomeProximaFase;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<BiduController>())
        {
            IrProximaFase();
        }
    }
    private void IrProximaFase()
    {
        SceneManager.LoadScene(this.nomeProximaFase);
    }

}
