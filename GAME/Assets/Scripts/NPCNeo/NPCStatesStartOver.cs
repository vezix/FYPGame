using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCStatesStartOver : MonoBehaviour
{
    // Start is called before the first frame update
    public BoxCollider[] Points;
    NavMeshAgent agent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            Debug.Log("NPC Restarted path");

            int i = Random.Range(0, Points.Length);
            agent = other.GetComponent<NavMeshAgent>();
            agent.ResetPath();
            agent.SetDestination(Points[i].transform.position);
            Debug.Log("Onto Next Isle");
            NPCStates CheckingIsle = other.GetComponent<NPCStates>();
            CheckingIsle.checkingIsle = 5;
            Debug.Log(CheckingIsle.checkingIsle);
        }
    }
}
