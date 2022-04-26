using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerderCaja : MonoBehaviour
{
    [SerializeField] private Eventos eventoPerderCaja,eventoPerderColor;
    //[SerializeField] Crecer tamaños;
    [SerializeField] private ParticleSystem choque;
    [SerializeField] private float duracionEfecto; 
    private bool eventoDisparado = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player" && eventoDisparado == false && collision.gameObject.tag != "Cajas F" && collision.gameObject.tag != "Cone" && collision.gameObject.tag != "Barrier")
        {

            eventoPerderColor.FireEvent();
            StartCoroutine("Efecto");
        }
    }
    IEnumerator Efecto()
    {
        choque.Play();
        eventoPerderCaja.FireEvent();

        eventoDisparado = true;
        /* tamaños.tamaño.localScale = tamaños.tamañoInicial;
        tamaños.tamañoActual = 0;*/

        //Debug.Log("se callo la caja");
        yield return new WaitForSeconds(duracionEfecto);
        this.gameObject.SetActive(false);
    }
}
