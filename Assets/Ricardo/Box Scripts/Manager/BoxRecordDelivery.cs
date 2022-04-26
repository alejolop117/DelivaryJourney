using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxRecordDelivery : MonoBehaviour
{
    public int conteoCafe, conteoAzul, conteoVerde,conteoGeneralRun;
    [SerializeField] Eventos entregaCaja;
    [SerializeField] Text conteo;
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
        conteo.text = conteoGeneralRun.ToString();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            PlayerPrefs.SetInt("Record", 0);
        }
    }
}
