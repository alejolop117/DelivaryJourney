using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crecer : MonoBehaviour , IReiniciable //hereda de una interfaz 
{
    [SerializeField] private Eventos eventoRecoger, eventoLleno, eventoGanarCaja,eventoReiniciar, entregaCaja, perderCaja,perderCajaG;
    [SerializeField] private float tamañoMaximo; //es el tamaño maximo de la caja
    [SerializeField] private float ritmoDeCrecimiento; //lo que crece por cada caja recolectada
    [SerializeField] private bool save; //determina si ha pasado por un punto de reinicio o no

    [SerializeField] private ParticleSystem crecer;
    [SerializeField] string nombre;
   
    


     bool disparoEvento = false; //determina si se ha disparado por lo menos una vez el evento
     float tamañoActual = 0; //contador de cuantas veces ha crecido mla caja
     Transform tamaño; //referencia a los parametros de escala del objeto
     Vector3 crecimiento, tamañoFinal; //vectores que determinan distintos tamaños del objeto
    [SerializeField] Vector3 tamañoInicial;
    
    // Start is called before the first frame update
    private void Awake()
    {
        tamaño = GetComponent<Transform>(); //se obtiene el componente del transform
        crecimiento = new Vector3(ritmoDeCrecimiento, ritmoDeCrecimiento, ritmoDeCrecimiento); //se determina el vector de cada cuanto crece dependiendo del ritmo
        tamañoFinal = new Vector3(tamañoMaximo, tamañoMaximo, tamañoMaximo); //se determina el vector de tamaño final de acuerdo al tamaño maximo
        
    }
    void Start()
    {
        save = false; //al inicio no pasa por un punto de reinicio
        
        
        //tamañoInicial = new Vector3(tamaño.localScale.x,tamaño.localScale.y,tamaño.localScale.z); //se tiene una referencia del tamaño inicial, util para cuando se reinicia el objeto
        eventoRecoger.GEvent += CrecerCaja;  //se subscriben dichas funciones a dichos eventos
        eventoReiniciar.GEvent += Desaparecer;
        
        reiniciarTamaño();
        //perderCajaG.GEvent += PerderCaja;
    }

    void CrecerCaja()
    {
        //la caja crece mientras no ha llegado a su maximo tamaño
        if (tamañoActual < tamañoMaximo)
        {
            
            crecer.Play();
            tamañoActual = tamañoActual + ritmoDeCrecimiento;
            tamaño.localScale = tamaño.localScale + crecimiento;
        }
        //si ya llega a su tamaño maximo y todavia no ha disparado el evento , dipara los respectivos eventos y se marca que ya se disparo una vez
        else if (tamañoActual >= tamañoMaximo && disparoEvento == false)
        {
            
            
            eventoLleno.FireEvent();
            eventoGanarCaja.FireEvent();
            disparoEvento = true;
            //Debug.Log("se lleno la caja");
        }


    }
    //desactiva el objeto si este no ha pasado por la zona de reinicio antes que otro
    void Desaparecer()
    {
        if (save == false)
        {

            reiniciarTamaño();
            this.gameObject.SetActive(false);
            //ganarVel.FireEvent();

        }
        else
        {
            save = false;
        }
    }
    void reiniciarTamaño()
    {
        //Debug.Log("se reinicio el tamaño de " + nombre);
        tamaño.localScale = tamañoInicial;
        tamañoActual = 0;
        
    }
   
    //verifica que ha pasado el objeto por el punto de inicio y otra vez pone en "0" las veces que ha disparado un evento
    //ademas devuelve el tamaño de la caja a su estado original
    public void Reiniciar()
    {
        save = true;
        disparoEvento = false;
        //Debug.Log("Llego la caja");
        
        reiniciarTamaño();
        
        eventoReiniciar.FireEvent();
        entregaCaja.FireEvent();
    }
   
    private void OnDestroy()
    {
        eventoRecoger.GEvent -= CrecerCaja;  //se dessubscriben dichas funciones a dichos eventos
        eventoReiniciar.GEvent -= Desaparecer;
        //perderCaja.GEvent -= PerderCaja;
    }
    private void OnEnable()
    {
        
        reiniciarTamaño();
        
        
    }
    private void OnDisable()
    {
        reiniciarTamaño();
        //Debug.Log("se reinicio el tamaño al apagarse");
    }
}
