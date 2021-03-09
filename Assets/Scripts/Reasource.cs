using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventoryReasource;

public class Reasource : Interactable
{

	

	/*void Start(){
		thePlayer = FindObjectOfType<PlayerController> ();	
	}*/

    public override void TakeDamage(int damage){
    	//new InventoryReasource(gameObject.name);
    	thePlayer.GetComponent<Inventory>().addItem( new InventoryReasourceClass(gameObject.name));
		
		Destroy (gameObject);			
	}
}
