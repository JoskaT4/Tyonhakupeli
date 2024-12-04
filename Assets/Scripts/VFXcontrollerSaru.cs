using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXcontrollerSaru : MonoBehaviour
{
    public ParticleSystem lataus;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
       
        if (lataus != null) {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit)) {

                ParticleSystem effect = Instantiate(lataus, transform.position, Quaternion.identity);
                effect.Play();
                Destroy(effect.gameObject, effect.main.duration + effect.main.startLifetime.constantMax);


            }
        }
    }
}
