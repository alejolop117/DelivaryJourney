using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TesteoResume : MonoBehaviour
{
    [SerializeField] GameObject menuMuerte;
    Scene currentScene;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
    }
    public void CargarlvlMainButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainTesteo");

    }

    public void CargarlvlTutoButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("TutorialTesteo");

    }
    public void Menuxx()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("TEsteomenu");
    }
}
