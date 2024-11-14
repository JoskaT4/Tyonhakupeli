using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckListA : MonoBehaviour
{
    public List<Toggle> toggles = new();
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var toggle in toggles)
        {
            toggle.onValueChanged.AddListener(state => 
            {
                print(state);
                print(toggle.name);
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
