using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle2 : MonoBehaviour
{
    [SerializeField]YellowScore greenScore;
    [SerializeField]  RedScore redScore;
    [SerializeField] BrownScore brownScore;
    [SerializeField] AudioManager audioCrash;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (greenScore.count > 0) greenScore.count--;
            if (redScore.count > 0) redScore.count--;
            if (brownScore.count > 0) brownScore.count--;

            audioCrash.CollisionCarSound();
        }
    }
}
