using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSkinManager : MonoBehaviour
{
    [SerializeField] int index;
    [SerializeField] Eventos cambioSkin;
    [SerializeField] string[] contadores;
    [SerializeField] int[] valores;
    [SerializeField] GameObject botonplay,boton_nosepuede,img_sinSkin;
    void Awake()
    {

        index = 0;
        //PlayerPrefs.SetInt("CharacterSelected", index);
        cambioSkin.GEvent += VerificarSkinA;
        boton_nosepuede.SetActive(false);
        img_sinSkin.SetActive(false);
    }
    void VerificarSkinA()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");
        if (index == 0)
        {
            botonplay.SetActive(true);
            boton_nosepuede.SetActive(false);
            img_sinSkin.SetActive(false);
        }
        else if (index == 4)
        {
            if (PlayerPrefs.GetInt("SkinBonus") > 0)
            {
                botonplay.SetActive(true);
                boton_nosepuede.SetActive(false);
                img_sinSkin.SetActive(false);
            }
            else
            {
                botonplay.SetActive(false);
                boton_nosepuede.SetActive(false);
                img_sinSkin.SetActive(false);
            }
        }
        else
        {
            if (PlayerPrefs.GetInt(contadores[index]) >= valores[index])
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
