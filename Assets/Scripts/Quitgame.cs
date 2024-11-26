using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quitgame : MonoBehaviour
{
    void OnGUI()
    {
       
        bool quitGame = GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height - 200, 200, 20), "Quit Game");
        if (quitGame)
        {
            Application.Quit(); // As far as I know, this only works in the compiled game (.exe)
        }
    }

     





     
     











}
   
     
    
     
     

