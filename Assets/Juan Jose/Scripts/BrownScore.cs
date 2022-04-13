using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class BrownScore : MonoBehaviour
{
    [SerializeField]
    private Eventos eventoRecoger;
    [SerializeField] TextMeshProUGUI brownCount;
    public int count = 0;

    private void Start()
    {
        eventoRecoger.GEvent += UpdateBrownBoxes;
        count = PlayerPrefs.GetInt("Conteo Cajas Cafe")+1;
    }
    private void Update()
    {
        brownCount.text = count.ToString() + "/100";
    }
    private void UpdateBrownBoxes()
    {
        count++;    
    }
}
