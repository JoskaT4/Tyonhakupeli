using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("Scene 3");
    }

    public void QuitGame()
    {
        Application.Quit();
    }







}
    

