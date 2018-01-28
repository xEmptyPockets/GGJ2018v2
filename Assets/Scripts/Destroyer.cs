using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {
    public bool destroy_offscreen = false;

    //Destroys the object if it's off screen
    void OnBecameInvisible(){
        if (destroy_offscreen){
            Destroy(gameObject);
        }
    }
}
