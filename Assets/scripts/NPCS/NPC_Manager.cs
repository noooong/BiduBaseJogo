using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC_Manager : MonoBehaviour
{
    public GameObject Cordeiro1;
    public GameObject Cordeiro2;
    public  bool ViraCasaca = false;
    public GameObject MiniGameDeEnergia;


    private void Awake()
    {
      
            Cordeiro2.SetActive(false);
       
    }

     public void Trocou()
    {
        Cordeiro2.SetActive(true);
        Cordeiro2.transform.position = Cordeiro1.transform.position;
        Cordeiro1.SetActive(false);
        Debug.Log("teste");
    }


    public void CaixaLigada()
    {
        MiniGameDeEnergia.SetActive(true);
    }
}
