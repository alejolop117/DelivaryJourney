using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntajeSkin : MonoBehaviour
{

    private Text puntaje;
    [SerializeField] string nombre, requerimiento;

    public void Awake()
    {
        puntaje = GetComponent<Text>();
        puntaje.text = PlayerPrefs.GetInt("Conteo Cajas " + nombre).ToString() + " / " + requerimiento;
    }
}
