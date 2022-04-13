using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    AudioSource audios;
    [SerializeField] AudioSource musicWorld, carEngine;
    [SerializeField] AudioClip gameOver;
    [SerializeField] Eventos game_Over, tutorialMessageF;


    private void Awake() {
        audios = GetComponent<AudioSource>();
        game_Over.GEvent += ControlEndSound;
        tutorialMessageF.GEvent += EndSoundOnTutorial;
    }

    void ControlEndSound() {
        carEngine.volume = 0;
        musicWorld.volume = 0;

        audios.clip = gameOver;
        carEngine.volume = 1;
        carEngine.loop = false;
        audios.Play();
    }

    void EndSoundOnTutorial() {
        carEngine.volume = 0;
        musicWorld.volume = 0;
    }

    private void OnDestroy() {
        game_Over.GEvent -= ControlEndSound;
        tutorialMessageF.GEvent -= EndSoundOnTutorial;
    }

    private void OnDisable() {
        game_Over.GEvent -= ControlEndSound;
        tutorialMessageF.GEvent -= EndSoundOnTutorial;
    }

}
