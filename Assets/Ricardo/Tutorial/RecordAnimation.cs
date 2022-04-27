using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordAnimation : MonoBehaviour
{
    [SerializeField] Vector2 tamañoNuevo;
    [SerializeField] float aparicion;
    void Start()
    {
        transform.LeanScale(tamañoNuevo, aparicion).setEaseOutQuart().setLoopPingPong();
    }

}
