using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] TMP_Text enemies_counter_text;
    [SerializeField] GameObject you_win_txt;
    string text="Remain to Eliminate: ";
    int enemiesLeft=0;
    public void updateEnemiesQuant(int quant)
    {
        enemiesLeft+=quant;
        enemies_counter_text.text = text +enemiesLeft;
        if (enemiesLeft <= 0)
        {
            you_win_txt.SetActive(true);
            Invoke("Restart", 1f);
        }
    }
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
