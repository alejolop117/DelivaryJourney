using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparecerMensaje : MonoBehaviour
{
    [SerializeField] Eventos mensaje;
    [SerializeField] bool lanzado;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"&& lanzado==false)
        {
            mensaje.FireEvent();
            lanzado = true;
        }
    }
}
