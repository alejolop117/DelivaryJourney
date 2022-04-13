using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeslizarLlantas : MonoBehaviour
{
    [SerializeField] Eventos deslizarLlantas;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            deslizarLlantas.FireEvent();
            //Debug.Log("esta derrapando");
        }
    }
}
