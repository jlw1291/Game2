using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactable : MonoBehaviour
{

	protected PlayerController thePlayer;

	public int maxHealth = 100;
	protected int currentHealth;

	void Start(){
		thePlayer = FindObjectOfType<PlayerController> ();	
		StartUpRoutine();
	}

	public virtual void StartUpRoutine(){
		;
	}


    public virtual void TakeDamage(int damage){
    	currentHealth -= damage;
    }
}