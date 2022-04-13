using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerAnimation : MonoBehaviour
{
    public Animator transitionAnim;
    
    public void metodoCargar()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(LoadScene(nextSceneIndex));
    }

    IEnumerator LoadScene(int sceneIndex)
    {
        transitionAnim.SetTrigger("StartTransition");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneIndex);
    }
}
