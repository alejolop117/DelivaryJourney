using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerderCaja : MonoBehaviour
{
    [SerializeField] private Eventos eventoPerderCaja,eventoPerderColor;
    [SerializeField] private ParticleSystem choque;
    [SerializeField] private float duracionEfecto; 
    private bool eventoDisparado = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Suelo" && eventoDisparado == false)
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
        //Debug.Log("se callo la caja");
        yield return new WaitForSeconds(duracionEfecto);
        this.gameObject.SetActive(false);
    }
}
