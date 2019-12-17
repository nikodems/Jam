using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    float timer;
    float timeToSpawn = 3.0f;
    Random rand = new Random();

    public GameObject tankPrefab;
    GameObject tank;
    int tankCounter = 0;
    public int maxTanks = 5;

    bool gameOver = false;
    bool gameStart = false;

    public Text missionObjectives;
    public Text missionEnd;
    // Start is called before the first frame update
    void Start()
    {
        HideMissionEnd();   
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameOver() && GameStart())
        {
            SpawnTanks();
        }

        if(Input.GetKeyDown("space") && missionObjectives.gameObject.activeSelf)
        {
            HideMissionObjectives();

            gameStart = true;
        }

        if(missionEnd.gameObject.activeSelf)
        {
            if(Input.GetKeyDown("space"))
            {
                SceneManager.LoadSceneAsync("Map");
            }
        }

        if(gameOver)
        {
            ShowMissionEnd();
        }

        if(Input.GetKeyDown("escape"))
        {
            ShowMissionEnd();
        }
    }

    private void SpawnTanks()
    {
        timer += Time.deltaTime;

        if (timer > timeToSpawn && tankCounter < maxTanks)
        {
            tank = Instantiate(tankPrefab, tankPrefab.gameObject.transform.position, Quaternion.identity);

            timeToSpawn = Random.Range(3.0f, 6.0f);


            timer = 0.0f;
            //tankCounter += 1;
        }

        if (tankCounter >= maxTanks && tank.gameObject == null)
        {
            gameOver = true;
        }
    }

    public bool GameOver()
    {
        return gameOver;
    }

    public bool GameStart()
    {
        return gameStart;
    }

    private void ShowMissionObjectives()
    {
        missionObjectives.gameObject.SetActive(true);
    }

    private void HideMissionObjectives()
    {
        missionObjectives.gameObject.SetActive(false);
    }

    private void ShowMissionEnd()
    {
        missionEnd.gameObject.SetActive(true);
    }

    private void HideMissionEnd()
    {
        missionEnd.gameObject.SetActive(false);
    }

    public void IncrementTankCounter()
    {
        tankCounter += 1;
    }
}
