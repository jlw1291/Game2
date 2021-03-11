using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RobInvScript : MonoBehaviour
{
    public PlayerCombat player;
    public Inventory inventory;
    public SpriteRenderer melee;

    public Text seaweedCount;
    public Text metalCount;
    public Text woodCount;
    public Text rationCount;
    public Text ammoCount;
    public Text mealCount;
    public Text healCount;

    public Sprite punch;
    public Sprite knife;
    public Sprite spear;
    public Sprite trident;

    public AudioSource select;
    public AudioSource error;
    public int seaweed;
    public int metal;
    public int wood;
    public int ration;
    public int fullHeal;
    public int meal;
    public int ammo;

    // Start is called before the first frame update
    void Start()
    {
        //Testing Values
        /*seaweed = 200;
        ration = 200;
        metal = 200;*/
    }

    // Update is called once per frame
    void Update()
    {
        CheckInv();
        ItemUpdate();

    }

    public void CraftHealth()
    {
        if(seaweed >=1 && ration >=2)
        {
            //seaweed -= 1;
            inventory.SetItemCount(ResouceItemType.Seaweed, -1);
            //ration -= 2;
            inventory.SetItemCount(ResouceItemType.Fishcan, -2);
            fullHeal += 1;
            select.Play();
        }
        else
        {
            CraftError();
        }
    }

    public void CraftFood()
    {
        if(ration>=3)
        {
            //ration -= 3;
            inventory.SetItemCount(ResouceItemType.Fishcan, -3);
            meal++;
            select.Play();
        }
        else
        {
            CraftError();
        }
    }

    public void CraftAmmo()
    {
        if(metal>=2)
        {
            //metal -= 2;
            inventory.SetItemCount(ResouceItemType.Metal, -2);
            //ammo += 15;
            inventory.SetItemCount(ResouceItemType.Bolt, 15);
            select.Play();
        }
        else
        {
            CraftError();
        }
    }

    public void EatRation()
    {
        if (ration >= 1)
        {
            //ration--;
            inventory.SetItemCount(ResouceItemType.Fishcan, -1);
            select.Play();
            if (player.GetHunger() < player.GetHungerMax())
            {
                player.SetHunger(25f);
            }
        }
        else
        {
            CraftError();
        }
    }

    public void EatMeal()
    {
        if(meal >= 1)
        {
            meal--;
            inventory.SetItemCount(ResouceItemType.Fishcan, -1);
            select.Play();
            if (player.GetHunger() < player.GetHungerMax())
            {
                player.SetHunger(player.GetHungerMax());
            }
        }
        else
        {
            CraftError();
        }
    }

    public void UseHeal()
    {
        if(fullHeal >= 1)
        {
            fullHeal--;
            select.Play();
            if (player.GetHealth() < player.GetHealthMax())
            {
                player.SetHealth(player.GetHealthMax());
            }
        }
        else
        {
            CraftError();
        }
    }

    public bool ShootGun()
    {
        if(ammo>=1)
        {
            //ammo--;
            inventory.SetItemCount(ResouceItemType.Bolt, -1);
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public void CheckInv()
    {
        seaweed = inventory.ReturnItemCount(ResouceItemType.Seaweed);
        metal = inventory.ReturnItemCount(ResouceItemType.Metal);
        wood = inventory.ReturnItemCount(ResouceItemType.Wood);
        ration = inventory.ReturnItemCount(ResouceItemType.Fishcan);
        ammo = inventory.ReturnItemCount(ResouceItemType.Bolt);

        string weapon = inventory.GetMeleeString();
        switch (weapon)
        {
            case "Trident":
                melee.sprite = trident;
                break;
            case "Spear":
                melee.sprite = spear;
                break;
            case "Knife":
                melee.sprite = knife;
                break;
            default:
                melee.sprite = punch;
                break;
        }
    }

    public void ItemUpdate()
    {
        seaweedCount.text = seaweed.ToString();
        rationCount.text = ration.ToString();
        metalCount.text = metal.ToString();
        woodCount.text = wood.ToString();
        ammoCount.text = ammo.ToString();
        mealCount.text = meal.ToString();
        healCount.text = fullHeal.ToString();
    }

    public void CraftError()
    {
        //display crafting error message "You don't have the required materials"
        Debug.Log("Couldn't Craft");
        error.Play();
    }
}
