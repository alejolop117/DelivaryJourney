using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main");
    }

    public void SalirJuego()
    {
        Application.Quit();

    }    
}
