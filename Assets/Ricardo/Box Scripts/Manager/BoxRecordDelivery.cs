using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoxRecordDelivery : MonoBehaviour
{
    public int conteoCafe, conteoAzul, conteoVerde,conteoGeneralRun;
    [SerializeField] Eventos entregaCaja,reto2;
    [SerializeField] TextMeshProUGUI conteo;
    [SerializeField] GameObject recordMessage;
    
    

    void Awake()
    {
        recordMessage.SetActive(false);
        conteoCafe = 0;
        conteoAzul = 0;
        conteoVerde = 0;
        conteoGeneralRun = 0;
        conteo.text = conteoGeneralRun.ToString();
      
        entregaCaja.GEvent += CompararRecord;
    }

    void CompararRecord()
    {
        conteoGeneralRun = conteoAzul + conteoVerde+conteoCafe;
        if (conteoGeneralRun > PlayerPrefs.GetInt("Record"))
        {
            PlayerPrefs.SetInt("Record", conteoGeneralRun);
            recordMessage.SetActive(true);
        }
        if (conteoGeneralRun >= 150)
        {
            //Debug.Log("se desbloqueo reto 2");
            reto2.FireEvent();
        }
        conteo.text = conteoGeneralRun.ToString();
    }
    /*private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            PlayerPrefs.SetInt("Record", 0);
        }
    }*/
}
