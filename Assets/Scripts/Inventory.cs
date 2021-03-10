using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<ResourceItem> itemList;
    private ResouceItemType melee;
    private ResouceItemType suit;
    private bool range = false;
    private bool lamp = false;
    private bool fins = false;

    public Inventory()
    {

        itemList = new List<ResourceItem>();
        itemList.Add(new ResourceItem(ResouceItemType.Fishcan, 0));
        itemList.Add(new ResourceItem(ResouceItemType.Seaweed, 0));
        itemList.Add(new ResourceItem(ResouceItemType.Wood, 0));
        itemList.Add(new ResourceItem(ResouceItemType.Metal, 0));
        itemList.Add(new ResourceItem(ResouceItemType.Bolt, 0));
        itemList.Add(new ResourceItem(ResouceItemType.Spear, 0));
        itemList.Add(new ResourceItem(ResouceItemType.Knife, 0));
        itemList.Add(new ResourceItem(ResouceItemType.Trident, 0));
        itemList.Add(new ResourceItem(ResouceItemType.Harpoon, 0));
        itemList.Add(new ResourceItem(ResouceItemType.RadSuit, 0));
        itemList.Add(new ResourceItem(ResouceItemType.HeatSuit, 0));
        itemList.Add(new ResourceItem(ResouceItemType.Fins, 0));
        itemList.Add(new ResourceItem(ResouceItemType.Lamp, 0));
        //Add Lamp here

    }

    public void addItem(ResourceItem item)
    {

        string inventory_List = "Invnentory Contains: ";

        /*Seaweed,	Fishcan,	Wood,	Metal, 	Bolt,	Spear,	Knife, 	Trident,	Harpoon,	RadSuit,	HeatSuit,	Fins*/

        switch (item.itemType)
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
                // code block
                break;
        }
        foreach (ResourceItem i in itemList)
        {
            if (i.itemType == item.itemType)
            {
                i.amount += 1;

            }

            inventory_List += " " + i.itemType + "-" + i.amount;
        }

        print(inventory_List);
    }

    public bool hasItem(ResouceItemType item)
    {
        foreach (ResourceItem i in itemList)
        {
            if (i.itemType == item)
            {
                return true;

            }
        }
        return false;
    }

    public List<ResourceItem> GetItemList()
    {
        return itemList;
    }


    public ResouceItemType GetMelee()
    {
        return melee;
    }

    public string GetMeleeString()
    {
        switch (melee)
        {
            case ResouceItemType.Trident:
                return "Trident";
                break;
            case ResouceItemType.Spear:
                return "Spear";
                break;
            case ResouceItemType.Knife:
                return "Knife";
                break;
            default:
                return "none";
        }
    }


    public ResouceItemType GetSuit()
    {
        return suit;
    }
    public bool GetRange()
    {
        return range;
    }
    public bool GetLamp()
    {
        return lamp;
    }
    public bool GetFins()
    {
        return fins;
    }




}