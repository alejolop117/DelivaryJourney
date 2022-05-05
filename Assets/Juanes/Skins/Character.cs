using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterData data;
    private Renderer renderer;
    void Start()
    {
        renderer = GetComponent<Renderer>();
        data.materialChanged.AddListener(ChangeMaterial);
        ChangeMaterial(data.material);
    }
    public void ChangeMaterial(Material newMaterial)
    {
        //renderer.sharedMaterial = newMaterial;
    }
}
