using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desplazar : MonoBehaviour
{
    private Rigidbody rb;
    //[SerializeField] float speed;
    [SerializeField] Vector3 direction;
    [SerializeField] float speedPlayer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        rb.velocity = direction * speedPlayer;
    }
}
