using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReacomodarCaja : MonoBehaviour
{
    [SerializeField] Eventos ganarSkin,lanzarMensaje,devolverMensaje;
    [SerializeField] float tiempoAnim;
    [SerializeField] Vector2 originalPos, posIni;
    void Awake()
    {
        ganarSkin.GEvent += Reacomodar;
    }

    void Reacomodar()
    {
        StartCoroutine("CambiarPosiciones");
    }
    IEnumerator CambiarPosiciones()
    {
        transform.localPosition = posIni;
        lanzarMensaje.FireEvent();
        yield return new WaitForSeconds(tiempoAnim);
        devolverMensaje.FireEvent();
        yield return new WaitForSeconds(tiempoAnim);
        transform.localPosition = originalPos;
    }
    private void OnDestroy()
    {
        ganarSkin.GEvent -= Reacomodar;
    }
    private void OnDisable()
    {
        ganarSkin.GEvent -= Reacomodar;
    }
}
