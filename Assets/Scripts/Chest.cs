using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{

	public GameObject reasource;
	

    public override void TakeDamage(int damage){
		//check if hit by player with knife


		GameObject newReasouce = Instantiate (reasource, gameObject.transform.position, gameObject.transform.rotation);
        
        //Reasource r = newReasouce.GetComponent<Reasource>();
        
        Debug.Log("Chest hit");
        Destroy (gameObject);			
	}
}
