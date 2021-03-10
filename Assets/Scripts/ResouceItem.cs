using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResouceItemType  {
	None,
	Seaweed,
	Fishcan,
	Wood,
	Metal, 
	Bolt,
	Spear,
	Knife, 
	Trident,
	Harpoon,
	RadSuit,
	HeatSuit,
	Fins,
	Lamp

}


public class ResourceItem 
{
    

    public ResouceItemType itemType;

    public int amount;

    public ResourceItem(ResouceItemType i, int a){
    	itemType = i;
    	amount = a;
    }

    
}

