using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSkinManager : MonoBehaviour
{
    [SerializeField] int index;
    [SerializeField] Eventos cambioSkin;
    [SerializeField] string[] contadores;
    [SerializeField] GameObject botonplay,boton_nosepuede,img_sinSkin;
    void Awake()
    {

        index = 0;
        
        cambioSkin.GEvent += VerificarSkinA;
    }
    void VerificarSkinA()
    {
        index = PlayerPrefs.GetInt("SkinA");
        if (index == 0)
        {
            botonplay.SetActive(true);
            boton_nosepuede.SetActive(false);
            img_sinSkin.SetActive(false);
        }
        else
        {
            if (PlayerPrefs.GetInt(contadores[index]) >= 10)
            {
                botonplay.SetActive(true);
                boton_nosepuede.SetActive(false);
                img_sinSkin.SetActive(false);
            }
            else
            {
                botonplay.SetActive(false);
                boton_nosepuede.SetActive(true);
                img_sinSkin.SetActive(true);
            }
        }
    }


    private void OnDestroy()
    {
        cambioSkin.GEvent -= VerificarSkinA;
        
    }
    private void OnDisable()
    {
        cambioSkin.GEvent -= VerificarSkinA;
     
    }
}
