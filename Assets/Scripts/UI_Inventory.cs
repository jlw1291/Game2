using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System; 

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;

    /*private Transform inventoryHolder;
    private Transform inventoryHolderTemplate;
    public GameObject template;*/
    //private Transform itemSlotContainer;
    private Transform itemSlotSuit;
    private Transform itemSlotMelee;
    private Transform itemSlotRange;
    private Transform itemSlotLamp;
    private Transform itemSlotFins;

    private Transform itemSlotSeaweed;
    private Transform itemSlotFishcan;
    private Transform itemSlotMetal; 
    private Transform itemSlotWood;
    private Transform itemSlotBolt;   


    private void Awake(){

        /*inventoryHolder = transform.Find("UI_Inventory_Container");
        inventoryHolderTemplate = inventoryHolder.transform.Find("UI_Inventory_Template");
        inventoryHolderTemplate.SetActive(false);*/

    	itemSlotSuit = transform.Find("itemSlotSuit");
        itemSlotMelee = transform.Find("itemSlotMelee");
        itemSlotRange = transform.Find("itemSlotRange");
        itemSlotLamp = transform.Find("itemSlotLamp");
        itemSlotFins = transform.Find("itemSlotFins");


        itemSlotSeaweed = transform.Find("itemSlotSeaweed");
        itemSlotFishcan = transform.Find("itemSlotFishcan");
        itemSlotMetal = transform.Find("itemSlotMetal");
        itemSlotWood = transform.Find("itemSlotWood");
        itemSlotBolt = transform.Find("itemSlotBolt");
        
    }

    public void setInventory(Inventory inventory){
    	this.inventory = inventory;
    	inventory.OnItemListChanged += Inventory_OnItemListChanged;
    	
    	RefreshInventoryItems();

    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e){
    	RefreshInventoryItems();
    }

    public void RefreshInventoryItems(){

        /*foreach (Transform child in itemSlotContainer){
            if(child == inventoryHolderTemplate){
                continue;
            }
            Destroy(child.gameObject);
        }*/
        print("Refresh Inventory");


    	

        ///RectTransform inventoryContainer = Instantiate( inventoryHolderTemplate,  inventoryHolderTemplate).GetComponent<RectTransform>();
       // inventoryContainer.SetActive(true);

    	//May need to destroy objects before refreshing

    // Set Suit Slot
        ResouceItemType suit = inventory.GetSuit();

        //GameObject newReasouce = Instantiate (reasource, gameObject.transform.position, gameObject.transform.rotation);

        Image suitimage = itemSlotSuit.Find("Image").GetComponent<Image>();
    	suitimage.sprite = inventory.GetSprite(suit);
		
    // Set Fins Slot
    	bool fins = inventory.GetFins();
        Image finimage = itemSlotFins.Find("Image").GetComponent<Image>();
        if(fins){ finimage.sprite = inventory.GetSprite(ResouceItemType.Fins); }
        else{ finimage.sprite = inventory.GetSprite(ResouceItemType.None); }
    
    // Set Lamp Slot	
    	bool lamp = inventory.GetLamp();
        Image lampimage = itemSlotLamp.Find("Image").GetComponent<Image>();
        if(lamp){ lampimage.sprite = inventory.GetSprite(ResouceItemType.Lamp); }
        else{ lampimage.sprite = inventory.GetSprite(ResouceItemType.None); }

    // Set Melee Slot
        ResouceItemType melee = inventory.GetMelee();
        Image meleeimage = itemSlotMelee.Find("Image").GetComponent<Image>();
        meleeimage.sprite = inventory.GetSprite(melee);

    // Set Range Slot 
        bool range = inventory.GetRange();
        Image rangeimage = itemSlotRange.Find("Image").GetComponent<Image>();
        if(range){ rangeimage.sprite = inventory.GetSprite(ResouceItemType.Harpoon); }
        else{ rangeimage.sprite = inventory.GetSprite(ResouceItemType.None); }



/*Seaweed,	Fishcan,	Wood,	Metal, 	Bolt,	Spear,	Knife, 	Trident,	Harpoon,	RadSuit,	HeatSuit,	Fins, 	Lamp*/

    	List<ResourceItem> list = inventory.GetItemList();
        string l ="Current Inventory:";
        foreach(ResourceItem item in inventory.GetItemList()){
            l += " " + item.itemType + "-" + item.amount;
        }
        print(l);

    	foreach(ResourceItem item in inventory.GetItemList()){
            print("Foreach, inventory");
            ResouceItemType r;
            Image image;
            Text text;
            
    		switch(item.itemType){
                case ResouceItemType.Seaweed:
                    image = itemSlotSeaweed.Find("Image").GetComponent<Image>();
                    text = itemSlotSeaweed.Find("Text").GetComponent<Text>();
                    r = ResouceItemType.Seaweed;
                    break;
                case ResouceItemType.Fishcan:
                    image = itemSlotFishcan.Find("Image").GetComponent<Image>();
                    text = itemSlotFishcan.Find("Text").GetComponent<Text>();
                    r = ResouceItemType.Fishcan;
                    break;
                case ResouceItemType.Metal:
                    image = itemSlotMetal.Find("Image").GetComponent<Image>();
                    text = itemSlotMetal.Find("Text").GetComponent<Text>();
                    r = ResouceItemType.Metal;
                    break;
                case ResouceItemType.Wood:
                    image = itemSlotWood.Find("Image").GetComponent<Image>();
                    text = itemSlotWood.Find("Text").GetComponent<Text>();
                    r = ResouceItemType.Wood;
                    break;
                case ResouceItemType.Bolt:
                    image = itemSlotBolt.Find("Image").GetComponent<Image>();
                    text = itemSlotBolt.Find("Text").GetComponent<Text>();
                    r = ResouceItemType.Bolt;
                    break;
                default:
                    r = ResouceItemType.None;
                    image = null;
                    text = null;
                    break;
            }

            if(item.amount > 0){ image.sprite = inventory.GetSprite(r); }
            else{ image.sprite = inventory.GetSprite(ResouceItemType.None); }
            text.text = item.amount.ToString();
            print("item: " + item.itemType + " amount: " + item.amount);
    	}
    }

}


