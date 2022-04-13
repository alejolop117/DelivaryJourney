using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class SkinsManager : MonoBehaviour
{
    [SerializeField] GameObject Car;
    public RectTransform mainMenu, MenuSkins;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.DOAnchorPos(Vector2.zero, 0.25f);
    }

    public void CarSkin()
    {
        Car.SetActive(true);
        mainMenu.DOAnchorPos(new Vector2(-1940, 0), 0.25f);
        MenuSkins.DOAnchorPos(new Vector2(0, 0), 0.25f);
        
    }

    public void CloseCarSkin()
    {
        Car.SetActive(false);
        mainMenu.DOAnchorPos(new Vector2(0, 0), 0.25f);
        MenuSkins.DOAnchorPos(new Vector2(-1940, 0), 0.25f);
    }

    public void QuitGame()
    {

        Application.Quit();
    }


}
