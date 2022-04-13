using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tuto : MonoBehaviour
{
   
    [SerializeField] int tut;
    
    [SerializeField] bool lvlprueba;
    // Start is called before the first frame update
    void Start()
    {
        if ( lvlprueba == true)
        {
            PlayerPrefs.SetInt("tutorial", 0);
        }
      
        else if (lvlprueba == false)
        {
            tut = PlayerPrefs.GetInt("tutorial");
        }
        
    }
   
    
   
    public void Tutorial()
    {
        if (tut < 2)
        {
            SceneManager.LoadScene("Tutorial");
           

        }
        else
        {
            SceneManager.LoadScene("Main");
           // StartCoroutine(LoadScene());
        }

    }
   
}
