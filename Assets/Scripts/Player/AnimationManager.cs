using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] Eventos driftE;
    [SerializeField] GameObject canvasMovement;
    Animator[] driftAnim;
    [SerializeField]float animTime = 0.4f;
    private void Awake() {
        driftAnim = GetComponentsInChildren<Animator>();
        driftE.GEvent += Drift;
    }

    IEnumerator Deslizar() {

        for (ushort i = 0; i < driftAnim.Length; i++) {
            driftAnim[i].SetBool("Drift", true);
        }
        //canvasMovement.SetActive(false);
        yield return new WaitForSeconds(animTime);

        for (ushort i = 0; i < driftAnim.Length; i++) {
            driftAnim[i].SetBool("Drift", false);
        }
        //canvasMovement.SetActive(true);
    }

    void Drift() {
        StartCoroutine("Deslizar");
    }

    private void OnDestroy() {
        driftE.GEvent -= Drift;
    }

    private void OnDisable() {
        driftE.GEvent -= Drift;
    }
}
