using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXcontrollerSaru : MonoBehaviour
{
    public ParticleSystem lataus;
    public Vector3 offset = new Vector3(-0.01f, -0.01f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cursorPos = Input.mousePosition;
        cursorPos.z = Camera.main.nearClipPlane;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(cursorPos);
        lataus.transform.position = worldPos + offset;

        // Play the particle system on mouse click
        if (Input.GetMouseButtonDown(0)) // 0 = Left mouse button
        {
            // Get the cursor position in screen space and convert it to world space
           

            // Move the particle effect to the cursor position
            
            ParticleSystem newParticle = Instantiate(lataus, worldPos, Quaternion.identity);
            lataus.Play();
            Destroy(newParticle.gameObject, newParticle.main.duration);
        }
    }
   
}
