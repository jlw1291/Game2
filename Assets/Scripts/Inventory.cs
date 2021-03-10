using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<ResourceItem> itemList;
    //private ResouceItemType melee = ResouceItemType.Knife; 

    public Inventory(){
    	
    	itemList = new List<ResourceItem>();
    	itemList.Add(new ResourceItem(ResouceItemType.Fishcan, 0));
    	itemList.Add(new ResourceItem(ResouceItemType.Wood, 0));
    	itemList.Add(new ResourceItem(ResouceItemType.Metal, 0));
    	itemList.Add(new ResourceItem(ResouceItemType.Bolt, 0));
    	//itemList.Add(new ResourceItem(ResouceItemType.Spear, 0));
    	itemList.Add(new ResourceItem(ResouceItemType.Knife, 0));
    	//itemList.Add(new ResourceItem(ResouceItemType.Trident, 0));
    	itemList.Add(new ResourceItem(ResouceItemType.Harpoon, 0));
    	//itemList.Add(new ResourceItem(ResouceItemType.RadSuit, 0));
    	itemList.Add(new ResourceItem(ResouceItemType.HeatSuit, 0));
    	itemList.Add(new ResourceItem(ResouceItemType.Fins, 0));

    	//Add Lamp here

    }

    public void addItem(ResourceItem item){
    	
    	string inventory_List = "Invnentory Contains: ";

    	/*if(item.itemType == ResouceItemType.Spear){
    		melee = ResouceItemType.Spear;
    	} else if(item.itemType == ResouceItemType.Trident){

    	}*/

    	foreach(ResourceItem i in itemList){
    		if(i.itemType == item.itemType ){
    			i.amount += 1;

    		}

    		inventory_List += " " + i.itemType + "-" + i.amount;
    	}

    	print(inventory_List);
    }

    public bool hasItem(ResouceItemType item){
    	foreach(ResourceItem i in itemList){
    		if(i.itemType == item ){
    			return true;

    		}
    	}
    	return false;
    }

    public List<ResourceItem> GetItemList(){
    	return itemList;
    }
}
