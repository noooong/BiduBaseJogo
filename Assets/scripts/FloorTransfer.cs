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

        
        if (collision.GetComponent<BiduController>() || collision.GetComponent<PlayerCtrl>())

        {
            IrProximaFase();
        }
    }

    public IEnumerator Wait()
    {
        new WaitForSeconds(0.5f);
        IrProximaFase();
        yield return true;
    }

    private void IrProximaFase()
    {
        SceneManager.LoadScene(this.nomeProximaFase);
    }

}
