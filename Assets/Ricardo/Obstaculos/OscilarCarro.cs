using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscilarCarro : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3 posicionNueva, posicionInicial, posicionRelativa; //esto es solo para llevar seguimiento de la posicion del objeto
    [SerializeField] Eventos reiniciarPos, reiniciarContador;
    [SerializeField] float amplitud, oscilationSpeed; //la amplitud determina que tan amplio Oscila el carro y la velocidad que tan rapido hace las Oscilaciones
    [SerializeField] PlayerMovement speedPlayer; //muy importante asignar el componente del playerMovement o no se movera
    Rigidbody rb;
    [SerializeField] bool cont;
    void Start()
    {
        reiniciarPos.GEvent += ReiniciarPos;
        reiniciarContador.GEvent += ReinicarContador;
        posicionInicial = transform.position;
        posicionNueva = transform.localPosition;
        posicionRelativa = posicionNueva;
        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        posicionNueva.z = 0;
        posicionRelativa.z += -speedPlayer.speed  * Time.deltaTime;
        posicionRelativa.x = Mathf.Sin(posicionRelativa.z * oscilationSpeed) * amplitud;
        if(posicionRelativa.x > 10)
        {
            posicionNueva.x = 10;
        }
        else if(posicionRelativa.x < -10)
        {
            posicionNueva.x = -10;
        }
        else
        {
            posicionNueva.x = posicionRelativa.x;
        }
        

        transform.localPosition = posicionNueva;
        rb.MovePosition(posicionNueva);
    }
    void ReiniciarPos()
    {

        cont = !cont;
        if (cont == true)
        {
            posicionNueva = posicionInicial;
            posicionRelativa = posicionNueva;
            transform.position = posicionNueva;
        }

    }
    void ReinicarContador()
    {

        if (cont == false)
        {
            cont = true;
        }
    }
    private void OnDestroy()
    {
        reiniciarPos.GEvent -= ReiniciarPos;
        reiniciarContador.GEvent -= ReinicarContador;
    }
    private void OnDisable()
    {
        reiniciarPos.GEvent -= ReiniciarPos;
        reiniciarContador.GEvent -= ReinicarContador;
    }

}
