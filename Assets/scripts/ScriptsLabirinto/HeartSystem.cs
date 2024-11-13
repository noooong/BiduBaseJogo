using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    public int vida;
    public int vidaMax;

    public Image[] heart;
    public Sprite full;
    public Sprite empty;


    void Start()
    {
        
    }

    void Update()
    {
        HealthLogic();
    }

    void HealthLogic()
    {
        if (vida > vidaMax)
        {
            vida = vidaMax; 
        }

        for (int i = 0; i < heart.Length; i++)
        {
            if (i < vida)
            {
                heart[i].sprite = full;

            }
            else
            {
                heart[i].sprite = empty;
            }


            if (i < vidaMax)
            {
                heart[i].enabled = true;    
            }
            else
            {
                heart[i].enabled = false;
            }
        }

        if(vida <= 0)
        {
            ReplaceScene.instance.ChangeLevelAtRandom();
        }
        //instancia o novo labirinto caso a vida do jogador esteja igual ou menor que zero
    }


}
