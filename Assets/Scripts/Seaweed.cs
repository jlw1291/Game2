using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seaweed : Enemy
{
    //private int currentHealth;

    public int minimum_damage;

    void Start()
    {
        currentHealth = maxHealth;
    }
   
    


	public override void TakeDamage(int damage){
		//check if hit by player with knife
        Debug.Log("Seaweed hit");
        if(damage >= minimum_damage){
            currentHealth -= damage;
            Debug.Log("Seaweed: " + currentHealth);

            if(currentHealth <=0)
            {
                Destroy (gameObject);
            }
        }			
	}
}
