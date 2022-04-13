using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MancharPantalla : MonoBehaviour
{
    [SerializeField] Eventos mancharHud;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("se choco coon un barril");
            mancharHud.FireEvent();
        }
    }
}
