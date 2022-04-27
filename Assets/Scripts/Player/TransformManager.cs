using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformManager : MonoBehaviour
{
    public float xPos = 14.5f, xNeg = -12.5f;
    Vector3 nullVector = new Vector3(0, 0, 0);
    Vector3 positionVector = new Vector3(0, 0, 0);
    PlayerMovement move;
    private void Start() {
        positionVector = transform.position;
        move = GetComponent<PlayerMovement>();
    }

    private void FixedUpdate() {
        ControlYZPosition();
        ControlRotation();
        ControlXPosition();
    }

    void ControlYZPosition () {
        if (transform.position.y != 1) {
            transform.position = new Vector3(transform.position.x, 1, 0);
        }
    }

    void ControlXPosition() {
        if (transform.position.x >= xPos && !move.left) {
            positionVector.x = xPos;
            transform.position = positionVector;
        }

        if (transform.position.x <= xNeg && !move.right) {
            positionVector.x = xNeg;
            transform.position = positionVector;
        }
    }

    void ControlRotation() {
        if (transform.eulerAngles != nullVector) transform.eulerAngles = nullVector;
    }

}
