using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    [SerializeField] GameObject deathMenu;
    [SerializeField] AudioSource gameOverClip;
    PlayerSoundManager deadSound;
    public AudioSource Audio;
    Scene currentScene;
    int currentSceneIndex;
    GameObject collidedObject;
    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collidedObject = collision.gameObject;
            deadSound = collidedObject.GetComponent<PlayerSoundManager>();
            Audio.Stop();
            gameOverClip.Play();
            Time.timeScale = 0f;
            deathMenu.SetActive(true);
        }
    }
}
