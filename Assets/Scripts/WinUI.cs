using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinUI : MonoBehaviour
{

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    public void ShowWin()
    {
        gameObject.SetActive(true);
        Time.timeScale = 1f;
    }

    public void HideWin()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMeniu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMeniu");
    }
}
