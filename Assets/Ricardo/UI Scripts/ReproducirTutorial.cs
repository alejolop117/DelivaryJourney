using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReproducirTutorial : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.GetInt("TutorialHabilitado") > 0)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);

        }
    }
    public void PlayTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
