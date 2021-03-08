using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Enemy
{

	public GameObject reasource;

    public override void TakeDamage(int damage){
		//check if hit by player with knife
		Instantiate (reasource, gameObject.transform.position, gameObject.transform.rotation);
        Debug.Log("Chest hit");
        Destroy (gameObject);			
	}
}
