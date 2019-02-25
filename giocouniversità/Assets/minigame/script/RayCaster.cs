using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{



    // Update is called once per frame
    void FixedUpdate()
    {
        
           
        if (Input.GetButton("Fire1"))
        {

            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, 1000f))
            {
                Debug.DrawRay(transform.position, transform.forward * 1000f, Color.blue);
               
                Healt enemyHealt = hit.collider.gameObject.GetComponent<Healt>();
                
            

                if (enemyHealt != null )
                {
                    enemyHealt.LoseHealt(50f);
                    Debug.Log("colpito ");
                }
            }
        }

       

           


            

        
    }
}
