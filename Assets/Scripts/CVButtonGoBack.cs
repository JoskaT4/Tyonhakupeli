using UnityEngine;
using UnityEngine.SceneManagement;  // Import to manage scenes

public class CVButtonGoBack : MonoBehaviour
{
    // This function will be called when the button is clicked
    public void OnBackButtonClick()
    {
        // Load the "GameScene_DragDrop" scene
        SceneManager.LoadScene("GameScene_DragDrop");
    }
}
