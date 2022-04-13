using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposicionar : MonoBehaviour
{
    [SerializeField] Vector2 posicionGameOver;
    [SerializeField] Eventos gameOver;
    // Start is called before the first frame update
    void Awake()
    {
        gameOver.GEvent += Reposicion;
    }

    void Reposicion()
    {
        transform.localScale = Vector2.zero;
        transform.localPosition = posicionGameOver;
        transform.LeanScale(Vector2.one, 0.1f).setEaseInOutQuint();
    }

    private void OnDestroy()
    {
        gameOver.GEvent -= Reposicion;
    }
    private void OnEnable()
    {
        gameOver.GEvent += Reposicion;
    }
    private void OnDisable()
    {
        gameOver.GEvent -= Reposicion;
    }
}
