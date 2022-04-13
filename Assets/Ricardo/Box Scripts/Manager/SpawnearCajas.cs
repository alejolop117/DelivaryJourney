using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnearCajas : MonoBehaviour
{
    [SerializeField] private Eventos eventoLlenoC, eventoLlenoR, eventoLlenoV;
    [SerializeField] Eventos spawnC, spawnA, spawnV;
    [SerializeField] private BoxPooling CajaC, CajaA, CajaV;
    [SerializeField] private Transform spawn;
    void Start()
    {
        eventoLlenoC.GEvent += SpawnearCajaCafe;
        spawnC.GEvent+= SpawnearCajaCafe;
        eventoLlenoR.GEvent += SpawnearCajaAzul;
        spawnA.GEvent += SpawnearCajaAzul;
        eventoLlenoV.GEvent += SpawnearCajaVerde;
        spawnV.GEvent += SpawnearCajaVerde;
    }

    void SpawnearCajaCafe()
    {
        //Instantiate(CajaC, spawn);
        GameObject cajaC = CajaC.GetPooledObject();
        if (cajaC != null)
        {
            cajaC.transform.position = spawn.transform.position;
            cajaC.transform.rotation = spawn.transform.rotation;
            cajaC.SetActive(true);
        }
    }
    void SpawnearCajaAzul()
    {
        GameObject cajaA = CajaA.GetPooledObject();
        if (cajaA != null)
        {
            cajaA.transform.position = spawn.transform.position;
            cajaA.transform.rotation = spawn.transform.rotation;
            cajaA.SetActive(true);
        }
    }
    void SpawnearCajaVerde()
    {
        GameObject cajaV = CajaV.GetPooledObject();
        if (cajaV != null)
        {
            cajaV.transform.position = spawn.transform.position;
            cajaV.transform.rotation = spawn.transform.rotation;
            cajaV.SetActive(true);
        }
    }
    private void OnDestroy()
    {
        eventoLlenoC.GEvent -= SpawnearCajaCafe;
        spawnC.GEvent -= SpawnearCajaCafe;
        eventoLlenoR.GEvent -= SpawnearCajaAzul;
        spawnA.GEvent -= SpawnearCajaAzul;
        eventoLlenoV.GEvent -= SpawnearCajaVerde;
        spawnV.GEvent -= SpawnearCajaVerde;
    }
}
