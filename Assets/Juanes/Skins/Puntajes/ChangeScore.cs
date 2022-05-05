using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScore : MonoBehaviour
{
    private GameObject[] PuntajesList;

    private int index;
    [SerializeField] bool testing;
    [SerializeField] int partidas;
    // Start is called before the first frame update
    private void Awake()
    {
        PlayerPrefs.SetInt("PuntajeSelected",0);
    }
    void Start()
    {
        index = PlayerPrefs.GetInt("PuntajeSelected");
        PuntajesList = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            PuntajesList[i] = transform.GetChild(i).gameObject;
        foreach (GameObject go in PuntajesList)
            go.SetActive(false);
        if (PuntajesList[0])
            PuntajesList[0].SetActive(true);

    }

    public void Atras()
    {
        PuntajesList[index].SetActive(false);
        index--;
        if (index < 0)
            index = PuntajesList.Length - 1;

        PuntajesList[index].SetActive(true);
    }
    public void Adelante()
    {
        PuntajesList[index].SetActive(false);
        index++;
        if (index == PuntajesList.Length)
            index = 0;

        PuntajesList[index].SetActive(true);
    }

    public void ConfirmButton()
    {
        PlayerPrefs.SetInt("PuntajeSelected", index);
        if (partidas == 1)
        {
            SceneManager.LoadScene("Main");
        }
        else if(partidas==0)
        {
            PlayerPrefs.SetInt("P", 1);
            PlayerPrefs.SetInt("TutorialHabilitado", 0);
            SceneManager.LoadScene("VideoTEst");
        }
        
    }
}
