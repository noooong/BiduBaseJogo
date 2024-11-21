using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : Interactable
{
    public static List<Door> PortasDaCena = new List<Door>();
     [HideInInspector]public string Nome;

    public GameObject Jogador;

    public Transform SpawnArea;

    private void Start()
    {
        Jogador = FindObjectOfType<BiduController>().gameObject;
        Jogador = FindObjectOfType<PlayerCtrl>().gameObject;



        if (Nome == "")
        {
            Nome = gameObject.name;
        }

        PortasDaCena.Add(this);

        for (int i = 0; i < PortasDaCena.Count; i++)
        {
            if (PortasDaCena[i].Nome == Nome && PortasDaCena[i] != this) 
            { 
                Nome = Nome + i; 
                PortasDaCena[i].gameObject.name = Nome; 
            }
        }
    }


    public void CarregaCena(string CenaACarregar)
    {
        PortasDaCena.Clear();
        PlayerPrefs.SetString("LastDoor", Nome);
       
        SceneManager.LoadScene(CenaACarregar);
    }
}
