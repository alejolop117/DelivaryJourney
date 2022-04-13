using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparecerMancha : MonoBehaviour
{
    [SerializeField] private Eventos mancharHUD;
    [SerializeField] private float duracionMancha,aparicion,desaparicion;
    
    void Awake()
    {
        transform.localScale = Vector2.zero;
        mancharHUD.GEvent += Mancha;
    }
    IEnumerator Aparecer()
    {
        transform.LeanScale(Vector2.one, aparicion).setEaseInOutQuint();
        yield return new WaitForSeconds(duracionMancha);
        transform.LeanScale(Vector2.zero, desaparicion).setEaseInBack();
    }
    void Mancha()
    {
        StartCoroutine("Aparecer");
    }
    private void OnDestroy()
    {
        mancharHUD.GEvent -= Mancha;
    }
}
