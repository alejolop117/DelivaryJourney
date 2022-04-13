using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pcControl : MonoBehaviour {

    [SerializeField] float speed = 20f;
    [SerializeField] float turnSpeed = 45f;
    [SerializeField] float horizontalInput;
    [SerializeField] float forwardInput;
    void Update() {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput); //Direction, Speed, Direction(+-)
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}
