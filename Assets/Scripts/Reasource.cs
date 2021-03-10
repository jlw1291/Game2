using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventoryReasource;

public class Reasource : Interactable
{

    public override void TakeDamage(int damage){
    	InventoryReasourceClass r =  new InventoryReasourceClass(gameObject.name);


    	thePlayer.GetComponent<Inventory>().addItem( r );
    	
    	Debug.Log("NUE Collected: " + r.Name);
		
		Destroy (gameObject);			
	}
}
