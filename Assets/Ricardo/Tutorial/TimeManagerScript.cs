using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManagerScript : MonoBehaviour
{
    [SerializeField] Eventos m1, m2, m3,mE,mP;
    [SerializeField] Eventos d1, d2, d3,dE,dP;
    [Range(0,1)]
    [SerializeField] float tiempo;
    void Awake()
    {
        m1.GEvent += RalentizarTiempo;
        m2.GEvent += RalentizarTiempo;
        m3.GEvent += RalentizarTiempo;
        mE.GEvent += RalentizarTiempo;
        mP.GEvent += RalentizarTiempo;
        d1.GEvent += RestaurarTiempo;
        d2.GEvent += RestaurarTiempo;
        d3.GEvent += RestaurarTiempo;
        dE.GEvent += RestaurarTiempo;
        dP.GEvent += RestaurarTiempo;
    } 
    void RalentizarTiempo()
    {
        Time.timeScale = tiempo;
    }
    void RestaurarTiempo()
    {
        Time.timeScale = 1;
    }
    private void OnDestroy()
    {
        m1.GEvent -= RalentizarTiempo;
        m2.GEvent -= RalentizarTiempo;
        m3.GEvent -= RalentizarTiempo;
        mE.GEvent -= RalentizarTiempo;
        mP.GEvent -= RalentizarTiempo;
        d1.GEvent -= RestaurarTiempo;
        d2.GEvent -= RestaurarTiempo;
        d3.GEvent -= RestaurarTiempo;
        dE.GEvent -= RestaurarTiempo;
        dP.GEvent -= RestaurarTiempo;
    }
    private void OnDisable()
    {
        m1.GEvent -= RalentizarTiempo;
        m2.GEvent -= RalentizarTiempo;
        m3.GEvent -= RalentizarTiempo;
        mE.GEvent -= RalentizarTiempo;
        mP.GEvent -= RalentizarTiempo;
        d1.GEvent -= RestaurarTiempo;
        d2.GEvent -= RestaurarTiempo;
        d3.GEvent -= RestaurarTiempo;
        dE.GEvent -= RestaurarTiempo;
        dP.GEvent -= RestaurarTiempo;
    }
}
