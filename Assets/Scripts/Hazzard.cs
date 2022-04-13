using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazzard : MonoBehaviour
{
    [SerializeField] float shakeIntensity = 5, shakeTime = 0.1f;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            CinemachineShake.Instance.ShakeCamera(shakeIntensity,shakeTime);
        }
    }
}
