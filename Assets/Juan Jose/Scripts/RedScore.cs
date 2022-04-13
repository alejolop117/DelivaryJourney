using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class RedScore : MonoBehaviour
{
    [SerializeField]
    private Eventos eventoRecoger;
    [SerializeField] TextMeshProUGUI redCount;
    public int count = 0;

    private void Start()
    {
        eventoRecoger.GEvent += UpdateRedBoxes;
        count = PlayerPrefs.GetInt("Conteo Cajas Azul")+1;
    }

    private void Update()
    {
        redCount.text = count.ToString() + "/100";
    } 
    private void UpdateRedBoxes()
    {
        count++;
    }
}
