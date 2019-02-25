using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpCandy : MonoBehaviour {

    public float respawnTime;
    public bool taken = false;
   /* public Text counText;
    public Text winText;

     private int count;

    private void Start()
    {
        count = 0;
        SetCountText();
        winText.text = "";
    }
    */
    private void OnTriggerEnter(Collider oter)
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        
        
        /*
        count = count + 1;
        SetCountText();*/

        Invoke ("Deley",respawnTime*Time.deltaTime) ;
	}	
	
    
    void Deley()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
        gameObject.GetComponent<MeshRenderer>().enabled = true;

    }
    /*
    void SetCountText()
    {
        counText.text = "Count " + count.ToString();
        if (count >= 31)
        {
            winText.text = "YOU WIN!!!";
        }
    } */

}
