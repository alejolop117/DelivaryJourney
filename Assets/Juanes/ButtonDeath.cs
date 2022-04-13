using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonDeath : MonoBehaviour
{
    [SerializeField] GameObject menuMuerte;
    Scene currentScene;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
    }
    public void CargarlvlButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");

    }
    public void Menux()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("menu");
    }

}
 