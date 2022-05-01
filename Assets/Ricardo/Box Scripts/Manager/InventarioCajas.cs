using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InventarioCajas : MonoBehaviour
{
    [SerializeField] private Eventos recogerCaja, reinicioCaja,perderColor,ganarSkin,finTutorial,gameOver,antitrampa;
    //[SerializeField] Eventos sumarC, sumarA, sumarV;
    [SerializeField] private string nombreCaja;
    [SerializeField] TextMeshProUGUI conteoCaja;
    [SerializeField] BoxRecordDelivery record;
    [SerializeField] private bool pruebas;
    [SerializeField] private int maximoPorCaja, conteoActual, cajasLlenas,objetivoSkin;
    [SerializeField] int skinGanada;

    
    [SerializeField] float tiempoSkin;
    public int conteoGeneral;
    
    void Awake()
    {
        //puntajeTotal = GetComponent<BoxScore>();
        conteoActual = 1;
        
        recogerCaja.GEvent += SumarCajas;
        reinicioCaja.GEvent += Reinicio;
        perderColor.GEvent += PerderCajaColor;
        finTutorial.GEvent += ReinicarContador;
        antitrampa.GEvent += ReinicarContador;
        gameOver.GEvent += GameOver;
    }
    void Start()
    {
        if (pruebas == false)
        {
            conteoGeneral = PlayerPrefs.GetInt("Conteo Cajas " + nombreCaja);
            //puntajeTotal.ScoreRecord = PlayerPrefs.GetInt("Record Cajas");
            conteoCaja.text = (conteoGeneral+conteoActual).ToString() + " / "+objetivoSkin;
        }
        else
        {
            conteoGeneral = 0;
            //puntajeTotal.ScoreRecord = 0;
            PlayerPrefs.SetInt("Conteo Cajas " + nombreCaja, conteoGeneral);
            //PlayerPrefs.SetInt("Record Cajas", puntajeTotal.ScoreRecord);
            conteoCaja.text = (conteoGeneral+conteoActual).ToString() + " / "+objetivoSkin;
        }
        skinGanada = PlayerPrefs.GetInt("Skin " + nombreCaja + " ganada");
    }
    void SumarCajas()
    {
        if (conteoActual < maximoPorCaja)
        {
            conteoActual++;
            conteoCaja.text = (conteoGeneral + conteoActual + (cajasLlenas * maximoPorCaja)).ToString() + " / "+objetivoSkin;
        }
        else
        {
            conteoActual = 1;
            cajasLlenas++;
            conteoCaja.text = (conteoGeneral + conteoActual+(cajasLlenas*maximoPorCaja)).ToString() + " / "+objetivoSkin;
        }
    }
    void Reinicio()
    {
        conteoGeneral = conteoActual + maximoPorCaja * cajasLlenas + conteoGeneral;
        if (nombreCaja == "Azul")
        {
            record.conteoAzul += conteoActual + maximoPorCaja * cajasLlenas;
           // sumarA.FireEvent();
        }
        if (nombreCaja == "Cafe")
        {
            record.conteoCafe += conteoActual + maximoPorCaja * cajasLlenas;
            //sumarC.FireEvent();
        }
        if (nombreCaja == "Verde")
        {
            record.conteoVerde += conteoActual + maximoPorCaja * cajasLlenas;
            //sumarV.FireEvent();
        }
        conteoActual = 1;
        PlayerPrefs.SetInt("Conteo Cajas " + nombreCaja, conteoGeneral);
        conteoCaja.text = ((PlayerPrefs.GetInt("Conteo Cajas " + nombreCaja)).ToString()) + " / "+objetivoSkin;
        
        cajasLlenas = 0;
        if (conteoGeneral >= objetivoSkin && PlayerPrefs.GetInt("Skin " + nombreCaja + " ganada")<=0)
        {
            PlayerPrefs.SetInt("Skin " + nombreCaja + " ganada", 1);
            StartCoroutine("GanarSkin");
            //Debug.Log("ha desbloqueado la skin "+nombreCaja);
        }
    }
    IEnumerator GanarSkin()
    {
        yield return new WaitForSeconds(tiempoSkin);
        ganarSkin.FireEvent();
    }
    void PerderCajaColor()
    {
        if (cajasLlenas <= 0)
        {
            conteoActual = 0;
            conteoCaja.text = (conteoGeneral + conteoActual + (cajasLlenas * maximoPorCaja)).ToString() + " / "+objetivoSkin;
        }
        else
        {
            cajasLlenas--;
            conteoCaja.text = (conteoGeneral + conteoActual + (cajasLlenas * maximoPorCaja)).ToString() + " / "+objetivoSkin;
        }
    }
    void ReinicarContador()
    {
        PlayerPrefs.SetInt("Conteo Cajas " + nombreCaja, 0);
        PlayerPrefs.SetInt("Skin " + nombreCaja + " ganada", 0);
        PlayerPrefs.SetInt("Record", 0);
    }
    void GameOver()
    {
        conteoCaja.text = (PlayerPrefs.GetInt("Conteo Cajas " + nombreCaja).ToString()) + " / "+objetivoSkin;
    }
    private void OnDestroy()
    {
        recogerCaja.GEvent -= SumarCajas;
        reinicioCaja.GEvent -= Reinicio;
        perderColor.GEvent -= PerderCajaColor;
        finTutorial.GEvent -= ReinicarContador;
        antitrampa.GEvent -= ReinicarContador;

        gameOver.GEvent -= GameOver;
    }
}
