using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinsModel : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] characterList;
    private int index;

    void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelect");
        characterList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            characterList[i] = transform.GetChild(i).gameObject;

        foreach (GameObject go in characterList)
            go.SetActive(false);
       
        if (characterList[index])
            characterList[index].SetActive(true);


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

    public void ConfirmPlay()
    {
        PlayerPrefs.SetInt("CharacterSelect", index);
        SceneManager.LoadScene("Main");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
