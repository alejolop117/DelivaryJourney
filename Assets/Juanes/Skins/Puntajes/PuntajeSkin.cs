using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuntajeSkin : MonoBehaviour
{

    private TextMeshProUGUI puntaje;
    [SerializeField] string nombre, requerimiento;

    public void Awake()
    {
        puntaje = GetComponent<TextMeshProUGUI>();
        puntaje.text = PlayerPrefs.GetInt("Conteo Cajas " + nombre).ToString() + " / " + requerimiento;
    }
}
