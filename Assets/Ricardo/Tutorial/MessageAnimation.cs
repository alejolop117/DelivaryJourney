using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageAnimation : MonoBehaviour
{
    [SerializeField] Eventos mensaje, desaparecer;
    [SerializeField] float aparicion,delay;
    [SerializeField] Vector2 posicionTextoInicial,posicionTextoFinal;
    [SerializeField] RectTransform texto;
    void Awake()
    {
        mensaje.GEvent += AparecerMensaje;
        desaparecer.GEvent += DesaparecerMensaje;
    }
    void AparecerMensaje()
    {
        texto.LeanMoveLocal(posicionTextoFinal, aparicion).setEaseOutExpo().delay = delay;
    }
    void DesaparecerMensaje()
    {
        texto.LeanMoveLocal(posicionTextoInicial, aparicion).setEaseInExpo();
    }
    private void OnDestroy()
    {
        desaparecer.GEvent -= DesaparecerMensaje;
        mensaje.GEvent -= AparecerMensaje;
    }
    private void OnDisable()
    {
        desaparecer.GEvent -= DesaparecerMensaje;
        mensaje.GEvent -= AparecerMensaje;
    }
}
