
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MiniGameQuickTime : MonoBehaviour
{

    [SerializeField] List<ItemJogo> jogos = new List<ItemJogo>();
    [SerializeField] int tentativas = 3;
    [SerializeField] int jogoAtual;
    public UnityEvent OnWin;
    public UnityEvent OnLose;
    [SerializeField] AudioClip WinSound, LoseSound;
    AudioSource audioSource;
    

    // Start is called before the first frame update
    void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();

        tentativas = 3;
        jogoAtual = 0;

       foreach (ItemJogo jogo in jogos)
        {
            jogo.Imagem.type = Image.Type.Filled;
            jogo.Imagem.fillMethod = Image.FillMethod.Radial360;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(jogoAtual < jogos.Count) 
        { 

            if(jogos[jogoAtual].Imagem.fillAmount >= 1 || jogos[jogoAtual].Imagem.fillAmount <= 0)
            {
                jogos[jogoAtual].Velocidade *= -1;
            }
            jogos[jogoAtual].Imagem.fillAmount += jogos[jogoAtual].Velocidade;

            if (Input.GetMouseButtonDown(0))
            {
                if (jogos[jogoAtual].Imagem.fillAmount > 0.8)
                {
                    jogos[jogoAtual].Imagem.fillAmount = 1;
                    jogoAtual++;
                
                }
                else { 
                
                    tentativas--; 
            
                    if(tentativas <= 0)
                    {
                        jogos[jogoAtual].Imagem.fillAmount = 1;
                        gameObject.SetActive(false);
                        audioSource.clip = LoseSound;
                        audioSource.Play();
                        Debug.Log("Perdeu MiniGame");
                        OnLose.Invoke();
                    }
                }

            }

            if(jogoAtual >= jogos.Count)
            {
                gameObject.SetActive(false);
                audioSource.clip = WinSound;
                audioSource.Play();
                Debug.Log("Venceu MiniGame");
                OnWin.Invoke();
                
            }
        }
    }

    [Serializable]
    class ItemJogo
    {
        public Image Imagem;
        public float Velocidade;
    }

}


