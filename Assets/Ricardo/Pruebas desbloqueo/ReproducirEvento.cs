using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReproducirEvento : MonoBehaviour
{
    [SerializeField] Eventos e1, e2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            e1.FireEvent();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            e2.FireEvent();
        }
    }
}
