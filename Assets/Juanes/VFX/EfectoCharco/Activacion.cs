using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activacion : MonoBehaviour
{
    [SerializeField] Eventos deslizarLlantas;
    [SerializeField] ParticleSystem charco;
    // Start is called before the first frame update
    void Awake()
    {
        deslizarLlantas.GEvent += DispararCharco;

    }

    public void DispararCharco()
    {
        charco.Play();
    }

    private void OnDestroy()
    {
        deslizarLlantas.GEvent -= DispararCharco;
    }
}
