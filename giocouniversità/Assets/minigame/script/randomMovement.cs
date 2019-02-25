using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomMovement : MonoBehaviour {

    float volocita ;
    private Rigidbody rb;
    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Vector3 position = new Vector3(Random.Range(-5,6), 0, Random.Range(-5,6));
        volocita = Random.Range(1, 2);
        rb.AddForce(position * volocita,ForceMode.Impulse);
       
	}
}
