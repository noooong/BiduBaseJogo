using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestarDialogo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<NPC_DT>().TriggerDialogue();
    }

    void Update()
    {
       // if (Input.GetKeyDown(KeyCode.Space)) { DialogueManager.instance.DisplayNextSentence(GetComponent<NPC_DT>()); }
    }
}
