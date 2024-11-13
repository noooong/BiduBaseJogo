using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoBase : MonoBehaviour
{
   public int vida { get; protected set; }

    public void LevaDano(int dano)
    {
        vida -= dano;
        Debug.Log(vida);
    }
}
