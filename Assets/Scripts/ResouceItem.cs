using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResouceItemType
{
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


public class ResourceItem : MonoBehaviour
{


	public ResouceItemType itemType;

	public int amount;

	public ResourceItem(ResouceItemType i, int a)
	{
		itemType = i;
		amount = a;
	}

}
