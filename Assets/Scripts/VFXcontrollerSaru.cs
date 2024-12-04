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
        // Hakee hiiren sijainnin
        Vector3 cursorPos = Input.mousePosition;
        cursorPos.z = Camera.main.nearClipPlane;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(cursorPos);
       
        // Muuttaa efektin sijainnin hiiren sijainnin mukaan ja offset lisätty
        lataus.transform.position = worldPos + offset;

        
        if (Input.GetMouseButtonDown(0)) 
        {

            // Spawnaa partikkelisysteemin, toistaa ja tuhoaa sen            
            ParticleSystem newParticle = Instantiate(lataus, worldPos, Quaternion.identity);
            lataus.Play();
            Destroy(newParticle.gameObject, newParticle.main.duration);

        }
    }
   
}
