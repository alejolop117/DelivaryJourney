using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerTutorial : MonoBehaviour
{
    [SerializeField] Eventos terminartutorial;

    private void Awake()
    {
        terminartutorial.GEvent += CargarJuego;
    }
    void CargarJuego()
    {
        PlayerPrefs.SetInt("tutorial", 1);
        SceneManager.LoadScene("Main");
    }
    private void OnDestroy()
    {
        terminartutorial.GEvent -= CargarJuego;
    }
    private void OnDisable()
    {
        terminartutorial.GEvent -= CargarJuego;
    }
    
}
