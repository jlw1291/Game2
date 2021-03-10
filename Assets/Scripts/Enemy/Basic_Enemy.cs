using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Basic_Enemy : MonoBehaviour
{
	//Public Variables: 
	public float speed = 0.3f;

	public float nextWaypointDistance = 3f;		//How close to waypoint before looking for next one

	public Transform[] targets;					//Patrol path points


	//Private Variables:
	private Rigidbody2D rb;						// Nescesary for vector movement
	
	private Seeker seeker;						//Seeker Script is nescesary for A* to work

	private Path path;

	private int index = 0;
	
	private int currentWayPoint = 0;

//---------------Functions --------------------------//
	
	void Start () {
		seeker = GetComponent<Seeker>();			//initilze seeker
		rb = GetComponent<Rigidbody2D> ();			//initilze rigidbody

		InvokeRepeating("UpdatePath", 0f, 0.5f);	//Calls UpdatePath every .5 seconds
													//  InvokeRepeating(string methodName, float time, float repeatRate); 

		
	}

	void UpdatePath(){
		//print("1Index: " + index);
		seeker.StartPath(rb.position, targets[index].position, OnPatrolComplete);		
		
	}

	void OnPatrolComplete(Path p){
		if (!p.error){
			path = p;
			currentWayPoint = 0;
		}
	}

	// Update is called once per frame
	void Update (){
		if(path == null){
			return;
		}
		if(currentWayPoint >= path.vectorPath.Count ){		//Have we made it to the end of the path??
			//print("2Index: " + index);
			float distToPatrolPoint = Vector2.Distance(rb.position, targets[index].position);

			if(distToPatrolPoint <= nextWaypointDistance){		// If within nextWaypointDistance of the destination move to next point int array
				index++;
				if(index > targets.Length - 1){	//bounds testing of the array
					index = 0;					// Don't know why I get out of bound errors
				}
			}
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
		if(d >= 0.01f){										//going right
     		transform.localScale = new Vector3(1f, 1f, 1f);
     	}else if(d <= -0.01f) {								//going left
     		transform.localScale = new Vector3(-1f, 1f, 1f);
     	}  
    
	}

	

}
