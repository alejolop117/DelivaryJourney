using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Obstacle1 : MonoBehaviour
{//este obstaculo reinicia la escena o muestra un mensaje de que el jugador perdio y puede reinicar o salir al menu 

    //Scene currentScene;
    //int currentSceneIndex;
    [SerializeField] bool tutorial; 
    [SerializeField] Eventos gameOver;
    [SerializeField] AudioManager crashSound;
    Vibrate vibrateEffect;
    int calls = 0;
    private void Awake()
    
    {
        vibrateEffect = GetComponent<Vibrate>();
        //currentScene = SceneManager.GetActiveScene(); 

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //SceneManager.LoadScene(currentScene.buildIndex);
            //Debug.Log("Fired Event");
            gameOver.FireEvent();
            vibrateEffect.VibrateP();
            crashSound.CollisionCarSound();
            calls++;
           // Debug.Log(calls);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")&&tutorial==true)
        {
            //SceneManager.LoadScene(currentScene.buildIndex);
            gameOver.FireEvent();
        }
    }
}
