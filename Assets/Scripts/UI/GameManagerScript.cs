using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;

     public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void nextLevel()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void nextLevel2()
    {
        SceneManager.LoadScene("Level 3");
    }
    public void nextLevel3()
    {
        SceneManager.LoadScene("Level 4");
    }

    public void mainMeniu()
    {
        SceneManager.LoadScene("MainMeniu");
    }
}
