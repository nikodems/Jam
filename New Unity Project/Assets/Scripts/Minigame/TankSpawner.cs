using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    float timer;
    float timeToSpawn = 3.0f;
    Random rand = new Random();

    public GameObject tankPrefab;
    GameObject tank;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeToSpawn)
        {
            tank = Instantiate(tankPrefab, tankPrefab.gameObject.transform.position, Quaternion.identity);

            timeToSpawn = Random.Range(3.0f, 6.0f);


            timer = 0.0f;
        }
    }
}
