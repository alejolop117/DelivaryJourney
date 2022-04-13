using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundAnim : MonoBehaviour
{
    [SerializeField] Eventos mensaje, desaparecer;
    [SerializeField] float aparicion;
    [SerializeField] CanvasGroup fondo;
    void Awake()
    {
        mensaje.GEvent += Aparecer;
        desaparecer.GEvent += Desaparecer;
        fondo.alpha = 0;
    }
    void Aparecer()
    {
        fondo.LeanAlpha(1, aparicion);
    }
    void Desaparecer()
    {
        fondo.LeanAlpha(0, aparicion);
    }
    private void OnDestroy()
    {
        desaparecer.GEvent -= Desaparecer;
        mensaje.GEvent -= Aparecer;
    }
    private void OnDisable()
    {
        desaparecer.GEvent -= Desaparecer;
        mensaje.GEvent -= Aparecer;
    }
}
