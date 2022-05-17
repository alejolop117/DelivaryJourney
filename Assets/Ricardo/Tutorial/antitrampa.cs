using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antitrampa : MonoBehaviour
{
    [SerializeField] Eventos reiniciarPuntaje;
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("sin trampa");
            PlayerPrefs.SetInt("P", 1);
            PlayerPrefs.SetInt("TutorialHabilitado", 1);
            reiniciarPuntaje.FireEvent();
        }
    }
}
