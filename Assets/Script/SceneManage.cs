using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;

public class SceneManage : MonoBehaviour
{
    public static SceneManage Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
    public List<GameObject> gameObjectsToKeep;
    public void LoadHall()
    {
        foreach (GameObject go in gameObjectsToKeep)
        {
            DontDestroyOnLoad(go);
        }
        SceneManager.LoadSceneAsync(3);
    }
    public void LoadMainMap()
    {
       /* foreach (GameObject go in gameObjectsToKeep)
        {
            DontDestroyOnLoad(go);
        }*/
        SceneManager.LoadSceneAsync(2);
    }

    public void LoadUpperFloor()
    {
        
        SceneManager.LoadSceneAsync(4);
    }

    public void LoadBasement()
    {
        SceneManager.LoadSceneAsync(5);
    }


}
