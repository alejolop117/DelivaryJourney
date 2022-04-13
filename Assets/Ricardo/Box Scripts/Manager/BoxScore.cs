using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BoxScore : MonoBehaviour
{
    [SerializeField]
    private Eventos eventoRecoger,eventoPerderCaja,reinicioCaja;
    [SerializeField] TextMeshProUGUI colorCount;
    [SerializeField] string nombreCaja;
    [SerializeField] InventarioCajas InvCaja;
    public int count , valorIni;

    private void Awake()
    {
        eventoRecoger.GEvent += UpdateBoxes;
        eventoPerderCaja.GEvent += LoseBox;
        reinicioCaja.GEvent += UpdateOverAllScore;
        count = PlayerPrefs.GetInt("Conteo Cajas "+nombreCaja);
        if (count == 0)
        {
            count = 1;
            colorCount.text = "1/100";
            valorIni = 0;
        }
        else
        {
            colorCount.text = count.ToString() + "/100";
            valorIni = count;
        }
        
        
    }

    private void UpdateBoxes()
    {
        count++;
        colorCount.text = count .ToString() + "/100";
    }
    void LoseBox()
    {
        //count--;
        if (count == valorIni)
        {
            count = valorIni;
            colorCount.text = count.ToString() + "/100";
        }
    }
    void UpdateOverAllScore()
    {
        valorIni = InvCaja.conteoGeneral;
        colorCount.text = count.ToString() + "/100";
    }
    private void OnDestroy()
    {
        eventoRecoger.GEvent -= UpdateBoxes;
        eventoPerderCaja.GEvent -= LoseBox;
        reinicioCaja.GEvent -= UpdateOverAllScore;
    }
    private void OnDisable()
    {
        eventoRecoger.GEvent -= UpdateBoxes;
        eventoPerderCaja.GEvent -= LoseBox;
        reinicioCaja.GEvent -= UpdateOverAllScore;
    }
}
