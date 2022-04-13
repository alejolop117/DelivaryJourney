using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    [SerializeField] GameObject[] secttion;
    [SerializeField] float spawnPos;
    [SerializeField] int totalSections;
    [SerializeField] LevelManager levelManager;
    [SerializeField] int mapState = 0;
    [SerializeField] float spawnPos2;
    [SerializeField] Transform spawnPoint;
    [SerializeField] Transform spawnPoint2;
    GameObject startSection;



    private void Start()
    {
        startSection = secttion[0];
        startSection.SetActive(true);
        startSection.transform.position = spawnPoint.position;
        startSection.transform.position = spawnPoint.position;
       // Instantiate(secttion[0], new Vector3(46, 0, spawnPos), Quaternion.identity);
    }

    private void Update()
    {
        if (levelManager.levelChangeRight)
        {
            levelManager.levelChangeRight = false;
            mapState++;
        }
        else if (mapState== 4) 
        {
            mapState = 0;
            levelManager.levelChangeRight = false;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("MapRight") && mapState == 0) //bosque 
        {
            GameObject temp;
            do
            {
                temp = secttion[Random.Range(0, 9)];
            }
            while (temp.activeSelf == true);
            temp.SetActive(true);
            temp.transform.position = spawnPoint.position;
            temp.transform.rotation = spawnPoint.rotation;
            //Instantiate(secttion[Random.Range(0, 3)], new Vector3(46, 0, spawnPos), Quaternion.identity);
        }
        else if (other.gameObject.CompareTag("MapRight") && mapState == 1) //pueblo 
        {
            GameObject temp;
            do
            {
                temp = secttion[Random.Range(9, 15)];
            }
            while (temp.activeSelf == true);
            temp.SetActive(true);
            temp.transform.position = spawnPoint.position;
            temp.transform.rotation = spawnPoint.rotation;
            //Instantiate(secttion[Random.Range(3, 5)], new Vector3(46, 0, spawnPos), Quaternion.identity);
        }
        else if (other.gameObject.CompareTag("MapRight") && mapState == 2) //desierto
        {
            GameObject temp;
            do
            {
                temp = secttion[Random.Range(15, 18)];
            }
            while (temp.activeSelf == true);
            temp.SetActive(true);
            temp.transform.position = spawnPoint2.position;
            temp.transform.rotation = spawnPoint2.rotation;
           // Instantiate(secttion[5], new Vector3(71.5f, 0, spawnPos2), Quaternion.identity);
        }
        else if (other.gameObject.CompareTag("MapRight") && mapState == 3) //nieve
        {
            GameObject temp;
            do
            {
                temp = secttion[Random.Range(18, 21)];
            }
            while (temp.activeSelf == true);
            temp.SetActive(true);
            temp.transform.position = spawnPoint2.position;
            temp.transform.rotation = spawnPoint2.rotation;
            //Instantiate(secttion[6], new Vector3(71.5f, 0, spawnPos2), Quaternion.identity);
        }
    }

}
