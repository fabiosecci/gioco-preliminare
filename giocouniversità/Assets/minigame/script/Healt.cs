using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healt : MonoBehaviour {

    public float healtAmount = 100f;


    void Update()
    {       

        if (healtAmount <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        TakeCollisionDamage(collision);
    }

    void TakeCollisionDamage(Collision other)
    {
        float damage = 0;

        if (other.gameObject.CompareTag("Bullet"))
        {
            damage = 10;           
        }

        LoseHealt(damage);


    }


    public void LoseHealt(float amontToLose)
    {
        if (amontToLose < 100f)
            healtAmount -= amontToLose;

        if (healtAmount<=0)
        {
            Destroy(gameObject);
        }
    }

   

}
