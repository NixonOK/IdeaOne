/*
 * Author: Comming Soon
 * Scripter: jyoti Roy
 * Discription: This script is to through a ball and to set a derection for throughing 
 * 
 */


using UnityEngine;
using System.Collections;

public class BallThrough : MonoBehaviour {


	public GameObject directionSeter; //derection seter resource
	public GameObject directionParticle; // direction viewer particle


	private Camera camera; //Camera object
	private GameObject directionSeterTracker; //keep track the DirectionSetter object

	void OnMouseDown(){
	
		 

		directionSeterTracker = (GameObject)Instantiate(directionSeter, camera.ScreenToWorldPoint( new Vector3(
								Input.mousePosition.x, Input.mousePosition.y, 10.0f)), 
								new Quaternion(0.0f,0.0f,0.0f, 0.0f) ); //Show the derection to through

	}


	void OnMouseDrag ()
	{
	
		directionSeterTracker.transform.position = camera.ScreenToWorldPoint (new Vector3 (
												   Input.mousePosition.x, Input.mousePosition.y, 10.0f)); //move the derection setter prefab when draging


		// direction calculation starts
		Vector2 ballPosition = new Vector2(this.transform.position.x, this.transform.position.y); // position of the ball
		Vector2 directionSeterTrackerPosition = new Vector2(directionSeterTracker.transform.position.x, directionSeterTracker.transform.position.y); // position of the tracker
		Vector2 thirdpoint = new Vector2 (directionSeterTrackerPosition.x, ballPosition.y); // position of the 3rd point of the 90 degree triangle driven from the points

		float tempAngle = Mathf.Atan2 (Mathf.Sqrt(Mathf.Pow(directionSeterTrackerPosition.x - thirdpoint.x,2) 
						  + Mathf.Pow(directionSeterTrackerPosition.y - thirdpoint.y,2))
						   ,Mathf.Sqrt(Mathf.Pow(ballPosition.x - thirdpoint.x,2)
						  + Mathf.Pow(ballPosition.y - thirdpoint.y,2)))*57.3f; // angle of the corner of the triangle at the ball

		Debug.Log(tempAngle.ToString());
	
		float realAngle; //will store the final angle to for the direction particle rotation
		if (directionSeterTrackerPosition.x > ballPosition.x) { // fixing the real angle
			if (directionSeterTrackerPosition.y > ballPosition.y)
				realAngle = 90.0f + tempAngle;
			else
				realAngle = 90.0f - tempAngle;
		} else {
			if (directionSeterTrackerPosition.y > ballPosition.y)
				realAngle = 270.0f - tempAngle;
			else
				realAngle = 270.0f + tempAngle;
			
		}
			

		//direction calculation ends

		//Debug.Log(realAngle.ToString());
		//Debug.Log("asdad");

		directionParticle.transform.eulerAngles = new Vector3 (0.0f,0.0f, realAngle); // show the direction targeted
	
	}

	void OnMouseUp(){
	
	
		GameObject.Destroy (directionSeterTracker); //Remov the direction setter sprite instantly when the touch removed


		GetComponentInChildren<ParticleSystem> ().gameObject.SetActive (false);
		GetComponent<Rigidbody2D> ().AddForce (new Vector2(0.0f,700.0f));// Thraough the ball



	}




	void Start () {
		
		camera = GameObject.Find("Camera").GetComponent<Camera>(); //Get our scene camera referance
	
	}
	

	void Update () {
	
	}
}
