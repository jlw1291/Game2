using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Inventory : MonoBehaviour
{
    private List<ResourceItem> itemList;
    private ResouceItemType melee = ResouceItemType.None; 
    private ResouceItemType suit = ResouceItemType.None;
    private bool range = false;
    private bool lamp = false;
    private bool fins = false;

    //[SerializeField] private UI_Inventory uiInventory;

    public event EventHandler OnItemListChanged;

    public Inventory(){
    	
    	itemList = new List<ResourceItem>();
    	/*itemList.Add(new ResourceItem(ResouceItemType.Fishcan, 2));
    	itemList.Add(new ResourceItem(ResouceItemType.Seaweed, 3));
    	itemList.Add(new ResourceItem(ResouceItemType.Wood, 5));
    	itemList.Add(new ResourceItem(ResouceItemType.Metal, 1));
    	itemList.Add(new ResourceItem(ResouceItemType.Bolt, 7));

    	melee = ResouceItemType.Knife;
    	suit = ResouceItemType.RadSuit;
    	fins = true;*/
    	itemList.Add(new ResourceItem(ResouceItemType.Fishcan, 0));
    	itemList.Add(new ResourceItem(ResouceItemType.Seaweed, 0));
    	itemList.Add(new ResourceItem(ResouceItemType.Wood, 0));
    	itemList.Add(new ResourceItem(ResouceItemType.Metal, 0));
    	itemList.Add(new ResourceItem(ResouceItemType.Bolt, 0));
    	//itemList.Add(new ResourceItem(ResouceItemType.Spear, 0));
	    	//itemList.Add(new ResourceItem(ResouceItemType.Knife, 0));
	    	//itemList.Add(new ResourceItem(ResouceItemType.Trident, 0));
	    	//itemList.Add(new ResourceItem(ResouceItemType.Harpoon, 0));
	    	//itemList.Add(new ResourceItem(ResouceItemType.RadSuit, 0));
	    	//itemList.Add(new ResourceItem(ResouceItemType.HeatSuit, 0));
	    	//itemList.Add(new ResourceItem(ResouceItemType.Fins, 0));
	    	//itemList.Add(new ResourceItem(ResouceItemType.Lamp, 0));
	    	//Add Lamp here
    }

    public void addItem(ResourceItem item){
    	
    	string inventory_List = "Invnentory Contains: ";

/*Seaweed,	Fishcan,	Wood,	Metal, 	Bolt,	Spear,	Knife, 	Trident,	Harpoon,	RadSuit,	HeatSuit,	Fins*/
    	
    	switch(item.itemType) 
		{
		  	case ResouceItemType.Trident:
		    	melee = ResouceItemType.Trident;
		    	break;
		  	case ResouceItemType.Spear:
		    	melee = ResouceItemType.Spear;
		    	break;
		    case ResouceItemType.Knife:
		    	melee = ResouceItemType.Knife;
		    	break;
		    case ResouceItemType.RadSuit:
		    	suit = ResouceItemType.RadSuit;
		    	break;
		    case ResouceItemType.HeatSuit:
		    	suit = ResouceItemType.HeatSuit;
		    	break;
		    case ResouceItemType.Harpoon:
		    	range = true;
		    	break;
		    case ResouceItemType.Fins:
		    	fins = true;
		    	break;
		    case ResouceItemType.Lamp:
		    	lamp = true;
		    	break;
		  	default:
		  		print("adding: " + item.itemType + " amount: " + item.amount);
		    	foreach(ResourceItem i in itemList){
		    		if(i.itemType == item.itemType ){

		    			i.amount += 1;

		    		}

		    		inventory_List += " " + i.itemType + "-" + i.amount;
		    	}

		    	print(inventory_List);
		    	print("adding: " + item.itemType + " amount: " + item.amount);
				break;
		}

		string l ="Inventory Inventory:";
        foreach(ResourceItem i in itemList){
            l += " " + i.itemType + "-" + i.amount;
        }
        print(l);
		
		//uiInventory.setInventory();
		//OnItemListChanged?.Invoke(this, EventArgs.Empty);
		//PlayerController theplayer = FindObjectOfType<PlayerController>();
		//theplayer.GetComponent<PlayerController>().updateInventory();
    	
    }

    public bool hasItem(ResouceItemType item){
    	foreach(ResourceItem i in itemList){
    		if(i.itemType == item ){
    			return true;

    		}
    	}
    	return false;
    }

    public List<ResourceItem> GetItemList(){ return itemList; }

   
    public ResouceItemType GetMelee(){ return melee; }

    public string GetMeleeString(){
    	switch(melee) 
		{
		  	case ResouceItemType.Trident:
		    	return "Trident";
		    	
		  	case ResouceItemType.Spear:
		    	return "Spear";
	
		    case ResouceItemType.Knife:
		    	return "Knife";

		    default:
		    	return "none";
		}
    }

    public ResouceItemType GetSuit(){
    	print("suit" + suit);
    	return suit;
    }
    public bool GetRange(){ return range; }

    public bool GetLamp(){ return lamp; }

    public bool GetFins(){ return fins; }

	public Sprite GetSprite(ResouceItemType item){
    	switch(item) 
		{
		  	case ResouceItemType.Trident:
		    	return ItemAssets.Instance.tridentSprite;  	
		  	case ResouceItemType.Spear:
		    	return ItemAssets.Instance.tridentSprite;		    
		    case ResouceItemType.Knife:
		    	return ItemAssets.Instance.knifeSprite;
		    case ResouceItemType.RadSuit:
		    	return ItemAssets.Instance.radsuitSprite;
		    case ResouceItemType.HeatSuit:
		    	return ItemAssets.Instance.heatsuitSprite;
		    case ResouceItemType.Harpoon:
		    	return ItemAssets.Instance.harpoonSprite;
		    case ResouceItemType.Fins:
		    	return ItemAssets.Instance.finsSprite;
		    case ResouceItemType.Lamp:
		    	return ItemAssets.Instance.lampSprite;
		    case ResouceItemType.Seaweed:
		    	return ItemAssets.Instance.seaweedSprite;
		    case ResouceItemType.Fishcan:
		    	return ItemAssets.Instance.fishcanSprite;
		    case ResouceItemType.Metal:
		    	return ItemAssets.Instance.metalSprite;
		    case ResouceItemType.Wood:
		    	return ItemAssets.Instance.woodSprite;
		    case ResouceItemType.Bolt:
		    	return ItemAssets.Instance.boltSprite;
		  	default:
		  		return ItemAssets.Instance.noneSprite;
		}    
	}

}
