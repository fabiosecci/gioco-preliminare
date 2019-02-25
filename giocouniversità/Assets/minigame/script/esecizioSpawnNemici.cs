using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esecizioSpawnNemici : MonoBehaviour {

    private float x, y, z,nextFire,vivo;
    public GameObject bullet;
    public Transform spawn;
    public float coolDownTime = 1f;



    // Use this for initialization
    void Start()
    {
        nextFire = Time.time + coolDownTime;
        Instantiate(bullet, spawn.position, spawn.rotation);
        
    }

    // Update is called once per frame
    void Update()
    {              
        if (Time.time == nextFire)
        {
            if (bullet.activeInHierarchy)                
            {
                Debug.Log("vivo");
            }
            else { 
                Instantiate(bullet, spawn.position, spawn.rotation);
                Debug.Log("morto");
                nextFire = Time.time + coolDownTime;
            }
            
        }





    }
}

