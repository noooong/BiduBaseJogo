using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotaDialogo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // if (Input.GetKeyDown(KeyCode.E)) { DialogueManager.instance.DisplayNextSentence(GetComponent<NPC_DT>()); }
  
    }

    public void ChamaDialogo()
    {
        GetComponent<NPC_DT>().TriggerDialogue();
    }
}
