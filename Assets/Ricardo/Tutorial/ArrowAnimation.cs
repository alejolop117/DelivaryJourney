using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAnimation : MonoBehaviour
{
    [SerializeField] Eventos mensaje,desaparecer;
    [SerializeField] float aparicion,tiempoRebote;
    [SerializeField] Vector2 posicionNueva;
    void Awake()
    {
        mensaje.GEvent += MovimientoFlecha;
        desaparecer.GEvent += DesaparecerFlecha;
        transform.localScale = Vector2.zero;
    }
    void MovimientoFlecha()
    {
        transform.LeanScale(Vector2.one, aparicion).setEaseOutQuart();
        transform.LeanMoveLocal(posicionNueva, tiempoRebote).setEaseOutQuart().setLoopPingPong();
    }
    void DesaparecerFlecha()
    {
        transform.LeanScale(Vector2.zero, aparicion).setEaseOutQuart();
    }
    private void OnDestroy()
    {
        desaparecer.GEvent -= DesaparecerFlecha;
        mensaje.GEvent -= MovimientoFlecha;
    }
    private void OnDisable()
    {
        desaparecer.GEvent -= DesaparecerFlecha;
        mensaje.GEvent -= MovimientoFlecha;
    }
}
