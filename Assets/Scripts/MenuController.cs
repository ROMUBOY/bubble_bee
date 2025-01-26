using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{

    public void StartGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
