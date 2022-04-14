using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerThree : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    [SerializeField] Eventos playerNear;
    AudioSource mAudioSource;

    private void Awake() {
        mAudioSource = GetComponent<AudioSource>();
        playerNear.GEvent += RandomClip;
    }

    void RandomClip() {
        int random = Random.Range(0, clips.Length);
        mAudioSource.clip = clips[random];
        mAudioSource.Play();
    }

    private void OnDisable() {
        playerNear.GEvent -= RandomClip;
    }

    private void OnDestroy() {
        playerNear.GEvent -= RandomClip;
    }
}
