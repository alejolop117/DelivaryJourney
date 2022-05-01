using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ListaPersonajes : MonoBehaviour
{
    private GameObject[] characterList;
    private int index;
    int partidas;
    [SerializeField] bool testing;
    private void Awake()
    {
        if (testing == true)
        {
            PlayerPrefs.SetInt("P", 0);
            PlayerPrefs.SetInt("TutorialHabilitado", 0);
        }
        partidas = PlayerPrefs.GetInt("P");
    }
    void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");
        characterList = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            characterList[i] = transform.GetChild(i).gameObject;

        foreach (GameObject go in characterList)
            go.SetActive(false);

        if (characterList[index])
            characterList[index].SetActive(true);

    }
    void Update()
    {

    }

    public void ToggleLeft()
    {
        characterList[index].SetActive(false);
        index--;
        if (index < 0)
            index = characterList.Length - 1;

        characterList[index].SetActive(true);
    }

    public void ToggleRight()
    {
        characterList[index].SetActive(false);
        index++;
        if (index == characterList.Length)
            index = 0;

        characterList[index].SetActive(true);
    }

    public void ConfirmButton()
    {
        PlayerPrefs.SetInt("PuntajeSelected", index);
        if (partidas > 0)
        {
            SceneManager.LoadScene("Main");
        }
        else 
        {
           // PlayerPrefs.SetInt("P", 1);
           // PlayerPrefs.SetInt("TutorialHabilitado", 1);
            SceneManager.LoadScene("VideoTEst");
        }
    }
}
