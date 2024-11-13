using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AIPath))]
[RequireComponent (typeof(Seeker))]
[RequireComponent(typeof (AIDestinationSetter))]
public class IACompanion : MonoBehaviour
{
   [SerializeField] AIPath aiPath;
    [SerializeField] Seeker seeker;
    [SerializeField] AIDestinationSetter destinationSetter;

    private void Awake()
    {
        if(aiPath == null) { aiPath = GetComponent<AIPath>(); }
        if(seeker == null) {  seeker = GetComponent<Seeker>(); }
        if (destinationSetter == null) {  destinationSetter = GetComponent<AIDestinationSetter>();}
    }

   public void SeguePlayer(Transform player)
    {
        destinationSetter.target = player;

    } 
}
