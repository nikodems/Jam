using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Vector3 velocity = new Vector3(0.0f, -5.0f, 0.0f);
    public Sprite explosionSprite;

    bool explode;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        explode = false;
    }

    // Update is called once per frame
    void Update()
    {
        //this.gameObject.transform.position += (velocity * Time.deltaTime);
        if(explode)
        {
            timer += Time.deltaTime;
        }

        if(timer > 2.0f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("aaa");
        //Destroy(this.gameObject);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = explosionSprite;
        this.gameObject.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
        this.gameObject.GetComponent<Rigidbody2D>().simulated = false;

        if(!explode)
        {
            explode = true;
        }
    }
}
