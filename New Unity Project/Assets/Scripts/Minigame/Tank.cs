using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    Vector3 velocity = new Vector3(-5.0f, 0.0f, 0.0f);
    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().flipX = true;

        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position += (velocity * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bomb")
        {
            gameController.IncrementTankCounter();

            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.IncrementTankCounter();

        Destroy(this.gameObject);
    }
}
