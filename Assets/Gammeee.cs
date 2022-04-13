using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Gammeee : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    Scene currentScene;
    int currentSceneIndex;
    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }
    }

}
