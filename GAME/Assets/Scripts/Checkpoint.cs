using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public HealthManager theHealthMan;
    public Renderer theRend;

    public Material cpOFF;
    public Material cpON;

    // Start is called before the first frame update
    void Start()
    {
        theHealthMan = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkpointOn()
    {
        Checkpoint[] checkpoints = FindObjectsOfType<Checkpoint>();
        foreach(Checkpoint cp in checkpoints)
        {
            cp.checkpointOff();
        }
        theRend.material = cpON;
    }
    public void checkpointOff()
    {
        theRend.material = cpOFF;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            theHealthMan.SetSpawnPoint(transform.position);
            checkpointOn();
        }
    }
}
