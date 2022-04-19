using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoger : MonoBehaviour
{
    [SerializeField] private Eventos evento,reaparecer;
    [SerializeField] private ParticleSystem recoger;
    [SerializeField] private float duracionEfecto;
    [SerializeField] AudioManager boxSound;

    private void Awake()
    {
        reaparecer.GEvent += Reaparicion;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            evento.FireEvent();
            boxSound.BoxCollected();
            StartCoroutine("Efecto");
        }
    }
    IEnumerator Efecto()
    {
        recoger.Play();
        //Debug.Log("se recogio la caja");
        yield return new WaitForSeconds(duracionEfecto);
        this.gameObject.SetActive(false);
    }
    void Reaparicion()
    {
        this.gameObject.SetActive(true);
    }
    private void OnDestroy()
    {
        reaparecer.GEvent -= Reaparicion;
    }
    
}
