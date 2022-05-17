using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabiliatrTut : MonoBehaviour
{
    [SerializeField] GameObject tutorial;
    void Awake()
    {
        if (PlayerPrefs.GetInt("TutorialHabilitado") > 0)
        {
            tutorial.SetActive(true);
        }
        else
        {
            tutorial.SetActive(false);
        }
    }
}
