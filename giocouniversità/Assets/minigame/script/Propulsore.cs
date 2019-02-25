using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propulsore : MonoBehaviour {

   
    public PlayerControl player; // reference to the car controller, must be dragged in inspector
    public AudioSource source;
    private Renderer m_Renderer;

    private void Start()
    {
        m_Renderer = GetComponent<Renderer>();
        
    }


    private void Update()
    {
        // enable the Renderer when the player jump, disable it otherwise.
        if (player.jumpInput > 0 )
        {         
            if (source.isPlaying)
            {
                return;
            }
            source.Play();
        }
        else
        {
            source.Stop();
        }

        m_Renderer.enabled = player.jumpInput > 0f;
        
    }
}

