using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotSuit;
    


    /*private void Awake(){
    	itemSlotSuit = transform.Find("itemSlotSuit");
    }

    public void setInventory(Inventory inventory){
    	this.inventory = inventory;
    	RefreshInventoryItems();
    }

    private void RefreshInventoryItems(){
    	/*Seaweed,
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
	Fins
    	List<ResourceItem> list = inventory.GetItemList();
    	foreach(ResourceItem item in inventory.GetItemList()){
    		if((item.itemType == ResouceItemType.HeatSuit || item.itemType == ResouceItemType.RadSuit) && item.amount >= 1){
    			
    			itemSlotSuit.gameObject.SetActive(true);
    		}

    	}
    }*/

}


