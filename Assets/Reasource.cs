using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reasource : Enemy
{
    public override void TakeDamage(int damage){
		// Add to inventory
		Debug.Log("Collected");
        Destroy (gameObject);			
	}
}
