using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alejo {
    public class CameraShake : MonoBehaviour {

        [SerializeField] Transform camTransform;
        //How long the object should shake for.
        [SerializeField] float initialShakeDuration = 0f;
        float shakeDuration;
        //Amplitude of the shake. A larger value shakes the camera harder.
        [SerializeField] float shakeAmount = 0.7f;
        [SerializeField] float decreseFactor = 1.0f;
        Vector3 originalPos;
        [SerializeField] bool enable = false;

        void Awake() {
            shakeDuration = initialShakeDuration;
            if(camTransform == null) {
                camTransform = GetComponent(typeof(Transform)) as Transform;
            }
        }

        private void OnEnable() {
            originalPos = camTransform.localPosition;
        }

        void Update() {
            if (!enable) return;
            if(shakeDuration > 0) {
                camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
                shakeDuration -= Time.deltaTime * decreseFactor;
            }
            else {
                enable = false;
                shakeDuration = 0f;
                camTransform.localPosition = originalPos;
            }
        }

        private void OnCollisionEnter(Collision collision) {
            enable = true;
            shakeDuration = initialShakeDuration;
        }
    }
}

