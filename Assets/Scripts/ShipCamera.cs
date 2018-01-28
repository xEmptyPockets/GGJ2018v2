using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCamera : MonoBehaviour {

    private Transform ship;

	// Use this for initialization
	void Start () {

        ship = GameObject.Find("Ship").transform;
		
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.position = new Vector3(ship.position.x, ship.position.y, -10);
		
	}
}
