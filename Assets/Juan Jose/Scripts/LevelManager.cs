using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject[] secttion;
    [SerializeField] float spawnPos;
   [SerializeField] int totalSections;
    public int tunnelCounter = 0;
    public int checkpointCounter = 0;
    bool tunnel;
    public bool levelChangeRight = false;
    public bool levelChangeLeft = false;
    [SerializeField] public int tunnelObjective;
    [SerializeField] public int checkpointObjective;
    [SerializeField] Transform spawn;
    GameObject startSection;
    


    private void Start()
    {
        startSection = secttion[0];
        startSection.SetActive(true);
        startSection.transform.position = spawn.position;
        startSection.transform.rotation = spawn.rotation;
      
        // secNumInit = Random.Range(1, totalSections);
        //Instantiate(secttion[0], new Vector3(0, -2.4f, spawnPos), Quaternion.identity);
    }

    private void Update()
    {
        if(tunnelCounter >= tunnelObjective + 1)
        {
            levelChangeLeft = true;
            levelChangeRight = true;
            tunnelCounter = 0;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        //secNum = Random.Range(2, totalSections);
        if (other.gameObject.CompareTag("Piso") && tunnelCounter != tunnelObjective && checkpointCounter != checkpointObjective)
        { 
            tunnelCounter++;
            checkpointCounter++;
            GameObject temp;          
            do
            {
                temp = secttion[Random.Range(2, 15)];
            }
            while (temp.activeSelf == true);

           temp.SetActive(true);

            temp.transform.position = spawn.position;
            temp.transform.rotation = spawn.rotation;  
            // Instantiate(secttion[Random.Range(2, totalSections)], new Vector3(0, -2.4f, spawnPos), Quaternion.identity);      
        }
        else if (other.gameObject.CompareTag("Piso") && tunnelCounter == tunnelObjective)
        { 
            tunnelCounter++;
            GameObject temp;
            temp = secttion[1];
            temp.SetActive(true);
            temp.transform.position = spawn.position;
            temp.transform.rotation = spawn.rotation;
            //Instantiate(secttion[1], new Vector3(0, -2.4f, spawnPos), Quaternion.identity);          
        }
        else if (other.gameObject.CompareTag("Piso") && checkpointCounter == checkpointObjective)
        {
            GameObject temp;
            temp = secttion[Random.Range(15,19)];
            temp.SetActive(true);
            temp.transform.position = spawn.position;
            temp.transform.rotation = spawn.rotation;
            //Instantiate(secttion[Random.Range(11,15)], new Vector3(0, -2.4f, spawnPos), Quaternion.identity);
            checkpointCounter = 0;           
        }

    }

}
