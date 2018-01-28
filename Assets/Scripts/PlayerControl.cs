using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    // Use this for initialization
    public float speed = 0;
    Vector3 mousePos;
    Camera c;
	void Start () {
        mousePos = new Vector3();
        c = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        mousePos = c.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -c.transform.position.z));
        Debug.Log(Input.mousePosition);
        Debug.Log(mousePos);
        transform.LookAt(mousePos);
        //transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, transform.localEulerAngles.z);

        if (Input.GetMouseButton(0))
        {
            transform.position += (-transform.position + mousePos).normalized * speed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }

    void FixedUpdate()
    {

    }
}
