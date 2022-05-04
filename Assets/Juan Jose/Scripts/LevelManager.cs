using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject[] secttion;
    [SerializeField] float spawnPos;
    [SerializeField] int totalSections;
    [SerializeField] int difficultyCounter = 0;
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
        startSection = secttion[Random.Range(3,7)];
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
        if (other.gameObject.CompareTag("Piso") && tunnelCounter != tunnelObjective && checkpointCounter != checkpointObjective && difficultyCounter == 0)
        {
            GameObject temp;
            tunnelCounter++;
            checkpointCounter++;

            do
            {
                temp = secttion[Random.Range(3, 7)];
            }
            while (temp.activeSelf == true);
            temp.SetActive(true);

            temp.transform.position = spawn.position;
            temp.transform.rotation = spawn.rotation;
        }
        else if (other.gameObject.CompareTag("Piso") && tunnelCounter != tunnelObjective && checkpointCounter != checkpointObjective && difficultyCounter == 1)
        {
            GameObject temp;
            tunnelCounter++;
            checkpointCounter++;

            do
            {
                temp = secttion[Random.Range(3, 11)];
            }
            while (temp.activeSelf == true);
            temp.SetActive(true);

            temp.transform.position = spawn.position;
            temp.transform.rotation = spawn.rotation;
        }
        else if (other.gameObject.CompareTag("Piso") && tunnelCounter != tunnelObjective && checkpointCounter != checkpointObjective && difficultyCounter == 2)
        {
            GameObject temp;
            tunnelCounter++;
            checkpointCounter++;

            do
            {
                temp = secttion[12];
            }
            while (temp.activeSelf == true);
            temp.SetActive(true);

            temp.transform.position = spawn.position;
            temp.transform.rotation = spawn.rotation;
            difficultyCounter++;
        }
        else if (other.gameObject.CompareTag("Piso") && tunnelCounter != tunnelObjective && checkpointCounter != checkpointObjective && difficultyCounter == 3)
        {        
            GameObject temp;
            tunnelCounter++;
            checkpointCounter++;

            do
            {
                temp = secttion[Random.Range(3,18)];
            }
            while (temp.activeSelf == true);
            temp.SetActive(true);

            temp.transform.position = spawn.position;
            temp.transform.rotation = spawn.rotation;
        }
        /*
        if (other.gameObject.CompareTag("Piso") && tunnelCounter != tunnelObjective && checkpointCounter != checkpointObjective)
        {
            tunnelCounter++;
            checkpointCounter++;
            GameObject temp; 
            if(difficultyCounter == 0)
            {
                do
                {
                    temp = secttion[Random.Range(3,7)];
                }
                while (temp.activeSelf == true);

                temp.SetActive(true);

                temp.transform.position = spawn.position;
                temp.transform.rotation = spawn.rotation;
            }
            else if (difficultyCounter == 1)
            {

                do
                {
                    temp = secttion[Random.Range(3, 11)];
                }
                while (temp.activeSelf == true);

                temp.SetActive(true);

                temp.transform.position = spawn.position;
                temp.transform.rotation = spawn.rotation;
            }
            else if (difficultyCounter == 2)
            {
                do
                {
                    temp = secttion[12];
                }
                while (temp.activeSelf == true);

                temp.SetActive(true);

                temp.transform.position = spawn.position;
                temp.transform.rotation = spawn.rotation;
                difficultyCounter++;
            }
            else if (difficultyCounter >= 3)
            {
                difficultyCounter = 3;
                do
                {
                    temp = secttion[Random.Range(3,18)];
                }
                while (temp.activeSelf == true );

                temp.SetActive(true);

                temp.transform.position = spawn.position;
                temp.transform.rotation = spawn.rotation;
            }



            // Instantiate(secttion[Random.Range(2, totalSections)], new Vector3(0, -2.4f, spawnPos), Quaternion.identity);    
        */

        else if (other.gameObject.CompareTag("Piso") && tunnelCounter == tunnelObjective)
        {
            tunnelCounter++;
            GameObject temp;
            temp = secttion[Random.Range(0, 4)];
            temp.SetActive(true);
            temp.transform.position = spawn.position;
            temp.transform.rotation = spawn.rotation;
            //Instantiate(secttion[1], new Vector3(0, -2.4f, spawnPos), Quaternion.identity);          
        }
        else if (other.gameObject.CompareTag("Piso") && checkpointCounter == checkpointObjective)
        {
            GameObject temp;
            temp = secttion[Random.Range(18, 22)];
            temp.SetActive(true);
            temp.transform.position = spawn.position;
            temp.transform.rotation = spawn.rotation;
            //Instantiate(secttion[Random.Range(11,15)], new Vector3(0, -2.4f, spawnPos), Quaternion.identity);
            checkpointCounter = 0;
            if(difficultyCounter < 3)
            {
                difficultyCounter++;
            }
            
        }
    }
}


