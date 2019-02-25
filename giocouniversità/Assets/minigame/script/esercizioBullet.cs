using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esercizioBullet : MonoBehaviour {

    // Use this for initialization
    private Rigidbody rb;
    public float bulletForce = 5;
   

    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        Vector3 bulletDir = transform.forward;
        rb.AddForce(bulletDir * bulletForce, ForceMode.Impulse);
        

    }

    // Update is called once per frame
    void Update()
    {

       

    }

    private void OnCollisionEnter(Collision collision)
    {

        

        
    }



}
