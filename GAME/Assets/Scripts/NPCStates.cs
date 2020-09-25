using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NPCStates : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform IsleParents;
    public int checkingIsle;
    [HideInInspector]

    NavMeshAgent theAgent;

    BoxCollider[] isleNodes;
    void Start()
    {
        theAgent = GetComponent<NavMeshAgent>();

        isleNodes = IsleParents.GetComponentsInChildren<BoxCollider>();
        Destination(); 
    }

    public void Destination()
    {
            int i = Random.Range(0, isleNodes.Length);
            theAgent.SetDestination(isleNodes[i].transform.position);
            Debug.Log(checkingIsle);
    }

    // Update is called once per frame
    void Update()
    { 
        bool interact = GetComponent<NPCInteraction>().getCurrentInteract();
        if (interact == true)
        {
            theAgent.isStopped = true;
        }
        else if (interact != true)
        {
            theAgent.isStopped = false;
        }
    }
}
