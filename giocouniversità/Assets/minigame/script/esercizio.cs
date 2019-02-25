using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esercizio : MonoBehaviour {

    private float x, y, z, fireTime,nextFire;
    public GameObject bullet;
    public Transform spawn;
    public float coolDownTime = 1f;
    public float random = 0.2f;


    // Use this for initialization
    void Start () {
        fireTime = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        /*
        x = Random.Range(-180, 360);
        y = Random.Range(-180, 360);
        z = Random.Range(-180, 360);

        transform.Rotate(new Vector3(x, y, z) * Time.deltaTime); */

        if (Time.time > nextFire)
        {
            Instantiate(bullet, spawn.position, spawn.rotation);
            nextFire = Time.time + coolDownTime; // +random         
           // random = Random.Range(-random, random);
        }





    }  
}
