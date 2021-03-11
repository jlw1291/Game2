using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AI_Agro_Enemy : MonoBehaviour
{
	
	//Public Variables
	public Transform playerSprite;

	public float speed = 200f; 

	public float nextWaypointDistance = 3f;

	public float agroRange = 20f;

	public Transform[] patrolPoints;

	//public Transform castPoint;	//If ray casting uncomment this variable

	//Private Variables

	private Path path;

	private int currentWayPoint = 0;

	private bool reachedEndOfPath = false;

	private Seeker seeker; 

	private Rigidbody2D rb;

	private int currentPatrol = 0;

	private int index = 0; 

	private bool patrol = true;

	

	

	void Start()
	{
		
		seeker = GetComponent<Seeker>();			//initilze seeker
		rb = GetComponent<Rigidbody2D> ();			//initilze rigidbody

		InvokeRepeating("UpdatePath", 0f, 0.5f);	//Calls UpdatePath every .5 seconds
													//  InvokeRepeating(string methodName, float time, float repeatRate); 	
	}

	void UpdatePath(){
		
		float distToPlayer = Vector2.Distance(rb.position, playerSprite.position);		//Calculate distance to player sprite
		
		if(distToPlayer <= agroRange){		//If player is withing Agro Distance
			SeekPlayer();
			patrol = false;
			
		}else{
			EnemyPatrol();
			patrol = true;
		}
	}

	

	void EnemyPatrol(){
		if (seeker.IsDone() ){
			seeker.StartPath(rb.position, patrolPoints[index].position, OnPathComplete);	
		}
	}

	/*void OnPatrolComplete(Path p){
		if (!p.error){
			path = p;
			currentWayPoint = 0;
		}
	}*/

	void SeekPlayer(){
		if (seeker.IsDone() ){
			seeker.StartPath(rb.position, playerSprite.position, OnPathComplete);
		}
	}


	void OnPathComplete(Path p){
		if (!p.error){
			path = p;
			currentWayPoint = 0;
		}
	}

	void Update()
	{

		if(path == null){
			return;
		}
		//if(currentWayPoint >= path.vectorPath.Count && patrol){				//If not done with path and on patrol
		if(patrol){
			updatePatrolPoint();
			
		}

		Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;	// Get vector to the next waypoint
		Vector2 force = direction * speed * Time.deltaTime;											//

		rb.AddForce(force);			//important make the sprite move
		turnAround(force.x);		//Makes sure the sprite faces the right direction

		float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]); 

		if(distance < nextWaypointDistance){	//check if close enough to waypoint before switching focus to next waypoint
			currentWayPoint++;
		}
	}

	void turnAround(float d){
		if(d >= 0.01f){
     		transform.localScale = new Vector3(1f, 1f, 1f);
     	}else if(d <= -0.01f) {
     		transform.localScale = new Vector3(-1f, 1f, 1f);
     	}  
    
	}

	void updatePatrolPoint(){
		//print("2Index: " + index);
		float distToPatrolPoint = Vector2.Distance(rb.position, patrolPoints[index].position);	//
		if(distToPatrolPoint <= nextWaypointDistance){	// If within nextWaypointDistance of the destination move to next point int array
			index++;
			if(index >= patrolPoints.Length ){		//Bounds checking
				index = 0;
			}
		}
	}

	/*bool SeesPlayer ()
    {
        // find the angle between player and direction guard is looking to see if within cone of vision
        Vector2 lookDir = (Vector2)(rb.transform.localRotation * Vector3.forward); // use flashlight direction as direction guard is looking
        Vector2 playerDir = (Vector2)playerSprite.transform.position - (Vector2)transform.position; // direction to player
        float playerAngle = Vector2.Angle (lookDir, playerDir);
 
        // find distance to player
        float playerDist = Vector3.Distance (playerSprite.transform.position, transform.position);
        float seeDistance = agroRange;
 
        // if player could be seen, check if there are obstacles (walls) between
        if (playerAngle <= 45 && playerDist <= seeDistance)
        {
        	print("looking for player");
            RaycastHit2D hit = Physics2D.Linecast (rb.transform.position, playerSprite.transform.position, 1 << LayerMask.NameToLayer("Platforms"));
            if (hit.collider != null) // no walls in the way
            {
                //Debug.Log ("I see you!");
                if(hit.collider.gameObject.CompareTag("Player")){
                	print("Sees Player");
                    return true;
                }


                
            }
        }
 
        return false; // can't see player
    }*/
	
}
