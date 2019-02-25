using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float inputDelay = 0.1f;
    public float fowardVel = 12;
    public float rotateVel = 100;

    Quaternion targetRotation;
    Rigidbody rBody;
    float fowardInput = 0, turnInput = 0;
    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }

    // Use this for initialization
    void Start()
    {
        targetRotation = transform.rotation;

        rBody = GetComponent<Rigidbody>();

    }

    private void GetInput()
    {
        fowardInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");


    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Turn();


    }

    void FixedUpdate()
    {

        Run();
    }

    void Run()
    {
        if (Mathf.Abs(fowardInput) > inputDelay)
        {
            rBody.velocity = transform.forward * fowardInput * fowardVel;
        }
        else
        {
            rBody.velocity = Vector3.zero;
        }
    }

    void Turn()
    {
        if (Mathf.Abs(turnInput) > inputDelay)
        {
            targetRotation *= Quaternion.AngleAxis( rotateVel * turnInput * Time.deltaTime,Vector3.up);
        }
        transform.rotation = targetRotation;
    }


}
