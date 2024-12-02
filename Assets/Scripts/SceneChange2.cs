using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement; 

public class SceneChange2: MonoBehaviour, IPointerClickHandler
{
    int tap;


    public void OnPointerClick(PointerEventData eventData)
    {
        tap = eventData.clickCount;
        if (tap == 2)
        {
            SceneManager.LoadScene(6); // When button is unchecked in Inspector, only a double click will activate this method.  
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(6); // When button is checked in Inspector, single click will activate this method.
    }

}
