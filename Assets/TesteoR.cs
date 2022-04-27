using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TesteoR : MonoBehaviour
{
    Scene currentScene;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
    }
    public void CargarlvlButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainTesteo");

    }
    public void Menux()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("TEsteomenu");
    }

    public void CargarlvlTutoButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("TutorialTesteo");

    }
}
