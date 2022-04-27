using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TesteoEscenas : MonoBehaviour
{
    [SerializeField] GameObject pauseMeenu;

    public void Paused()
    {
        pauseMeenu.SetActive(true);
        Time.timeScale = 0f;
        // Debug.Log("pausado");

    }

    public void Resume()
    {
        pauseMeenu.SetActive(false);
        Time.timeScale = 1f;
        //Debug.Log("Jugando");

    }


    public void LoadMenu()
    {
        Time.timeScale = 1f;
        //Debug.Log("Cargando_Menu");
        SceneManager.LoadScene("TEsteoMenu");
    }
}
