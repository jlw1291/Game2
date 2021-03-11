using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Interactable {

	
	public GameObject death;
	public GameObject drop;

	public float speed = 0.3f;

	private float turnTimer;
	public float timeTrigger;

	private Rigidbody2D myRigidbody;

	//Combat Variable Initialization for health


	public Animator animator;
 

	// Use this for initialization
	public override void StartUpRoutine(){
		myRigidbody = GetComponent<Rigidbody2D> ();

		turnTimer = 0;
		timeTrigger = 3f;

		//Initialize health on start
		currentHealth = maxHealth;
	}

	// Update is called once per frame
	void Update (){
		myRigidbody.velocity = new Vector3 (myRigidbody.transform.localScale.x * speed, myRigidbody.velocity.y, 0f);

		turnTimer += Time.deltaTime;
		if(turnTimer >= timeTrigger){
			turnAround ();
			turnTimer = 0;
		}



	}

	public override void TakeDamage(int damage)
    {
		currentHealth -= damage;
		//play hurt animation
		animator.SetTrigger("Hurt");

		if(currentHealth <=0)
        {
			Die();
        }			
    }
	void Die()
    {
		animator.SetBool("IsDead",true);
		Debug.Log("Enemy died!");
		GetComponent<Collider2D>().enabled = false;

		//Enable the Destroy(gameObject) if you want the fish to disappear completely from the scene
		Instantiate (drop, gameObject.transform.position, gameObject.transform.rotation);
		Destroy (transform.parent.gameObject);
		
    }


	void OnTriggerEnter2D(Collider2D other){

		if(other.tag == "Player" && thePlayer.rushing){
			Instantiate (death, gameObject.transform.position, gameObject.transform.rotation);
			Destroy (transform.parent.gameObject);
		}

	}

	void turnAround(){
		if (transform.localScale.x == 1) {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		} else {
			transform.localScale = new Vector3 (1f,1f,1f);
		}
	}
}
