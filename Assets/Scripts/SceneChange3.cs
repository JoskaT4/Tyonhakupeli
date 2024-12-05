using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange3 : MonoBehaviour
{
    public void ChangeScene()
    {
        Debug.Log("scene vaihtuu");
        SceneManager.LoadScene(4);
    }
}
