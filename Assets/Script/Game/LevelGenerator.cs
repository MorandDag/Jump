using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static bool deathPlayer = false;

    public GameObject[] platform;
    public GameObject mainCamera, player, restartMenu, pointsMenu;
    public Transform spaceForPlatforms, gameSpace;

    public int numberOfPlatform;
    public float levelWidth;
    public float minY = .2f;
    public float maxY = 1.5f;

    Vector2 spawnPosition = new Vector2();

    int pointPlus = 0;

    void Update()
    {
        if (deathPlayer)
        {
            restartMenu.SetActive(true);
            pointsMenu.SetActive(false);
            FindObjectOfType<Game>().PauseGame(true);
        }

        if(TextPoints.points >= numberOfPlatform - 20)
        {
            pointPlus = numberOfPlatform - TextPoints.points;
            numberOfPlatform += 100;
            
            CreateLevel();
        }

    }

    public void CreateLevel()
    {
        levelWidth = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x - .5f;
        bool specialPlatforfm = false;
        
        for (int i = TextPoints.points + pointPlus; i < numberOfPlatform; i++)
        {
            int typePlatform = Random.Range(0, 100);

            if (!specialPlatforfm)
            {
                if (typePlatform >= 0 && typePlatform < 50)
                {
                    typePlatform = 0;
                }
                else if (typePlatform >= 51 && typePlatform < 90)
                {
                    typePlatform = 1;
                    specialPlatforfm = true;
                }
                else if (typePlatform >= 91 && typePlatform < 100)
                {
                    typePlatform = 2;
                    specialPlatforfm = true;
                }
                else
                {
                    typePlatform = 0;
                }
            }
            else
            {
                typePlatform = 0;
                specialPlatforfm = false;
            }
                
            

            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            GameObject newPlatform = Instantiate(platform[typePlatform], spawnPosition, Quaternion.identity) as GameObject;
            newPlatform.transform.parent = spaceForPlatforms;
            newPlatform.GetComponent<Platform>().numPlatform = i+1;
            newPlatform.GetComponent<Platform>().type = typePlatform;
        }
    }

    public void RestartGame()
    {
        foreach (Transform child in spaceForPlatforms)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in gameSpace)
        {
            if(child.gameObject.tag == "Player")
                Destroy(child.gameObject);
        }

        TextPoints.points = 0;
        pointPlus = 0;

        GameObject newPlayer = Instantiate(player, new Vector3(0, -1.08f, 0), Quaternion.identity) as GameObject;
        newPlayer.transform.parent = gameSpace;
        newPlayer.GetComponent<Player>().levSet = gameObject.GetComponent<LevelGenerator>();

        mainCamera.transform.position = new Vector3(0, 0, mainCamera.transform.position.z);
        mainCamera.GetComponent<CameraFollow>().target = newPlayer.transform;
        CameraFollow.newPos.y = 0;

        FindObjectOfType<Game>().PauseGame(false);
        deathPlayer = false;
        numberOfPlatform = 100;
        spawnPosition.y = 0;

        CreateLevel();
    }
}
