using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Vector3 velocity = new Vector3(0.0f, -5.0f, 0.0f);
    public Sprite explosionSprite;

    bool explode;
    float timer;
    float rotationZ = 0.0f;
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

            if (timer > 0.5f)
            {
                Destroy(this.gameObject);
            }
        }

        if (!this.gameObject.GetComponent<SpriteRenderer>().flipX)
        {
            if (this.gameObject.transform.eulerAngles.z < 90)
            {
                rotationZ += 1.0f;

                if (rotationZ < 90)
                {
                    this.gameObject.transform.Rotate(new Vector3(0.0f, 0.0f, rotationZ));
                }
            }
        }
        else if(this.gameObject.GetComponent<SpriteRenderer>().flipX)
        {
            if (this.gameObject.transform.eulerAngles.z > 270 || this.gameObject.transform.eulerAngles.z == 0)
            {
                rotationZ -= 1.0f;

                if (rotationZ > -90.0f)
                {
                    this.gameObject.transform.Rotate(new Vector3(0.0f, 0.0f, rotationZ));
                }
                else
                {
                    rotationZ = -90.0f;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("aaa");
        //Destroy(this.gameObject);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = explosionSprite;
        this.gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        this.gameObject.GetComponent<Rigidbody2D>().simulated = false;

        if (!explode)
        {
            explode = true;
        }
    }

    public void FlipSprite()
    {
        this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
    }
}
