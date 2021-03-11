using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Reasource : Interactable
{
	public ResouceItemType itemID;

    public override void TakeDamage(int damage){
    	

    	ResourceItem r =  new ResourceItem(itemID, 1);
    	thePlayer.GetComponent<Inventory>().addItem( r );
    	thePlayer.GetComponent<PlayerController>().updateInventory();
    	Debug.Log("NUE Collected: " + r.itemType);
		
		Destroy (gameObject);			
	}


}



