using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seaweed : Interactable
{
    //private int currentHealth;

    public int minimum_damage;
    public GameObject drop;

    
    public override void StartUpRoutine(){
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
                Instantiate (drop, gameObject.transform.position, gameObject.transform.rotation);
                Destroy (gameObject);
            }
        }			
	}
}
