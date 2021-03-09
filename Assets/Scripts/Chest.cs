using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Enemy
{

	public GameObject reasource;
	public GameObject player;

    public override void TakeDamage(int damage){
		//check if hit by player with knife
		GameObject newReasouce = Instantiate (reasource, gameObject.transform.position, gameObject.transform.rotation);
        
        Reasource r = newReasouce.GetComponent<Reasource>();
        r.player = player;

        Debug.Log("Chest hit");
        Destroy (gameObject);			
	}
}
