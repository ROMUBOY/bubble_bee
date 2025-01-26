using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAfterSeconds : MonoBehaviour
{
    public float seconds = 5f;
    public int nextSceneIndex = -1;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadScene", seconds);
    }

    void LoadScene()
    {
        if(nextSceneIndex < 0)
        {
            Scene scene = SceneManager.GetActiveScene();
            nextSceneIndex = scene.buildIndex;
        }
        
        SceneManager.LoadScene(nextSceneIndex);
    }
}
