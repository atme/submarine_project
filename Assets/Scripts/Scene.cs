﻿using UnityEngine;
using System.Collections;

public class Scene : MonoBehaviour {
	public GameObject mine;
	private static int mineDistance = 10;
	private static int mineDistancefloor = 15;
	private float nextfloorCoordinate = 5.0f;
	private float nextMineCoordinate = 10.0f;
	public GameObject floorwithgrass;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (rigidbody.position.x > nextMineCoordinate) {
			CreateMine ();
			nextMineCoordinate += mineDistance;
		}
		if(rigidbody.position.x > nextfloorCoordinate){
			CreateFloor();
			nextfloorCoordinate += mineDistancefloor;
		}
	}

	void CreateFloor() {
		Instantiate (floorwithgrass, new Vector2 (transform.position.x + 20.0f, -5.5f), transform.rotation);
		}

	void CreateMine() {
		float upMinePosition = Random.Range (3.0f, 1.0f);
		Vector2 upPosition = new Vector2(transform.position.x + (mineDistance * 2), upMinePosition);
		Vector2 downPosition = new Vector2(transform.position.x + (mineDistance * 2), upMinePosition - Random.Range (5, 1));

		//GameObject mineClone = (GameObject) Instantiate(mine, position, transform.rotation);
		Instantiate(mine, upPosition, transform.rotation);
		Instantiate(mine, downPosition, transform.rotation);
	}

	public static int GetMineDistance() {
		return mineDistance;
	}

}
