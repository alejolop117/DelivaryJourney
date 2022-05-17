using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinBonusAnimation : MonoBehaviour
{
    [SerializeField] Eventos skinDesbloqueada;
    [SerializeField] bool desbloqueado;
    [SerializeField] float aparicion, delay;
    [SerializeField] Vector2 posicionTextoInicial, posicionTextoFinal;
    [SerializeField] RectTransform texto;
    void Awake()
    {
        skinDesbloqueada.GEvent += AnimacionBonus;
        if (PlayerPrefs.GetInt("SkinBonus") > 0)
        {
            desbloqueado = true;
        }
        else
        {
            desbloqueado = false;
        }
    }
    void AnimacionBonus()
    {
        if (desbloqueado == false)
        {
            desbloqueado = true;
            StartCoroutine("AnimacionBonusN");
        }
        
    }
    IEnumerator AnimacionBonusN()
    {
        texto.LeanMoveLocal(posicionTextoFinal, aparicion).setEaseOutExpo().delay = delay;
        yield return new WaitForSeconds(1.5f);
        texto.LeanMoveLocal(posicionTextoInicial, aparicion).setEaseInExpo();
    }
    private void OnDestroy()
    {
        skinDesbloqueada.GEvent -= AnimacionBonus;
    }
}
