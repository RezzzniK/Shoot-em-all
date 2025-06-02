using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void Restart()
    {
        
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restart");
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();//will not work in Unity Editor, only in build
    }
}
