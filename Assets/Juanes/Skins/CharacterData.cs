using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Develop/CharacterData")]
public class CharacterData : ScriptableObject
{
    public Material material;
    public int CurrentMaterialIndex;
    public UnityEvent<Material> materialChanged;
}

