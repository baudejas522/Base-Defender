using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    public GameObject levelsUI;

    public void levels()
    {
        levelsUI.SetActive(true);
    }

    public void LevelMeniu()
    {
        SceneManager.LoadScene("Levels");
    }

    public void Controls()
    {
        SceneManager.LoadScene("CONTROLS");
    }
}
