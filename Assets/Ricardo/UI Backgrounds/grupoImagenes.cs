using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class grupoImagenes : MonoBehaviour
{
    [SerializeField] Sprite[] imagen;
     Image fondo;
    [SerializeField] int num;
    void Start()
    {
        num = Random.Range(0, imagen.Length);
        fondo = GetComponent<Image>();
        fondo.sprite = imagen[num];
    }
    
}
