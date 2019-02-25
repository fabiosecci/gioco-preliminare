using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public float speed=10;
    public float jumpForce=10;
    public float gravity = 9.81f;
    public float pushPower = 1;
    public float coolDownTime = 0.5f;
    public AudioSource source;


    private float nextFire;

    private Vector3 movement;

    private CharacterController controller;

    public GameObject bullet;
    public Transform spawn;

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if (controller.isGrounded)
        {
            float movementH = Input.GetAxis("Horizontal");
            float movementV = Input.GetAxis("Vertical");

            movement = new Vector3(movementH, 0, movementV)*speed;

            if (Input.GetButton("Jump"))
            {
                movement.y = jumpForce;
            }
            
        }
        movement.y = movement.y - (gravity*Time.deltaTime);
        controller.Move(movement * Time.deltaTime);

        if (Input.GetButton("Fire1")&& Time.time>nextFire)
        {
            nextFire = Time.time + coolDownTime;
            Instantiate(bullet, spawn.position, spawn.rotation);
            source.Play();

        }

	}

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;

        if (rb == null|| rb.isKinematic)
        {       
            return;
        }

        Vector3 pushDir = new Vector3(controller.velocity.x, controller.velocity.y, controller.velocity.z);
        rb.velocity = pushDir *pushPower ;

    }


}
