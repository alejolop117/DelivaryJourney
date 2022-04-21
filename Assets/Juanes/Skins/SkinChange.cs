using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinChange : MonoBehaviour
{

    [SerializeField] private List<Material> skins;
    [SerializeField] private CharacterData data;
    [SerializeField] Eventos cambioSkin;
    private int index;
    private void Start()
    {
        index = data.CurrentMaterialIndex;
     
        //PlayerPrefs.SetInt("SkinA", index);
     
        ChangeSkinA(0);
 
    }

  
    public void ChangeSkinA(int x)
    {
        index += x;
        if (index < 0)
        {
            index = skins.Count - 1;
            PlayerPrefs.SetInt("SkinA", index);
        }
        if (index > skins.Count)
        {
            index = 0;
            PlayerPrefs.SetInt("SkinA", index);
        }
        PlayerPrefs.SetInt("SkinA", index);
        cambioSkin.FireEvent();
        UpdateSkin();
    }
   

    public void UpdateSkin()
    {
        data.CurrentMaterialIndex = index;
        data.material = skins[index];
        data.materialChanged?.Invoke(data.material);
    }

}
