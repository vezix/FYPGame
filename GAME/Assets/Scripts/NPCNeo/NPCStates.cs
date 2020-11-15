using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NPCStates : MonoBehaviour
{

    public Transform IsleParents;
    public int checkingIsle;
    [HideInInspector]
    NavMeshAgent theAgent;
    public Animator anim;
    BoxCollider[] isleNodes;

    private Vector3 previousPosition;
    public float curSpeed;
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
        bool interact = GetComponent<NPC>().getCurrentInteract();
        if (interact == true)
        {
            theAgent.isStopped = true;
        }
        else if (interact != true)
        {
            theAgent.isStopped = false;
        }

        Vector3 curMove = transform.position - previousPosition;
        curSpeed = curMove.magnitude / Time.deltaTime;
        previousPosition = transform.position;

        if (curSpeed != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else anim.SetBool("isWalking", false);
    }
}
