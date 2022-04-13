using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionVel : MonoBehaviour
{
    [SerializeField] Transform modelo;
    Quaternion rotacion;


    private void Start()
    {
        rotacion = transform.localRotation;
    }
    void Update()
    {
        rotacion.y = modelo.rotation.y+90;
        transform.localRotation = rotacion;
    }
}
