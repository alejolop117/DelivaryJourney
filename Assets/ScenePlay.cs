using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePlay : MonoBehaviour
{
    public void Cambiemos()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
