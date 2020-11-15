using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCStates_Isles : MonoBehaviour
{
    // Start is called before the first frame update
    public BoxCollider[] Points;
    public BoxCollider Counter;
    private Animator anim;
    NavMeshAgent agent;

   private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            Debug.Log("NPC Entered");

            int i = Random.Range(0, Points.Length);
            agent  = other.GetComponent<NavMeshAgent>();
            anim = other.GetComponentInChildren<Animator>();
            StartCoroutine(Browse(i,other));
        }
    }

    IEnumerator Browse(int i,Collider other)
    {
        NPCStates CheckingIsle = other.GetComponent<NPCStates>();

        anim.Play("Thinking");
        yield return new WaitForSeconds(5);
        anim.Play("Idle");
        if (agent != null)
        {
            if (CheckingIsle.checkingIsle > 0)
            {
                agent.ResetPath();
                agent.SetDestination(Points[i].transform.position);
                Debug.Log("Onto Next Isle");
            }
            else
            {
                agent.ResetPath();
                agent.SetDestination(Counter.transform.position);
                Debug.Log("Onto Counter");
            }
            CheckingIsle.checkingIsle--;
            Debug.Log(CheckingIsle.checkingIsle);

        }
    }

}
