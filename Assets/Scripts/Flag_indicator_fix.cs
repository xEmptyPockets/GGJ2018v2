using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag_indicator_fix : MonoBehaviour {
	Vector3 direction;
    Vector3 dir;
    float angle;
    private GameObject destination;
    // Use this for initialization
	void Start (){
	}

	void FixedUpdate(){
		direction= transform.parent.transform.position;
		transform.position = new Vector3(direction.x, direction.y+6, direction.z);

        destination = GameObject.FindWithTag("Destination");
        if (destination != null)
        {
            dir = destination.transform.position - transform.position;
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
	}
	// Update is called once per frame
	void Update () {
		
	}
}
