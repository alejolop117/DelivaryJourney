using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSkinBonus : MonoBehaviour
{
    [SerializeField] Eventos reto1, reto2,skinBonusDesbloqueada;
    [SerializeField] bool r1, r2,testing;
    void Start()
    {
        r1 = false;
        r2 = false;
        reto1.GEvent += PrimerReto;
        reto2.GEvent += SegundoReto;
        if (testing == true)
        {
            PlayerPrefs.SetInt("SkinBonus", 0);
        }
        //Debug.Log(PlayerPrefs.GetInt("SkinBonus"));
    }

    void PrimerReto()
    {
        r1 = true;
        VerificacionReto();
    }
    void SegundoReto()
    {
        r2 = true;
        VerificacionReto();
    }
    void VerificacionReto()
    {
        if (r1 == true && r2 == true)
        {
            PlayerPrefs.SetInt("SkinBonus", 1);
            skinBonusDesbloqueada.FireEvent();
            //Debug.Log("desbloqueado");
        }
    }
    private void OnDestroy()
    {
        reto1.GEvent -= PrimerReto;
        reto2.GEvent -= SegundoReto;
    }
}
