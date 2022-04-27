using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTuto : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void CargarTuto()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("TutorialTesteo");

    }
    public void CargarMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("menu");

    }
}
