using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaAnimation : MonoBehaviour
{
    [SerializeField] Eventos mensaje, desaparecer;
    [SerializeField] CanvasGroup transparencia;
    [SerializeField] float aparicion;
    void Awake()
    {
        mensaje.GEvent += AparecerArea;
        desaparecer.GEvent += DesaparecerArea;
        transparencia.alpha = 0;
        transform.localScale = Vector2.zero;
    }
    void AparecerArea()
    {
        transparencia.LeanAlpha(1, aparicion);
        transform.LeanScale(Vector2.one, aparicion).setEaseOutQuart();
        transparencia.LeanAlpha(0.8f, aparicion).setLoopPingPong();
    }
    void DesaparecerArea()
    {
        transparencia.LeanAlpha(0, aparicion);
        transform.LeanScale(Vector2.zero, aparicion).setEaseOutQuart();
    }
    private void OnDestroy()
    {
        desaparecer.GEvent -= DesaparecerArea;
        mensaje.GEvent -= AparecerArea;
    }
    private void OnDisable()
    {
        desaparecer.GEvent -= DesaparecerArea;
        mensaje.GEvent -= AparecerArea;
    }
}
