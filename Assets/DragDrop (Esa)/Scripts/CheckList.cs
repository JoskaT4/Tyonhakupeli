using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CheckList : MonoBehaviour{
       
    public Toggle checklist_toggle;
    public bool playersReady;
   
    public void Start(){   
        checklist_toggle = GameObject.Find("toggle1").GetComponent<Toggle>();
    }

    public void EnableDisable(){       
        if (checklist_toggle.interactable == true){
            checklist_toggle.interactable = false;
        }       
    }
}
