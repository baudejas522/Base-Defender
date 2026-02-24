using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMeniu : MonoBehaviour

{
    public GameObject MainMeniuUI;

    public void mainMeniu()
    {
        MainMeniuUI.SetActive(true);
    }

    public void Play()
    {
        SceneManager.LoadScene("Level 1");
    }
    
}
