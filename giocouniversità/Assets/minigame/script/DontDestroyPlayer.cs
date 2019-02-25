using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyPlayer : MonoBehaviour {


    public static DontDestroyPlayer instance;

	
	void Awake () {

        if (!instance)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            Destroy(this.gameObject);
        }



        




	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
