using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour
{
    public int value;
    public GameObject PickupEffect;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<GameManager>().AddGold(value);
            FindObjectOfType<AudioManager>().PlaySFX("Coin");
            Destroy(gameObject);
        }
    }
}
