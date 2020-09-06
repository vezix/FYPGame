using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationChange : MonoBehaviour
{
    // Start is called before the first frame update
    private int xPos, zPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            xPos = Random.Range(-20,20);
            zPos = Random.Range(-20,20);

            this.gameObject.transform.position = new Vector3(xPos, 1.5f, zPos);
        }
    }

  /*  private void OnTriggerStay(Collider other)
    {
        if (other.tag == "NPC")
        {
            xPos = Random.Range(-34, 12);
            zPos = Random.Range(-16, 31);

            this.gameObject.transform.position = new Vector3(xPos, 1.5f, zPos);
        }
    }
  */
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
