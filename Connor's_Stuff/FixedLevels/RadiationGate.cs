using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiationGate : MonoBehaviour
{

    public PlayerController player;

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider other)
    {
        if (other.CompareTag("Player") && player.GetComponent<Inventory>().GetSuit() == ResouceItemTag.RadSuit)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
