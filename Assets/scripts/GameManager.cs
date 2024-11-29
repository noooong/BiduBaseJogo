using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public EstadoCordeiro estadoCordeiro = EstadoCordeiro.Neutro;
    public static GameManager Instance;
    

    private void Awake()
    {
        if(Instance != null && Instance != this) { Destroy(gameObject); }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }



}

public enum EstadoCordeiro

{
    Neutro,
    SeguindoBidu,
    Saiu
}
