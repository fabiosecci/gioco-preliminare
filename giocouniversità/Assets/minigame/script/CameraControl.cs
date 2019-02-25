using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Transform body;
    public Transform torso;
    public Transform head;
    public Transform camTrasform;

    [Range (0.1f,1f)]
    public float smouthFactor = 0.5f;
    public float sensivityX=4.0f;
    public float sensivityY = 1.0f;

    private Camera cam;
    public float currentZoom = 1.5f;
    public float distance = 3.0f;
    private float currentX = 0.0f;

    public float minX;
    public float maxX;

    private const float minY= -20.0f;
    private const float maxY = 50.0f;
    private float currentY = 0.0f;

    private Vector3 offset;
	// Use this for initialization
	private void Start () {

        camTrasform=transform;
        cam = Camera.main;
        
	}
    private void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel");
        currentX += Input.GetAxis("Mouse X")* sensivityX;
        //currentX = Mathf.Clamp(currentX, minX, maxX);
        currentY -= Input.GetAxis("Mouse Y") * sensivityY;
        currentY =Mathf.Clamp(currentY,minY,maxY);
        
    }
   
    private void LateUpdate () {

        //Ruota();  
        Vector3 dir = new Vector3(0, 0, -distance);

        Quaternion rotation =Quaternion.Euler(currentY, currentX, 0);

        camTrasform.position = body.position + rotation * dir*currentZoom;
        camTrasform.LookAt(body.position);
        torso.transform.forward = camTrasform.transform.forward;
        head.transform.forward = camTrasform.transform.forward;
    }

    public void Ruota()
    {

        //trovare il modo di modificare solo la y
        body.transform.rotation = camTrasform.transform.rotation;  
    }


}
