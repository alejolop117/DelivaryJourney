using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private int sceneIndex;
    [SerializeField] private CharacterData data;
    public void ChangeScene()
    {
        data.materialChanged.RemoveAllListeners();
        SceneManager.LoadScene(sceneIndex);
    }
}