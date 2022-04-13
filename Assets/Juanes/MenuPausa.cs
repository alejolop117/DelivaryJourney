using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void Paused()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
       // Debug.Log("pausado");

    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        //Debug.Log("Jugando");

    }

   
    public void LoadMenu(int menu)
    {
        Time.timeScale = 1f;
        //Debug.Log("Cargando_Menu");
         SceneManager.LoadScene(menu);
    }

   

  
}
