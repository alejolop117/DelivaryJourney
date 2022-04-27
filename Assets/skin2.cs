using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skin2 : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector3 offset = new Vector3(0, 5, -7);

    void LateUpdate() // LateUpdate is called after all Update functions have been called. 
    {
        transform.position = player.transform.position + offset;
    }
}
