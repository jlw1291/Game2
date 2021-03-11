using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiationGate : MonoBehaviour
{

    public PlayerController player;
    public GameObject collider;

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && player.GetComponent<Inventory>().GetSuit() == ResouceItemType.RadSuit)
        {
            collider.GetComponent<Collider2D>().enabled = false;
      
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
