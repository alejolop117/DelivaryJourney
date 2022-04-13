using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Eventos /*lostBoxes*/ boxesDelivered, messageR, messageL, messageE, messageP, messageF,
        dMessgeR, dMessgeL;
    AudioSource audios;
    public AudioClip boxCollected, coneCrash, fenceCrash, barrierCrash, carCrash,
        boxDelivered, tutorialMessage, tutorialMessageF, checkTutorial, click;
    public bool isInTutorial = false;

    private void Awake() {
        audios = GetComponent<AudioSource>();
        //lostBoxes.GEvent += LostBox;
        boxesDelivered.GEvent += BoxDelivered;
        messageE.GEvent += TutorialMessage;
        messageL.GEvent += TutorialMessage;
        messageR.GEvent += TutorialMessage;
        messageP.GEvent += TutorialMessage;
        messageF.GEvent += TutorialMessageFinal;
        dMessgeL.GEvent += CheckTutorial;
        dMessgeR.GEvent += CheckTutorial;

    }

    public void OnClick() {
        audios.clip = click;
        audios.Play();
    }
    void CheckTutorial() {
        if(isInTutorial == true) {
            audios.clip = checkTutorial;
            audios.Play();
            isInTutorial = false;
        }
    }
    void TutorialMessageFinal() {
        audios.clip = tutorialMessageF;
        audios.Play();
    }
    void TutorialMessage() {
        audios.clip = tutorialMessage;
        audios.Play();
        isInTutorial = true;
    }

    public void CollisionCarSound() {
        audios.clip = carCrash;
        audios.Play();
    }

    public void BoxCollected() {
        audios.clip = boxCollected;
        audios.Play();
    }

    public void ConeCrash() {
        audios.clip = coneCrash;
        audios.Play();
    }

    public void FenceCrash() {
        audios.clip = fenceCrash;
        audios.Play();
    }

    public void BarrierCrash() {
        audios.clip = barrierCrash;
        audios.Play();
    } 

    public void BoxDelivered () {
        audios.clip = boxDelivered;
        audios.Play();
    }

    private void OnDestroy() {
        //lostBoxes.GEvent -= LostBox;
        boxesDelivered.GEvent -= BoxDelivered;
        messageE.GEvent -= TutorialMessage;
        messageL.GEvent -= TutorialMessage;
        messageR.GEvent -= TutorialMessage;
        messageP.GEvent -= TutorialMessage;
        messageF.GEvent -= TutorialMessageFinal;
        dMessgeL.GEvent -= CheckTutorial;
        dMessgeR.GEvent -= CheckTutorial;
    }

    private void OnDisable() {
        //lostBoxes.GEvent -= LostBox;
        dMessgeL.GEvent -= CheckTutorial;
        dMessgeR.GEvent -= CheckTutorial;
        boxesDelivered.GEvent -= BoxDelivered;
        messageE.GEvent -= TutorialMessage;
        messageL.GEvent -= TutorialMessage;
        messageP.GEvent -= TutorialMessage;
        messageR.GEvent -= TutorialMessage;
        messageF.GEvent -= TutorialMessageFinal;
    }
}
