using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    private Rigidbody rb;
    public float bulletForce = 10;
    public float lifeTime = 5;
    private float fireTime;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
        Vector3 bulletDir = transform.forward ;
        rb.AddForce(bulletDir * bulletForce, ForceMode.Impulse);
        fireTime = Time.time;

	}
	
	// Update is called once per frame
	void Update () {

        if (Time.time > lifeTime + fireTime)
        {
            Destroy(gameObject);
        }

	}

    private void OnCollisionEnter(Collision collision)
    {

        float pushPower = 2;
        Rigidbody rb = collision.collider.attachedRigidbody;

            if (rb == null || rb.isKinematic)
            {
                return;
            }

            Vector3 pushDir = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.velocity = pushDir * pushPower;

            Destroy(gameObject);
        }

        
    
}
