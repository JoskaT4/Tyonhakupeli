using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameObjectState
{
    public string name;
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
    public bool isActive;
}

public class SceneState
{
    public List<GameObjectState> gameObjectStates = new List<GameObjectState>();
}

public class SceneStateManager : MonoBehaviour
{
    private SceneState currentSceneState = new SceneState();

    // Save the current state of the scene
    public void SaveSceneState()
    {
        currentSceneState.gameObjectStates.Clear();
        foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
        {
            GameObjectState state = new GameObjectState
            {
                name = obj.name,
                position = obj.transform.position,
                rotation = obj.transform.rotation,
                scale = obj.transform.localScale,
                isActive = obj.activeSelf
            };
            currentSceneState.gameObjectStates.Add(state);
        }
    }

    // Restore the saved state of the scene
    public void LoadSceneState()
    {
        foreach (GameObjectState state in currentSceneState.gameObjectStates)
        {
            GameObject obj = GameObject.Find(state.name);
            if (obj != null)
            {
                obj.transform.position = state.position;
                obj.transform.rotation = state.rotation;
                obj.transform.localScale = state.scale;
                obj.SetActive(state.isActive);
            }
        }
    }
}
