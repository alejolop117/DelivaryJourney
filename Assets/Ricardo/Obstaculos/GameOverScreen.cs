using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] Eventos gameOver;
    [SerializeField] GameObject botonPausa,controles;
    [SerializeField] ParticleSystem choque;
    [SerializeField] float aparicion;
    [Range(0, 1)]
    [SerializeField]private float velocidadTiempo;
   
    void Awake()
    {
        transform.localScale = Vector2.zero;
        gameOver.GEvent += GameOver;   
    }
    void GameOver()
    {
        choque.Play();
        DesactivarBotones();
        Time.timeScale = velocidadTiempo;
        StartCoroutine("Terminar");
    }
    IEnumerator Terminar()
    {
        //Debug.Log("muerto");
        transform.LeanScale(Vector2.one, aparicion).setEaseOutQuart();
        yield return new WaitForSeconds(aparicion);
        Time.timeScale = 0;
    }
    void DesactivarBotones()
    {
        botonPausa.SetActive(false);
        controles.SetActive(false);
    }
    private void OnDestroy()
    {
        gameOver.GEvent -= GameOver;
    }
}
