using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMangerTwo : MonoBehaviour
{
    [SerializeField] Eventos [] events;
    AudioSource audios;
    public AudioClip [] clips;
    

    private void Awake() {
        audios = GetComponent<AudioSource>();
        events[0].GEvent += ClipOne;
        events[1].GEvent += ClipTwo;
        events[2].GEvent += ClipThree;
        events[3].GEvent += ClipThree;
        events[4].GEvent += ClipThree;
        events[5].GEvent += ClipFour;

    }

    void ClipOne() {
        audios.clip = clips[0];
        audios.Play();
    }

    void ClipTwo() {
        audios.clip = clips[1];
        audios.Play();
    }

    void ClipThree() {
        audios.clip = clips[2];
        audios.Play();
    }

    void ClipFour() {
        audios.clip = clips[3];
        audios.Play();
    }

    private void OnDestroy() {
        events[0].GEvent -= ClipOne;
        events[1].GEvent -= ClipTwo;
        events[2].GEvent -= ClipThree;
        events[3].GEvent -= ClipThree;
        events[4].GEvent -= ClipThree;
        events[5].GEvent -= ClipFour;
    }

    private void OnDisable() {
        events[0].GEvent -= ClipOne;
        events[1].GEvent -= ClipTwo;
        events[2].GEvent -= ClipThree;
        events[3].GEvent -= ClipThree;
        events[4].GEvent -= ClipThree;
        events[5].GEvent -= ClipFour;
    }
}
