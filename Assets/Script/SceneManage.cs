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
    private void Start()
    {
        foreach (GameObject go in gameObjectsToKeep)
        {
            DontDestroyOnLoad(go);
        }
    }
    public List<GameObject> gameObjectsToKeep;
    public void LoadHall()
    {
       
        SceneManager.LoadSceneAsync(3);
    }
    public void LoadMainMap()
    {
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Player"));
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("MainCamera"));
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
