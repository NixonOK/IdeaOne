/*
 * Author: Comming Soon!
 * Scripter: Jyoti Roy,  ,  ,  !
 * Description: This script to select the floor
 * 
 */



using UnityEngine;
using System.Collections;

public class floorSelector : MonoBehaviour {

	public Sprite floorSampleOne, floorSampleTwo; //reference to the floor sprites




	void Start () {

		GetComponent<SpriteRenderer> ().sprite = floorSampleOne; // set a prefixed floor image
	
	}
	




	void Update () {
	
	}
}
