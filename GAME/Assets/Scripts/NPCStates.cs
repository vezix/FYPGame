using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NPCStates : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform CounterParents;
    public Transform IsleParents;
    public int checkingIsle;
    int checkingIslecounter = 0;

    NavMeshAgent theAgent;

    BoxCollider[] counterNodes;
    BoxCollider[] isleNodes;
    void Start()
    {
        theAgent = GetComponent<NavMeshAgent>();

        counterNodes = CounterParents.GetComponentsInChildren<BoxCollider>();
        isleNodes = IsleParents.GetComponentsInChildren<BoxCollider>();
    }

    void Destination()
    {
        if (checkingIslecounter < checkingIsle) {
            int i = Random.Range(0, isleNodes.Length);
            theAgent.SetDestination(isleNodes[i].transform.position);
            checkingIsle++;
        }
        else
        {
            int i = Random.Range(0, counterNodes.Length);
            theAgent.SetDestination(counterNodes[i].transform.position);

        }
    }


    // Update is called once per frame
    void Update()
    {
        bool interact = GetComponent<NPCInteraction>().getCurrentInteract();
        if (interact == true)
        {
            theAgent.isStopped = true;
        }
        else theAgent.isStopped = false;
    }
}
