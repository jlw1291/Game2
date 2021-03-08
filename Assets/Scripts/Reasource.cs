using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventoryReasource;

public class Reasource : Enemy
{

	public GameObject player;

    public override void TakeDamage(int damage){
    	//new InventoryReasource(gameObject.name);
    	player.GetComponent<Inventory>().addItem( new InventoryReasourceClass(gameObject.name));
		
		Destroy (gameObject);			
	}
}
