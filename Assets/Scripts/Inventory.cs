using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventoryReasource;

public class Inventory : MonoBehaviour
{
    public List<InventoryReasourceClass> items; 

    void Start(){
        BuildInventory();
    }

    void BuildInventory(){
        items = new List<InventoryReasourceClass>(); 
    }

    public void addItem(InventoryReasourceClass r){
        Debug.Log("Attempting to Collect: " + r.Name);
    	items.Add(r);
        string item_List = "List: ";
        foreach(var i in items) {
            item_List += " " + i.Name;
        }
        Debug.Log(item_List);
        Debug.Log("Inventory Length: " + items.Capacity);
   
    }


}
