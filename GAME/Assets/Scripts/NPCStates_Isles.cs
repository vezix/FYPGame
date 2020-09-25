using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCStates_Isles : MonoBehaviour
{
    // Start is called before the first frame update
    public BoxCollider[] Points;
    public BoxCollider Counter;
    NavMeshAgent agent;

   private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            Debug.Log("NPC Entered");

            int i = Random.Range(0, Points.Length);
            agent  = other.GetComponent<NavMeshAgent>();
            StartCoroutine(Browse(i,other));
        }
    }

    IEnumerator Browse(int i,Collider other)
    {
        NPCStates CheckingIsle = other.GetComponent<NPCStates>();
        yield return new WaitForSeconds(5);
        if (agent != null)
        {
            if (CheckingIsle.checkingIsle > 0)
            {
                agent.SetDestination(Points[i].transform.position);
                Debug.Log("Onto Next Isle");
            }
            else
            {
                agent.SetDestination(Counter.transform.position);
                Debug.Log("Onto Counter");
            }
            CheckingIsle.checkingIsle--;
            Debug.Log(CheckingIsle.checkingIsle);

        }
    }

}
