using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscilarCarro : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3 posicionNueva,posicionInicial,posicionRelativa; //esto es solo para llevar seguimiento de la posicion del objeto
    [SerializeField] Eventos reiniciarPos;
    [SerializeField] float amplitud,oscilationSpeed; //la amplitud determina que tan amplio Oscila el carro y la velocidad que tan rapido hace las Oscilaciones
    [SerializeField] PlayerMovement speedPlayer; //muy importante asignar el componente del playerMovement o no se movera
    Rigidbody rb;

    void Awake()
    {
        reiniciarPos.GEvent += ReiniciarPos;
        posicionInicial = transform.position;
        posicionNueva = transform.position;
        posicionRelativa = posicionNueva;
        rb = GetComponent<Rigidbody>();
        
    }

    void FixedUpdate()
    {
        posicionNueva.z += -speedPlayer.speed*0.5f * Time.deltaTime;
        
        posicionNueva.x = Mathf.Sin(posicionNueva.z*oscilationSpeed) * amplitud ;
        rb.MovePosition(posicionNueva);
    }
    void ReiniciarPos()
    {
        posicionNueva = posicionInicial;
        posicionRelativa = posicionNueva;
    }
    private void OnDestroy()
    {
        reiniciarPos.GEvent -= ReiniciarPos;
    }
    private void OnDisable()
    {
        reiniciarPos.GEvent -= ReiniciarPos;
    }
    
}
