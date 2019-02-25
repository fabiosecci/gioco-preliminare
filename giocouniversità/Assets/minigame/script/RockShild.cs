using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockShild : MonoBehaviour {

    public float VitaTotale;
    public float Energy;
    private float MezzaVita;
   
    private Rigidbody rb;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();
        MezzaVita = VitaTotale / 2;
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnCollisionEnter(Collision collision)
    {
        if (VitaTotale<MezzaVita)
        {
            rb.useGravity = true;
        }
        if (VitaTotale > MezzaVita)
        {
            rb.useGravity = false;
        }

        if (VitaTotale < 0)
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        { 
        TakeCollisionDamage(collision);
        }

    }

    void TakeCollisionDamage(Collision other)
    {
        float damage = 0;

        if (other.gameObject.CompareTag("Bullet"))
        {
            damage = 1;
            TakeDamage(damage);
        }

    }



    void TakeDamage(float damage)
    {
            VitaTotale -=  damage;
            
    }


    void TakeHeart(Collider other)
    {
        if (other.gameObject.CompareTag("Energy"))
        {
                VitaTotale += Energy;
               

            }
        }
    }
