using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Global : MonoBehaviour

{
 private void Start()
    {
        SceneManager.LoadScene ("MainMeniu");
    }
 
   private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
