using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPC_DT : MonoBehaviour
{
    public List<Dialogue> dialogue;
    [SerializeField] UnityEvent OnDialogueEnd;

    public void TriggerDialogue()
    {
       
        DialogueManager.instance.StartDialogue(dialogue, this);
    }

    public void TriggerEndDialogue()
    {
        OnDialogueEnd.Invoke();     
    }



}
