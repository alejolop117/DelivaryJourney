using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReinicioCajas : MonoBehaviour
{
    [SerializeField] Eventos reinicioCajas;
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Cajas F")
        {
            other.gameObject.GetComponent<Crecer>().Reiniciar();
            reinicioCajas.FireEvent();
        }
    }
}
