using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    public GameObject Jogador;


    private void Start()
    {
        Jogador = FindObjectOfType<BiduController>().gameObject;
    }

    public void CarregaCena(string CenaACarregar)
    { 
        SceneManager.LoadScene(CenaACarregar);
    }
}

