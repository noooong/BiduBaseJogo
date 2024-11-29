using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using  System.Threading.Tasks;
using Unity.VisualScripting;
using System;
using System.Linq;

public class DialogueManager : MonoBehaviour
{
    //aqui colocamos uma fila de frases,nomes e sprites
    Queue<string> sentences = new Queue<string>();
    private Queue<string> nomeQueue = new Queue<string>();
    private Queue<Sprite> SpriteQueue = new Queue<Sprite>();
    public static DialogueManager instance;

    public GameObject CaixaDeDialogo;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image TalkingPicture;

    bool GoToNextDialogue;

    //o void awake garante que só exista uma instância de DialogueManager, caso uma nova instância for criada, a anterior vai ser destruída
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(instance );
        }
        Debug.Log(gameObject.name);
        instance = this;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GoToNextDialogue = true;
        }
    }

    public void StartDialogue (Dialogue dialogue, NPC_DT DT = null)
    {
        
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.setences)
        {
            sentences.Enqueue(sentence);
        }

        StartCoroutine(DisplayNextSentence(DT));
        // chamando o DisplayNextSentence para exibir a proxima frase
    }


    public void StartDialogue(List<Dialogue> dialogues, NPC_DT DT)
    {
        nameText.text = "";
        dialogueText.text = "";
        TalkingPicture.sprite = null;
        SpriteQueue.Clear();
        nomeQueue.Clear();
        sentences.Clear();
        CaixaDeDialogo.SetActive(true);
        sentences.Clear();
        foreach(Dialogue dialogue in dialogues) { 
            
            foreach (string sentence in dialogue.setences)
            {
                SpriteQueue.Enqueue(dialogue.Foto);
                nomeQueue.Enqueue(dialogue.name);
                sentences.Enqueue(sentence);
               // Debug.Log(sentence);
                
                
            }
        }
       // TalkingPicture.gameObject.SetActive(SpriteQueue.Count != 0); 
        
        StartCoroutine(DisplayNextSentence(DT));
        
    }
    IEnumerator DisplayNextSentence(NPC_DT DT)
    {


        //verificando se tem mais frases na lista, se não houver, chama o EndDialogue
        if (sentences.Count == 0) 
        {
            EndDialogue(DT);
            yield return null; 
        }
        string sentence = "";
        if (sentences.Count > 0) { sentence = sentences.Dequeue(); }
        
        dialogueText.text = sentence;
        


        if (SpriteQueue.Count > 0)
        {
            Sprite foto = SpriteQueue.Dequeue();
            TalkingPicture.sprite = foto;

        }

        if (nomeQueue.Count > 0) {
            string nome = nomeQueue.Dequeue();
            nameText.text = nome;
        }

        while (GoToNextDialogue == false) 
        {
            
           yield return null;
        }
        GoToNextDialogue = false;
        Debug.Log("Teste");
        StartCoroutine(DisplayNextSentence(DT));

    }


    //desativa a caixa de dialogo se não houver mais frases para exibir
    void EndDialogue(NPC_DT DT)
    {
        Debug.Log("EndDialogue");
        if (DT != null) { DT.TriggerEndDialogue(); }
        else { Debug.Log("Nenhum DT encontrado"); }
        CaixaDeDialogo.SetActive(false);
    }

}
