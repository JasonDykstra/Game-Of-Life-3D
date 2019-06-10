using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour {


    public bool alive = false;
    public bool nextAlive = false;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //object does not get updated if its not active. need to create an outside script to toggle setactive instead of doing it locally within the object we are trying to toggle. cant tell itself to turn itself on.
        GetComponent<Renderer>().enabled = alive;
    }
}
