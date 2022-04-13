using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance { get; private set; }
    CinemachineVirtualCamera cmVc;
    float shakeTimer;
    float shakeTimerTotal;
    float startingIntensity;
    private void Awake() {
        Instance = this;
        cmVc = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity, float time) {
        CinemachineBasicMultiChannelPerlin cBMP =
             cmVc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cBMP.m_AmplitudeGain = intensity;
        startingIntensity = intensity;
        shakeTimerTotal = time;
        shakeTimer = time;

    }

    private void Update() {
        if (shakeTimer > 0f) {
            shakeTimer -= Time.deltaTime;
            if(shakeTimer <= 0f) {
                //Time Over
                CinemachineBasicMultiChannelPerlin cBMP =
             cmVc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cBMP.m_AmplitudeGain = 
                    Mathf.Lerp(startingIntensity, 0f, 1 - (shakeTimer / shakeTimerTotal));

            }
        }
    }
}
