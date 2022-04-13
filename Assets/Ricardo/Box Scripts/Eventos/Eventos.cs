using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Evento")]
public class Eventos : ScriptableObject
{
    public delegate void EventInGame();
    public event EventInGame GEvent; //aca se declara el evento

    public void FireEvent() //esta funcion dispara el evento
    {
        GEvent?.Invoke();
    }
}
