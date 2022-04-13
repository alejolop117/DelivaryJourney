using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteRoads : MonoBehaviour
{
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            Destroy(collision.gameObject);
        }
    }

}
