using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCStates_Isles : MonoBehaviour
{
    // Start is called before the first frame update
    public BoxCollider[] Points;
    public Transform CounterParent; 
    private BoxCollider[] Counter;
    private Animator anim;
    public int waiting = 5;
    NavMeshAgent agent;

    private void Start()
    {
        Counter = CounterParent.GetComponentsInChildren<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            Debug.Log("NPC Entered");

            int i = Random.Range(0, Points.Length);
            int j = Random.Range(0, Counter.Length);
            agent  = other.GetComponent<NavMeshAgent>();
            anim = other.GetComponentInChildren<Animator>();
            StartCoroutine(Browse(i,j,other));
        }
    }

    IEnumerator Browse(int i,int j,Collider other)
    {
        NPCStates CheckingIsle = other.GetComponent<NPCStates>();

        anim.Play("Thinking");
        yield return new WaitForSeconds(waiting);
        anim.Play("Idle");
        if (agent != null)
        {
            if (CheckingIsle.checkingIsle > 0)
            {
                agent.SetDestination(Points[i].transform.position);
                Debug.Log("Onto Next Isle");
            }
            else
            {
                agent.SetDestination(Counter[j].transform.position);
                Debug.Log("Onto Counter");
            }
            CheckingIsle.checkingIsle--;
            Debug.Log(CheckingIsle.checkingIsle);

        }
    }

}
