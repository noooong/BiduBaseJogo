using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public AIDestinationSetter Destino;
    AIPath aIPath;
    public GameObject Saida;
  

    private void Awake()
    {
        Destino = GetComponent<AIDestinationSetter>();
        aIPath = GetComponent<AIPath>();
    }
    void Start()
    {
        
    }

     void Update()
    {
        if (aIPath.reachedEndOfPath == true)
        {
            Destroy(this.gameObject);
        }
    }

    public void AcabaDialogo()
    {
        Destino.target = Saida.transform;
        aIPath.endReachedDistance = 0;


        

    }
}
