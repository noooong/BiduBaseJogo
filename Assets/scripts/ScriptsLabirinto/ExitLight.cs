using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLight : MonoBehaviour
{
   [SerializeField] public GameObject Luzinha;
    PlayerCtrl playerCtrl;
    Door door;
    void Start()
    {
        
    }

   
    void Update()
    {

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))     
            Luzinha.SetActive(true);
             //StartCoroutine(Perai());
    }
   private void OnTriggerExit2D(Collider2D collision)
    {
        Luzinha.SetActive(false);
    }
    public IEnumerator Perai()
    {
       new WaitForSeconds(2);
        chamaodoor();
        yield return true;
    }
    public void chamaodoor()
    {
        door.CarregaCena("SampleScene");
    }

}
