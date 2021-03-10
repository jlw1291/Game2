using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobInvScript : MonoBehaviour
{
    public PlayerCombat player;

    public AudioSource select;
    public AudioSource error;
    public int seaweed;
    public int metal;
    public int wood;
    public int ration;
    public int fullHeal;
    public int meal;
    public int ammo;
    public bool knife = false;

    // Start is called before the first frame update
    void Start()
    {
        seaweed = 200;
        ration = 200;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CraftHealth()
    {
        if(seaweed >=1 && ration >=2)
        {
            seaweed -= 1;
            ration -= 2;
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
            ration -= 3;
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
            metal -= 2;
            ammo += 15;
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
            ration--;
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
            ration--;
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

    public void CraftError()
    {
        //display crafting error message "You don't have the required materials"
        Debug.Log("Couldn't Craft");
        error.Play();
    }
}
