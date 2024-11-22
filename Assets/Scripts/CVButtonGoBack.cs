using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CVButtonGoBack : MonoBehaviour
{

    public void OnBackButtonClick()
    {
        SceneManager.LoadScene("GameScene_DragDrop");
    }


}
