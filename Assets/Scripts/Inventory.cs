using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventoryReasource;

public class Inventory : MonoBehaviour
{
    public List<InventoryReasourceClass> items; 

    void BuildInventory(){
        items = new List<InventoryReasourceClass>(); 
    }

    public void addItem(InventoryReasourceClass r){

    	items.Add(r);
    	
        foreach(InventoryReasourceClass s in items){
            Debug.Log("inventory:" + s.Name);  
        }
        Debug.Log("added :" + r.Name);
   
    }


}
