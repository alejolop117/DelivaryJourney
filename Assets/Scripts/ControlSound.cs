using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSound : MonoBehaviour
{
    [SerializeField] AudioSource sLineaMeta;
    static ushort state = 0;
   

    private void OnTriggerEnter(Collider other) {
        
        if (other.CompareTag("Player") && state == 0) {
            sLineaMeta.Play();
            state = 1;

        }

        else if(other.CompareTag("Player") && state == 1) {
            sLineaMeta.Pause();
            state = 0;
        }
    }
}
