using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameController gameController;
    float speed = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if (gameController.GameStart() && !gameController.GameOver())
        {
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(speed * Time.time, 0);
        }
    }
}
