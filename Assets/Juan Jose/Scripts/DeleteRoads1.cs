using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteRoads1 : MonoBehaviour
{
    [SerializeField] Transform despawn;
    [SerializeField] Eventos reaparecer;
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Piso") || other.gameObject.CompareTag("MapLeft") || other.gameObject.CompareTag("MapRight"))
        {
            reaparecer.FireEvent();
            other.gameObject.transform.position = despawn.position;
            other.gameObject.transform.position = despawn.position;
            other.gameObject.SetActive(false);

        }
    }
}
