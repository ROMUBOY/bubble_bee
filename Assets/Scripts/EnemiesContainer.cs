using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemiesContainer : MonoBehaviour
{
    private int _enemiesNumber;

    // Start is called before the first frame update
    void Start()
    {
        _enemiesNumber = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemiesNumber <= 0)
        {
            Invoke("LoadNextScene", 3f);
        }
    }

    void LoadNextScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1);
    }

    public void WasEnemyDestroyed()
    {
        _enemiesNumber--;
    }
}
