using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
    GameObject inGameToggle;

    private void Start()
    {
        inGameToggle = GameObject.Find("Toggle Name");
    }

    //Use buttons linked to this
    public void ChangeValueToTrue()
    {
        inGameToggle.GetComponent<Toggle>().isOn = true;
    }

    //Use buttons linked to this
    public void ChangeValueToFalse()
    {
        inGameToggle.GetComponent<Toggle>().isOn = false;
    }

}
