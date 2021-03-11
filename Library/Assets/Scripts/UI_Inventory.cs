using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System; 

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;

    private Transform itemSlotContainer;

    private Transform gearSlotTemp;
    private Transform itemSlotTemplate;


    private void Awake(){

        itemSlotContainer = transform.Find("InventoryUI");
        print("found inventory");

        
        itemSlotTemplate = transform.Find("ResourceSlotTemp");

        print("found temp");
        
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

        /*foreach (Transform child in itemSlotContainer) {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }*/

        print("Hi");

        int x = 0;
        int y = 0;
        int width = 70;
        int hight = 50;

        if(inventory.GetSuit() != ResouceItemType.None){
            MakeSlotGear(itemSlotTemplate, inventory.GetSuit(), x, y, width, hight, 1);
        }else{
            MakeSlotGear(itemSlotTemplate, inventory.GetSuit(), x, y, width, hight, 0);
        }

 print("Hi");
        x++;

        if(inventory.GetRange()){
            MakeSlotGear(itemSlotTemplate, ResouceItemType.Harpoon, x, y, width, hight, 1);
        }else{
            MakeSlotGear(itemSlotTemplate, ResouceItemType.None, x, y, width, hight, 0);
        }

 print("Hi");
        x++;

        if(inventory.GetFins()){
            MakeSlotGear(itemSlotTemplate, ResouceItemType.Fins, x, y, width, hight, 1);
        }else{
            MakeSlotGear(itemSlotTemplate, ResouceItemType.None, x, y, width, hight, 0);
        }

 print("Hi");
        x++;

        if(inventory.GetLamp()){
            MakeSlotGear(itemSlotTemplate, ResouceItemType.Lamp, x, y, width, hight, 1);
        }else{
            MakeSlotGear(itemSlotTemplate, ResouceItemType.None, x, y, width, hight, 0);
        }


        x++;


        if(inventory.GetMelee() != ResouceItemType.None){
            MakeSlotGear(itemSlotTemplate, inventory.GetMelee(), x, y, width, hight, 1);
        }else{
            MakeSlotGear(itemSlotTemplate, inventory.GetMelee(), x, y, width, hight, 0);
        }

        x++;

        foreach (ResourceItem item in inventory.GetItemList()) {
           MakeSlot(itemSlotTemplate, item, x, y, width, hight);

            x++;
            if (x >= 5) {
                x = 0;
                y++;
            }
        }
    }

    private void MakeSlot(Transform itemSlotTemplate, ResourceItem item, int x, int y, int width, int hight){

        RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
        itemSlotRectTransform.gameObject.SetActive(true);
        
        /*itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () => {
            // Use item
            inventory.UseItem(item);
        };*/
        
        itemSlotRectTransform.anchoredPosition = new Vector2(x * width, -y * hight);
        Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
        Text text = itemSlotRectTransform.Find("Text").GetComponent<Text>();

        if(item.amount > 0){ image.sprite = inventory.GetSprite(item.itemType); }
        else{ image.sprite = inventory.GetSprite(ResouceItemType.None); }
        
        text.text = item.amount.ToString();
    }

    private void MakeSlotGear(Transform itemSlotTemplate, ResouceItemType item, int x, int y, int width, int hight, int exists){

        RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
        itemSlotRectTransform.gameObject.SetActive(true);
        
        /*itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () => {
            // Use item
            inventory.UseItem(item);
        };*/
        
        itemSlotRectTransform.anchoredPosition = new Vector2(x * width, -y * hight);
        Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
        Text text = itemSlotRectTransform.Find("Text").GetComponent<Text>();

        if(exists > 0){ image.sprite = inventory.GetSprite(item); }
        else{ image.sprite = inventory.GetSprite(ResouceItemType.None); }
        
        text.text = "1";
    }

}


