using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorCajas : MonoBehaviour
{

    public int contador;
    [SerializeField] int cC, cV, cA;
    //[SerializeField] Text cont;
    [SerializeField] Eventos eventoGanarCaja, eventoPerderCaja, eventoGameOver,reinicioCajas,cambiarVel;
    [SerializeField] Eventos ganarC, ganarV, ganarA,perderC,perderV,perderA;
    [SerializeField] Eventos recogerCV, recogerCA, recogerCC;
    [SerializeField] Eventos reiniciarV, reiniciarA, reiniciarC;
    [SerializeField] Eventos spawnC, spawnV, spawnA;

   [SerializeField] Eventos reiniciarDisparoC, reiniciarDisparoA, reiniciarDisparoV;


    void Start()
    {
        cC = 1;
        cV = 1;
        cA = 1;
        contador = cC + cV + cA;
        //cont.text = contador.ToString();
        eventoGanarCaja.GEvent += SumarCajas;
        eventoPerderCaja.GEvent += RestarCajas;

        ganarC.GEvent += SumarCafe;
        ganarV.GEvent += SumarVerde;
        ganarA.GEvent += SumarAzul;

        perderC.GEvent += PerderCafe;
        perderV.GEvent += PerderVerde;
        perderA.GEvent += PerderAzul;

        reinicioCajas.GEvent += ReinicioCajas;

        recogerCV.GEvent += ReaparecerV;
        recogerCA.GEvent += ReaparecerA;
        recogerCC.GEvent += ReaparecerC;
    }
    void SumarCajas()
    {
        contador++;
        //cont.text = contador.ToString();
        cambiarVel.FireEvent();
    }
    void RestarCajas()
    {
        contador--;
        //cont.text = contador.ToString();
        cambiarVel.FireEvent();
        GameOver();
    }
    void SumarCafe()
    {
        cC++;
        //PlayerPrefs.SetInt(("Anterior Azul"), cC);
    }
    void SumarAzul()
    {
        cA++;
        //PlayerPrefs.SetInt(("Anterior Azul"), cA);
    }
    void SumarVerde()
    {
        cV++;
        //PlayerPrefs.SetInt(("Anterior Azul"), cV);
    }
    void PerderCafe()
    {
        cC--;
        
        if (cC < 0)
        {
            cC = 0;
        }
       // PlayerPrefs.SetInt(("Anterior Azul"), cC);
        /* if (cC == 1)
          {
              reiniciarDisparoC.FireEvent();
          }*/
    }
    void PerderAzul()
    {
        cA--;
        
        if (cA < 0)
        {
            cA = 0;
        }
       // PlayerPrefs.SetInt(("Anterior Azul"), cA);
        /*if (cA == 1)
         {
             reiniciarDisparoA.FireEvent();
         }*/
    }
    void PerderVerde()
    {
        cV--;
        
        if (cV < 0)
        {
            cV = 0;
        }
        //PlayerPrefs.SetInt(("Anterior Azul"), cV);
        /*if (cV == 1)
        {
            reiniciarDisparoV.FireEvent();
        }*/
    }
    void ReinicioCajas()
    {
        if (cC > 1)
        {
            cC = 1;
        }
        if (cA > 1)
        {
            cA = 1;
        }
        if (cV > 1)
        {
            cV = 1;
        }
        contador = cC + cA + cV;
        cambiarVel.FireEvent();
        //cont.text = contador.ToString();
    }
    void GameOver()
    {
        if (contador <= 0)
        {
            eventoGameOver.FireEvent();
            //Debug.Log("Game Over");
        }
    }
    void ReaparecerV()
    {
        if (cV <= 0)
        {
            cV = 1;
            contador++;
            //cont.text = contador.ToString();
            reiniciarV.FireEvent();
            spawnV.FireEvent();
        }
    }
    void ReaparecerA()
    {
        if (cA <= 0)
        {
            cA = 1;
            contador++;
            //cont.text = contador.ToString();
            reiniciarA.FireEvent();
            spawnA.FireEvent();
        }
    }
    void ReaparecerC()
    {
        if (cC <= 0)
        {
            cC = 1;
            contador++;
            //cont.text = contador.ToString();
            reiniciarC.FireEvent();
            spawnC.FireEvent();
        }
    }
    private void OnDestroy()
    {
        eventoGanarCaja.GEvent -= SumarCajas;
        eventoPerderCaja.GEvent -= RestarCajas;

        ganarC.GEvent -= SumarCafe;
        ganarV.GEvent -= SumarVerde;
        ganarA.GEvent -= SumarAzul;

        perderC.GEvent -= PerderCafe;
        perderV.GEvent -= PerderVerde;
        perderA.GEvent -= PerderAzul;

        reinicioCajas.GEvent -= ReinicioCajas;

        recogerCV.GEvent -= ReaparecerV;
        recogerCA.GEvent -= ReaparecerA;
        recogerCC.GEvent -= ReaparecerC;
    }
    private void OnDisable()
    {
        eventoGanarCaja.GEvent -= SumarCajas;
        eventoPerderCaja.GEvent -= RestarCajas;

        ganarC.GEvent -= SumarCafe;
        ganarV.GEvent -= SumarVerde;
        ganarA.GEvent -= SumarAzul;

        perderC.GEvent -= PerderCafe;
        perderV.GEvent -= PerderVerde;
        perderA.GEvent -= PerderAzul;

        reinicioCajas.GEvent -= ReinicioCajas;

        recogerCV.GEvent -= ReaparecerV;
        recogerCA.GEvent -= ReaparecerA;
        recogerCC.GEvent -= ReaparecerC;
    }
}
