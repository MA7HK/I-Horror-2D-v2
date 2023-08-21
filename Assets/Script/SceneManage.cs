using UnityEngine.SceneManagement;
using UnityEngine;

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
    
    public void LoadHall()
    {
        SceneManager.LoadScene(3);
    }
    
    public void LoadUpperFloor()
    {
        SceneManager.LoadScene(4);
    }
    
    public void LoadBasement()
    {
        SceneManager.LoadScene(5);
    }

}
