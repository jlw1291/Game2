using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : Enemy {

	private PlayerController thePlayer;
	public GameObject death;

	public float speed = 0.3f;

	private float turnTimer;
	public float timeTrigger;

	private Rigidbody2D myRigidbody;

	//Combat Variable Initialization for health
	public int maxHealth = 100;
	int currentHealth;

	public Animator animator;
	bool alive = true;
 

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();	
		myRigidbody = GetComponent<Rigidbody2D> ();

		turnTimer = 0;
		timeTrigger = 3f;

		//Initialize health on start
		currentHealth = maxHealth;
	}

	// Update is called once per frame
	void Update (){
		if(alive){
			myRigidbody.velocity = new Vector3 (myRigidbody.transform.localScale.x * speed, myRigidbody.velocity.y, 0f);
		}else{
			Destroy (gameObject);
		}
	
	}

	public void TakeDamage(int damage)
    {
		currentHealth -= damage;
		//play hurt animation
		animator.SetTrigger("Hurt");

		if(currentHealth <=0)
        {
			Die();
			alive = false;
			
        }			
    }
	void Die()
    {
		animator.SetBool("IsDead",true);
		Debug.Log("Enemy died!");
		GetComponent<Collider2D>().enabled = false;
		Destroy (transform.parent.gameObject);
		
		
    }


	void OnTriggerEnter2D(Collider2D other){
		Debug.Log("Triggered!!");
		if(other.tag == "Player" && thePlayer.rushing){

			Instantiate (death, gameObject.transform.position, gameObject.transform.rotation);
			transform.localScale = new Vector3 (0f, 0f, 0f);
			Destroy (gameObject);
		}

	}

	
}