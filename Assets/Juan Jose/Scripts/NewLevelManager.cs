using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLevelManager : MonoBehaviour
{
    [SerializeField] Roads roads;
    float zPos = 213.4f;
    bool creatingSection = false;
    int secNum;
    [SerializeField] int totalSections;

    void Update()
    {
        if (!creatingSection)
        {
            creatingSection = true;
            StartCoroutine(CreateSection());
        }
    }

    IEnumerator CreateSection()
    {
        secNum = Random.Range(0, totalSections);
        Instantiate(roads, new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 153.4f;
        yield return new WaitForSeconds(2.5f);
        creatingSection = false;
    }
}
