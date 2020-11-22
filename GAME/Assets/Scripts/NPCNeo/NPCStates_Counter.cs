using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCStates_Counter : MonoBehaviour
{
    // Start is called before the first frame update
    public BoxCollider outside;
    private Animator anim;
    NavMeshAgent agent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            Debug.Log("NPC Entered");
            anim = other.GetComponentInChildren<Animator>();
            agent = other.GetComponent<NavMeshAgent>();
            StartCoroutine(goout(other));
        }
    }

    IEnumerator goout(Collider other)
    {
        anim.Play("Searching Pockets");
        yield return new WaitForSeconds(2);
        anim.Play("Idle");
        if (agent != null)
        {
                agent.SetDestination(outside.transform.position);
                Debug.Log("Onto Outside");

        }
    }

}
