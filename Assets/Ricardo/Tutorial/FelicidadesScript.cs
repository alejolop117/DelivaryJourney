using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FelicidadesScript : MonoBehaviour
{
    [SerializeField] Eventos entregarCajas,desaparecerMensaje;
    [SerializeField] float tiempoMensaje;
    void Start()
    {
        entregarCajas.GEvent += AparecerMensaje;
    }
    void AparecerMensaje()
    {
        StartCoroutine("Mensaje");
    }
    IEnumerator Mensaje()
    {
        yield return new WaitForSeconds(tiempoMensaje);
        desaparecerMensaje.FireEvent();
    }
    private void OnDestroy()
    {
        entregarCajas.GEvent -= AparecerMensaje;
    }
    private void OnDisable()
    {
        entregarCajas.GEvent -= AparecerMensaje;
    }
}
