using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCStates_Outside : MonoBehaviour
{
    // Start is called before the first frame update
    public BoxCollider Inside;
    NavMeshAgent agent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            Debug.Log("NPC is Outside");

            agent = other.GetComponent<NavMeshAgent>();
            agent.ResetPath();
            agent.SetDestination(Inside.transform.position);
            Debug.Log("Onto Inside");

        }
    }

}
