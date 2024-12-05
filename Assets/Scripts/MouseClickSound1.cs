using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickSound : MonoBehaviour
{

    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check for mouse click input
        if (Input.GetMouseButtonDown(0)) // 0 for left mouse button
        {
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}
        
        
    
