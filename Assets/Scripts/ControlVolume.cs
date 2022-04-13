using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlVolume : MonoBehaviour
{
    [SerializeField] float changePerSecond;
    [SerializeField] Eventos gameOver;
    AudioSource mAudioSouerce;

    private void Awake() {
        mAudioSouerce = GetComponent<AudioSource>();
        gameOver.GEvent += TurnOFFonGameOVer;
    }

    private void Update() {
        mAudioSouerce.volume += changePerSecond * Time.deltaTime;
        
    }

    void TurnOFFonGameOVer() {
        mAudioSouerce.Pause();
    }

    private void OnDestroy() {
        gameOver.GEvent -= TurnOFFonGameOVer;
    }
    private void OnDisable() {
        gameOver.GEvent -= TurnOFFonGameOVer;
    }
    
}
