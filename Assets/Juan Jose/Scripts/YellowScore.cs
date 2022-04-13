using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class YellowScore : MonoBehaviour
{
    [SerializeField]
    private Eventos eventoRecoger;
    [SerializeField] TextMeshProUGUI yellowCount;
    public int count = 0;

    private void Start()
    {
        eventoRecoger.GEvent += UpdateYellowBoxes;
        count = PlayerPrefs.GetInt("Conteo Cajas Verde")+1;
    }
    private void Update()
    {
        yellowCount.text = count.ToString() + "/100";
    }
    private void UpdateYellowBoxes()
    {
        count++;      
    }

}
